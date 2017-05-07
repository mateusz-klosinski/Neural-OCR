using Neural_OCR.Parser;
using System;
using System.Collections.Generic;

namespace Neural_OCR.Network
{
    public class Teacher
    {
        private ImageParser _parser;
        private NeuralNetwork _network;
        private List<TeachingElement> _elements;

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
            _elements = new List<TeachingElement>();

            //for (int i = 0; i < 10; i++)
            //{
            //    _elements.Add(_parser.CreateTeachingElementFromImage(
            //        Path.GetFullPath($"Digits/{i}.jpg"),
            //        i
            //        ));
            //}
            //niech się uczy na razie bramki XOR xd
            _elements.AddRange(
                new List<TeachingElement> {
                    new TeachingElement
                    {
                        Inputs = new List<double> {0,0},
                        ExpectedOutputs = new List<double> { 0 }
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double> {0,1},
                        ExpectedOutputs = new List<double> { 1 }
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double> {1,0},
                        ExpectedOutputs = new List<double> { 1 }
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double> {1,1},
                        ExpectedOutputs = new List<double> { 0 }
                    },
            });
        }


        public void Learn(int numberOfEpochs)
        {
            for (int i = 0; i < numberOfEpochs; i++)
            {
                _elements.ForEach(e => _network.Learn(e));
                _elements.Reverse();
                //if (i == 0 || i == numberOfEpochs - 1)
                Console.WriteLine(GlobalError);
            }
        }


        public void Test()
        {
            var element = _elements[2];

            var output = _network.Test(element);

            Console.WriteLine("spodziewane wyniki");
            element.ExpectedOutputs.ForEach(o => Console.Write(o + ", "));
            Console.WriteLine("");
            Console.WriteLine("Otrzymane wyniki");
            output.ForEach(o => Console.Write(o + ", "));
            Console.WriteLine("");
        }
    }
}
