using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace fitnesstrackerr
{
    public partial class Profile : Form
    {
        private string loggedInUsername;
        public Profile(string username)
        {
            InitializeComponent();
            loggedInUsername = username;

            textBox6.MaxLength = 10; // Contact No max 10 digits

            // Hook validation events
            textBox4.TextChanged += ValidateForm; // Name
            textBox3.TextChanged += ValidateForm; // Age
            textBox1.TextChanged += ValidateForm; // Email
            textBox6.TextChanged += ValidateForm; // Contact
            textBox5.TextChanged += ValidateForm; // Height
            textBox2.TextChanged += ValidateForm; // Weight
            comboBox1.SelectedIndexChanged += ValidateForm; // Gender
         
        }

        private void ValidateForm(object sender, EventArgs e)
        {
            bool isNameValid = !string.IsNullOrWhiteSpace(textBox4.Text);
            bool isAgeValid = int.TryParse(textBox3.Text, out int age) && age > 0 && age <= 120;

            // ✅ Email format using regex
            string email = textBox1.Text.Trim();
            bool isEmailValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            // ✅ Contact No - must be 10 digits
            bool isContactValid = long.TryParse(textBox6.Text, out long contact) && textBox6.Text.Length == 10;

            bool isHeightValid = double.TryParse(textBox5.Text, out double height) && height > 0;
            bool isWeightValid = double.TryParse(textBox2.Text, out double weight) && weight > 0;

            bool isGenderSelected = comboBox1.SelectedIndex != -1;

            // Final check
            btnRegister.Enabled = isNameValid && isAgeValid && isEmailValid && isContactValid
                && isHeightValid && isWeightValid && isGenderSelected;
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            string imagePath = @"C:\Users\Uday\OneDrive\Desktop\user.png";
            if (System.IO.File.Exists(imagePath))
            {
                Bitmap original = new Bitmap(Image.FromFile(imagePath));
                Bitmap inverted = InvertImage(original);
                pictureBox3.Image = inverted;
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
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (btnRegister.Enabled)
            {
                MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                if (string.IsNullOrWhiteSpace(textBox4.Text) ||    // Name
                string.IsNullOrWhiteSpace(textBox3.Text) ||    // Age
                string.IsNullOrWhiteSpace(textBox1.Text) ||    // Email
                string.IsNullOrWhiteSpace(textBox6.Text) ||    // Contact No
                string.IsNullOrWhiteSpace(textBox5.Text) ||    // Height
                string.IsNullOrWhiteSpace(textBox2.Text) ||    // Weight
                comboBox1.SelectedIndex == -1)                 // Gender
                {
                    MessageBox.Show("Please fill out all fields before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
        }
            private void HighlightEmptyFields()
        {
            // Helper method to highlight empty fields
            textBox4.BackColor = string.IsNullOrWhiteSpace(textBox4.Text) ? Color.Red : Color.White;
            textBox3.BackColor = string.IsNullOrWhiteSpace(textBox3.Text) ? Color.Red : Color.White;
            textBox1.BackColor = string.IsNullOrWhiteSpace(textBox1.Text) ? Color.Red : Color.White;
            textBox6.BackColor = string.IsNullOrWhiteSpace(textBox6.Text) ? Color.Red : Color.White;
            textBox5.BackColor = string.IsNullOrWhiteSpace(textBox5.Text) ? Color.Red : Color.White;
            textBox2.BackColor = string.IsNullOrWhiteSpace(textBox2.Text) ? Color.Red : Color.White;
            comboBox1.BackColor = comboBox1.SelectedIndex == -1 ? Color.Red : Color.White;
        }
        
    }
}

