namespace KinoRudnev
{
    partial class FilmInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFilm = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPlacesCount = new System.Windows.Forms.Label();
            this.PlacesNumeric = new System.Windows.Forms.NumericUpDown();
            this.pbdeadpool2 = new System.Windows.Forms.Label();
            this.dateTimeSeans = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoosePlace = new System.Windows.Forms.Button();
            this.listBoxTimes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFilmDuration = new System.Windows.Forms.Label();
            this.lblAvailablePlaces = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlacesNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilm
            // 
            this.lblFilm.AutoSize = true;
            this.lblFilm.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblFilm.Location = new System.Drawing.Point(189, 181);
            this.lblFilm.Name = "lblFilm";
            this.lblFilm.Size = new System.Drawing.Size(20, 22);
            this.lblFilm.TabIndex = 0;
            this.lblFilm.Text = ".";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInfo.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblInfo.Location = new System.Drawing.Point(187, 131);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(259, 28);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Информация о сеансе";
            // 
            // lblPlacesCount
            // 
            this.lblPlacesCount.AutoSize = true;
            this.lblPlacesCount.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblPlacesCount.Location = new System.Drawing.Point(189, 227);
            this.lblPlacesCount.Name = "lblPlacesCount";
            this.lblPlacesCount.Size = new System.Drawing.Size(20, 22);
            this.lblPlacesCount.TabIndex = 2;
            this.lblPlacesCount.Text = ".";
            // 
            // PlacesNumeric
            // 
            this.PlacesNumeric.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.PlacesNumeric.Location = new System.Drawing.Point(430, 558);
            this.PlacesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PlacesNumeric.Name = "PlacesNumeric";
            this.PlacesNumeric.Size = new System.Drawing.Size(120, 36);
            this.PlacesNumeric.TabIndex = 13;
            this.PlacesNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pbdeadpool2
            // 
            this.pbdeadpool2.AutoSize = true;
            this.pbdeadpool2.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.pbdeadpool2.Location = new System.Drawing.Point(188, 560);
            this.pbdeadpool2.Name = "pbdeadpool2";
            this.pbdeadpool2.Size = new System.Drawing.Size(223, 29);
            this.pbdeadpool2.TabIndex = 12;
            this.pbdeadpool2.Tag = "dasdas";
            this.pbdeadpool2.Text = "Количество мест";
            // 
            // dateTimeSeans
            // 
            this.dateTimeSeans.Location = new System.Drawing.Point(347, 351);
            this.dateTimeSeans.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dateTimeSeans.Name = "dateTimeSeans";
            this.dateTimeSeans.Size = new System.Drawing.Size(200, 20);
            this.dateTimeSeans.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label1.Location = new System.Drawing.Point(186, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Сеанс";
            // 
            // btnChoosePlace
            // 
            this.btnChoosePlace.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnChoosePlace.Location = new System.Drawing.Point(390, 631);
            this.btnChoosePlace.Name = "btnChoosePlace";
            this.btnChoosePlace.Size = new System.Drawing.Size(160, 41);
            this.btnChoosePlace.TabIndex = 16;
            this.btnChoosePlace.Text = "Далее";
            this.btnChoosePlace.UseVisualStyleBackColor = true;
            // 
            // listBoxTimes
            // 
            this.listBoxTimes.FormattingEnabled = true;
            this.listBoxTimes.Location = new System.Drawing.Point(347, 401);
            this.listBoxTimes.Name = "listBoxTimes";
            this.listBoxTimes.Size = new System.Drawing.Size(200, 121);
            this.listBoxTimes.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 18.25F);
            this.label2.Location = new System.Drawing.Point(188, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Время";
            // 
            // lblFilmDuration
            // 
            this.lblFilmDuration.AutoSize = true;
            this.lblFilmDuration.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblFilmDuration.Location = new System.Drawing.Point(189, 313);
            this.lblFilmDuration.Name = "lblFilmDuration";
            this.lblFilmDuration.Size = new System.Drawing.Size(20, 22);
            this.lblFilmDuration.TabIndex = 19;
            this.lblFilmDuration.Text = ".";
            // 
            // lblAvailablePlaces
            // 
            this.lblAvailablePlaces.AutoSize = true;
            this.lblAvailablePlaces.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.lblAvailablePlaces.Location = new System.Drawing.Point(189, 272);
            this.lblAvailablePlaces.Name = "lblAvailablePlaces";
            this.lblAvailablePlaces.Size = new System.Drawing.Size(20, 22);
            this.lblAvailablePlaces.TabIndex = 20;
            this.lblAvailablePlaces.Text = ".";
            // 
            // FilmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(655, 692);
            this.Controls.Add(this.lblAvailablePlaces);
            this.Controls.Add(this.lblFilmDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxTimes);
            this.Controls.Add(this.btnChoosePlace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeSeans);
            this.Controls.Add(this.PlacesNumeric);
            this.Controls.Add(this.pbdeadpool2);
            this.Controls.Add(this.lblPlacesCount);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblFilm);
            this.Name = "FilmInfo";
            this.Text = "FilmInfo";
            ((System.ComponentModel.ISupportInitialize)(this.PlacesNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilm;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPlacesCount;
        private System.Windows.Forms.NumericUpDown PlacesNumeric;
        private System.Windows.Forms.Label pbdeadpool2;
        private System.Windows.Forms.DateTimePicker dateTimeSeans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChoosePlace;
        private System.Windows.Forms.ListBox listBoxTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFilmDuration;
        private System.Windows.Forms.Label lblAvailablePlaces;
    }
}