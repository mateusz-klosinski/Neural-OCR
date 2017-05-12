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
            this.buttonPickImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.learningChart = new ZedGraph.ZedGraphControl();
            this.labelError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownEpochs = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTeachNetwork = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.paintBoard1 = new Neural_OCR.PaintBoard();
            this.ButtonClearPaintBoard = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpochs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonClearPaintBoard);
            this.groupBox1.Controls.Add(this.paintBoard1);
            this.groupBox1.Location = new System.Drawing.Point(14, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 277);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Painting area";
            // 
            // buttonPickImage
            // 
            this.buttonPickImage.Location = new System.Drawing.Point(236, 273);
            this.buttonPickImage.Name = "buttonPickImage";
            this.buttonPickImage.Size = new System.Drawing.Size(125, 23);
            this.buttonPickImage.TabIndex = 1;
            this.buttonPickImage.Text = "Pick an image";
            this.buttonPickImage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.learningChart);
            this.groupBox2.Controls.Add(this.labelError);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownEpochs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonTeachNetwork);
            this.groupBox2.Controls.Add(this.buttonPickImage);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(905, 344);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // learningChart
            // 
            this.learningChart.Location = new System.Drawing.Point(366, 19);
            this.learningChart.Name = "learningChart";
            this.learningChart.ScrollGrace = 0D;
            this.learningChart.ScrollMaxX = 0D;
            this.learningChart.ScrollMaxY = 0D;
            this.learningChart.ScrollMaxY2 = 0D;
            this.learningChart.ScrollMinX = 0D;
            this.learningChart.ScrollMinY = 0D;
            this.learningChart.ScrollMinY2 = 0D;
            this.learningChart.Size = new System.Drawing.Size(516, 210);
            this.learningChart.TabIndex = 8;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Green;
            this.labelError.Location = new System.Drawing.Point(236, 144);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(52, 13);
            this.labelError.TabIndex = 6;
            this.labelError.Text = "0,049043";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Error";
            // 
            // numericUpDownEpochs
            // 
            this.numericUpDownEpochs.Location = new System.Drawing.Point(236, 70);
            this.numericUpDownEpochs.Name = "numericUpDownEpochs";
            this.numericUpDownEpochs.Size = new System.Drawing.Size(122, 20);
            this.numericUpDownEpochs.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of epochs";
            // 
            // buttonTeachNetwork
            // 
            this.buttonTeachNetwork.Location = new System.Drawing.Point(236, 96);
            this.buttonTeachNetwork.Name = "buttonTeachNetwork";
            this.buttonTeachNetwork.Size = new System.Drawing.Size(124, 23);
            this.buttonTeachNetwork.TabIndex = 2;
            this.buttonTeachNetwork.Text = "Teach network";
            this.buttonTeachNetwork.UseVisualStyleBackColor = true;
            this.buttonTeachNetwork.Click += new System.EventHandler(this.buttonTeachNetwork_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Network thinks it\'s";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Enabled = false;
            this.textBoxResult.Location = new System.Drawing.Point(485, 247);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(27, 20);
            this.textBoxResult.TabIndex = 4;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(389, 285);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(123, 23);
            this.buttonRecognize.TabIndex = 5;
            this.buttonRecognize.Text = "Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            // 
            // paintBoard1
            // 
            this.paintBoard1.Location = new System.Drawing.Point(23, 19);
            this.paintBoard1.Name = "paintBoard1";
            this.paintBoard1.Size = new System.Drawing.Size(187, 217);
            this.paintBoard1.TabIndex = 0;
            this.paintBoard1.Text = "paintBoard1";
            // 
            // ButtonClearPaintBoard
            // 
            this.ButtonClearPaintBoard.Location = new System.Drawing.Point(23, 243);
            this.ButtonClearPaintBoard.Name = "ButtonClearPaintBoard";
            this.ButtonClearPaintBoard.Size = new System.Drawing.Size(100, 28);
            this.ButtonClearPaintBoard.TabIndex = 1;
            this.ButtonClearPaintBoard.Text = "Clear";
            this.ButtonClearPaintBoard.UseVisualStyleBackColor = true;
            this.ButtonClearPaintBoard.Click += new System.EventHandler(this.ButtonClearPaintBoard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 364);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Neural-OCR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEpochs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPickImage;
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
    }
}

