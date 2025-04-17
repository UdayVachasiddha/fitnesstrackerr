using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace fitnesstrackerr
{
    public partial class Goal : Form
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Uday\OneDrive\Desktop\LoginDatabase.accdb;";
        OleDbConnection conn;
        private string username; // store username

        public Goal(string loggedInUsername)
        {
            InitializeComponent();
            username = loggedInUsername;
        }

        private void Goal_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter your calorie goal.");
                return;
            }

            using (OleDbConnection con = new OleDbConnection(connString))

                try
            {
                int calorieGoal = int.Parse(textBox4.Text);

                    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Uday\OneDrive\Desktop\LoginDatabase.accdb");

                conn.Open();
                OleDbCommand command = new OleDbCommand("INSERT INTO Goal (CalorieGoal) VALUES (?)", conn);

                // Use logged in UserID here (assuming 1 for now)
                command.Parameters.AddWithValue("?", calorieGoal);            

                command.ExecuteNonQuery();
                

                MessageBox.Show("Goal set successfully!");

                // Navigate to Activity page
                Activity activityForm = new Activity(username);
                activityForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
