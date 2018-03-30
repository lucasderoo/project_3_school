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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menu_text = new System.Windows.Forms.Label();
            this.question_1 = new System.Windows.Forms.Button();
            this.question_2 = new System.Windows.Forms.Button();
            this.question_3 = new System.Windows.Forms.Button();
            this.button_top5 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.top_bar = new System.Windows.Forms.PictureBox();
            this.side_bar = new System.Windows.Forms.PictureBox();
            this.checkBox2012_2 = new System.Windows.Forms.CheckBox();
            this.checkBox2013_2 = new System.Windows.Forms.CheckBox();
            this.checkBox2015_2 = new System.Windows.Forms.CheckBox();
            this.checkBox2014_2 = new System.Windows.Forms.CheckBox();
            this.checkBox2017_2 = new System.Windows.Forms.CheckBox();
            this.checkBox2016_2 = new System.Windows.Forms.CheckBox();
            this.checkBox2012_2017 = new System.Windows.Forms.CheckBox();
            this.checkBox2017_1 = new System.Windows.Forms.CheckBox();
            this.checkBox2016_1 = new System.Windows.Forms.CheckBox();
            this.checkBox2015_1 = new System.Windows.Forms.CheckBox();
            this.checkBox2014_1 = new System.Windows.Forms.CheckBox();
            this.checkBox2013_1 = new System.Windows.Forms.CheckBox();
            this.checkBox2012_1 = new System.Windows.Forms.CheckBox();
            this.button_load_chart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button_show_cars = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.side_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
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
            this.menu_text.TabIndex = 19;
            this.menu_text.Text = "Menu";
            // 
            // question_1
            // 
            this.question_1.BackColor = System.Drawing.Color.White;
            this.question_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question_1.Location = new System.Drawing.Point(12, 71);
            this.question_1.Name = "question_1";
            this.question_1.Size = new System.Drawing.Size(123, 41);
            this.question_1.TabIndex = 20;
            this.question_1.Text = "onderzoeksvraag 1";
            this.question_1.UseVisualStyleBackColor = false;
            // 
            // question_2
            // 
            this.question_2.BackColor = System.Drawing.Color.White;
            this.question_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question_2.Location = new System.Drawing.Point(12, 129);
            this.question_2.Name = "question_2";
            this.question_2.Size = new System.Drawing.Size(123, 41);
            this.question_2.TabIndex = 21;
            this.question_2.Text = "onderzoeksvraag 2";
            this.question_2.UseVisualStyleBackColor = false;
            // 
            // question_3
            // 
            this.question_3.BackColor = System.Drawing.Color.White;
            this.question_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.question_3.Location = new System.Drawing.Point(12, 189);
            this.question_3.Name = "question_3";
            this.question_3.Size = new System.Drawing.Size(123, 41);
            this.question_3.TabIndex = 22;
            this.question_3.Text = "onderzoeksvraag 3";
            this.question_3.UseVisualStyleBackColor = false;
            this.question_3.Click += new System.EventHandler(this.question_3_Click);
            // 
            // button_top5
            // 
            this.button_top5.BackColor = System.Drawing.Color.White;
            this.button_top5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_top5.Location = new System.Drawing.Point(150, 565);
            this.button_top5.Name = "button_top5";
            this.button_top5.Size = new System.Drawing.Size(112, 35);
            this.button_top5.TabIndex = 23;
            this.button_top5.Text = "Top 5";
            this.button_top5.UseVisualStyleBackColor = false;
            this.button_top5.Visible = false;
            this.button_top5.Click += new System.EventHandler(this.button_top5_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(371, 71);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Gemiddelde verkoopprijs";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Ontwikkeling gemiddelde verkoopprijs";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(671, 413);
            this.chart1.TabIndex = 24;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // top_bar
            // 
            this.top_bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.top_bar.Location = new System.Drawing.Point(138, -1);
            this.top_bar.Name = "top_bar";
            this.top_bar.Size = new System.Drawing.Size(921, 58);
            this.top_bar.TabIndex = 2;
            this.top_bar.TabStop = false;
            // 
            // side_bar
            // 
            this.side_bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.side_bar.Location = new System.Drawing.Point(0, -1);
            this.side_bar.Name = "side_bar";
            this.side_bar.Size = new System.Drawing.Size(144, 614);
            this.side_bar.TabIndex = 1;
            this.side_bar.TabStop = false;
            // 
            // checkBox2012_2
            // 
            this.checkBox2012_2.AutoSize = true;
            this.checkBox2012_2.Location = new System.Drawing.Point(169, 95);
            this.checkBox2012_2.Name = "checkBox2012_2";
            this.checkBox2012_2.Size = new System.Drawing.Size(50, 17);
            this.checkBox2012_2.TabIndex = 25;
            this.checkBox2012_2.Text = "2012";
            this.checkBox2012_2.UseVisualStyleBackColor = true;
            this.checkBox2012_2.Visible = false;
            this.checkBox2012_2.CheckedChanged += new System.EventHandler(this.checkBox2012_2_CheckedChanged);
            // 
            // checkBox2013_2
            // 
            this.checkBox2013_2.AutoSize = true;
            this.checkBox2013_2.Location = new System.Drawing.Point(169, 125);
            this.checkBox2013_2.Name = "checkBox2013_2";
            this.checkBox2013_2.Size = new System.Drawing.Size(50, 17);
            this.checkBox2013_2.TabIndex = 26;
            this.checkBox2013_2.Text = "2013";
            this.checkBox2013_2.UseVisualStyleBackColor = true;
            this.checkBox2013_2.Visible = false;
            this.checkBox2013_2.CheckedChanged += new System.EventHandler(this.checkBox2013_2_CheckedChanged);
            // 
            // checkBox2015_2
            // 
            this.checkBox2015_2.AutoSize = true;
            this.checkBox2015_2.Location = new System.Drawing.Point(169, 185);
            this.checkBox2015_2.Name = "checkBox2015_2";
            this.checkBox2015_2.Size = new System.Drawing.Size(50, 17);
            this.checkBox2015_2.TabIndex = 28;
            this.checkBox2015_2.Text = "2015";
            this.checkBox2015_2.UseVisualStyleBackColor = true;
            this.checkBox2015_2.Visible = false;
            this.checkBox2015_2.CheckedChanged += new System.EventHandler(this.checkBox2015_2_CheckedChanged);
            // 
            // checkBox2014_2
            // 
            this.checkBox2014_2.AutoSize = true;
            this.checkBox2014_2.Location = new System.Drawing.Point(169, 155);
            this.checkBox2014_2.Name = "checkBox2014_2";
            this.checkBox2014_2.Size = new System.Drawing.Size(50, 17);
            this.checkBox2014_2.TabIndex = 27;
            this.checkBox2014_2.Text = "2014";
            this.checkBox2014_2.UseVisualStyleBackColor = true;
            this.checkBox2014_2.Visible = false;
            this.checkBox2014_2.CheckedChanged += new System.EventHandler(this.checkBox2014_2_CheckedChanged);
            // 
            // checkBox2017_2
            // 
            this.checkBox2017_2.AutoSize = true;
            this.checkBox2017_2.Location = new System.Drawing.Point(169, 245);
            this.checkBox2017_2.Name = "checkBox2017_2";
            this.checkBox2017_2.Size = new System.Drawing.Size(50, 17);
            this.checkBox2017_2.TabIndex = 30;
            this.checkBox2017_2.Text = "2017";
            this.checkBox2017_2.UseVisualStyleBackColor = true;
            this.checkBox2017_2.Visible = false;
            this.checkBox2017_2.CheckedChanged += new System.EventHandler(this.checkBox2017_2_CheckedChanged);
            // 
            // checkBox2016_2
            // 
            this.checkBox2016_2.AutoSize = true;
            this.checkBox2016_2.Location = new System.Drawing.Point(169, 215);
            this.checkBox2016_2.Name = "checkBox2016_2";
            this.checkBox2016_2.Size = new System.Drawing.Size(50, 17);
            this.checkBox2016_2.TabIndex = 29;
            this.checkBox2016_2.Text = "2016";
            this.checkBox2016_2.UseVisualStyleBackColor = true;
            this.checkBox2016_2.Visible = false;
            this.checkBox2016_2.CheckedChanged += new System.EventHandler(this.checkBox2016_2_CheckedChanged);
            // 
            // checkBox2012_2017
            // 
            this.checkBox2012_2017.AutoSize = true;
            this.checkBox2012_2017.Location = new System.Drawing.Point(169, 275);
            this.checkBox2012_2017.Name = "checkBox2012_2017";
            this.checkBox2012_2017.Size = new System.Drawing.Size(83, 17);
            this.checkBox2012_2017.TabIndex = 31;
            this.checkBox2012_2017.Text = "2012 - 2017";
            this.checkBox2012_2017.UseVisualStyleBackColor = true;
            this.checkBox2012_2017.Visible = false;
            this.checkBox2012_2017.CheckedChanged += new System.EventHandler(this.checkBox2012_2017_CheckedChanged);
            // 
            // checkBox2017_1
            // 
            this.checkBox2017_1.AutoSize = true;
            this.checkBox2017_1.Checked = true;
            this.checkBox2017_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2017_1.Location = new System.Drawing.Point(293, 234);
            this.checkBox2017_1.Name = "checkBox2017_1";
            this.checkBox2017_1.Size = new System.Drawing.Size(50, 17);
            this.checkBox2017_1.TabIndex = 37;
            this.checkBox2017_1.Text = "2017";
            this.checkBox2017_1.UseVisualStyleBackColor = true;
            this.checkBox2017_1.Visible = false;
            // 
            // checkBox2016_1
            // 
            this.checkBox2016_1.AutoSize = true;
            this.checkBox2016_1.Checked = true;
            this.checkBox2016_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2016_1.Location = new System.Drawing.Point(293, 204);
            this.checkBox2016_1.Name = "checkBox2016_1";
            this.checkBox2016_1.Size = new System.Drawing.Size(50, 17);
            this.checkBox2016_1.TabIndex = 36;
            this.checkBox2016_1.Text = "2016";
            this.checkBox2016_1.UseVisualStyleBackColor = true;
            this.checkBox2016_1.Visible = false;
            // 
            // checkBox2015_1
            // 
            this.checkBox2015_1.AutoSize = true;
            this.checkBox2015_1.Checked = true;
            this.checkBox2015_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2015_1.Location = new System.Drawing.Point(293, 174);
            this.checkBox2015_1.Name = "checkBox2015_1";
            this.checkBox2015_1.Size = new System.Drawing.Size(50, 17);
            this.checkBox2015_1.TabIndex = 35;
            this.checkBox2015_1.Text = "2015";
            this.checkBox2015_1.UseVisualStyleBackColor = true;
            this.checkBox2015_1.Visible = false;
            // 
            // checkBox2014_1
            // 
            this.checkBox2014_1.AutoSize = true;
            this.checkBox2014_1.Checked = true;
            this.checkBox2014_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2014_1.Location = new System.Drawing.Point(293, 144);
            this.checkBox2014_1.Name = "checkBox2014_1";
            this.checkBox2014_1.Size = new System.Drawing.Size(50, 17);
            this.checkBox2014_1.TabIndex = 34;
            this.checkBox2014_1.Text = "2014";
            this.checkBox2014_1.UseVisualStyleBackColor = true;
            this.checkBox2014_1.Visible = false;
            // 
            // checkBox2013_1
            // 
            this.checkBox2013_1.AutoSize = true;
            this.checkBox2013_1.Checked = true;
            this.checkBox2013_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2013_1.Location = new System.Drawing.Point(293, 114);
            this.checkBox2013_1.Name = "checkBox2013_1";
            this.checkBox2013_1.Size = new System.Drawing.Size(50, 17);
            this.checkBox2013_1.TabIndex = 33;
            this.checkBox2013_1.Text = "2013";
            this.checkBox2013_1.UseVisualStyleBackColor = true;
            this.checkBox2013_1.Visible = false;
            // 
            // checkBox2012_1
            // 
            this.checkBox2012_1.AutoSize = true;
            this.checkBox2012_1.Checked = true;
            this.checkBox2012_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2012_1.Location = new System.Drawing.Point(293, 84);
            this.checkBox2012_1.Name = "checkBox2012_1";
            this.checkBox2012_1.Size = new System.Drawing.Size(50, 17);
            this.checkBox2012_1.TabIndex = 32;
            this.checkBox2012_1.Text = "2012";
            this.checkBox2012_1.UseVisualStyleBackColor = true;
            this.checkBox2012_1.Visible = false;
            // 
            // button_load_chart
            // 
            this.button_load_chart.BackColor = System.Drawing.Color.White;
            this.button_load_chart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_load_chart.Location = new System.Drawing.Point(930, 500);
            this.button_load_chart.Name = "button_load_chart";
            this.button_load_chart.Size = new System.Drawing.Size(112, 35);
            this.button_load_chart.TabIndex = 38;
            this.button_load_chart.Text = "Load chart";
            this.button_load_chart.UseVisualStyleBackColor = false;
            this.button_load_chart.Visible = false;
            this.button_load_chart.Click += new System.EventHandler(this.button_load_chart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::project_3_school.Properties.Resources.overzicht;
            this.pictureBox1.Location = new System.Drawing.Point(293, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(749, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::project_3_school.Properties.Resources.overzicht;
            this.pictureBox2.Location = new System.Drawing.Point(293, 320);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(749, 230);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // button_show_cars
            // 
            this.button_show_cars.BackColor = System.Drawing.Color.White;
            this.button_show_cars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_show_cars.Location = new System.Drawing.Point(930, 565);
            this.button_show_cars.Name = "button_show_cars";
            this.button_show_cars.Size = new System.Drawing.Size(112, 35);
            this.button_show_cars.TabIndex = 41;
            this.button_show_cars.Text = "Show cars";
            this.button_show_cars.UseVisualStyleBackColor = false;
            this.button_show_cars.Visible = false;
            this.button_show_cars.Click += new System.EventHandler(this.button_show_cars_Click);
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.White;
            this.button_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back.Location = new System.Drawing.Point(150, 565);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(112, 35);
            this.button_back.TabIndex = 42;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Visible = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // Deelvraag3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(1054, 612);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_show_cars);
            this.Controls.Add(this.button_load_chart);
            this.Controls.Add(this.checkBox2017_1);
            this.Controls.Add(this.checkBox2016_1);
            this.Controls.Add(this.checkBox2015_1);
            this.Controls.Add(this.checkBox2014_1);
            this.Controls.Add(this.checkBox2013_1);
            this.Controls.Add(this.checkBox2012_1);
            this.Controls.Add(this.checkBox2012_2017);
            this.Controls.Add(this.checkBox2017_2);
            this.Controls.Add(this.checkBox2016_2);
            this.Controls.Add(this.checkBox2015_2);
            this.Controls.Add(this.checkBox2014_2);
            this.Controls.Add(this.checkBox2013_2);
            this.Controls.Add(this.checkBox2012_2);
            this.Controls.Add(this.question_3);
            this.Controls.Add(this.question_2);
            this.Controls.Add(this.question_1);
            this.Controls.Add(this.menu_text);
            this.Controls.Add(this.top_bar);
            this.Controls.Add(this.side_bar);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_top5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chart1);
            this.Name = "Project_3";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.side_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox side_bar;
        private System.Windows.Forms.PictureBox top_bar;
        private System.Windows.Forms.Label menu_text;
        private System.Windows.Forms.Button question_1;
        private System.Windows.Forms.Button question_2;
        private System.Windows.Forms.Button question_3;
        private System.Windows.Forms.Button button_top5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkBox2012_2;
        private System.Windows.Forms.CheckBox checkBox2013_2;
        private System.Windows.Forms.CheckBox checkBox2015_2;
        private System.Windows.Forms.CheckBox checkBox2014_2;
        private System.Windows.Forms.CheckBox checkBox2017_2;
        private System.Windows.Forms.CheckBox checkBox2016_2;
        private System.Windows.Forms.CheckBox checkBox2012_2017;
        private System.Windows.Forms.CheckBox checkBox2017_1;
        private System.Windows.Forms.CheckBox checkBox2016_1;
        private System.Windows.Forms.CheckBox checkBox2015_1;
        private System.Windows.Forms.CheckBox checkBox2014_1;
        private System.Windows.Forms.CheckBox checkBox2013_1;
        private System.Windows.Forms.CheckBox checkBox2012_1;
        private System.Windows.Forms.Button button_load_chart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button_show_cars;
        private System.Windows.Forms.Button button_back;
    }
}