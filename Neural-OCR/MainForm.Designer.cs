namespace Neural_OCR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonClearPaintBoard = new System.Windows.Forms.Button();
            this.buttonScaleImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownMomentum = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLearningRate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfNeuronsInHiddendLayers = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfHiddenLayers = new System.Windows.Forms.NumericUpDown();
            this.learningChart = new ZedGraph.ZedGraphControl();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownEpochs = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTeachNetwork = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfInputNeurons = new System.Windows.Forms.NumericUpDown();
            this.buttonInitialize = new System.Windows.Forms.Button();
            this.paintBoard1 = new Neural_OCR.PaintBoard();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfNeuronsInHiddendLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfHiddenLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfInputNeurons)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonClearPaintBoard);
            this.groupBox1.Controls.Add(this.buttonScaleImage);
            this.groupBox1.Controls.Add(this.paintBoard1);
            this.groupBox1.Location = new System.Drawing.Point(14, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Painting area";
            // 
            // ButtonClearPaintBoard
            // 
            this.ButtonClearPaintBoard.Location = new System.Drawing.Point(6, 242);
            this.ButtonClearPaintBoard.Name = "ButtonClearPaintBoard";
            this.ButtonClearPaintBoard.Size = new System.Drawing.Size(82, 28);
            this.ButtonClearPaintBoard.TabIndex = 1;
            this.ButtonClearPaintBoard.Text = "Clear";
            this.ButtonClearPaintBoard.UseVisualStyleBackColor = true;
            this.ButtonClearPaintBoard.Click += new System.EventHandler(this.ButtonClearPaintBoard_Click);
            // 
            // buttonScaleImage
            // 
            this.buttonScaleImage.Location = new System.Drawing.Point(123, 242);
            this.buttonScaleImage.Name = "buttonScaleImage";
            this.buttonScaleImage.Size = new System.Drawing.Size(87, 27);
            this.buttonScaleImage.TabIndex = 1;
            this.buttonScaleImage.Text = "Scale";
            this.buttonScaleImage.UseVisualStyleBackColor = true;
            this.buttonScaleImage.Click += new System.EventHandler(this.buttonScaleImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonInitialize);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.learningChart);
            this.groupBox2.Controls.Add(this.textBoxResult);
            this.groupBox2.Controls.Add(this.buttonRecognize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelError);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownEpochs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonTeachNetwork);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(943, 309);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownNumberOfInputNeurons);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numericUpDownMomentum);
            this.groupBox3.Controls.Add(this.numericUpDownLearningRate);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numericUpDownNumberOfNeuronsInHiddendLayers);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.numericUpDownNumberOfHiddenLayers);
            this.groupBox3.Location = new System.Drawing.Point(237, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 63);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuration";
            // 
            // numericUpDownMomentum
            // 
            this.numericUpDownMomentum.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.numericUpDownMomentum.DecimalPlaces = 1;
            this.numericUpDownMomentum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownMomentum.Location = new System.Drawing.Point(586, 32);
            this.numericUpDownMomentum.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.numericUpDownMomentum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownMomentum.Name = "numericUpDownMomentum";
            this.numericUpDownMomentum.Size = new System.Drawing.Size(108, 20);
            this.numericUpDownMomentum.TabIndex = 16;
            this.numericUpDownMomentum.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownMomentum.ValueChanged += new System.EventHandler(this.numericUpDownMomentum_ValueChanged);
            // 
            // numericUpDownLearningRate
            // 
            this.numericUpDownLearningRate.DecimalPlaces = 1;
            this.numericUpDownLearningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownLearningRate.Location = new System.Drawing.Point(475, 32);
            this.numericUpDownLearningRate.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.numericUpDownLearningRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownLearningRate.Name = "numericUpDownLearningRate";
            this.numericUpDownLearningRate.Size = new System.Drawing.Size(105, 20);
            this.numericUpDownLearningRate.TabIndex = 15;
            this.numericUpDownLearningRate.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.numericUpDownLearningRate.ValueChanged += new System.EventHandler(this.numericUpDownLearningRate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(583, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Momentum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Learning rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of hidden layers";
            // 
            // numericUpDownNumberOfNeuronsInHiddendLayers
            // 
            this.numericUpDownNumberOfNeuronsInHiddendLayers.Location = new System.Drawing.Point(290, 32);
            this.numericUpDownNumberOfNeuronsInHiddendLayers.Name = "numericUpDownNumberOfNeuronsInHiddendLayers";
            this.numericUpDownNumberOfNeuronsInHiddendLayers.Size = new System.Drawing.Size(170, 20);
            this.numericUpDownNumberOfNeuronsInHiddendLayers.TabIndex = 10;
            this.numericUpDownNumberOfNeuronsInHiddendLayers.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNumberOfNeuronsInHiddendLayers.ValueChanged += new System.EventHandler(this.numericUpDownNumberOfNeuronsInHiddendLayers_ValueChanged);
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Number of neurons in hidden layers";
            // 
            // numericUpDownNumberOfHiddenLayers
            // 
            this.numericUpDownNumberOfHiddenLayers.Location = new System.Drawing.Point(18, 32);
            this.numericUpDownNumberOfHiddenLayers.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownNumberOfHiddenLayers.Name = "numericUpDownNumberOfHiddenLayers";
            this.numericUpDownNumberOfHiddenLayers.Size = new System.Drawing.Size(118, 20);
            this.numericUpDownNumberOfHiddenLayers.TabIndex = 9;
            this.numericUpDownNumberOfHiddenLayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfHiddenLayers.ValueChanged += new System.EventHandler(this.numericUpDownNumberOfHiddenLayers_ValueChanged);
            // 
            // learningChart
            // 
            this.learningChart.Location = new System.Drawing.Point(237, 86);
            this.learningChart.Name = "learningChart";
            this.learningChart.ScrollGrace = 0D;
            this.learningChart.ScrollMaxX = 0D;
            this.learningChart.ScrollMaxY = 0D;
            this.learningChart.ScrollMaxY2 = 0D;
            this.learningChart.ScrollMinX = 0D;
            this.learningChart.ScrollMinY = 0D;
            this.learningChart.ScrollMinY2 = 0D;
            this.learningChart.Size = new System.Drawing.Size(490, 210);
            this.learningChart.TabIndex = 8;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Enabled = false;
            this.textBoxResult.Location = new System.Drawing.Point(871, 275);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(27, 20);
            this.textBoxResult.TabIndex = 4;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(736, 245);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(201, 23);
            this.buttonRecognize.TabIndex = 5;
            this.buttonRecognize.Text = "Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(772, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Network thinks it\'s";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Green;
            this.labelError.Location = new System.Drawing.Point(879, 205);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(52, 13);
            this.labelError.TabIndex = 6;
            this.labelError.Text = "0,049043";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(902, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Error";
            // 
            // numericUpDownEpochs
            // 
            this.numericUpDownEpochs.Enabled = false;
            this.numericUpDownEpochs.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownEpochs.Location = new System.Drawing.Point(733, 140);
            this.numericUpDownEpochs.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownEpochs.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownEpochs.Name = "numericUpDownEpochs";
            this.numericUpDownEpochs.Size = new System.Drawing.Size(204, 20);
            this.numericUpDownEpochs.TabIndex = 4;
            this.numericUpDownEpochs.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownEpochs.ValueChanged += new System.EventHandler(this.numericUpDownEpochs_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(785, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of epochs";
            // 
            // buttonTeachNetwork
            // 
            this.buttonTeachNetwork.Enabled = false;
            this.buttonTeachNetwork.Location = new System.Drawing.Point(733, 166);
            this.buttonTeachNetwork.Name = "buttonTeachNetwork";
            this.buttonTeachNetwork.Size = new System.Drawing.Size(204, 23);
            this.buttonTeachNetwork.TabIndex = 2;
            this.buttonTeachNetwork.Text = "Teach network";
            this.buttonTeachNetwork.UseVisualStyleBackColor = true;
            this.buttonTeachNetwork.Click += new System.EventHandler(this.buttonTeachNetwork_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Number of input neurons";
            // 
            // numericUpDownNumberOfInputNeurons
            // 
            this.numericUpDownNumberOfInputNeurons.Location = new System.Drawing.Point(151, 32);
            this.numericUpDownNumberOfInputNeurons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfInputNeurons.Name = "numericUpDownNumberOfInputNeurons";
            this.numericUpDownNumberOfInputNeurons.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumberOfInputNeurons.TabIndex = 18;
            this.numericUpDownNumberOfInputNeurons.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownNumberOfInputNeurons.ValueChanged += new System.EventHandler(this.numericUpDownNumberOfInputNeurons_ValueChanged);
            // 
            // buttonInitialize
            // 
            this.buttonInitialize.Location = new System.Drawing.Point(736, 89);
            this.buttonInitialize.Name = "buttonInitialize";
            this.buttonInitialize.Size = new System.Drawing.Size(204, 23);
            this.buttonInitialize.TabIndex = 14;
            this.buttonInitialize.Text = "Initialize Network";
            this.buttonInitialize.UseVisualStyleBackColor = true;
            this.buttonInitialize.Click += new System.EventHandler(this.buttonInitialize_Click);
            // 
            // paintBoard1
            // 
            this.paintBoard1.Location = new System.Drawing.Point(6, 19);
            this.paintBoard1.Name = "paintBoard1";
            this.paintBoard1.Size = new System.Drawing.Size(204, 217);
            this.paintBoard1.TabIndex = 0;
            this.paintBoard1.Text = "paintBoard1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 330);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Neural-OCR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfNeuronsInHiddendLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfHiddenLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfInputNeurons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTeachNetwork;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownEpochs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonRecognize;
        private ZedGraph.ZedGraphControl learningChart;
        private PaintBoard paintBoard1;
        private System.Windows.Forms.Button ButtonClearPaintBoard;
        private System.Windows.Forms.Button buttonScaleImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfNeuronsInHiddendLayers;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfHiddenLayers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownMomentum;
        private System.Windows.Forms.NumericUpDown numericUpDownLearningRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfInputNeurons;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonInitialize;
    }
}

