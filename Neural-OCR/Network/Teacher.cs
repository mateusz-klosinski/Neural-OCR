using Neural_OCR.Parser;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ZedGraph;

namespace Neural_OCR.Network
{
    public class Teacher
    {
        private ImageParser _parser;
        private NeuralNetwork _network;
        private List<TeachingElement> _elements;
        private PointPairList _errorListForChart;

        private List<int> _expectedOutputs;
        private List<List<double>> _trainingInputs;

        public double GlobalError
        {
            get
            {
                return _network.GlobalError;
            }
        }

        public Teacher(NeuralNetwork network, PointPairList errorListForChart)
        {
            _parser = new ImageParser();
            _network = network;
            _elements = new List<TeachingElement>();
            _errorListForChart = errorListForChart;



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
                Debug.WriteLine(GlobalError);
                _errorListForChart.Add(i, GlobalError);
            }
        }


        public int Test(Bitmap image)
        {
            TeachingElement element = _parser.CreateTeachingElementFromImage(image, 2);

            var output = _network.Test(element);

            return (int)output;
        }
    }
}
