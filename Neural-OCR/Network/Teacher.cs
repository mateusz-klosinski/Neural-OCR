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

            _expectedOutputs = _parser.ReadExpectedOutputsFromCsv(36000);
            _trainingInputs = _parser.LoadTrainingInputsFromCsv();

            for (int i = 0; i < _expectedOutputs.Count; i++)
            {
                _elements.Add(new TeachingElement
                {
                    ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(_expectedOutputs[i]),
                    Inputs = _trainingInputs[i]
                });
            }

            /*for (int i = 0; i < 10; i++)
            {
                _elements.Add(_parser.CreateTeachingElementFromImage(
                    Path.GetFullPath($"Digits/{i}.jpg"),
                    i
                    ));
            }*/


            /*_elements.AddRange(
                new List<TeachingElement>
                {
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1 ,1,
                            1, -1, 1,
                            1, -1, 1,
                            1, -1, 1,
                            1, -1, 1
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(0),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            -1, -1, 1,
                            -1, 1, 1,
                            1, -1, 1,
                            -1, -1, 1,
                            -1, -1, 1
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(1),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            -1, -1, 1,
                            -1, 1, -1,
                            1, -1, -1,
                            1, 1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(2),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            -1, -1, 1,
                            1, 1, 1,
                            -1, -1, 1,
                            1, 1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(3),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, -1, 1,
                            1, -1, 1,
                            1, 1, 1,
                            -1, -1, 1,
                            -1, -1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(4),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            1, -1 , -1,
                            1, 1, 1,
                            -1, -1, 1,
                            1, 1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(5),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            1, -1, -1,
                            1, 1, 1,
                            1, -1, 1,
                            1, 1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(6),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            -1, -1, 1,
                            -1, 1 , -1,
                            1, -1, -1,
                            1, -1 , -1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(7),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            1, -1, 1,
                            1, 1, 1,
                            1, -1, 1,
                            1, 1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(8),
                    },
                    new TeachingElement
                    {
                        Inputs = new List<double>
                        {
                            1, 1, 1,
                            1, -1, 1,
                            1, 1, 1,
                            -1, -1, 1,
                            1, 1, 1,
                        },
                        ExpectedOutputs = ExpectedOutputFactory.getExpectedOutput(9),
                    }
                });*/
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


        public void Test(Bitmap image)
        {
            TeachingElement element = _parser.CreateTeachingElementFromImage(image, 2);

            var output = _network.Test(element);

            Debug.WriteLine("spodziewane wyniki");

            element.ExpectedOutputs.ForEach(o => Debug.Write(o + ", "));


            Debug.WriteLine("");
            Debug.WriteLine("Otrzymane wyniki");

            output.ForEach(o => Debug.Write(o + ", "));
            Debug.WriteLine("");
        }
    }
}
