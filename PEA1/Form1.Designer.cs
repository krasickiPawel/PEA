
namespace PEA1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.readRawButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.neighbourLabel = new System.Windows.Forms.Label();
            this.neighbourComboBox = new System.Windows.Forms.ComboBox();
            this.checkBoxDiversyfication = new System.Windows.Forms.CheckBox();
            this.trackBarExecuteTimes = new System.Windows.Forms.TrackBar();
            this.labelAlgorithmWorking = new System.Windows.Forms.Label();
            this.labelPopulationSize = new System.Windows.Forms.Label();
            this.textBoxPopulationSize = new System.Windows.Forms.TextBox();
            this.labelMutationValue = new System.Windows.Forms.Label();
            this.labelCrossValue = new System.Windows.Forms.Label();
            this.comboBoxCrossMethod = new System.Windows.Forms.ComboBox();
            this.labelMutationMethod = new System.Windows.Forms.Label();
            this.textBoxMutationValue = new System.Windows.Forms.TextBox();
            this.textBoxCrossValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExecuteTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "SA",
            "TS",
            "BF",
            "DP"});
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SA",
            "TS",
            "BF",
            "DP",
            "Genethic"});
            this.comboBox1.Location = new System.Drawing.Point(249, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wybierz algorytm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(56, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "Wybierz plik";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Plik:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(430, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "Wykonaj";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Najlepsza droga:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Czas wykonania algorytmu:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(602, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 65);
            this.button3.TabIndex = 8;
            this.button3.Text = "Wykonaj x10";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(643, 469);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(128, 65);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Zakończ";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // readRawButton
            // 
            this.readRawButton.Enabled = false;
            this.readRawButton.Location = new System.Drawing.Point(56, 469);
            this.readRawButton.Name = "readRawButton";
            this.readRawButton.Size = new System.Drawing.Size(225, 65);
            this.readRawButton.TabIndex = 10;
            this.readRawButton.Text = "Wczytaj niesformatowany plik";
            this.readRawButton.UseVisualStyleBackColor = true;
            this.readRawButton.Visible = false;
            this.readRawButton.Click += new System.EventHandler(this.readRawButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(56, 147);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(237, 20);
            this.timeLabel.TabIndex = 11;
            this.timeLabel.Text = "Podaj czas działania algorytmu [s]:";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(312, 144);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(98, 27);
            this.timeTextBox.TabIndex = 12;
            // 
            // neighbourLabel
            // 
            this.neighbourLabel.AutoSize = true;
            this.neighbourLabel.Location = new System.Drawing.Point(430, 147);
            this.neighbourLabel.Name = "neighbourLabel";
            this.neighbourLabel.Size = new System.Drawing.Size(87, 20);
            this.neighbourLabel.TabIndex = 13;
            this.neighbourLabel.Text = "Sąsiedztwo:";
            // 
            // neighbourComboBox
            // 
            this.neighbourComboBox.FormattingEnabled = true;
            this.neighbourComboBox.Items.AddRange(new object[] {
            "Swap",
            "Invert"});
            this.neighbourComboBox.Location = new System.Drawing.Point(520, 144);
            this.neighbourComboBox.Name = "neighbourComboBox";
            this.neighbourComboBox.Size = new System.Drawing.Size(101, 28);
            this.neighbourComboBox.TabIndex = 14;
            // 
            // checkBoxDiversyfication
            // 
            this.checkBoxDiversyfication.AutoSize = true;
            this.checkBoxDiversyfication.Location = new System.Drawing.Point(642, 146);
            this.checkBoxDiversyfication.Name = "checkBoxDiversyfication";
            this.checkBoxDiversyfication.Size = new System.Drawing.Size(129, 24);
            this.checkBoxDiversyfication.TabIndex = 15;
            this.checkBoxDiversyfication.Text = "Dywersyfikacja";
            this.checkBoxDiversyfication.UseVisualStyleBackColor = true;
            // 
            // trackBarExecuteTimes
            // 
            this.trackBarExecuteTimes.LargeChange = 10;
            this.trackBarExecuteTimes.Location = new System.Drawing.Point(602, 30);
            this.trackBarExecuteTimes.Maximum = 100;
            this.trackBarExecuteTimes.Minimum = 1;
            this.trackBarExecuteTimes.Name = "trackBarExecuteTimes";
            this.trackBarExecuteTimes.Size = new System.Drawing.Size(169, 56);
            this.trackBarExecuteTimes.TabIndex = 16;
            this.trackBarExecuteTimes.Value = 10;
            this.trackBarExecuteTimes.Scroll += new System.EventHandler(this.trackBarExecuteTimes_Scroll);
            // 
            // labelAlgorithmWorking
            // 
            this.labelAlgorithmWorking.AutoSize = true;
            this.labelAlgorithmWorking.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAlgorithmWorking.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelAlgorithmWorking.Location = new System.Drawing.Point(56, 437);
            this.labelAlgorithmWorking.Name = "labelAlgorithmWorking";
            this.labelAlgorithmWorking.Size = new System.Drawing.Size(242, 21);
            this.labelAlgorithmWorking.TabIndex = 17;
            this.labelAlgorithmWorking.Text = "Trwa działanie algorytmu...";
            // 
            // labelPopulationSize
            // 
            this.labelPopulationSize.AutoSize = true;
            this.labelPopulationSize.Location = new System.Drawing.Point(56, 198);
            this.labelPopulationSize.Name = "labelPopulationSize";
            this.labelPopulationSize.Size = new System.Drawing.Size(263, 20);
            this.labelPopulationSize.TabIndex = 18;
            this.labelPopulationSize.Text = "Podaj wielkość populacji początkowej:";
            // 
            // textBoxPopulationSize
            // 
            this.textBoxPopulationSize.Location = new System.Drawing.Point(325, 195);
            this.textBoxPopulationSize.Name = "textBoxPopulationSize";
            this.textBoxPopulationSize.Size = new System.Drawing.Size(85, 27);
            this.textBoxPopulationSize.TabIndex = 19;
            // 
            // labelMutationValue
            // 
            this.labelMutationValue.AutoSize = true;
            this.labelMutationValue.Location = new System.Drawing.Point(430, 198);
            this.labelMutationValue.Name = "labelMutationValue";
            this.labelMutationValue.Size = new System.Drawing.Size(213, 20);
            this.labelMutationValue.TabIndex = 20;
            this.labelMutationValue.Text = "Współczynnik mutacji (0.0-1.0):";
            // 
            // labelCrossValue
            // 
            this.labelCrossValue.AutoSize = true;
            this.labelCrossValue.Location = new System.Drawing.Point(430, 244);
            this.labelCrossValue.Name = "labelCrossValue";
            this.labelCrossValue.Size = new System.Drawing.Size(245, 20);
            this.labelCrossValue.TabIndex = 21;
            this.labelCrossValue.Text = "Współczynnik krzyżowania (0.0-1.0):";
            // 
            // comboBoxCrossMethod
            // 
            this.comboBoxCrossMethod.FormattingEnabled = true;
            this.comboBoxCrossMethod.Items.AddRange(new object[] {
            "PMX",
            "OX"});
            this.comboBoxCrossMethod.Location = new System.Drawing.Point(312, 241);
            this.comboBoxCrossMethod.Name = "comboBoxCrossMethod";
            this.comboBoxCrossMethod.Size = new System.Drawing.Size(98, 28);
            this.comboBoxCrossMethod.TabIndex = 22;
            // 
            // labelMutationMethod
            // 
            this.labelMutationMethod.AutoSize = true;
            this.labelMutationMethod.Location = new System.Drawing.Point(56, 244);
            this.labelMutationMethod.Name = "labelMutationMethod";
            this.labelMutationMethod.Size = new System.Drawing.Size(207, 20);
            this.labelMutationMethod.TabIndex = 23;
            this.labelMutationMethod.Text = "Wybierz metodę krzyżowania:";
            // 
            // textBoxMutationValue
            // 
            this.textBoxMutationValue.Location = new System.Drawing.Point(676, 195);
            this.textBoxMutationValue.Name = "textBoxMutationValue";
            this.textBoxMutationValue.Size = new System.Drawing.Size(95, 27);
            this.textBoxMutationValue.TabIndex = 24;
            // 
            // textBoxCrossValue
            // 
            this.textBoxCrossValue.Location = new System.Drawing.Point(676, 241);
            this.textBoxCrossValue.Name = "textBoxCrossValue";
            this.textBoxCrossValue.Size = new System.Drawing.Size(95, 27);
            this.textBoxCrossValue.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.textBoxCrossValue);
            this.Controls.Add(this.textBoxMutationValue);
            this.Controls.Add(this.labelMutationMethod);
            this.Controls.Add(this.comboBoxCrossMethod);
            this.Controls.Add(this.labelCrossValue);
            this.Controls.Add(this.labelMutationValue);
            this.Controls.Add(this.textBoxPopulationSize);
            this.Controls.Add(this.labelPopulationSize);
            this.Controls.Add(this.labelAlgorithmWorking);
            this.Controls.Add(this.checkBoxDiversyfication);
            this.Controls.Add(this.neighbourComboBox);
            this.Controls.Add(this.neighbourLabel);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.readRawButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.trackBarExecuteTimes);
            this.Name = "Form1";
            this.Text = "PEA_TSP";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarExecuteTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarExecuteTimes;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button readRawButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label neighbourLabel;
        private System.Windows.Forms.ComboBox neighbourComboBox;
        private System.Windows.Forms.CheckBox checkBoxDiversyfication;
        private System.Windows.Forms.Label labelAlgorithmWorking;
        private System.Windows.Forms.Label labelPopulationSize;
        private System.Windows.Forms.TextBox textBoxPopulationSize;
        private System.Windows.Forms.Label labelMutationValue;
        private System.Windows.Forms.Label labelCrossValue;
        private System.Windows.Forms.ComboBox comboBoxCrossMethod;
        private System.Windows.Forms.Label labelMutationMethod;
        private System.Windows.Forms.TextBox textBoxMutationValue;
        private System.Windows.Forms.TextBox textBoxCrossValue;
    }
}

