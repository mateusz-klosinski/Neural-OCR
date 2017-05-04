using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class NeuralNetwork
    {
        private Layer _inputLayer;
        private List<Layer> _hiddenLayers;
        private Layer _outputLayer;

        public int NumberOfInputs { get; private set; }
        public int NumberOfOutputs { get; private set; }
        public int NumberOfHiddenLayers { get; private set; }

        public NeuralNetwork(int numberOfInputs, int numberOfOutputs, int numberOfHiddenLayers)
        {
            NumberOfInputs = numberOfInputs;
            NumberOfOutputs = numberOfOutputs;
            NumberOfHiddenLayers = numberOfHiddenLayers;

            initializeLayers();
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



        public void Learn(TeachingElement element)
        {
            feedForward();
            backPropagate();
        }

        private void feedForward()
        {
            throw new NotImplementedException();
        }

        private void backPropagate()
        {
            throw new NotImplementedException();
        }
    }
}
