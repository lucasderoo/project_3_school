using System;
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
        int[] alleJaren = new int[] { 2012, 2013, 2014, 2015, 2016, 2017 };
        int[] alleResultaten = new int[6]; // de gemiddelde verkoopprijzen tussen 2012 en 2017 -> wordt gebruikt als coördinaten voor in de grafiek
        int checkBoxCounter = 0; // deze variabele zorgt ervoor dat er maximaal twee checkboxes geselecteerd kunnen worden

        public project_3()
        {
            InitializeComponent();
        }

        public SqlConnection create_conn()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=" + System.Environment.MachineName + "\\SQLEXPRESS;Initial Catalog=project_3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            var ov_2_buttons = new List<Button> { ov_2_button_2007, ov_2_button_2008, ov_2_button_2009, ov_2_button_2010, ov_2_button_2011, ov_2_button_2012, ov_2_button_2013, ov_2_button_2007, ov_2_button_2014, ov_2_button_2015, ov_2_button_2016, ov_2_button_2017, ov_2_button_all_years };
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

            this.ov_2_mainchart.Visible = false;
            this.ov_2_chb_elek.Visible = false;
            this.ov_2_chk_hybrid.Visible = false;
            this.ov_2_chk_diesel.Visible = false;
            this.ov_2_price_filter.Visible = false;
            this.ov_2_trackbar1_value.Visible = false;
            this.ov_2_trackbar2_value.Visible = false;
            this.ov_2_catalogus_bar1.Visible = false;
            this.ov_2_catalogus_bar2.Visible = false;
            this.ov_2_cataloguswaarde_text.Visible = false;
            this.ov_2_charbtn_3.Visible = false;
            this.ov_2_charbtn_2.Visible = false;
            this.ov_2_charbtn_1.Visible = false;
        }

        public void hide_ov_3()
        {
            List<Button> ov_3_buttons = ov_3_get_buttons();
            foreach (var button in ov_3_buttons)
            {
                button.Visible = false;
            }
            hideContent1();
            hideContent2();
        }

        private void showContent1() // toon alle inhoud op de eerste pagina
        {
            chart1.Visible = true;
            checkBox2012_1.Visible = true;
            checkBox2013_1.Visible = true;
            checkBox2014_1.Visible = true;
            checkBox2015_1.Visible = true;
            checkBox2016_1.Visible = true;
            checkBox2017_1.Visible = true;
            button_top5.Visible = true;
            button_load_chart.Visible = true;
        }

        private void showContent2() // toon alle inhoud op de tweede pagina
        {
            checkBox2012_2.Visible = true;
            checkBox2013_2.Visible = true;
            checkBox2014_2.Visible = true;
            checkBox2015_2.Visible = true;
            checkBox2016_2.Visible = true;
            checkBox2017_2.Visible = true;
            checkBox2012_2017.Visible = true;
            button_back.Visible = true;
            button_show_cars.Visible = true;
        }

        private void hideContent1() // verberg alle inhoud op de eerste pagina
        {
            chart1.Visible = false;
            checkBox2012_1.Visible = false;
            checkBox2013_1.Visible = false;
            checkBox2014_1.Visible = false;
            checkBox2015_1.Visible = false;
            checkBox2016_1.Visible = false;
            checkBox2017_1.Visible = false;
            button_load_chart.Visible = false;
            button_top5.Visible = false;
        }

        private void hideContent2() // verberg alle inhoud op de tweede pagina
        {
            checkBox2012_2.Visible = false;
            checkBox2013_2.Visible = false;
            checkBox2014_2.Visible = false;
            checkBox2015_2.Visible = false;
            checkBox2016_2.Visible = false;
            checkBox2017_2.Visible = false;
            checkBox2012_2017.Visible = false;
            button_show_cars.Visible = false;
            button_back.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
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

            this.ov_2_mainchart.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            List<Button> ov_2_buttons = ov_2_get_buttons();
            foreach (var button in ov_2_buttons)
            {
                button.Visible = true;
            }

            this.ov_2_mainchart.Series["Elektrisch"].Color = Color.YellowGreen;
            this.ov_2_mainchart.Series["Hybride"].Color = Color.DeepSkyBlue;
            this.ov_2_mainchart.Series["Diesel"].Color = Color.Red;

            this.ov_2_mainchart.Visible = true;

            clear_button_color();
            this.ov_2_button_all_years.BackColor = System.Drawing.Color.Yellow;

            ov_2_main_chart(5000 * this.ov_2_catalogus_bar1.Value, 5000 * this.ov_2_catalogus_bar2.Value);

            this.ov_2_chb_elek.Visible = true;
            this.ov_2_chk_hybrid.Visible = true;
            this.ov_2_chk_diesel.Visible = true;

            this.ov_2_price_filter.Visible = true;
            this.ov_2_trackbar1_value.Visible = true;
            this.ov_2_trackbar2_value.Visible = true;
            this.ov_2_catalogus_bar1.Visible = true;
            this.ov_2_catalogus_bar2.Visible = true;
            this.ov_2_cataloguswaarde_text.Visible = true;

            this.ov_2_charbtn_3.Visible = true;
            this.ov_2_charbtn_2.Visible = true;
            this.ov_2_charbtn_1.Visible = true;

            this.ov_2_charbtn_1.BackColor = System.Drawing.Color.Yellow;

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


        public void ov_2_year_chart(int year, int min_price, int max_price)
        {
            empty_chart(this.ov_2_mainchart); // do not forget to empty the chart!!
            SqlConnection myConnection = create_conn(); // change "LUCASPC" to your pc name!!

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            string start_date;
            string end_date;

            var days_in_month = get_days_in_month();
            var month_names = get_month_names();

            for (int i = 1; i <= 12; i++)
            {
                if (i > 9)
                {
                    start_date = year.ToString() + i.ToString() + "01";
                    end_date = year.ToString() + i.ToString() + days_in_month[i - 1].ToString();
                }
                else
                {
                    start_date = year + "0" + i + "01";
                    end_date = year.ToString() + "0" + i.ToString() + days_in_month[i - 1].ToString();
                }

                cmd.CommandText = "SELECT COUNT(*) FROM elec_cars_nl WHERE datum_eerste BETWEEN '" + start_date + "' and '" + end_date + "' and catalogusprijs BETWEEN " + min_price + " and " + max_price + "";
                int result1 = (int)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT COUNT(*) FROM diesel_cars_nl WHERE datum_eerste_tenaam BETWEEN '" + start_date + "' and '" + end_date + "' and catalogusprijs BETWEEN " + min_price + " and " + max_price + "";
                Int32 result2 = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT COUNT(*) FROM hybr_cars_nl WHERE datum_eerste BETWEEN '" + start_date + "' and '" + end_date + "' and catalogusprijs BETWEEN " + min_price + " and " + max_price + "";
                Int32 result3 = (Int32)cmd.ExecuteScalar();

                this.ov_2_mainchart.Series["Elektrisch"].Points.AddXY(month_names[i - 1], result1);
                this.ov_2_mainchart.Series["Diesel"].Points.AddXY(month_names[i - 1], result2);
                this.ov_2_mainchart.Series["Hybride"].Points.AddXY(month_names[i - 1], result3);
            }
        }

        public void ov_2_main_chart(int min_price, int max_price)
        {
            empty_chart(this.ov_2_mainchart); // do not forget to empty the chart!!
            SqlConnection myConnection = create_conn(); // change "LUCASPC" to your pc name!!

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;

            for (int i = 2007; i <= 2017; i++)
            {
                string year1 = i.ToString();
                int i_1 = i + 1;
                string year2 = i_1.ToString();

                year1 = year1 + "0101";
                year2 = year2 + "0101";

                cmd.CommandText = "SELECT COUNT(*) FROM elec_cars_nl WHERE datum_eerste BETWEEN '" + year1 + "' and '" + year2 + "' and catalogusprijs BETWEEN " + min_price + " and " + max_price + "";
                Int32 result1 = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT COUNT(*) FROM diesel_cars_nl WHERE datum_eerste_tenaam BETWEEN '" + year1 + "' and '" + year2 + "' and catalogusprijs BETWEEN " + min_price + " and " + max_price + "";
                Int32 result2 = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT COUNT(*) FROM hybr_cars_nl WHERE datum_eerste BETWEEN '" + year1 + "' and '" + year2 + "' and catalogusprijs BETWEEN " + min_price + " and " + max_price + "";
                Int32 result3 = (Int32)cmd.ExecuteScalar();

                this.ov_2_mainchart.Series["Elektrisch"].Points.AddXY(i.ToString(), result1);
                this.ov_2_mainchart.Series["Diesel"].Points.AddXY(i.ToString(), result2);
                this.ov_2_mainchart.Series["Hybride"].Points.AddXY(i.ToString(), result3);
            }
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
            showContent1();
            addChart();
            //question_3.Enabled = false;
        }

        void clear_button_color()
        {
            List<Button> ov_2_buttons = ov_2_get_buttons();
            foreach (var btn in ov_2_buttons)
            {
                btn.BackColor = System.Drawing.Color.White;
            }
        }

        void year_button_handler(object sender, EventArgs e)
        {
            clear_button_color();
            Button button = sender as Button;
            button.BackColor = System.Drawing.Color.Yellow;
            button.FlatStyle = FlatStyle.Flat;

            if (button.Name == "ov_2_button_all_years")
            {
                ov_2_main_chart(5000 * this.ov_2_catalogus_bar1.Value, 5000 * this.ov_2_catalogus_bar2.Value);
            }
            else
            {
                ov_2_year_chart(Int32.Parse(button.Text), 5000 * this.ov_2_catalogus_bar1.Value, 5000 * this.ov_2_catalogus_bar2.Value);
            }
        }

        private void ov_2_chb_elek_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            var chart_colors = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("Elektrisch", "YellowGreen"),
                new KeyValuePair<string, string>("Hybride", "DeepSkyBlue"),
                new KeyValuePair<string, string>("Diesel", "Red"),
            };

            if (checkbox.Checked)
            {
                foreach (var chart_color in chart_colors)
                {
                    if (chart_color.Key == checkbox.Text)
                    {
                        this.ov_2_mainchart.Series[checkbox.Text].Color = Color.FromName(chart_color.Value);
                        break;
                    }
                }
            }
            else
            {
                this.ov_2_mainchart.Series[checkbox.Text].Color = Color.Transparent;
            }

        }

        private void ov_2_catalogus_bar1_Scroll(object sender, EventArgs e)
        {
            int val = 5000 * ov_2_catalogus_bar2.Value;
            ov_2_trackbar2_value.Text = val.ToString();
        }


        private void ov_2_catalogus_bar2_Scroll(object sender, EventArgs e)
        {
            int val = 5000 * ov_2_catalogus_bar1.Value;
            ov_2_trackbar1_value.Text = val.ToString();
        }

        private void ov_2_price_filter_Click(object sender, EventArgs e)
        {
            List<Button> ov_2_buttons = ov_2_get_buttons();
            foreach (var btn in ov_2_buttons)
            {
                if (btn.BackColor != System.Drawing.Color.White)
                {
                    string text = btn.Text;
                    if (text.Length == 4)
                    {
                        ov_2_year_chart(Int32.Parse(btn.Text), 5000 * this.ov_2_catalogus_bar1.Value, 5000 * this.ov_2_catalogus_bar2.Value);
                    }
                    else
                    {
                        ov_2_main_chart(5000 * this.ov_2_catalogus_bar1.Value, 5000 * this.ov_2_catalogus_bar2.Value);
                    }
                    break;
                }
            }
        }
        void setcolor_chart_btn()
        {
            this.ov_2_charbtn_3.BackColor = System.Drawing.Color.Gainsboro;
            this.ov_2_charbtn_2.BackColor = System.Drawing.Color.Gainsboro;
            this.ov_2_charbtn_1.BackColor = System.Drawing.Color.Gainsboro;
        }
        private void ov_2_charbtn_1_Click(object sender, EventArgs e)
        {
            setcolor_chart_btn();
            this.ov_2_charbtn_1.BackColor = System.Drawing.Color.Yellow;
            this.ov_2_mainchart.Series["Elektrisch"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.ov_2_mainchart.Series["Hybride"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.ov_2_mainchart.Series["Diesel"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void ov_2_charbtn_2_Click(object sender, EventArgs e)
        {
            setcolor_chart_btn();
            this.ov_2_charbtn_2.BackColor = System.Drawing.Color.Yellow;
            this.ov_2_mainchart.Series["Elektrisch"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            this.ov_2_mainchart.Series["Hybride"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            this.ov_2_mainchart.Series["Diesel"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void ov_2_charbtn_3_Click(object sender, EventArgs e)
        {
            setcolor_chart_btn();
            this.ov_2_charbtn_3.BackColor = System.Drawing.Color.Yellow;
            this.ov_2_mainchart.Series["Elektrisch"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            this.ov_2_mainchart.Series["Hybride"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            this.ov_2_mainchart.Series["Diesel"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
        }

        public void ov_1_main_chart()
        {
            empty_chart(this.ov_1_mainchart);
            SqlConnection con = create_conn();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            for (int i = 2007; i <= 2016; i++)
            {
                cmd.CommandText = "SELECT SUM(CAST(quantity_electric as int) + CAST(quantity_hybrid as int)) FROM cars_by_month_nor  WHERE year = '" + i + "'";
                Int32 result1 = (Int32)cmd.ExecuteScalar();

                cmd.CommandText = "SELECT SUM(CAST(quantity_diesel as int)) FROM cars_by_month_nor  WHERE year = '" + i + "'";
                Int32 result2 = (Int32)cmd.ExecuteScalar();


                cmd.CommandText = "SELECT SUM(CAST(quantity as int) - CAST(quantity_hybrid as int) - CAST(quantity_electric as int) - CAST(quantity_diesel as int)) FROM cars_by_month_nor WHERE year = '" + i + "'";
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
            SqlConnection con = create_conn();

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

        private void ov_1_maintb_Scroll(object sender, EventArgs e)
        {
            SqlConnection con = create_conn();
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

        private void addChart() // creëer de grafiek
        {
            SqlConnection myConnection = new SqlConnection("Data Source=" + System.Environment.MachineName + "\\SQLEXPRESS; Initial Catalog=project_3; Integrated Security=True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;
            myConnection.Open();

            for (int i = 0; i < alleJaren.Length; i++)
            {
                cmd.CommandText = "SELECT AVG(catalogusprijs) " +
                "FROM all_cars_electric_nl " +
                "JOIN all_cars_filter_nl " +
                "ON all_cars_electric_nl.kenteken = all_cars_filter_nl.kenteken " +
                "WHERE datum_tenaamstelling BETWEEN '" + alleJaren[i] + "-01-01' AND '" + alleJaren[i] + "-12-31' " +
                "AND catalogusprijs != 0";

                Int32 result = (Int32)cmd.ExecuteScalar();
                alleResultaten[i] = result;
            }
            myConnection.Close();
        }

        private void button_top5_Click(object sender, EventArgs e)
        {
            hideContent1();
            showContent2();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            hideContent2();
            showContent1();
        }

        private void button_load_chart_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Gemiddelde verkoopprijs"].Points.Clear();
            this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.Clear();

            int[] jaren = alleJaren;
            int[] resultaten = alleResultaten;

            if (checkBox2012_1.Checked == true)
            {
                if (checkBox2013_1.Checked == true)
                {
                    if (checkBox2014_1.Checked == true)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                }
                            }
                        }
                    }
                    else if (checkBox2014_1.Checked == false)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                }
                            }
                        }
                    }
                }
                else if (checkBox2013_1.Checked == false)
                {
                    if (checkBox2014_1.Checked == true)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                }
                            }
                        }
                    }
                    else if (checkBox2014_1.Checked == false)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[0], alleResultaten[0]);
                                }
                            }
                        }
                    }
                }
            }
            else if (checkBox2012_1.Checked == false)
            {
                if (checkBox2013_1.Checked == true)
                {
                    if (checkBox2014_1.Checked == true)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                }
                            }
                        }
                    }
                    else if (checkBox2014_1.Checked == false)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[1], alleResultaten[1]);
                                }
                            }
                        }
                    }
                }
                else if (checkBox2013_1.Checked == false)
                {
                    if (checkBox2014_1.Checked == true)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[2], alleResultaten[2]);
                                }
                            }
                        }
                    }
                    else if (checkBox2014_1.Checked == false)
                    {
                        if (checkBox2015_1.Checked == true)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[3], alleResultaten[3]);
                                }
                            }
                        }
                        if (checkBox2015_1.Checked == false)
                        {
                            if (checkBox2016_1.Checked == true)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                                else if (checkBox2017_1.Checked == false)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[4], alleResultaten[4]);
                                }
                            }
                            else if (checkBox2016_1.Checked == false)
                            {
                                if (checkBox2017_1.Checked == true)
                                {
                                    this.chart1.Series["Gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);

                                    this.chart1.Series["Ontwikkeling gemiddelde verkoopprijs"].Points.AddXY(alleJaren[5], alleResultaten[5]);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button_show_cars_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;

            if (checkBox2012_2.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2012;
                pictureBox2.Visible = false;
            }
            if (checkBox2012_2.Checked == true & checkBox2013_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2012;
                pictureBox2.Image = project_3_school.Properties.Resources._2013;
            }
            if (checkBox2012_2.Checked == true & checkBox2014_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2012;
                pictureBox2.Image = project_3_school.Properties.Resources._2014;
            }
            if (checkBox2012_2.Checked == true & checkBox2015_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2012;
                pictureBox2.Image = project_3_school.Properties.Resources._2015;
            }
            if (checkBox2012_2.Checked == true & checkBox2016_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2012;
                pictureBox2.Image = project_3_school.Properties.Resources._2016;
            }
            if (checkBox2012_2.Checked == true & checkBox2017_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2012;
                pictureBox2.Image = project_3_school.Properties.Resources._2017;
            }
            if (checkBox2012_2.Checked == true & checkBox2012_2017.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Image = project_3_school.Properties.Resources._2012;
            }

            if (checkBox2013_2.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2013;
                pictureBox2.Visible = false;
            }
            if (checkBox2013_2.Checked == true & checkBox2014_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2013;
                pictureBox2.Image = project_3_school.Properties.Resources._2014;
            }
            if (checkBox2013_2.Checked == true & checkBox2015_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2013;
                pictureBox2.Image = project_3_school.Properties.Resources._2015;
            }
            if (checkBox2013_2.Checked == true & checkBox2016_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2013;
                pictureBox2.Image = project_3_school.Properties.Resources._2016;
            }
            if (checkBox2013_2.Checked == true & checkBox2017_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2013;
                pictureBox2.Image = project_3_school.Properties.Resources._2017;
            }
            if (checkBox2013_2.Checked == true & checkBox2012_2017.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Image = project_3_school.Properties.Resources._2013;
            }

            if (checkBox2014_2.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2014;
                pictureBox2.Visible = false;
            }
            if (checkBox2014_2.Checked == true & checkBox2015_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2014;
                pictureBox2.Image = project_3_school.Properties.Resources._2015;
            }
            if (checkBox2014_2.Checked == true & checkBox2016_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2014;
                pictureBox2.Image = project_3_school.Properties.Resources._2016;
            }
            if (checkBox2014_2.Checked == true & checkBox2017_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2014;
                pictureBox2.Image = project_3_school.Properties.Resources._2017;
            }
            if (checkBox2014_2.Checked == true & checkBox2012_2017.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Image = project_3_school.Properties.Resources._2014;
            }

            if (checkBox2015_2.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2015;
                pictureBox2.Visible = false;
            }
            if (checkBox2015_2.Checked == true & checkBox2016_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2015;
                pictureBox2.Image = project_3_school.Properties.Resources._2016;
            }
            if (checkBox2015_2.Checked == true & checkBox2017_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2015;
                pictureBox2.Image = project_3_school.Properties.Resources._2017;
            }
            if (checkBox2015_2.Checked == true & checkBox2012_2017.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Image = project_3_school.Properties.Resources._2015;
            }

            if (checkBox2016_2.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2016;
                pictureBox2.Visible = false;
            }
            if (checkBox2016_2.Checked == true & checkBox2017_2.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2016;
                pictureBox2.Image = project_3_school.Properties.Resources._2017;
            }
            if (checkBox2016_2.Checked == true & checkBox2012_2017.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Image = project_3_school.Properties.Resources._2016;
            }

            if (checkBox2017_2.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources._2017;
                pictureBox2.Visible = false;
            }
            if (checkBox2017_2.Checked == true & checkBox2012_2017.Checked == true)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Image = project_3_school.Properties.Resources._2017;
            }
            if (checkBox2012_2017.Checked == true & checkBoxCounter != 2)
            {
                pictureBox1.Image = project_3_school.Properties.Resources.overzicht;
                pictureBox2.Visible = false;
            }
        }

        private void checkBoxValidate() // het uitzetten van de overige checkboxes
        {
            if (checkBoxCounter == 2)
            {
                if (checkBox2012_2.Checked == false)
                {
                    checkBox2012_2.Enabled = false;
                }
                if (checkBox2013_2.Checked == false)
                {
                    checkBox2013_2.Enabled = false;
                }
                if (checkBox2014_2.Checked == false)
                {
                    checkBox2014_2.Enabled = false;
                }
                if (checkBox2015_2.Checked == false)
                {
                    checkBox2015_2.Enabled = false;
                }
                if (checkBox2016_2.Checked == false)
                {
                    checkBox2016_2.Enabled = false;
                }
                if (checkBox2017_2.Checked == false)
                {
                    checkBox2017_2.Enabled = false;
                }
                if (checkBox2012_2017.Checked == false)
                {
                    checkBox2012_2017.Enabled = false;
                }
            }
            else if (checkBoxCounter != 2)
            {
                checkBox2012_2.Enabled = true;
                checkBox2013_2.Enabled = true;
                checkBox2014_2.Enabled = true;
                checkBox2015_2.Enabled = true;
                checkBox2016_2.Enabled = true;
                checkBox2017_2.Enabled = true;
                checkBox2012_2017.Enabled = true;
            }
        }

        private void checkBox2012_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2012_2.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2012_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2012_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }

        private void checkBox2013_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2013_2.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2013_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2013_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }

        private void checkBox2014_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2014_2.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2014_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2014_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }

        private void checkBox2015_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2015_2.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2015_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2015_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }

        private void checkBox2016_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2016_2.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2016_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2016_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }

        private void checkBox2017_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2017_2.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2017_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2017_2.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }

        private void checkBox2012_2017_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCounter >= 0 & checkBoxCounter < 2)
            {
                if (checkBox2012_2017.Checked == true)
                {
                    checkBoxCounter += 1;
                }
                else if (checkBox2012_2017.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            else if (checkBoxCounter == 2)
            {
                if (checkBox2012_2017.Checked == false)
                {
                    checkBoxCounter -= 1;
                }
            }
            checkBoxValidate();
        }
    }
}