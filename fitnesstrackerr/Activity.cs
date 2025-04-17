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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace fitnesstrackerr
{
    public partial class Activity : Form
    {
        private string selectedActivity;
        private string username = "uday";

        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Uday\OneDrive\Desktop\LoginDatabase.accdb;";
        OleDbConnection conn;
        string loggedInUsername;

        public Activity(string username)
        {
            InitializeComponent();
            loggedInUsername = Session.LoggedInUsername;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox6.SelectedItem.ToString())
            {
                case "Running":
                    lblMetric1.Text = "Steps";
                    lblMetric2.Text = "Distance (in m)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Walking":
                    lblMetric1.Text = "Steps";
                    lblMetric2.Text = "Distance (in m)";
                    lblMetric3.Text = "Time Taken (in min)";
                    break;
                case "Cycling":
                    lblMetric1.Text = "Speed";
                    lblMetric2.Text = "Distance (in m)";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Swimming":
                    lblMetric1.Text = "Laps";
                    lblMetric2.Text = "Time (in min)";
                    lblMetric3.Text = "Avg Heart Rate";
                    break;
                case "Yoga":
                    lblMetric1.Text = "Avg Heart Rate";
                    lblMetric2.Text = "Avg Breathing Rate";
                    lblMetric3.Text = "Time (in min)";
                    break;
                case "Lifting":
                    lblMetric1.Text = "Sets";
                    lblMetric2.Text = "Avg Heart Rate";
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
            if (comboBox6.SelectedItem == null)
            {
                MessageBox.Show("Please select an activity.");
                return;
            }

            string activity = comboBox6.SelectedItem.ToString();
            string metric1 = txtMetric1.Text.Trim();
            string metric2 = txtMetric2.Text.Trim();
            string metric3 = txtMetric3.Text.Trim();
            string dateLogged = DateTime.Now.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(metric1) || string.IsNullOrEmpty(metric2) || string.IsNullOrEmpty(metric3))
            {
                MessageBox.Show("Please fill in all metric fields.");
                return;
            }

            string query = "";
            OleDbCommand cmd;

            try
            {
                using (conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    switch (activity)
                    {
                        case "Running":
                            query = "INSERT INTO Running (Username, Steps, Distance, [Time], DateLogged) VALUES (?, ?, ?, ?, ?)";
                            cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("?", loggedInUsername);
                            cmd.Parameters.AddWithValue("?", metric1);
                            cmd.Parameters.AddWithValue("?", metric2);
                            cmd.Parameters.AddWithValue("?", metric3);
                            cmd.Parameters.AddWithValue("?", dateLogged);
                            break;

                        case "Walking":
                            query = "INSERT INTO Walking (Username, Steps, Distance, [Time], DateLogged) VALUES (?, ?, ?, ?, ?)";
                            cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("?", loggedInUsername);
                            cmd.Parameters.AddWithValue("?", metric1);
                            cmd.Parameters.AddWithValue("?", metric2);
                            cmd.Parameters.AddWithValue("?", metric3);
                            cmd.Parameters.AddWithValue("?", dateLogged);
                            break;

                        case "Cycling":
                            query = "INSERT INTO Cycling (Username, Speed, Distance, [Time], DateLogged) VALUES (?, ?, ?, ?, ?)";
                            cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("?", loggedInUsername);
                            cmd.Parameters.AddWithValue("?", metric1);
                            cmd.Parameters.AddWithValue("?", metric2);
                            cmd.Parameters.AddWithValue("?", metric3);
                            cmd.Parameters.AddWithValue("?", dateLogged);
                            break;

                        case "Swimming":
                            query = "INSERT INTO Swimming (Username, Laps, [Time], AvgHeartRate, DateLogged) VALUES (?, ?, ?, ?, ?)";
                            cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("?", loggedInUsername);
                            cmd.Parameters.AddWithValue("?", metric1);
                            cmd.Parameters.AddWithValue("?", metric2);
                            cmd.Parameters.AddWithValue("?", metric3);
                            cmd.Parameters.AddWithValue("?", dateLogged);
                            break;

                        case "Yoga":
                            query = "INSERT INTO Yoga (Username, AvgHeartRate, AvgBreathingRate, [Time], DateLogged) VALUES (?, ?, ?, ?, ?)";
                            cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("?", loggedInUsername);
                            cmd.Parameters.AddWithValue("?", metric1);
                            cmd.Parameters.AddWithValue("?", metric2);
                            cmd.Parameters.AddWithValue("?", metric3);
                            cmd.Parameters.AddWithValue("?", dateLogged);
                            break;

                        case "Lifting":
                            query = "INSERT INTO Lifting (Username, Sets, AvgHeartRate, [Time], DateLogged) VALUES (?, ?, ?, ?, ?)";
                            cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("?", loggedInUsername);
                            cmd.Parameters.AddWithValue("?", metric1);
                            cmd.Parameters.AddWithValue("?", metric2);
                            cmd.Parameters.AddWithValue("?", metric3);
                            cmd.Parameters.AddWithValue("?", dateLogged);
                            break;

                        default:
                            MessageBox.Show("Unknown activity selected.");
                            return;
                    }

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show(activity + " activity saved successfully!");
                        // Optionally navigate to Progress form here
                    }
                    else
                    {
                        MessageBox.Show("Failed to save activity.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }

            double caloriesBurned = CalculateCalories(activity, metric1, metric2, metric3);

            // Navigate to Dashboard and pass all values
            Dashboard dashboard = new Dashboard(loggedInUsername, activity, double.Parse(metric1), double.Parse(metric2), double.Parse(metric3), caloriesBurned);
            dashboard.Show();
            this.Hide();
        }

        private double CalculateCalories(string activity, string metric1, string metric2, string metric3)
        {
            double m1 = double.Parse(metric1);
            double m2 = double.Parse(metric2);
            double m3 = double.Parse(metric3); // Assuming m3 is time in minutes
            double caloriesBurned = 0;

            switch (activity)
            {
                case "Walking":
                    // m1 = Steps, m2 = Distance (meters), m3 = Time (min)
                    // Assumption: 0.04 cal/step, 0.03 cal/meter, 0.4 cal/min
                    caloriesBurned = (0.04 * m1) + (0.03 * m2) + (0.4 * m3);
                    break;

                case "Running":
                    // m1 = Steps, m2 = Distance (meters), m3 = Time (min)
                    // Assumption: 0.06 cal/step, 0.05 cal/meter, 0.7 cal/min
                    caloriesBurned = (0.06 * m1) + (0.05 * m2) + (0.7 * m3);
                    break;

                case "Cycling":
                    // m1 = Speed (km/h), m2 = Distance (meters), m3 = Time (min)
                    // Assumption: 0.03 cal per km/h of speed, 0.05 cal/meter, 0.6 cal/min
                    caloriesBurned = (0.03 * m1) + (0.05 * m2) + (0.6 * m3);
                    break;

                case "Swimming":
                    // m1 = Laps, m2 = Time (min), m3 = Avg Heart Rate
                    // Assumption: 5 cal/lap, 0.3 cal/min, 0.1 cal/bpm
                    caloriesBurned = (5 * m1) + (0.3 * m2) + (0.1 * m3);
                    break;

                case "Yoga":
                    // m1 = Type of Yoga (ignored), m2 = Avg Breathing Rate, m3 = Time (min)
                    // Assumption: 0.25 cal/min, 0.1 cal/breath per min
                    caloriesBurned = (0.25 * m3) + (0.1 * m2);
                    break;

                case "Lifting":
                    // m1 = Sets, m2 = Avg Heart Rate, m3 = Time (min)
                    // Assumption: 2 cal/set, 0.05 cal/bpm, 0.4 cal/min
                    caloriesBurned = (2 * m1) + (0.05 * m2) + (0.4 * m3);
                    break;

                default:
                    caloriesBurned = 0;
                    break;
            }
            return Math.Round(caloriesBurned, 2);
        }

        //// Navigate to Dashboard and pass all values
        //Dashboard dashboard = new Dashboard(loggedInUsername, activity, m1, m2, m3, caloriesBurned);
        //    dashboard.Show();
        //    this.Hide();
        //}

        private void Activity_Load(object sender, EventArgs e)
        {

        }
    }
}
