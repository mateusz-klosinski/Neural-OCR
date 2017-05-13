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
        private int _numberOfEpochs = 2000;

        public MainForm()
        {
            InitializeComponent();
            errorListForChart = initializeLearningChart();

            var network = initializeNetwork();
            _teacher = new Teacher(network, errorListForChart);
        }


        private NeuralNetwork initializeNetwork()
        {
            var network = new NeuralNetwork();

            network.InitializeInputLayer(15, 10);
            network.InitializeHiddenLayers(1, 8);
            network.InitializeOutputLayer(10);
            network.Randomize();

            return network;
        }

        private void buttonTeachNetwork_Click(object sender, System.EventArgs e)
        {
            _teacher.Learn(_numberOfEpochs);
        }

        private PointPairList initializeLearningChart()
        {
            GraphPane graphPane = learningChart.GraphPane;

            graphPane.XAxis.Title.Text = "Epochs";
            graphPane.YAxis.Title.Text = "Error";

            graphPane.XAxis.Scale.Max = _numberOfEpochs;
            graphPane.YAxis.Scale.Max = 1.0;

            PointPairList errorListForChart = new PointPairList();

            LineItem curve = new LineItem("Error", errorListForChart, Color.Blue, SymbolType.None, 1.5f);
            graphPane.CurveList.Add(curve);

            return errorListForChart;
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
            _teacher.Test(paintBoard1.GetImage());
        }
    }
}
