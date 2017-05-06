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


        private Random _random = new Random();

        public double Output()
        {
            _output = Activation(SumarizeInputs());
            return _output;
        }

        public void RandomizeWeights()
        {
            for (int i = 0; i < Weights.Count-1; i++)
            {
                Weights[i] = _random.NextDouble();
            }

            _biasWeight = _random.NextDouble();
        }

        public void AdjustWeights()
        {
            for (int i = 0; i < Weights.Count-1; i++)
            {
                Weights[i] += Error * Inputs[i];
            }

            _biasWeight += Error;
        }

        public void SetError(double globalError)
        {
            Error = (-2 * _output * Math.Pow(Math.E, Math.Pow(-_output, 2))) * globalError; //TODO nie jestem pewien czy przypadkiem nie powinno tu być wagi ale to wieczorem xd
        }

        private double SumarizeInputs()
        {
            double sum = 0;

            for (int i = 0; i < Inputs.Count-1; i++)
            {
                sum += Inputs[i] * Weights[i];
            }

            return sum + _biasWeight;
        }

        private double Activation(double sumarizedInputs)
        {
            var activatedValue = Math.Pow(Math.E, Math.Pow(-sumarizedInputs, 2));
            return activatedValue;
        }
        
    }
}
