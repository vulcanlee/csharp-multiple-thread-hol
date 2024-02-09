namespace MH04
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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(119, 53);
            label1.Name = "label1";
            label1.Size = new Size(135, 50);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.ForeColor = Color.Coral;
            label2.Location = new Point(119, 334);
            label2.Name = "label2";
            label2.Size = new Size(109, 41);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // button1
            // 
            button1.Location = new Point(119, 271);
            button1.Name = "button1";
            button1.Size = new Size(211, 34);
            button1.TabIndex = 2;
            button1.Text = "呼叫 Web API";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 3;
            textBox1.Text = "8";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(119, 175);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 30);
            textBox2.TabIndex = 4;
            textBox2.Text = "9";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(119, 222);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 30);
            textBox3.TabIndex = 5;
            textBox3.Text = "3000";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 439);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            MouseMove += Form1_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
