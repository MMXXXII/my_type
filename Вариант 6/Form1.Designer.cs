namespace Вариант_6
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
            txtFirst = new TextBox();
            txtSecond = new TextBox();
            txtResult = new TextBox();
            cmbOperation = new ComboBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(90, 44);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(125, 27);
            txtFirst.TabIndex = 0;
            txtFirst.TextChanged += txtFirst_TextChanged;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(266, 44);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(125, 27);
            txtSecond.TabIndex = 1;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(90, 252);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(327, 27);
            txtResult.TabIndex = 2;
            // 
            // cmbOperation
            // 
            cmbOperation.FormattingEnabled = true;
            cmbOperation.Items.AddRange(new object[] { "Сложение", "Вычитание", "Умножение", "Сравнение", "Вывод значения в любой СС" });
            cmbOperation.Location = new Point(90, 99);
            cmbOperation.Name = "cmbOperation";
            cmbOperation.Size = new Size(100, 28);
            cmbOperation.TabIndex = 3;
            cmbOperation.Text = "Сложение";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Двоичная", "Восьмиричная", "Десятичная", "Шеснадцатиричная" });
            comboBox1.Location = new Point(90, 154);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Двоичная";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(cmbOperation);
            Controls.Add(txtResult);
            Controls.Add(txtSecond);
            Controls.Add(txtFirst);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirst;
        private TextBox txtSecond;
        private TextBox txtResult;
        private ComboBox cmbOperation;
        private ComboBox comboBox1;
    }
}
