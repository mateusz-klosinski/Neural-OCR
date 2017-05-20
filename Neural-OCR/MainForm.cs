using Neural_OCR.Network;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Neural_OCR
{
    public partial class MainForm : Form
    {
        private Teacher _teacher;
        private PointPairList errorListForChart;


        public int NumberOfEpochs { get; set; } = 2000;
        public int NumberOfHiddenLayers { get; set; } = 1;
        public int NumberOfInputNeurons { get; set; } = 15;
        public int NumberOfNeuronsInEveryHiddenLayer { get; set; } = 10;
        public int NumberOfOutputs { get; set; }
        public int NumberOfCharactersToRecognize { get; set; }
        public int NumberOfExamplesForSingleChar { get; set; }

        public string DataSet { get; set; }

        public MainForm()
        {
            InitializeComponent();
            GraphRefreshTimer.Interval = 100;
        }


        private NeuralNetwork initializeNetwork()
        {
            var network = new NeuralNetwork();

            network.InitializeInputLayer(120, NumberOfInputNeurons);
            network.InitializeHiddenLayers(NumberOfHiddenLayers, NumberOfNeuronsInEveryHiddenLayer);
            network.InitializeOutputLayer(NumberOfOutputs);
            network.Randomize();

            return network;
        }


        private PointPairList initializeLearningChart()
        {
            GraphPane graphPane = learningChart.GraphPane;

            graphPane.XAxis.Title.Text = "Epochs";
            graphPane.YAxis.Title.Text = "Error";

            graphPane.XAxis.Scale.Max = NumberOfEpochs;
            graphPane.YAxis.Scale.Max = 1.0;

            PointPairList errorListForChart = new PointPairList();

            LineItem curve = new LineItem("Error", errorListForChart, Color.Blue, SymbolType.None, 1.5f);
            graphPane.CurveList.Add(curve);

            return errorListForChart;
        }




        private void buttonTeachNetwork_Click(object sender, System.EventArgs e)
        {
            _teacher.Learn(NumberOfEpochs);
            GraphRefreshTimer.Start();
        }

        private void ButtonClearPaintBoard_Click(object sender, System.EventArgs e)
        {
            paintBoard1.ClearImage();
        }

        private void buttonScaleImage_Click(object sender, System.EventArgs e)
        {
            paintBoard1.GetImage();
        }

        private void buttonRecognize_Click(object sender, System.EventArgs e)
        {
            var number = _teacher.Test(paintBoard1.GetImage());

            if (DataSet == "Letters")
            {
                textBoxResult.Text = ((char)(number + 65)).ToString();
            }

            if (DataSet == "PaintDigits")
            {
                textBoxResult.Text = number.ToString();
            }
        }

        private void numericUpDownNumberOfHiddenLayers_ValueChanged(object sender, System.EventArgs e)
        {
            NumberOfHiddenLayers = (int)numericUpDownNumberOfHiddenLayers.Value;
        }

        private void numericUpDownNumberOfInputNeurons_ValueChanged(object sender, System.EventArgs e)
        {
            NumberOfInputNeurons = (int)numericUpDownNumberOfInputNeurons.Value;
        }

        private void numericUpDownNumberOfNeuronsInHiddendLayers_ValueChanged(object sender, System.EventArgs e)
        {
            NumberOfNeuronsInEveryHiddenLayer = (int)numericUpDownNumberOfNeuronsInHiddendLayers.Value;
        }

        private void numericUpDownLearningRate_ValueChanged(object sender, System.EventArgs e)
        {
            _teacher.LearningRate = (double)numericUpDownLearningRate.Value;
        }

        private void numericUpDownMomentum_ValueChanged(object sender, System.EventArgs e)
        {
            _teacher.Momentum = (double)numericUpDownMomentum.Value;
        }

        private void numericUpDownEpochs_ValueChanged(object sender, System.EventArgs e)
        {
            NumberOfEpochs = (int)numericUpDownEpochs.Value;
        }

        private void radioButtonDigitsOcr_CheckedChanged(object sender, System.EventArgs e)
        {
            NumberOfOutputs = 10;
            DataSet = "PaintDigits";
            NumberOfCharactersToRecognize = 10;
            NumberOfExamplesForSingleChar = 6;
        }

        private void radioButtonLettersOcr_CheckedChanged(object sender, System.EventArgs e)
        {
            NumberOfOutputs = 26;
            DataSet = "Letters";
            NumberOfCharactersToRecognize = 26;
            NumberOfExamplesForSingleChar = 3;
        }

        private void buttonInitialize_Click(object sender, System.EventArgs e)
        {
            errorListForChart = initializeLearningChart();

            var network = initializeNetwork();
            _teacher = new Teacher(network, errorListForChart, DataSet, NumberOfCharactersToRecognize, NumberOfExamplesForSingleChar);

            numericUpDownMomentum.Enabled = true;
            numericUpDownLearningRate.Enabled = true;

            radioButtonDigitsOcr.Enabled = false;
            radioButtonLettersOcr.Enabled = false;

            numericUpDownNumberOfHiddenLayers.Enabled = false;
            numericUpDownNumberOfInputNeurons.Enabled = false;
            numericUpDownNumberOfNeuronsInHiddendLayers.Enabled = false;

            buttonInitialize.Enabled = false;
            buttonTeachNetwork.Enabled = true;
            numericUpDownEpochs.Enabled = true;
        }

        private void GraphRefreshTimer_Tick(object sender, System.EventArgs e)
        {
            learningChart.Invalidate();

            if (_teacher.IsLearningDone)
            {
                GraphRefreshTimer.Stop();
            }
        }
    }
}
