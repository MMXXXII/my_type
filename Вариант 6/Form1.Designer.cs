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
            txtResult = new TextBox();
            cmbOperation = new ComboBox();
            comboBox1 = new ComboBox();
            txtSecond = new TextBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox3 = new ComboBox();
            SuspendLayout();
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(169, 29);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(170, 27);
            txtFirst.TabIndex = 0;
            txtFirst.TextChanged += txtFirst_TextChanged;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(160, 201);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(327, 27);
            txtResult.TabIndex = 2;
            // 
            // cmbOperation
            // 
            cmbOperation.Anchor = AnchorStyles.None;
            cmbOperation.FormattingEnabled = true;
            cmbOperation.Items.AddRange(new object[] { "Сложение", "Вычитание", "Умножение", "Сравнение" });
            cmbOperation.Location = new Point(269, 148);
            cmbOperation.Name = "cmbOperation";
            cmbOperation.Size = new Size(138, 28);
            cmbOperation.TabIndex = 3;
            cmbOperation.Text = "Сложение";
            cmbOperation.SelectedIndexChanged += cmbOperation_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Двоичная", "Восьмиричная", "Десятичная", "Шеснадцатиричная" });
            comboBox1.Location = new Point(398, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Двоичная";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(169, 91);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(170, 27);
            txtSecond.TabIndex = 5;
            txtSecond.TextChanged += txtSecond_TextChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Двоичная", "Восьмиричная", "Десятичная", "Шеснадцатиричная" });
            comboBox2.Location = new Point(398, 91);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 6;
            comboBox2.Text = "Двоичная";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 32);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 7;
            label1.Text = "Первое число: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 98);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 8;
            label2.Text = "Второе число: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 204);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 9;
            label3.Text = "Результат:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Двоичная", "Восьмиричная", "Десятичная", "Шеснадцатиричная" });
            comboBox3.Location = new Point(516, 201);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 10;
            comboBox3.Text = "Двоичная";
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 264);
            Controls.Add(comboBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(txtSecond);
            Controls.Add(comboBox1);
            Controls.Add(cmbOperation);
            Controls.Add(txtResult);
            Controls.Add(txtFirst);
            Name = "Form1";
            Text = "Рассчеты числа с разными системами счисления";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirst;
        private TextBox txtResult;
        private ComboBox cmbOperation;
        private ComboBox comboBox1;
        private TextBox txtSecond;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox3;
    }
}
