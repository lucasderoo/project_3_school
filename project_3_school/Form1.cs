using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

        private void question_3_Click(object sender, EventArgs e)
        {
            showContent1();
            addChart();
            question_3.Enabled = false;
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

        private void addChart() // creëer de grafiek
        {
            SqlConnection myConnection = new SqlConnection("Data Source=LUCASPC\\SQLEXPRESS; Initial Catalog=project_3_full; Integrated Security=True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
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