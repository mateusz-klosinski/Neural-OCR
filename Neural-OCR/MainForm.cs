﻿using Neural_OCR.Network;
using System.Windows.Forms;

namespace Neural_OCR
{
    public partial class MainForm : Form
    {
        private Teacher _teacher;


        public MainForm()
        {
            InitializeComponent();
            _teacher = new Teacher(new NeuralNetwork(15, 10, 2, 10));
        }

        private void buttonTeachNetwork_Click(object sender, System.EventArgs e)
        {
            _teacher.Learn(2000);
            _teacher.Test();
        }
    }
}
