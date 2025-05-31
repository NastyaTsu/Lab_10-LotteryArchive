namespace LotteryArchive
{
    partial class CozdatLottery
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            button1 = new Button();
            label5 = new Label();
            numericUpDown4 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(196, 20);
            label1.TabIndex = 0;
            label1.Text = "Введите название лотереи";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(230, 20);
            label2.TabIndex = 2;
            label2.Text = "Введите количество участников";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 94);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(230, 27);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 133);
            label3.Name = "label3";
            label3.Size = new Size(209, 20);
            label3.TabIndex = 4;
            label3.Text = "Введите количество билетов";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(12, 156);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(209, 27);
            numericUpDown2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 198);
            label4.Name = "label4";
            label4.Size = new Size(178, 20);
            label4.TabIndex = 6;
            label4.Text = "Введите призовой фонд";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(12, 221);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(178, 27);
            numericUpDown3.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(78, 335);
            button1.Name = "button1";
            button1.Size = new Size(154, 65);
            button1.TabIndex = 8;
            button1.Text = "Создать лотерею";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 262);
            label5.Name = "label5";
            label5.Size = new Size(151, 20);
            label5.TabIndex = 9;
            label5.Text = "Цена одного билета";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(12, 285);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(151, 27);
            numericUpDown4.TabIndex = 10;
            // 
            // CozdatLottery
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(332, 403);
            Controls.Add(numericUpDown4);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(numericUpDown3);
            Controls.Add(label4);
            Controls.Add(numericUpDown2);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "CozdatLottery";
            Text = "CozdatLottery";
            Load += CozdatLottery_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private Button button1;
        private Label label5;
        private NumericUpDown numericUpDown4;
    }
}