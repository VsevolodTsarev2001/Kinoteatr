using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kinoteatr
{
    public partial class AdminForm : Form
    {
        private SqlConnection conn = null;
        private DataGridView infoPanel;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public AdminForm()
        {
            InitializeComponent();
            InitializeAdminForm();
        }

        private void InitializeAdminForm()
        {
            this.Text = "Admin Dashboard";
            this.Size = new Size(800, 640);
            this.BackColor = Color.FromArgb(34, 34, 34);

            Button btnViewUsers = new Button
            {
                Text = "View Users",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(40, 15),
                FlatStyle = FlatStyle.Flat
            };
            btnViewUsers.FlatAppearance.BorderSize = 0;
            btnViewUsers.Click += BtnViewUsers_Click;
            this.Controls.Add(btnViewUsers);

            Button btnViewBookings = new Button
            {
                Text = "View Bookings",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(40, 75),
                FlatStyle = FlatStyle.Flat
            };
            btnViewBookings.FlatAppearance.BorderSize = 0;
            btnViewBookings.Click += BtnViewBookings_Click;
            this.Controls.Add(btnViewBookings);

            Button btnViewMovies = new Button
            {
                Text = "View Movies",
                Font = new Font("Arial", 14),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(48, 48, 48),
                Size = new Size(200, 50),
                Location = new Point(40, 135),
                FlatStyle = FlatStyle.Flat
            };
            btnViewMovies.FlatAppearance.BorderSize = 0;
            btnViewMovies.Click += BtnViewMovies_Click;
            this.Controls.Add(btnViewMovies);

            Button btnSettings = new Button
            {
                Size = new Size(120, 70),
                Location = new Point(650, 15),
                FlatStyle = FlatStyle.Flat,

            };
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.Image = Image.FromFile(@"..\..\..\settings.png");
            btnSettings.Click += BtnSettings_Click;
            this.Controls.Add(btnSettings);

            infoPanel = new DataGridView
            {
                Size = new Size(770, 250),
                Location = new Point(5, 350),
                BackColor = Color.FromArgb(24, 24, 24)
            };
            this.Controls.Add(infoPanel);

            conn = DatabaseConnection.GetConnection();
        }

        private void BtnViewUsers_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Users";
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                infoPanel.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void BtnViewBookings_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Booking";
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                infoPanel.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void BtnViewMovies_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Movies";
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                infoPanel.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
           AdminSettingsForm ADS = new AdminSettingsForm();
            ADS.Show();
        }
    }
}