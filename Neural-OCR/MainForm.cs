using Neural_OCR.Network;
using System.Windows.Forms;

namespace Neural_OCR
{
    public partial class MainForm : Form
    {
        private Teacher _teacher;


        public MainForm()
        {
            InitializeComponent();
            _teacher = new Teacher(new NeuralNetwork(18, 10, 0));
            _teacher.Learn(10000);
            _teacher.Test();
        }

    }
}
