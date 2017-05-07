using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neural_OCR.Network
{
    public class Neuron //TODO Zaimplementować momentum
    {
        private double _biasWeight;
        private static double _biasValue = 1.0;
        private double _output;

        public double Error;

        public List<double> Weights;
        public List<double> Inputs;

        public Neuron()
        {
            Weights = new List<double>();
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
                Weights.Add(_random.NextDouble());
            }

            _biasWeight = _random.NextDouble();
        }

        public void AdjustWeights(double learningRate)
        {
            for (int i = 0; i < Weights.Count; i++)
            {
                Weights[i] = Weights[i] + learningRate * Error * Inputs[i];
            }

            _biasWeight = _biasWeight + learningRate * Error * _biasValue;
        }

        public void SetError(List<double> forwardNeuronsErrors, List<double> forwardNeuronsWeights)
        {
            Error = 0;
            for (int i = 0; i < forwardNeuronsWeights.Count; i++)
            {
                Error += forwardNeuronsErrors[i] * forwardNeuronsWeights[i] * derivative(_output);
            }
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
            var activatedValue = 1.0 / (1.0 + Math.Exp(-sumarizedInputs));
            return activatedValue;
        }

        private double derivative(double value)
        {
            return value * (1 - value);
        }

    }
}
