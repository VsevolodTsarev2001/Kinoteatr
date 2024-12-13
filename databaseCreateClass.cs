using System;
using System.Data.SqlClient;
using System.Windows.Forms; 

namespace Kinoteatr
{
    internal class DatabaseCreateClass
    {
        public void CreateDatabase()
        {
            SqlConnection conn = null;
            try
            {
                    conn = DatabaseConnection.GetConnection();
                    conn.Open();

                    string createTablesQuery = @"
                    -- Create 'Users' table if it does not exist
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Users' AND xtype = 'U')
                    BEGIN
                        CREATE TABLE Users (
                            UserID INT NOT NULL IDENTITY(1,1),  
                            Username NVARCHAR(20) NOT NULL,
                            Email NVARCHAR(255) NOT NULL,  
                            Password NVARCHAR(255) NOT NULL,  
                            Role NVARCHAR(20) NOT NULL,
                            CONSTRAINT Users_pk PRIMARY KEY (UserID)
                        );
                    END

                    -- Create 'Movies' table if it does not exist
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Movies' AND xtype = 'U')
                    BEGIN
                        CREATE TABLE Movies (
                            MovieID INT NOT NULL IDENTITY(1,1),  
                            Title NVARCHAR(50) NOT NULL,
                            Genre NVARCHAR(50) NOT NULL,
                            Description NVARCHAR(255) NOT NULL, 
                            ReleaseDate DATETIME NOT NULL, 
                            Duration INT NOT NULL,
                            Rating FLOAT NOT NULL,
                            CONSTRAINT Movies_pk PRIMARY KEY (MovieID)
                        );
                    END

                    -- Create 'Seats' table if it does not exist
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Seats' AND xtype = 'U')
                    BEGIN
                        CREATE TABLE Seats (
                            SeatID INT NOT NULL IDENTITY(1,1), 
                            MovieID INT NOT NULL,
                            Row INT NOT NULL,
                            SeatNumber INT NOT NULL,
                            IsBooked INT NOT NULL,
                            CONSTRAINT Seats_pk PRIMARY KEY (SeatID),
                            CONSTRAINT Seats_Movies FOREIGN KEY (MovieID) REFERENCES Movies (MovieID)
                        );
                    END

                    -- Create 'Booking' table if it does not exist
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Booking' AND xtype = 'U')
                    BEGIN
                        CREATE TABLE Booking (
                            BookingID INT NOT NULL IDENTITY(1,1), 
                            UserID INT NOT NULL,
                            MovieID INT NOT NULL,
                            SeatNumber INT NOT NULL,  
                            BookingDate DATETIME NOT NULL,
                            CONSTRAINT Booking_pk PRIMARY KEY (BookingID),
                            CONSTRAINT Booking_Movies FOREIGN KEY (MovieID) REFERENCES Movies (MovieID),
                            CONSTRAINT Booking_Users FOREIGN KEY (UserID) REFERENCES Users (UserID)
                        );
                            
                        -- INSERT INTO Users (Username,Email,Password,Role)
                        -- VALUES ('admin','admin@example',1234,'Admin')

                    END
                    ";

                    using (SqlCommand cmd = new SqlCommand(createTablesQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga andmebaasi või tabeli loomisel: " + ex.Message);
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
