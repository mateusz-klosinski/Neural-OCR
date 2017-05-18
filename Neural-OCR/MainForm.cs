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


        public MainForm()
        {
            InitializeComponent();
        }


        private NeuralNetwork initializeNetwork()
        {
            var network = new NeuralNetwork();

            network.InitializeInputLayer(80, NumberOfInputNeurons);
            network.InitializeHiddenLayers(NumberOfHiddenLayers, NumberOfNeuronsInEveryHiddenLayer);
            network.InitializeOutputLayer(10);
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

            textBoxResult.Text = number.ToString();
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

        private void buttonInitialize_Click(object sender, System.EventArgs e)
        {
            errorListForChart = initializeLearningChart();

            var network = initializeNetwork();
            _teacher = new Teacher(network, errorListForChart);


            numericUpDownNumberOfHiddenLayers.Enabled = false;
            numericUpDownNumberOfInputNeurons.Enabled = false;
            numericUpDownNumberOfNeuronsInHiddendLayers.Enabled = false;

            buttonInitialize.Enabled = false;
            buttonTeachNetwork.Enabled = true;
        }
    }
}
