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
    }
}
