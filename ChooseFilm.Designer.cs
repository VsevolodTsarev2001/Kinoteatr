namespace KinoRudnev
{
    partial class numericPlaces
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(numericPlaces));
            this.btnChoosePlace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChoosePlace
            // 
            this.btnChoosePlace.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnChoosePlace.Location = new System.Drawing.Point(1073, 707);
            this.btnChoosePlace.Name = "btnChoosePlace";
            this.btnChoosePlace.Size = new System.Drawing.Size(160, 41);
            this.btnChoosePlace.TabIndex = 0;
            this.btnChoosePlace.Text = "Далее";
            this.btnChoosePlace.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 28.25F);
            this.label1.Location = new System.Drawing.Point(492, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 45);
            this.label1.TabIndex = 2;
            this.label1.Tag = "asdasd";
            this.label1.Text = "Выберите фильм";
            // 
            // numericPlaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 774);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChoosePlace);
            this.Name = "numericPlaces";
            this.Text = "Выберите фильм";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoosePlace;
        private System.Windows.Forms.Label label1;
    }
}