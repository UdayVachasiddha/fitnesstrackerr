using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace fitnesstrackerr
{
    public partial class Dashboard : Form
    {
        private string loggedInUsername;
        private string selectedActivity;
        private double metric1, metric2, metric3, caloriesBurned;
        private int targetProgress = 0;
        private int currentProgress = 0;


        // Connection string for database
        private readonly string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Uday\OneDrive\Desktop\LoginDatabase.accdb;";
        public Dashboard(string username, string activity, double m1, double m2, double m3, double calories)
        {
            InitializeComponent();

            //MessageBox.Show($"Constructor received username: {username}");

            loggedInUsername = username;
            selectedActivity = activity;
            metric1 = m1;
            metric2 = m2;
            metric3 = m3;
            caloriesBurned = calories;
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
            // Set all textboxes to read-only and color
            SetReadOnlyTextBoxes();

            // Process images if needed
            ProcessImages();

            // Update the dashboard with current data
            UpdateDashboard();
        }

        private void UpdateDashboard()
        {
            DisplayMetrics();
            DisplayCalories();
            UpdateProgressBar();
        }

        private void DisplayMetrics()
        {
            switch (selectedActivity)
            {
                case "Walking":
                    txtWalkingDistance.Text = metric2.ToString();
                    txtWalkingTime.Text = metric3.ToString();
                    txtWalkingSteps.Text = metric1.ToString();
                    break;
                case "Running":
                    txtRunningDistance.Text = metric2.ToString();
                    txtRunningTime.Text = metric3.ToString();
                    txtRunningSteps.Text = metric1.ToString();
                    break;
                case "Swimming":
                    txtSwimmingLaps.Text = metric1.ToString();
                    txtSwimmingTime.Text = metric2.ToString();
                    txtSwimmingAvgHeartRate.Text = metric3.ToString();
                    break;
                case "Cycling":
                    txtCyclingDistance.Text = metric2.ToString();
                    txtCyclingTime.Text = metric3.ToString();
                    txtCyclingAvgSpeed.Text = metric1.ToString();
                    break;
                case "Yoga":
                    txtYogaType.Text = metric1.ToString();
                    txtYogaTime.Text = metric3.ToString();
                    txtYogaAvgBreathingRate.Text = metric2.ToString();
                    break;
                case "Lifting":
                    txtLiftingSets.Text = metric1.ToString();
                    txtLiftingTime.Text = metric3.ToString();
                    txtLiftingAvgHeartRate.Text = metric2.ToString();
                    break;
            }
        }

        private void DisplayCalories()
        {
            txtCaloriesBurned.Text = caloriesBurned.ToString("0.##");
        }

        private void UpdateProgressBar()
        {
            try
            {
                // First check if username is valid
                if (string.IsNullOrEmpty(loggedInUsername))
                {
                    MessageBox.Show("Username is null or empty. Please login again.");
                    return;
                }

                double goal = GetUserGoal(loggedInUsername);
                Console.WriteLine($"Retrieved goal: {goal} for user: {loggedInUsername}");

                if (goal <= 0)
                {
                    goal = 2000; // Default goal
                    Console.WriteLine("Using default goal of 2000 calories.");
                }

                // Calculate percentage of goal achieved
                double percentage = (caloriesBurned / goal) * 100;
                int percent = (int)Math.Round(percentage);
                percent = Math.Max(0, Math.Min(100, percent)); // Ensure value is between 0-100

                Console.WriteLine($"Calories burned: {caloriesBurned}, Goal: {goal}, Percentage: {percent}%");

                // Update the progress bar
                progressBarCircle.Value = percent;
                progressBarCircle.Text = $"{percent}%";

                // Update color based on progress
                if (percent < 33)
                    progressBarCircle.ProgressColor = Color.Red;
                else if (percent < 66)
                    progressBarCircle.ProgressColor = Color.Orange;
                else
                    progressBarCircle.ProgressColor = Color.LimeGreen;

                // Store this as the target for animation if needed
                targetProgress = percent;
                currentProgress = percent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating progress bar: {ex.Message}");
            }
        }

        private double GetUserGoal(string username)
        {
            double goal = 0; // Default value as fallback

            try
            {
                // Debug output
                Console.WriteLine($"Attempting to get goal for user: {username}");

                // Make sure username isn't null or empty
                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Username is null or empty");
                    return 2000; // Return default value
                }

                string query = "SELECT CalorieGoal FROM Goal WHERE Username = ?";
                Console.WriteLine($"Executing query: {query}");

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        Console.WriteLine("Database connection opened successfully");

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("?", username);

                            object result = cmd.ExecuteScalar();
                            Console.WriteLine($"Query result: {(result == null ? "null" : result.ToString())}");

                            if (result != null && result != DBNull.Value)
                            {
                                if (double.TryParse(result.ToString(), out double parsedGoal))
                                {
                                    goal = parsedGoal;
                                    Console.WriteLine($"Successfully parsed goal: {goal}");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to parse goal value from database");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No goal found for this user in database");

                                // Try case-insensitive search as fallback
                                string fallbackQuery = "SELECT CalorieGoal FROM Goal WHERE UCASE(Username) = UCASE(?)";
                                using (OleDbCommand cmd2 = new OleDbCommand(fallbackQuery, conn))
                                {
                                    cmd2.Parameters.AddWithValue("?", username);
                                    object fallbackResult = cmd2.ExecuteScalar();

                                    if (fallbackResult != null && fallbackResult != DBNull.Value)
                                    {
                                        if (double.TryParse(fallbackResult.ToString(), out double parsedGoal))
                                        {
                                            goal = parsedGoal;
                                            Console.WriteLine($"Found goal with case-insensitive search: {goal}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception connEx)
                    {
                        Console.WriteLine($"Database connection error: {connEx.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserGoal: {ex.Message}");
            }

            // If still no goal, use default
            if (goal <= 0)
            {
                goal = 2000;
                Console.WriteLine("Using default goal of 2000 calories");
            }

            return goal;
        }

        private void SetReadOnlyTextBoxes()
        {
            // Walking
            SetReadOnlyAndColor(txtWalkingDistance);
            SetReadOnlyAndColor(txtWalkingTime);
            SetReadOnlyAndColor(txtWalkingSteps);

            // Running
            SetReadOnlyAndColor(txtRunningDistance);
            SetReadOnlyAndColor(txtRunningTime);
            SetReadOnlyAndColor(txtRunningSteps);

            // Swimming
            SetReadOnlyAndColor(txtSwimmingLaps);
            SetReadOnlyAndColor(txtSwimmingTime);
            SetReadOnlyAndColor(txtSwimmingAvgHeartRate);

            // Cycling
            SetReadOnlyAndColor(txtCyclingDistance);
            SetReadOnlyAndColor(txtCyclingTime);
            SetReadOnlyAndColor(txtCyclingAvgSpeed);

            // Yoga
            SetReadOnlyAndColor(txtYogaType);
            SetReadOnlyAndColor(txtYogaTime);
            SetReadOnlyAndColor(txtYogaAvgBreathingRate);

            // Lifting
            SetReadOnlyAndColor(txtLiftingSets);
            SetReadOnlyAndColor(txtLiftingTime);
            SetReadOnlyAndColor(txtLiftingAvgHeartRate);

            // Calories
            SetReadOnlyAndColor(txtCaloriesBurned);
        }

        private void SetReadOnlyAndColor(System.Windows.Forms.TextBox textBox)
        {
            textBox.ReadOnly = true;
            textBox.ForeColor = Color.Firebrick;
        }

        private void ProcessImages()
        {
            try
            {
                // Handle pictureBox2 image if it exists
                if (pictureBox2.Image != null)
                {
                    Bitmap original = new Bitmap(pictureBox2.Image);
                    pictureBox2.Image = InvertImage(original);
                }

                // Handle pictureBox3 image if it exists
                if (pictureBox3.Image != null)
                {
                    Bitmap original = new Bitmap(pictureBox3.Image);
                    pictureBox3.Image = InvertImage(original);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing images: {ex.Message}");
            }
        }

        // If you want to use animation for the progress bar
        private void StartProgressAnimation()
        {
            currentProgress = 0;
            timer1.Start();
        }

        private Bitmap InvertImage(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            // Create a copy instead of modifying the original
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(
                        pixelColor.A,
                        255 - pixelColor.R,
                        255 - pixelColor.G,
                        255 - pixelColor.B);
                    result.SetPixel(x, y, invertedColor);
                }
            }
            return result;
        }

        // If you want to use animation for the progress bar

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentProgress < targetProgress)
            {
                currentProgress++;
                progressBarCircle.Value = currentProgress;
                // Set text if the control supports it
                progressBarCircle.Text = currentProgress.ToString() + "%";
            }
            else
            {
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(loggedInUsername);
            profileForm.Show();      // Show the Profile form
            this.Hide();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            Goal goalPage = new Goal("test_username");
            // Show the Goal page
            goalPage.Show();

            // Optionally hide or close the dashboard
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
