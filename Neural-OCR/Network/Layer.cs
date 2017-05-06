using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Layer
    {
        private List<Neuron> neurons;

        public List<double> Inputs
        {
            set
            {
                neurons.ForEach(n =>
                {
                    n.Inputs = value;
                });
            }
        }


        public List<double> Outputs
        {
            get
            {
                List<double> neuronsOutput = new List<double>();

                neurons.ForEach(n =>
                {
                    neuronsOutput.Add(n.Output());
                });

                return neuronsOutput;
            }
        }



        public Layer(int numberOfNeurons)
        {
            initializeNeurons(numberOfNeurons);
        }





        private void initializeNeurons(int numberOfNeurons)
        {
            neurons = new List<Neuron>();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                neurons.Add(new Neuron());
            }
        }


        public void Randomize(Random randomGenerator)
        {
            neurons.ForEach(n => n.RandomizeWeights(randomGenerator));
        }



        public void SetNeruonsError(double globalError)
        {
            neurons.ForEach(n =>
            {
                n.SetError(globalError);
            });
        }


        public void AdjustNeuronsWeights()
        {
            neurons.ForEach(n =>
            {
                n.AdjustWeights();
            });
        }
    }
}
