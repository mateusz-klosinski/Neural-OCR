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
            GlobalError = feedForward();

            backPropagate(GlobalError);
        }

        private double feedForward()
        {
            throw new NotImplementedException();
        }

        private void backPropagate(double globalError)
        {
            throw new NotImplementedException();
        }
    }
}
