using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace fitnesstrackerr
{
    public partial class LoginRegister : Form
    {
        public LoginRegister()
        {
            InitializeComponent();
            string loggedInUsername = "JohnDoe"; // or any hardcoded name
            string activity = "Running";         // hardcoded activity

            double m1 = 5.0;
            double m2 = 3.2;
            double m3 = 4.7;
            double caloriesBurned = 250.5;
            Dashboard dashboard = new Dashboard(loggedInUsername, activity, m1, m2, m3, caloriesBurned);

        }

        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LoginDatabase.accdb;";
        OleDbConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap original = new Bitmap(pictureBox1.Image);
                Bitmap inverted = InvertImage(original);
                pictureBox1.Image = inverted;
            }
        }

        private Bitmap InvertImage(Bitmap original)
        {
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
                    original.SetPixel(x, y, invertedColor);
                }
            }
            return original;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
        }

        int loginAttempts = 0;
        const int MaxLoginAttempts = 3;
        DateTime lockoutEndTime = DateTime.MinValue;

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (DateTime.Now < lockoutEndTime)
            {
                TimeSpan remaining = lockoutEndTime - DateTime.Now;
                MessageBox.Show($"Too many attempts. Try again after {remaining.Seconds} seconds.");
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            //if (loginAttempts >= MaxLoginAttempts)
            //{
            //    MessageBox.Show("Maximum login attempts exceeded. Please try again later.");
            //    btnLogin.Enabled = false;
            //    return;
            //}

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Login WHERE Username = ? AND [Password] = ?";
                    OleDbCommand cmd = new OleDbCommand(query, con);

                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Login successful!");
                        loginAttempts = 0;

                        Session.LoggedInUsername = username;
                        string loggedInUsername = "JohnDoe";
                        string activity = "Running";

                        double m1 = 5.0;
                        double m2 = 3.2;
                        double m3 = 4.7;
                        double caloriesBurned = 250.5;

                        // ✅ Create the Dashboard and show it
                        Dashboard dashboard = new Dashboard(loggedInUsername, activity, m1, m2, m3, caloriesBurned);
                        dashboard.Show();

                        //// ✅ Hide the current form (this one)
                        this.Hide();

                    }

                    else
                    {
                        loginAttempts++;

                        if (loginAttempts >= MaxLoginAttempts)
                        {
                            lockoutEndTime = DateTime.Now.AddSeconds(30); // 30 sec cooldown
                            MessageBox.Show("Too many failed attempts. Please try again after 30 seconds.");
                        }
                        else
                        {
                            int remainingAttempts = MaxLoginAttempts - loginAttempts;
                            MessageBox.Show($"Invalid credentials. {remainingAttempts} attempt(s) left.");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LoginDatabase.accdb;";
        OleDbConnection con;
        private void btnRegister_Click(object sender, EventArgs e)
        {


            string username = textBox4.Text;
            string password = txtRegisterPassword.Text;


            if (password.Length != 12 || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                MessageBox.Show("Password must be 12 characters and contain both uppercase and lowercase letters.");
                return;
            }


            using (OleDbConnection con = new OleDbConnection(conString))
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Login ([Username], [Password]) VALUES (?, ?)", con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Registration successful!");
                    this.Hide();
                    new LoginRegister().Show();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtRegisterPassword.UseSystemPasswordChar = !chkShowRegisterPassword.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtLoginPassword.UseSystemPasswordChar = !chkShowLoginPassword.Checked;
            
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
        }
    }
}
