using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Neuron 
    {
        private double _biasWeight;
        private static double _biasValue = 1.0;
        private double _output;

        public double Error;

        public List<double> PreviousWeights;
        public List<double> Weights;
        public List<double> Inputs;

        public Neuron()
        {
            Weights = new List<double>();
            PreviousWeights = new List<double>();
        }

        public double Output()
        {
            _output = activation(sumarizeInputs());
            return _output;
        }

        public void RandomizeWeights(Random _random, int numberOfInputs)
        {
            for (int i = 0; i < numberOfInputs; i++)
            {
                double randomValue = _random.NextDouble() * (0.1 - (-0.1)) + (-0.1);
                Weights.Add(randomValue);
                PreviousWeights.Add(randomValue);
            }

            double randomVal = _random.NextDouble() * (0.1 - (-0.1)) + (-0.1);
            _biasWeight = randomVal;
        }

        public void AdjustWeights(double learningRate)
        {
            for (int i = 0; i < Weights.Count; i++)
            {
                Weights[i] = Weights[i] + learningRate * Error * Inputs[i];
            }

            _biasWeight = _biasWeight + learningRate * Error * _biasValue;
        }

        public void AdjustWeights(double learningRate, double momentum)
        {
            var tempWeights = new List<double>(Weights);

            for (int i = 0; i < Weights.Count; i++)
            {
                Weights[i] = Weights[i] + learningRate * Error * Inputs[i] - momentum * (Weights[i] - PreviousWeights[i]);
            }

            _biasWeight = _biasWeight + learningRate * Error * _biasValue;

            PreviousWeights = tempWeights;
        }

        public void SetError(List<double> forwardNeuronsErrors, List<double> forwardNeuronsWeights)
        {
            Error = 0;
            for (int i = 0; i < forwardNeuronsWeights.Count; i++)
            {
                Error += forwardNeuronsErrors[i] * forwardNeuronsWeights[i];
            }
            Error *= derivative(_output);
        }

        public void SetErrorForOutputNeuron(double expectedResult)
        {
            Error = expectedResult - _output;
        }

        private double sumarizeInputs()
        {
            double sum = 0;

            for (int i = 0; i < Inputs.Count; i++)
            {
                sum += Inputs[i] * Weights[i];
            }

            return sum + _biasWeight * _biasValue;
        }

        private double activation(double sumarizedInputs)
        {
            var activatedValue = Math.Tanh(sumarizedInputs);
            return activatedValue;
        }

        private double derivative(double value)
        {
            return 1 - Math.Pow(Math.Tanh(value), 2);
        }

    }
}
