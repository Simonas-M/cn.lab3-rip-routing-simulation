﻿namespace RoutingRIP
{
    partial class GraphView
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
            this.centedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.centedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // centedImage
            // 
            this.centedImage.Location = new System.Drawing.Point(12, 12);
            this.centedImage.Name = "centedImage";
            this.centedImage.Size = new System.Drawing.Size(560, 417);
            this.centedImage.TabIndex = 0;
            this.centedImage.TabStop = false;
            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.centedImage);
            this.Name = "GraphView";
            this.Text = "GraphView";
            ((System.ComponentModel.ISupportInitialize)(this.centedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox centedImage;
    }
}