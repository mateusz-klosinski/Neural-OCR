using System.Drawing;
using Neural_OCR.Network;
using System.Windows.Forms;
using ZedGraph;

namespace Neural_OCR
{
    public partial class MainForm : Form
    {
        private Teacher _teacher;
        private PointPairList errorListForChart;
        private int _numberOfEpochs = 200;

        public MainForm()
        {
            InitializeComponent();
            errorListForChart = initializeLearningChart();

            _teacher = new Teacher(new NeuralNetwork(15, 10, 1, 10), errorListForChart);
        }

        private void buttonTeachNetwork_Click(object sender, System.EventArgs e)
        {
            _teacher.Learn(_numberOfEpochs);
            _teacher.Test();
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
    }
}
