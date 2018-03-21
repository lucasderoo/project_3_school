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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.side_bar = new System.Windows.Forms.PictureBox();
            this.top_bar = new System.Windows.Forms.PictureBox();
            this.question_1 = new System.Windows.Forms.Button();
            this.question_2 = new System.Windows.Forms.Button();
            this.question_3 = new System.Windows.Forms.Button();
            this.ov_2_mainchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ov_2_button_2017 = new System.Windows.Forms.Button();
            this.ov_2_button_2016 = new System.Windows.Forms.Button();
            this.ov_2_button_2015 = new System.Windows.Forms.Button();
            this.ov_2_button_2014 = new System.Windows.Forms.Button();
            this.ov_2_button_2013 = new System.Windows.Forms.Button();
            this.ov_2_button_2012 = new System.Windows.Forms.Button();
            this.ov_2_button_2011 = new System.Windows.Forms.Button();
            this.ov_2_button_2010 = new System.Windows.Forms.Button();
            this.ov_2_button_2009 = new System.Windows.Forms.Button();
            this.ov_2_button_2008 = new System.Windows.Forms.Button();
            this.ov_2_button_2007 = new System.Windows.Forms.Button();
            this.ov_2_button_all_years = new System.Windows.Forms.Button();
            this.menu_text = new System.Windows.Forms.Label();
            this.ov_2_chb_elek = new System.Windows.Forms.CheckBox();
            this.ov_2_chk_hybrid = new System.Windows.Forms.CheckBox();
            this.ov_2_chk_diesel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.side_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ov_2_mainchart)).BeginInit();
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
            // ov_2_mainchart
            // 
            chartArea2.Name = "ChartArea1";
            this.ov_2_mainchart.ChartAreas.Add(chartArea2);
            this.ov_2_mainchart.Cursor = System.Windows.Forms.Cursors.Default;
            legend2.Name = "Legend1";
            this.ov_2_mainchart.Legends.Add(legend2);
            this.ov_2_mainchart.Location = new System.Drawing.Point(295, 71);
            this.ov_2_mainchart.Name = "ov_2_mainchart";
            this.ov_2_mainchart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Hybride";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Elektrisch";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Diesel";
            this.ov_2_mainchart.Series.Add(series4);
            this.ov_2_mainchart.Series.Add(series5);
            this.ov_2_mainchart.Series.Add(series6);
            this.ov_2_mainchart.Size = new System.Drawing.Size(747, 363);
            this.ov_2_mainchart.TabIndex = 5;
            this.ov_2_mainchart.Text = "chart1";
            this.ov_2_mainchart.Visible = false;
            // 
            // ov_2_button_2017
            // 
            this.ov_2_button_2017.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2017.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2017.Location = new System.Drawing.Point(167, 71);
            this.ov_2_button_2017.Name = "ov_2_button_2017";
            this.ov_2_button_2017.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2017.TabIndex = 6;
            this.ov_2_button_2017.Text = "2017";
            this.ov_2_button_2017.UseVisualStyleBackColor = false;
            this.ov_2_button_2017.Visible = false;
            this.ov_2_button_2017.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2016
            // 
            this.ov_2_button_2016.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2016.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2016.Location = new System.Drawing.Point(167, 112);
            this.ov_2_button_2016.Name = "ov_2_button_2016";
            this.ov_2_button_2016.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2016.TabIndex = 7;
            this.ov_2_button_2016.Text = "2016";
            this.ov_2_button_2016.UseVisualStyleBackColor = false;
            this.ov_2_button_2016.Visible = false;
            this.ov_2_button_2016.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2015
            // 
            this.ov_2_button_2015.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2015.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2015.Location = new System.Drawing.Point(167, 153);
            this.ov_2_button_2015.Name = "ov_2_button_2015";
            this.ov_2_button_2015.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2015.TabIndex = 8;
            this.ov_2_button_2015.Text = "2015";
            this.ov_2_button_2015.UseVisualStyleBackColor = false;
            this.ov_2_button_2015.Visible = false;
            this.ov_2_button_2015.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2014
            // 
            this.ov_2_button_2014.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2014.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2014.Location = new System.Drawing.Point(167, 194);
            this.ov_2_button_2014.Name = "ov_2_button_2014";
            this.ov_2_button_2014.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2014.TabIndex = 9;
            this.ov_2_button_2014.Text = "2014";
            this.ov_2_button_2014.UseVisualStyleBackColor = false;
            this.ov_2_button_2014.Visible = false;
            this.ov_2_button_2014.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2013
            // 
            this.ov_2_button_2013.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2013.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2013.Location = new System.Drawing.Point(167, 235);
            this.ov_2_button_2013.Name = "ov_2_button_2013";
            this.ov_2_button_2013.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2013.TabIndex = 10;
            this.ov_2_button_2013.Text = "2013";
            this.ov_2_button_2013.UseVisualStyleBackColor = false;
            this.ov_2_button_2013.Visible = false;
            this.ov_2_button_2013.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2012
            // 
            this.ov_2_button_2012.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2012.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2012.Location = new System.Drawing.Point(167, 276);
            this.ov_2_button_2012.Name = "ov_2_button_2012";
            this.ov_2_button_2012.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2012.TabIndex = 11;
            this.ov_2_button_2012.Text = "2012";
            this.ov_2_button_2012.UseVisualStyleBackColor = false;
            this.ov_2_button_2012.Visible = false;
            this.ov_2_button_2012.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2011
            // 
            this.ov_2_button_2011.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2011.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2011.Location = new System.Drawing.Point(167, 317);
            this.ov_2_button_2011.Name = "ov_2_button_2011";
            this.ov_2_button_2011.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2011.TabIndex = 12;
            this.ov_2_button_2011.Text = "2011";
            this.ov_2_button_2011.UseVisualStyleBackColor = false;
            this.ov_2_button_2011.Visible = false;
            this.ov_2_button_2011.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2010
            // 
            this.ov_2_button_2010.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2010.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2010.Location = new System.Drawing.Point(167, 358);
            this.ov_2_button_2010.Name = "ov_2_button_2010";
            this.ov_2_button_2010.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2010.TabIndex = 13;
            this.ov_2_button_2010.Text = "2010";
            this.ov_2_button_2010.UseVisualStyleBackColor = false;
            this.ov_2_button_2010.Visible = false;
            this.ov_2_button_2010.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2009
            // 
            this.ov_2_button_2009.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2009.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2009.Location = new System.Drawing.Point(167, 399);
            this.ov_2_button_2009.Name = "ov_2_button_2009";
            this.ov_2_button_2009.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2009.TabIndex = 14;
            this.ov_2_button_2009.Text = "2009";
            this.ov_2_button_2009.UseVisualStyleBackColor = false;
            this.ov_2_button_2009.Visible = false;
            this.ov_2_button_2009.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2008
            // 
            this.ov_2_button_2008.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2008.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2008.Location = new System.Drawing.Point(167, 440);
            this.ov_2_button_2008.Name = "ov_2_button_2008";
            this.ov_2_button_2008.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2008.TabIndex = 15;
            this.ov_2_button_2008.Text = "2008";
            this.ov_2_button_2008.UseVisualStyleBackColor = false;
            this.ov_2_button_2008.Visible = false;
            this.ov_2_button_2008.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_2007
            // 
            this.ov_2_button_2007.BackColor = System.Drawing.Color.White;
            this.ov_2_button_2007.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_2007.Location = new System.Drawing.Point(167, 481);
            this.ov_2_button_2007.Name = "ov_2_button_2007";
            this.ov_2_button_2007.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_2007.TabIndex = 16;
            this.ov_2_button_2007.Text = "2007";
            this.ov_2_button_2007.UseVisualStyleBackColor = false;
            this.ov_2_button_2007.Visible = false;
            this.ov_2_button_2007.Click += new System.EventHandler(this.year_button_handler);
            // 
            // ov_2_button_all_years
            // 
            this.ov_2_button_all_years.BackColor = System.Drawing.Color.White;
            this.ov_2_button_all_years.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ov_2_button_all_years.Location = new System.Drawing.Point(167, 522);
            this.ov_2_button_all_years.Name = "ov_2_button_all_years";
            this.ov_2_button_all_years.Size = new System.Drawing.Size(112, 35);
            this.ov_2_button_all_years.TabIndex = 17;
            this.ov_2_button_all_years.Text = "volledig overzicht";
            this.ov_2_button_all_years.UseVisualStyleBackColor = false;
            this.ov_2_button_all_years.Visible = false;
            this.ov_2_button_all_years.Click += new System.EventHandler(this.year_button_handler);
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
            // ov_2_chb_elek
            // 
            this.ov_2_chb_elek.Checked = true;
            this.ov_2_chb_elek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ov_2_chb_elek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ov_2_chb_elek.ForeColor = System.Drawing.Color.Black;
            this.ov_2_chb_elek.Location = new System.Drawing.Point(295, 451);
            this.ov_2_chb_elek.Name = "ov_2_chb_elek";
            this.ov_2_chb_elek.Size = new System.Drawing.Size(104, 24);
            this.ov_2_chb_elek.TabIndex = 0;
            this.ov_2_chb_elek.Text = "Elektrisch";
            this.ov_2_chb_elek.Visible = false;
            this.ov_2_chb_elek.CheckedChanged += new System.EventHandler(this.ov_2_chb_elek_CheckedChanged);
            // 
            // ov_2_chk_hybrid
            // 
            this.ov_2_chk_hybrid.Checked = true;
            this.ov_2_chk_hybrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ov_2_chk_hybrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ov_2_chk_hybrid.ForeColor = System.Drawing.Color.Black;
            this.ov_2_chk_hybrid.Location = new System.Drawing.Point(295, 481);
            this.ov_2_chk_hybrid.Name = "ov_2_chk_hybrid";
            this.ov_2_chk_hybrid.Size = new System.Drawing.Size(104, 24);
            this.ov_2_chk_hybrid.TabIndex = 19;
            this.ov_2_chk_hybrid.Text = "Hybride";
            this.ov_2_chk_hybrid.Visible = false;
            this.ov_2_chk_hybrid.CheckedChanged += new System.EventHandler(this.ov_2_chb_elek_CheckedChanged);
            // 
            // ov_2_chk_diesel
            // 
            this.ov_2_chk_diesel.Checked = true;
            this.ov_2_chk_diesel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ov_2_chk_diesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ov_2_chk_diesel.ForeColor = System.Drawing.Color.Black;
            this.ov_2_chk_diesel.Location = new System.Drawing.Point(295, 511);
            this.ov_2_chk_diesel.Name = "ov_2_chk_diesel";
            this.ov_2_chk_diesel.Size = new System.Drawing.Size(104, 24);
            this.ov_2_chk_diesel.TabIndex = 20;
            this.ov_2_chk_diesel.Text = "Diesel";
            this.ov_2_chk_diesel.Visible = false;
            this.ov_2_chk_diesel.CheckedChanged += new System.EventHandler(this.ov_2_chb_elek_CheckedChanged);
            // 
            // project_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(1054, 612);
            this.Controls.Add(this.ov_2_chk_diesel);
            this.Controls.Add(this.ov_2_chk_hybrid);
            this.Controls.Add(this.ov_2_chb_elek);
            this.Controls.Add(this.menu_text);
            this.Controls.Add(this.ov_2_button_all_years);
            this.Controls.Add(this.ov_2_button_2007);
            this.Controls.Add(this.ov_2_button_2008);
            this.Controls.Add(this.ov_2_button_2009);
            this.Controls.Add(this.ov_2_button_2010);
            this.Controls.Add(this.ov_2_button_2011);
            this.Controls.Add(this.ov_2_button_2012);
            this.Controls.Add(this.ov_2_button_2013);
            this.Controls.Add(this.ov_2_button_2014);
            this.Controls.Add(this.ov_2_button_2015);
            this.Controls.Add(this.ov_2_button_2016);
            this.Controls.Add(this.ov_2_button_2017);
            this.Controls.Add(this.ov_2_mainchart);
            this.Controls.Add(this.question_3);
            this.Controls.Add(this.question_2);
            this.Controls.Add(this.question_1);
            this.Controls.Add(this.top_bar);
            this.Controls.Add(this.side_bar);
            this.Name = "project_3";
            this.Text = "project 3";
            ((System.ComponentModel.ISupportInitialize)(this.side_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ov_2_mainchart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox side_bar;
        private System.Windows.Forms.PictureBox top_bar;
        private System.Windows.Forms.Button question_1;
        private System.Windows.Forms.Button question_2;
        private System.Windows.Forms.Button question_3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ov_2_mainchart;
        private System.Windows.Forms.Button ov_2_button_2017;
        private System.Windows.Forms.Button ov_2_button_2016;
        private System.Windows.Forms.Button ov_2_button_2015;
        private System.Windows.Forms.Button ov_2_button_2014;
        private System.Windows.Forms.Button ov_2_button_2013;
        private System.Windows.Forms.Button ov_2_button_2012;
        private System.Windows.Forms.Button ov_2_button_2011;
        private System.Windows.Forms.Button ov_2_button_2010;
        private System.Windows.Forms.Button ov_2_button_2009;
        private System.Windows.Forms.Button ov_2_button_2008;
        private System.Windows.Forms.Button ov_2_button_2007;
        private System.Windows.Forms.Button ov_2_button_all_years;
        private System.Windows.Forms.Label menu_text;
        private System.Windows.Forms.CheckBox ov_2_chb_elek;
        private System.Windows.Forms.CheckBox ov_2_chk_hybrid;
        private System.Windows.Forms.CheckBox ov_2_chk_diesel;
    }
}

