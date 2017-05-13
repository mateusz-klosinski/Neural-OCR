using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class NeuralNetwork
    {
        private Layer _inputLayer;
        private List<Layer> _hiddenLayers;
        private Layer _outputLayer;

        private Random _randomGenerator;

        private double _learningRate = 0.1;
        private double momentum = 0.7;

        public int NumberOfInputs { get; private set; }
        public int NumberOfNeuronsInHiddenLayer { get; private set; }
        public int NumberOfOutputs { get; private set; }
        public int NumberOfHiddenLayers { get; private set; }
        public double GlobalError { get; private set; }


        public NeuralNetwork(int numberOfInputs, int numberOfOutputs, int numberOfHiddenLayers, int numberOfNeuronsInHiddenLayer)
        {
            NumberOfInputs = numberOfInputs;
            NumberOfOutputs = numberOfOutputs;
            NumberOfHiddenLayers = PassOrLimitToMax(numberOfHiddenLayers, 3);
            NumberOfNeuronsInHiddenLayer = numberOfNeuronsInHiddenLayer;

            initializeLayers();
            randomize();
        }

        private int PassOrLimitToMax(int value, int inclusiveMaximum)
        {
            return value > inclusiveMaximum ? inclusiveMaximum : value;
        }

        private void initializeLayers()
        {
            _inputLayer = new Layer(NumberOfInputs);
            _outputLayer = new Layer(NumberOfOutputs);
            _hiddenLayers = new List<Layer>();

            for (int i = 0; i < NumberOfHiddenLayers; i++)
            {
                _hiddenLayers.Add(new Layer(NumberOfNeuronsInHiddenLayer));
            }
        }


        private void randomize()
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



        public List<double> Test(TeachingElement element)
        {
            List<double> outputResponse = forwardPropagate(element);
            return outputResponse;
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
            _inputLayer.AdjustNeuronsWeights(_learningRate, momentum);
            _hiddenLayers.ForEach(hl => hl.AdjustNeuronsWeights(_learningRate, momentum));
            _outputLayer.AdjustNeuronsWeights(_learningRate, momentum);
        }
    }
}
