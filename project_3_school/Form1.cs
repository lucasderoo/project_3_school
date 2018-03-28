﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_3_school
{
    public partial class project_3 : Form
    {

        public project_3()
        {
            InitializeComponent();
        }


        public SqlConnection create_conn(string pcname)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=" + pcname + "\\SQLEXPRESS;Initial Catalog=full_db_prj_3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myConnection.Open();

            return myConnection;
        }

        public List<int> get_days_in_month()
        {
            return new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }

        public List<Button> ov_1_get_buttons()
        {
            var ov_2_buttons = new List<Button> { ov_1_fullchart_button, ov_1_co2_chart_button };
            return ov_2_buttons;
        }

        public List<string> get_month_names()
        {
            return new List<string> { "jan", "feb", "mrt", "apr", "jun", "mei", "jul", "aug", "sept", "okt", "nov", "dec" };
        }

        public List<Button> ov_2_get_buttons()
        {
            var ov_2_buttons = new List<Button> {};
            return ov_2_buttons;
        }

        public List<Button> ov_3_get_buttons()
        {
            var ov_2_buttons = new List<Button> { };
            return ov_2_buttons;

        }

        public void empty_chart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
        }

        public void hide_ov_1()
        {
            List<Button> ov_1_buttons = ov_1_get_buttons();
            foreach (var button in ov_1_buttons)
            {
                button.Visible = false;
            }

            this.ov_1_mainchart.Visible = false;
            this.ov_1_maintb.Visible = false;
            this.ov_1_checkbox_benzin.Visible = false;
            this.ov_1_checkbox_diesel.Visible = false;
            this.ov_1_checkbox_electric.Visible = false;
            this.ov_1_selected_year_label.Visible = false;
        }

        public void hide_ov_2()
        {
            List<Button> ov_2_buttons = ov_2_get_buttons();
            foreach (var button in ov_2_buttons)
            {
                button.Visible = false;
            }
        }

        public void hide_ov_3()
        {
            List<Button> ov_3_buttons = ov_3_get_buttons();
            foreach (var button in ov_3_buttons)
            {
                button.Visible = false;
            }

        }
        public void show_ov_1()
        {
            hide_ov_2(); // hide other questions
            hide_ov_3(); // hide other questions
            this.ov_1_selected_year_label.Visible = true;

            List<Button> ov_1_buttons = ov_1_get_buttons();
            foreach (var button in ov_1_buttons)
            {
                button.Visible = true;
            }

            this.ov_1_mainchart.Visible = true;
            this.ov_1_maintb.Visible = true;
            this.ov_1_checkbox_benzin.Visible = true;
            this.ov_1_checkbox_diesel.Visible = true;
            this.ov_1_checkbox_electric.Visible = true;        
        }

        public void show_ov_2()
        {
            hide_ov_1(); // hide other questions
            hide_ov_3(); // hide other questions

            List<Button> ov_2_buttons = ov_2_get_buttons();
            foreach (var button in ov_2_buttons)
            {
                button.Visible = true;
            }

        }
        
        public void show_ov_3()
        {
            hide_ov_1(); // hide other questions
            hide_ov_2(); // hide other questions

            List<Button> ov_3_buttons = ov_3_get_buttons();
            foreach (var button in ov_3_buttons)
            {
                button.Visible = true;
            }
        }

        public void ov_1_main_chart()
        {
            empty_chart(this.ov_1_mainchart);
            SqlConnection con = create_conn("PC-COEN");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            for (int i = 2007; i <= 2016; i++)
            {
                cmd.CommandText = "SELECT SUM(CAST(quantity_electric as int) + CAST(quantity_hybrid as int)) FROM cars_by_month_nor  WHERE year = '" + i.ToString() + "'";
                Int32 result1 = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT SUM(CAST(quantity_diesel as int)) FROM cars_by_month_nor  WHERE year = '" + i.ToString() + "'";
                Int32 result2 = (Int32)cmd.ExecuteScalar();


                cmd.CommandText = "SELECT SUM(CAST(quantity as int) - CAST(quantity_hybrid as int) - CAST(quantity_electric as int) - CAST(quantity_diesel as int)) FROM cars_by_month_nor WHERE year = '" + i.ToString() + "'";
                Int32 result3 = (Int32)cmd.ExecuteScalar();

                this.ov_1_mainchart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                this.ov_1_mainchart.Series["Elektrisch/hybride"].Points.AddXY(i.ToString(), result1);
                this.ov_1_mainchart.Series["Diesel"].Points.AddXY(i.ToString(), result2);
                this.ov_1_mainchart.Series["Benzine"].Points.AddXY(i.ToString(), result3);

            }
            con.Close();
            ov_1_selected_year_label.Text = "2007-2016";
            this.ov_1_mainchart.Titles["JaarTitel"].Text = "2007-2016";
        }

        public void ov_1_full_co2_chart()
        {
            empty_chart(this.ov_1_mainchart);
            SqlConnection con = create_conn("PC-COEN");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            for (int i = 2007; i <= 2016; i++)
            {
                cmd.CommandText = "SELECT SUM(CAST(bensin_co2 as int)) FROM cars_by_month_nor  WHERE year = '" + i.ToString() + "'";
                Int32 result1 = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT SUM(CAST(diesel_co2 as int)) FROM cars_by_month_nor  WHERE year = '" + i.ToString() + "'";
                Int32 result2 = (Int32)cmd.ExecuteScalar();

                this.ov_1_mainchart.Series["Co2_benzine"].Points.AddXY(i.ToString(), result1);
                this.ov_1_mainchart.Series["Co2_diesel"].Points.AddXY(i.ToString(), result2);

            }
            con.Close();
            ov_1_selected_year_label.Text = "2007-2016";
            this.ov_1_mainchart.Titles["JaarTitel"].Text = "2007-2016";          
        }
        
        void clear_ov_button_colors()
        {
            this.question_1.BackColor = System.Drawing.Color.White;
            this.question_2.BackColor = System.Drawing.Color.White;
            this.question_3.BackColor = System.Drawing.Color.White;
        }
        private void question_1_Click(object sender, EventArgs e)
        {
            clear_ov_button_colors();
            this.question_1.BackColor = System.Drawing.Color.Yellow;
            show_ov_1();
        }

        private void question_2_Click(object sender, EventArgs e)
        {
            clear_ov_button_colors();
            this.question_2.BackColor = System.Drawing.Color.Yellow;
            show_ov_2();
        }

        private void question_3_Click(object sender, EventArgs e)
        {
            clear_ov_button_colors();
            this.question_3.BackColor = System.Drawing.Color.Yellow;
            show_ov_3();
        }

        private void ov_1_maintb_Scroll(object sender, EventArgs e)
        {
            SqlConnection con = create_conn("PC-COEN");
            empty_chart(this.ov_1_mainchart);
            this.ov_1_mainchart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            this.ov_1_mainchart.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "SELECT SUM(CAST(quantity_electric as int) + CAST(quantity_hybrid as int)) FROM cars_by_month_nor  WHERE year = '" + ov_1_maintb.Value + "'";
            Int32 result1 = (Int32)cmd.ExecuteScalar();

            cmd.CommandText = "SELECT SUM(CAST(quantity_diesel as int)) FROM cars_by_month_nor  WHERE year = '" + ov_1_maintb.Value + "'";
            Int32 result2 = (Int32)cmd.ExecuteScalar();


            cmd.CommandText = "SELECT SUM(CAST(quantity as int) - CAST(quantity_hybrid as int) - CAST(quantity_electric as int) - CAST(quantity_diesel as int)) FROM cars_by_month_nor  WHERE year = '" + ov_1_maintb.Value + "'";
            Int32 result3 = (Int32)cmd.ExecuteScalar();

            this.ov_1_mainchart.Series["Elektrisch/hybride"].Points.AddXY(ov_1_maintb.Value.ToString(), result1);
            this.ov_1_mainchart.Series["Diesel"].Points.AddXY(ov_1_maintb.Value.ToString(), result2);
            this.ov_1_mainchart.Series["Benzine"].Points.AddXY(ov_1_maintb.Value.ToString(), result3);
            this.ov_1_mainchart.Series["Top 1"].Points.AddXY(ov_1_maintb.Value.ToString(), 0);
            this.ov_1_mainchart.Series["Top 2"].Points.AddXY(ov_1_maintb.Value.ToString(), 0);
            this.ov_1_mainchart.Series["Top 3"].Points.AddXY(ov_1_maintb.Value.ToString(), 0);

            cmd.CommandText = "SELECT TOP 3 [make], SUM([quantity]) as quantity FROM cars_by_make_nor  WHERE year = '" + ov_1_maintb.Value + "' GROUP BY[make] ORDER BY SUM([quantity]) DESC";
            SqlDataReader result4 = cmd.ExecuteReader();
            int s = 0;
            List<int> myValues = new List<int>(new int[] { 1, 2, 3 });

            while (result4.Read())
            {
                s = s + 1;
                this.ov_1_mainchart.Series["Top " + s].Points.AddXY(result4.GetValue(0), result4.GetValue(1));
                foreach (var val in myValues)
                {
                    if (val != s)
                    {
                        this.ov_1_mainchart.Series["Top " + val].Points.AddXY(result4.GetValue(0), 0);
                    }
                }
            }
            ov_1_selected_year_label.Text = ov_1_maintb.Value.ToString();
            this.ov_1_mainchart.Titles["JaarTitel"].Text = ov_1_maintb.Value.ToString();
        }

        private void ov_1_fullchart_button_Click(object sender, EventArgs e)
        {
            ov_1_main_chart();
        }

        private void ov_1_co2_chart_button_Click(object sender, EventArgs e)
        {
            ov_1_full_co2_chart();
        }

        private void ov_1_checkbox_electric_CheckedChanged(object sender, EventArgs e)
        {
            if (ov_1_checkbox_electric.Checked)
            {
                this.ov_1_mainchart.Series["Elektrisch/hybride"].Color = Color.DodgerBlue;
            }
            else
            {
                this.ov_1_mainchart.Series["Elektrisch/hybride"].Color = Color.Transparent;
            }

        }

        private void ov_1_checkbox_diesel_CheckedChanged(object sender, EventArgs e)
        {
            if (ov_1_checkbox_diesel.Checked)
            {
                this.ov_1_mainchart.Series["Diesel"].Color = Color.OrangeRed;
            }
            else
            {
                this.ov_1_mainchart.Series["Diesel"].Color = Color.Transparent;
            }
        }

        private void ov_1_checkbox_benzin_CheckedChanged(object sender, EventArgs e)
        {
            if (ov_1_checkbox_benzin.Checked)
            {
                this.ov_1_mainchart.Series["Benzine"].Color = Color.Orange;
            }
            else
            {
                this.ov_1_mainchart.Series["Benzine"].Color = Color.Transparent;
            }
        }
    }
}
