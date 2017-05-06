using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Layer
    {
        private List<Neuron> neurons;




        public Layer(int numberOfNeurons)
        {
            initializeNeurons(numberOfNeurons);
        }



        private void initializeNeurons(int numberOfNeurons)
        {
            neurons = new List<Neuron>();
            for (int i = 0; i < numberOfNeurons; i++)
            {

            }
        }

        internal void Randomize(Random randomGenerator)
        {
            throw new NotImplementedException();
        }
    }
}
