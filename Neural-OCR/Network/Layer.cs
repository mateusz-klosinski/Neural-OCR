using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Layer
    {
        private List<Neuron> _neurons;

        public List<double> Inputs
        {
            set
            {
                _neurons.ForEach(n =>
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

                _neurons.ForEach(n =>
                {
                    neuronsOutput.Add(n.Output());
                });

                return neuronsOutput;
            }
        }


        public List<double> Errors
        {
            get
            {
                List<double> neuronsErrors = new List<double>();

                _neurons.ForEach(n =>
                {
                    neuronsErrors.Add(n.Error);
                });

                return neuronsErrors;
            }
        }

        public List<List<double>> EachNeuronWeights
        {
            get
            {
                List<List<double>> eachNeuronWeights = new List<List<double>>();

                _neurons.ForEach(n =>
                {
                    eachNeuronWeights.Add(n.Weights);
                });

                return eachNeuronWeights;
            }
        }



        public Layer(int numberOfNeurons)
        {
            initializeNeurons(numberOfNeurons);
        }




        private void initializeNeurons(int numberOfNeurons)
        {
            _neurons = new List<Neuron>();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                _neurons.Add(new Neuron());
            }
        }
        
        public void Randomize(Random randomGenerator)
        {
            _neurons.ForEach(n => n.RandomizeWeights(randomGenerator));
        }

        public void SetNeuronsError(List<double> forwardNeuronsErrors, List<List<double>> forwardNeuronsWeights)
        {
            for (int i = 0; i < _neurons.Count - 1; i++)
            {
                _neurons[i].SetError(forwardNeuronsErrors[i], forwardNeuronsWeights[i]);
            }
        }

        public void SetOuputNeuronsError(List<double> expectedResults)
        {
            for (int i = 0; i < _neurons.Count - 1; i++)
            {
                _neurons[i].SetErrorForOutputNeuron(expectedResults[i]);
            }
        }
        
        public void AdjustNeuronsWeights(double learningRate, List<double> previousNeuronsOutput)
        {
            _neurons.ForEach(n =>
            {
                n.AdjustWeights(learningRate, previousNeuronsOutput);
            });
        }
    }
}
