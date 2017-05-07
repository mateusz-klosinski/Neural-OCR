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

        private double _learningRate = 0.6;
        private double _momentum = 0.1;

        public int NumberOfInputs { get; private set; }
        public int NumberOfOutputs { get; private set; }
        public int NumberOfHiddenLayers { get; private set; }
        public double GlobalError { get; private set; }


        public NeuralNetwork(int numberOfInputs, int numberOfOutputs, int numberOfHiddenLayers)
        {
            NumberOfInputs = numberOfInputs;
            NumberOfOutputs = numberOfOutputs;
            NumberOfHiddenLayers = numberOfHiddenLayers;

            initializeLayers();
            randomize();
        }



        private void initializeLayers()
        {
            _inputLayer = new Layer(NumberOfInputs);
            _outputLayer = new Layer(NumberOfOutputs);
            _hiddenLayers = new List<Layer>();

            for (int i = 0; i < NumberOfHiddenLayers; i++)
            {
                _hiddenLayers.Add(new Layer(NumberOfInputs));
            }
        }


        private void randomize()
        {
            _randomGenerator = new Random();

            _inputLayer.Randomize(_randomGenerator, NumberOfInputs);
            _hiddenLayers.ForEach(hl => hl.Randomize(_randomGenerator, NumberOfInputs));
            _outputLayer.Randomize(_randomGenerator, NumberOfInputs);
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
            _inputLayer.AdjustNeuronsWeights(_learningRate);
            _hiddenLayers.ForEach(hl => hl.AdjustNeuronsWeights(_learningRate));
            _outputLayer.AdjustNeuronsWeights(_learningRate);
        }
    }
}
