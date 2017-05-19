using Neural_OCR.ListExtensions;
using Neural_OCR.Parser;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ZedGraph;

namespace Neural_OCR.Network
{
    public class Teacher
    {
        private ImageParser _parser;
        private NeuralNetwork _network;
        private List<TeachingElement> _elements;
        private PointPairList _errorListForChart;


        public double GlobalError
        {
            get
            {
                return _network.GlobalError;
            }
        }

        public double Momentum
        {
            get
            {
                return _network.Momentum;
            }
            set
            {
                _network.Momentum = value;
            }
        }

        public double LearningRate
        {
            get
            {
                return _network.LearningRate;
            }
            set
            {
                _network.LearningRate = value;
            }
        }


        public Teacher(NeuralNetwork network, PointPairList errorListForChart, string dataSet, int numberOfCharactersToRecognize, int numberOfExamplesForSingleChar)
        {
            _parser = new ImageParser(dataSet);
            _network = network;
            _elements = new List<TeachingElement>();
            _errorListForChart = errorListForChart;


            for (int i = 0; i < numberOfCharactersToRecognize; i++)
            {
                for (int j = 0; j < numberOfExamplesForSingleChar; j++)
                {
                    _elements.Add(_parser.CreateTeachingElementFromImage(
                    Path.GetFullPath($"{dataSet}/{i}-{j}.png"),
                    i
                    ));
                }
            }
        }


        public void Learn(int numberOfEpochs)
        {
            /*int j=0;
            Task.Run(() =>
            {
                for (int i = 0; i < numberOfEpochs; i++)
                {
                    _elements.ForEach(e =>
                    {
                        _network.Learn(e);

                        Debug.WriteLine(GlobalError);
                        _errorListForChart.Add(j++, GlobalError);
                    });
                    _elements.Reverse();
                    _elements.Shuffle();
                }
            });*/

            Task.Run(() =>
            {
                for (int i = 0; i < numberOfEpochs; i++)
                {
                    _elements.ForEach(e => _network.Learn(e));
                    _elements.Reverse();
                    _elements.Shuffle();
                    Debug.WriteLine(GlobalError);
                    _errorListForChart.Add(i, GlobalError);
                    /*Naprawiłem to, że wrzuca do grafu błąd każdego znaku po kolei 
                     *ale to co się odpitala z UI to o panie, więc nie polecam tego. 
                     *Jakiś mniej więcej wizualny pogląd i tak mamy ale jakby co to odkomentuj górę i możesz looknać :D*/
                }
            });
        }


        public int Test(Bitmap image)
        {
            TeachingElement element = _parser.CreateTeachingElementFromImage(image, 2);

            var output = _network.Test(element);

            return (int)output;
        }
    }
}
