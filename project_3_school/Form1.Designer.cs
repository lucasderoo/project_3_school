namespace project_3_school
{
    partial class project_3
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
            this.side_bar = new System.Windows.Forms.PictureBox();
            this.top_bar = new System.Windows.Forms.PictureBox();
            this.question_1 = new System.Windows.Forms.Button();
            this.question_2 = new System.Windows.Forms.Button();
            this.question_3 = new System.Windows.Forms.Button();
            this.menu_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.side_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // side_bar
            // 
            this.side_bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.side_bar.Location = new System.Drawing.Point(0, -1);
            this.side_bar.Name = "side_bar";
            this.side_bar.Size = new System.Drawing.Size(144, 614);
            this.side_bar.TabIndex = 0;
            this.side_bar.TabStop = false;
            // 
            // top_bar
            // 
            this.top_bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.top_bar.Location = new System.Drawing.Point(138, -1);
            this.top_bar.Name = "top_bar";
            this.top_bar.Size = new System.Drawing.Size(921, 58);
            this.top_bar.TabIndex = 1;
            this.top_bar.TabStop = false;
            // 
            // question_1
            // 
            this.question_1.BackColor = System.Drawing.Color.White;
            this.question_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question_1.Location = new System.Drawing.Point(12, 71);
            this.question_1.Name = "question_1";
            this.question_1.Size = new System.Drawing.Size(123, 41);
            this.question_1.TabIndex = 2;
            this.question_1.Text = "onderzoeksvraag 1";
            this.question_1.UseVisualStyleBackColor = false;
            this.question_1.Click += new System.EventHandler(this.question_1_Click);
            // 
            // question_2
            // 
            this.question_2.BackColor = System.Drawing.Color.White;
            this.question_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question_2.Location = new System.Drawing.Point(12, 129);
            this.question_2.Name = "question_2";
            this.question_2.Size = new System.Drawing.Size(123, 41);
            this.question_2.TabIndex = 3;
            this.question_2.Text = "onderzoeksvraag 2";
            this.question_2.UseVisualStyleBackColor = false;
            this.question_2.Click += new System.EventHandler(this.question_2_Click);
            // 
            // question_3
            // 
            this.question_3.BackColor = System.Drawing.Color.White;
            this.question_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question_3.Location = new System.Drawing.Point(12, 189);
            this.question_3.Name = "question_3";
            this.question_3.Size = new System.Drawing.Size(123, 41);
            this.question_3.TabIndex = 4;
            this.question_3.Text = "onderzoeksvraag 3";
            this.question_3.UseVisualStyleBackColor = false;
            this.question_3.Click += new System.EventHandler(this.question_3_Click);
            // 
            // menu_text
            // 
            this.menu_text.AutoSize = true;
            this.menu_text.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menu_text.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.menu_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_text.ForeColor = System.Drawing.Color.White;
            this.menu_text.Location = new System.Drawing.Point(24, 9);
            this.menu_text.Name = "menu_text";
            this.menu_text.Size = new System.Drawing.Size(96, 37);
            this.menu_text.TabIndex = 18;
            this.menu_text.Text = "Menu";
            // 
            // project_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(1054, 612);
            this.Controls.Add(this.menu_text);
            this.Controls.Add(this.question_3);
            this.Controls.Add(this.question_2);
            this.Controls.Add(this.question_1);
            this.Controls.Add(this.top_bar);
            this.Controls.Add(this.side_bar);
            this.Name = "project_3";
            this.Text = "project 3";
            ((System.ComponentModel.ISupportInitialize)(this.side_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox side_bar;
        private System.Windows.Forms.PictureBox top_bar;
        private System.Windows.Forms.Button question_1;
        private System.Windows.Forms.Button question_2;
        private System.Windows.Forms.Button question_3;
        private System.Windows.Forms.Label menu_text;
    }
}

