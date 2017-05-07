using Neural_OCR.Parser;
using System;
using System.Collections.Generic;
using System.IO;

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

            for (int i = 0; i < 10; i++)
            {
                _elements.Add(_parser.CreateTeachingElementFromImage(
                    Path.GetFullPath($"Digits/{i}.jpg"),
                    i
                    ));
            }
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
        }
    }
}
