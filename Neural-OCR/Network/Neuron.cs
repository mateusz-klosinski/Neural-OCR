using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Neuron
    {
        private double _biasWeight;

        private double _output;


        public List<double> Weights;

        public double Error;

        public double Momentum;

        public List<double> Inputs;



        public double Output()
        {
            _output = activation(SumarizeInputs());
            return _output;
        }

        public void RandomizeWeights(Random _random)
        {
            for (int i = 0; i < Weights.Count - 1; i++)
            {
                Weights[i] = _random.NextDouble();
            }

            _biasWeight = _random.NextDouble();
        }

        public void AdjustWeights()
        {
            for (int i = 0; i < Weights.Count - 1; i++)
            {
                Weights[i] += Error * Inputs[i];
            }

            _biasWeight += Error;
        }

        public void SetError(double globalError)
        {
            Error = derivative(_output) * globalError; //no tu wagi powinny jeszcze być neuronu wyjściowego ale nie za bardzo wiem ocb xd
        }

        public void SetErrorForOutputNeuron(double expectedResult)
        {
            Error = derivative(_output) * (expectedResult - _output);
        }

        private double SumarizeInputs()
        {
            double sum = 0;

            for (int i = 0; i < Inputs.Count - 1; i++)
            {
                sum += Inputs[i] * Weights[i];
            }

            return sum + _biasWeight;
        }

        private double activation(double sumarizedInputs)
        {
            var activatedValue = 1.0 / (1.0 + Math.Exp(-sumarizedInputs));
            return activatedValue;
        }

        private double derivative(double output)
        {
            return output * (1 - output);
        }

    }
}
