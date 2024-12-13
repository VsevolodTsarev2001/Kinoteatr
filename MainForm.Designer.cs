namespace Kinoteatr
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMovies;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MainForm";

            this.flowLayoutPanelMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // flowLayoutPanelMovies
            // 
            this.flowLayoutPanelMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMovies.AutoScroll = true;
            this.flowLayoutPanelMovies.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMovies.Name = "flowLayoutPanelMovies";
            this.flowLayoutPanelMovies.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanelMovies.TabIndex = 0;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelMovies);
            this.Name = "MainForm";
            this.Text = "RCinema";
            this.ResumeLayout(false);
        }

        #endregion
    }
}