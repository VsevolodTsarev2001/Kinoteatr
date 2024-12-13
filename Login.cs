using System.Data.SqlClient;
using System.Text;

namespace Kinoteatr
{
    public partial class Login : Form
    {
        SqlConnection conn = null;

        private TextBox usernameTextBox, passwordTextBox;
        private Label titleLabel, usernameLabel, passwordLabel;
        private Button decorativeLine, loginButton;
        private Panel gridPanel;

        public Login()
        {
            InitializeComponent();
            CreateDatabaseIfNotExist();
            CustomizeDesign();
        }

        private void CreateDatabaseIfNotExist()
        {
            DatabaseCreateClass db = new DatabaseCreateClass();
            db.CreateDatabase();
        }

        private void CustomizeDesign()
        {
            Text = "Login";
            ClientSize = new Size(600, 400);
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(34, 34, 34);

            titleLabel = new Label
            {
                Text = "LOGIN",
                Font = new Font("Courier New", 32, FontStyle.Bold),
                ForeColor = Color.Lime,
                AutoSize = true,
                Location = new Point(ClientSize.Width / 2 - 80, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(titleLabel);

            usernameLabel = new Label
            {
                Text = "USERNAME:",
                Font = new Font("Courier New", 14, FontStyle.Bold),
                ForeColor = Color.Lime,
                AutoSize = true,
                Location = new Point(50, 100)
            };
            Controls.Add(usernameLabel);

            usernameTextBox = new TextBox
            {
                Font = new Font("Courier New", 14, FontStyle.Bold),
                BackColor = Color.Black,
                ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(50, 130),
                Width = ClientSize.Width - 100,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            Controls.Add(usernameTextBox);

            passwordLabel = new Label
            {
                Text = "PASSWORD:",
                Font = new Font("Courier New", 14, FontStyle.Bold),
                ForeColor = Color.Lime,
                AutoSize = true,
                Location = new Point(50, 180)
            };
            Controls.Add(passwordLabel);

            passwordTextBox = new TextBox
            {
                Font = new Font("Courier New", 14, FontStyle.Bold),
                BackColor = Color.Black,
                ForeColor = Color.Lime,
                BorderStyle = BorderStyle.FixedSingle,
                PasswordChar = '*',
                Location = new Point(50, 210),
                Width = ClientSize.Width - 100,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            Controls.Add(passwordTextBox);

            decorativeLine = new Button
            {
                Text = "Create account",
                Font = new Font("Courier New", 12),
                ForeColor = Color.Lime,
                AutoSize = true,
                Location = new Point(50, 260),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            decorativeLine.Click += DecorativeLine_Click;
            this.Controls.Add(decorativeLine);

            loginButton = new Button
            {
                Text = "LOGIN",
                Font = new Font("Courier New", 14, FontStyle.Bold),
                BackColor = Color.Lime,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 320),
                Width = 200,
                Height = 50,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom
            };
            loginButton.FlatAppearance.BorderSize = 1;
            loginButton.Click += LoginButton_Click;
            this.Controls.Add(loginButton);

            gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Tile
            };
            this.Controls.Add(gridPanel);
            gridPanel.SendToBack();
        }

        private void DecorativeLine_Click(object? sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.ShowDialog();
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();

                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        if (role == "Admin")
                        {
                            AdminForm adminForm = new AdminForm();
                            adminForm.Show();
                        }
                        else
                        {
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}