using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Neuron
    {
        private int _numberOfInputs;

        public List<double> Weights { get; set; }

        public Neuron(int numberOfInputs)
        {
            _numberOfInputs = numberOfInputs;
        }

        public double SumarizeInputs(List<double> inputs)
        {
            double sum = 0;

            for (int i = 0; i < _numberOfInputs-1; i++)
            {
                sum += inputs[i] * Weights[i];
            }

            return sum;
        }

        public double Activation(double neuronInput)
        {
            var output = Math.Pow(Math.E, Math.Pow(-neuronInput, 2));
            return output;
        }

        public double ErrorDerivative(double neuronOutput)
        {
            var errorOut = -2 * neuronOutput * Math.Pow(Math.E, Math.Pow(-neuronOutput, 2));
            return errorOut;
        }
    }
}
