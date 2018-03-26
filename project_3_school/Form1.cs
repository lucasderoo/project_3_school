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

        public project_3()
        {
            InitializeComponent();
        }

        public SqlConnection create_conn(string pcname)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=" + pcname + "\\SQLEXPRESS;Initial Catalog=project_3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myConnection.Open();

            return myConnection;
        }

        public List<int> get_days_in_month()
        {
            return new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }

        public List<Button> ov_1_get_buttons()
        {
            var ov_2_buttons = new List<Button> { };
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

        }
        public void show_ov_1()
        {
            hide_ov_2(); // hide other questions
            hide_ov_3(); // hide other questions

            List<Button> ov_1_buttons = ov_1_get_buttons();
            foreach (var button in ov_1_buttons)
            {
                button.Visible = true;
            }

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
            SqlConnection myConnection = create_conn("LUCASPC"); // change "LUCASPC" to your pc name!!

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
            SqlConnection myConnection = create_conn("LUCASPC"); // change "LUCASPC" to your pc name!!

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
                foreach(var chart_color in chart_colors)
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
    }
}
