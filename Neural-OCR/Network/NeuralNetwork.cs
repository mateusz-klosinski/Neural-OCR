using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural_OCR.Network
{
    public class NeuralNetwork
    {
        private Layer _inputLayer;
        private List<Layer> _hiddenLayers;
        private Layer _outputLayer;

        private Random _randomGenerator;

        public double LearningRate { get; set; } = 0.3;
        public double Momentum { get; set; } = 0.5;

        public int NumberOfInputs { get; private set; }
        public int NumberOfNeuronsInHiddenLayer { get; private set; }
        public int NumberOfOutputs { get; private set; }
        public int NumberOfHiddenLayers { get; private set; }
        public double GlobalError { get; private set; }





        public void InitializeInputLayer(int numberOfInputs, int numberOfNeurons)
        {
            _inputLayer = new Layer(numberOfNeurons);
            NumberOfInputs = numberOfInputs;
        }




        public void InitializeHiddenLayers(int numberOfLayers, int numberOfNeuronsInLayer)
        {
            _hiddenLayers = new List<Layer>();

            var limitedNumberOfLayers = PassOrLimitToMax(numberOfLayers, 3);

            for (int i = 0; i < limitedNumberOfLayers; i++)
            {
                _hiddenLayers.Add(new Layer(numberOfNeuronsInLayer));
            }

            NumberOfHiddenLayers = numberOfLayers;
        }

        private int PassOrLimitToMax(int value, int inclusiveMaximum)
        {
            return value > inclusiveMaximum ? inclusiveMaximum : value;
        }




        public void InitializeOutputLayer(int numberOfOutputs)
        {
            _outputLayer = new Layer(numberOfOutputs);
            NumberOfOutputs = numberOfOutputs;
        }





        public void Randomize()
        {
            _randomGenerator = new Random();

            _inputLayer.Randomize(_randomGenerator, NumberOfInputs);

            var previousLayer = _inputLayer;

            foreach (var hiddenLayer in _hiddenLayers)
            {
                hiddenLayer.Randomize(_randomGenerator, previousLayer.NumberOfNeurons);
                previousLayer = hiddenLayer;
            }

            _outputLayer.Randomize(_randomGenerator, previousLayer.NumberOfNeurons);
        }





        public double Test(TeachingElement element)
        {
            List<double> outputResponse = forwardPropagate(element);

            var sortedOutputResponse = new List<double>(outputResponse);
            sortedOutputResponse.Sort();
            sortedOutputResponse.Reverse();

            return outputResponse.IndexOf(sortedOutputResponse.First());
        }





        public void Learn(TeachingElement element)
        {
            forwardPropagate(element);
            backPropagate(element);

            GlobalError = countGlobalError(_outputLayer.Errors);
        }


        private List<double> forwardPropagate(TeachingElement element)
        {
            List<double> inputResponse = layerResponse(_inputLayer, element.Inputs);
            List<double> hiddenResponse = hiddenLayersResponse(inputResponse);
            List<double> outputResponse = layerResponse(_outputLayer, hiddenResponse);

            return outputResponse;
        }

        private List<double> layerResponse(Layer layer, List<double> inputs)
        {
            layer.Inputs = inputs;
            return layer.Outputs;
        }

        private List<double> hiddenLayersResponse(List<double> inputs)
        {
            List<double> currentResponse = inputs;
            _hiddenLayers.ForEach(hl =>
            {
                currentResponse = layerResponse(hl, currentResponse);
            });

            return currentResponse;
        }

        private double countGlobalError(List<double> layerErrors)
        {
            double squaredErrorsSum = 0;
            layerErrors.ForEach(le => squaredErrorsSum += Math.Pow(le, 2));

            double average = squaredErrorsSum / layerErrors.Count;

            return Math.Sqrt(average);
        }



        private void backPropagate(TeachingElement element)
        {
            _outputLayer.SetOuputNeuronsError(element.ExpectedOutputs);
            propagateErrorThroughLayers();
            adjustWeights();
        }

        private void propagateErrorThroughLayers()
        {
            List<double> errors = _outputLayer.Errors;
            List<List<double>> weights = _outputLayer.EachNeuronWeights;

            List<Layer> reversedHiddenLayers = new List<Layer>(_hiddenLayers);
            reversedHiddenLayers.Reverse();

            reversedHiddenLayers.ForEach(rhl =>
            {
                rhl.SetNeuronsError(errors, weights);
                weights = rhl.EachNeuronWeights;
                errors = rhl.Errors;
            });

            _inputLayer.SetNeuronsError(errors, weights);
        }

        private void adjustWeights()
        {
            _inputLayer.AdjustNeuronsWeights(LearningRate, Momentum);
            _hiddenLayers.ForEach(hl => hl.AdjustNeuronsWeights(LearningRate, Momentum));
            _outputLayer.AdjustNeuronsWeights(LearningRate, Momentum);
        }
    }
}
