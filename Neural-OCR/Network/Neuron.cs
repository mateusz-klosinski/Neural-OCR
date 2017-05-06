using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Neuron()
        {
            Weights = new List<double>();
        }

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

        public void AdjustWeights(double learningRate, List<double> previousNeuronsOutput)
        {
            for (int i = 0; i < Weights.Count - 1; i++)
            {
                Weights[i] = Weights[i] + learningRate * Error * derivative(previousNeuronsOutput[i]);
            }
        }

        public void SetError(List<double> forwardNeuronsErrors, List<double> forwardNeuronsWeights)
        {
            for (int i = 0; i < forwardNeuronsWeights.Count - 1; i++)
            {
                Error += forwardNeuronsErrors[i] * forwardNeuronsWeights[i];
            }
        }

        public void SetErrorForOutputNeuron(double expectedResult)
        {
            Error = expectedResult - _output;
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

        private double derivative(double value)
        {
            return value * (1 - value);
        }

    }
}
