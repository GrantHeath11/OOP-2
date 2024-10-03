namespace Finished_ICE_Week5
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
            comboBoxFirstValue = new ComboBox();
            comboBoxSecondValue = new ComboBox();
            labelOutput = new Label();
            SuspendLayout();
            // 
            // comboBoxFirstValue
            // 
            comboBoxFirstValue.FormattingEnabled = true;
            comboBoxFirstValue.Location = new Point(312, 92);
            comboBoxFirstValue.Name = "comboBoxFirstValue";
            comboBoxFirstValue.Size = new Size(182, 33);
            comboBoxFirstValue.TabIndex = 0;
            comboBoxFirstValue.SelectedIndexChanged += comboBoxFirstValue_SelectedIndexChanged;
            // 
            // comboBoxSecondValue
            // 
            comboBoxSecondValue.FormattingEnabled = true;
            comboBoxSecondValue.Location = new Point(309, 209);
            comboBoxSecondValue.Name = "comboBoxSecondValue";
            comboBoxSecondValue.Size = new Size(182, 33);
            comboBoxSecondValue.TabIndex = 1;
            comboBoxSecondValue.SelectedIndexChanged += comboBoxSecondValue_SelectedIndexChanged_1;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(374, 273);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(69, 25);
            labelOutput.TabIndex = 2;
            labelOutput.Text = "Output";
            labelOutput.Click += labelOutput_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelOutput);
            Controls.Add(comboBoxSecondValue);
            Controls.Add(comboBoxFirstValue);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxFirstValue;
        private ComboBox comboBoxSecondValue;
        private Label labelOutput;
    }
}
