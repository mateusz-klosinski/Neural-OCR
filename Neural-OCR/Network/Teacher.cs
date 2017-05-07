using Neural_OCR.Parser;
using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Teacher
    {
        private ImageParser _parser;
        private NeuralNetwork _network;

        public double GlobalError
        {
            get
            {
                return _network.GlobalError;
            }
        }

        public Teacher(NeuralNetwork network)
        {
            _parser = new ImageParser();
            _network = network;
        }


        public void Learn(int numberOfEpochs)
        {
            TeachingElement element1 = new TeachingElement
            {
                Inputs = new List<double>(new double[] { 0, 0 }),
                ExpectedOutputs = new List<double>(new double[] { 0 })
            };


            TeachingElement element2 = new TeachingElement
            {
                Inputs = new List<double>(new double[] { 0, 1 }),
                ExpectedOutputs = new List<double>(new double[] { 1 })
            };

            TeachingElement element3 = new TeachingElement
            {
                Inputs = new List<double>(new double[] { 1, 0 }),
                ExpectedOutputs = new List<double>(new double[] { 1 })
            };

            TeachingElement element4 = new TeachingElement
            {
                Inputs = new List<double>(new double[] { 1, 1 }),
                ExpectedOutputs = new List<double>(new double[] { 0 })
            };


            List<TeachingElement> elements = new List<TeachingElement>
            {
                element1, element2, element3, element4
            };

            for (int i = 0; i < numberOfEpochs; i++)
            {
                elements.ForEach(e => _network.Learn(e));
                elements.Reverse();
                //if (i == 0 || i == numberOfEpochs - 1)
                    Console.WriteLine(GlobalError);
            }
        }


        public void Test()
        {
            TeachingElement element3 = new TeachingElement
            {
                Inputs = new List<double>(new double[] { 0, 0 }),
                ExpectedOutputs = new List<double>(new double[] { 1 })
            };

            List<double> outputs = _network.Test(element3);

            Console.WriteLine("Output!");
            outputs.ForEach(o => Console.WriteLine(o));
        }
    }
}
