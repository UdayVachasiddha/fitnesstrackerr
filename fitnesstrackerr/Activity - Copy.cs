using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fitnesstrackerr
{
    public partial class Activity : Form
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Uday\OneDrive\Desktop\LoginDatabase.accdb;";
        OleDbConnection conn;
        public Activity()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelHeartRate_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCalories_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSpeed_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox6.SelectedItem.ToString())
            {
                case "Running":
                    lblMetric1.Text = "Steps";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Swimming":
                    lblMetric1.Text = "Laps";
                    lblMetric2.Text = "Time (in min)";
                    lblMetric3.Text = "avg Heart Rate (BPM)";
                    break;
                case "Cycling":
                    lblMetric1.Text = "Type";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Walking":
                    lblMetric1.Text = "Steps";
                    lblMetric2.Text = "Distance (in km)";
                    lblMetric3.Text = "Time Taken (in min)";
                    break;
                case "Lifting":
                    lblMetric1.Text = "Sets";
                    lblMetric2.Text = "Avg Heart Rate";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Yoga":
                    lblMetric1.Text = "Type of Yoga";
                    lblMetric2.Text = "Avg Breathing rate";
                    lblMetric3.Text = "Time (in min)";
                    break;
                default:
                    lblMetric1.Text = "Metric 1";
                    lblMetric2.Text = "Metric 2";
                    lblMetric3.Text = "Metric 3";
                    break;
            }
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            string activity = comboBox6.SelectedItem?.ToString();
            string metric1 = textBox1.Text.Trim();
            string metric2 = textBox2.Text.Trim();
            string metric3 = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(activity) || string.IsNullOrEmpty(metric1) ||
                string.IsNullOrEmpty(metric2) || string.IsNullOrEmpty(metric3))
            {
                MessageBox.Show("Please fill all the fields before saving.", "Validation Error");
                return;
            }

            try
            {
                using (conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    string query = "";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    switch (activity)
                    {
                        case "Running":
                            query = "INSERT INTO Running (Steps, Distance, Time) VALUES (@metric1, @metric2, @metric3)";
                            break;
                        case "Walking":
                            query = "INSERT INTO Walking (Steps, Distance, Time) VALUES (@metric1, @metric2, @metric3)";
                            break;
                        case "Cycling":
                            query = "INSERT INTO Cycling (Type, Distance, Time) VALUES (@metric1, @metric2, @metric3)";
                            break;
                        case "Swimming":
                            query = "INSERT INTO Swimming (Laps, Time, AvgHeartRate) VALUES (@metric1, @metric2, @metric3)";
                            break;
                        case "Lifting":
                            query = "INSERT INTO Lifting (Sets, AvgHeartRate, Time) VALUES (@metric1, @metric2, @metric3)";
                            break;
                        case "Yoga":
                            query = "INSERT INTO Yoga (TypeOfYoga, AvgBreathingRate, Time) VALUES (@metric1, @metric2, @metric3)";
                            break;
                        default:
                            MessageBox.Show("Invalid activity selected.");
                            return;
                    }

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@metric1", metric1);
                    cmd.Parameters.AddWithValue("@metric2", metric2);
                    cmd.Parameters.AddWithValue("@metric3", metric3);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Activity saved successfully!");

                    // Navigate to Progress page
                    Progress progress = new Progress();
                    progress.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

