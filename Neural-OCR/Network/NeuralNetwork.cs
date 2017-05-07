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

        private static double _learningRate = 0.6;

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

            _inputLayer.Randomize(_randomGenerator);
            _hiddenLayers.ForEach(hl => hl.Randomize(_randomGenerator));
            _outputLayer.Randomize(_randomGenerator);
        }





        public void Learn(TeachingElement element)
        {
            List<double> inputResponse;

            GlobalError = forwardPropagate(element, out inputResponse);

            backPropagate(element, inputResponse);
        }



        private double forwardPropagate(TeachingElement element, out List<double> inputResponse)
        {
            inputResponse = layerResponse(_inputLayer, element.Inputs);
            List<double> hiddenResponse = hiddenLayersResponse(inputResponse);
            List<double> outputResponse = layerResponse(_outputLayer, hiddenResponse);

            _outputLayer.SetOuputNeuronsError(element.ExpectedOutputs);

            double globalError = countGlobalError(_outputLayer.Errors);
            return globalError;
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

        private void backPropagate(TeachingElement element, List<double> inputResponse)
        {
            var firstHiddenLayer = _hiddenLayers.First(); 
            
            /*Wsteczna propagacja błędów*/


            _hiddenLayers.ForEach(hl =>
            {
                hl.SetNeuronsError(_outputLayer.Errors, _outputLayer.EachNeuronWeights);
            });

            _inputLayer.SetNeuronsError(firstHiddenLayer.Errors, firstHiddenLayer.EachNeuronWeights);


            /*Dostosowywanie wag*/


            _inputLayer.AdjustNeuronsWeights(_learningRate, element.Inputs);

            _hiddenLayers.ForEach(hl =>
            {
                hl.AdjustNeuronsWeights(_learningRate, inputResponse);
            });
            

        }
    }
}
