namespace Andre_BrandaoTeodoro_Sec003_Exercise03
{
    partial class AsynchronousProgamming
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(164, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(287, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Calculate Factorial(46) Fibonacci(46) and roll dice(6000000)";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(13, 30);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(569, 23);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Start";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(12, 60);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(570, 320);
            this.resultTextBox.TabIndex = 2;
            // 
            // AsynchronousProgamming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 392);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "AsynchronousProgamming";
            this.Text = "Ex03 - Asynchronous Programming";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

