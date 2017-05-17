namespace RoutingRIP
{
    partial class RoutingTableView
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
            this.RTable = new System.Windows.Forms.DataGridView();
            this.Hops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Through = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RTable)).BeginInit();
            this.SuspendLayout();
            // 
            // RTable
            // 
            this.RTable.AllowUserToAddRows = false;
            this.RTable.AllowUserToDeleteRows = false;
            this.RTable.AllowUserToResizeColumns = false;
            this.RTable.AllowUserToResizeRows = false;
            this.RTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.RTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hops,
            this.To,
            this.Through});
            this.RTable.Location = new System.Drawing.Point(12, 12);
            this.RTable.Name = "RTable";
            this.RTable.ReadOnly = true;
            this.RTable.RowHeadersVisible = false;
            this.RTable.Size = new System.Drawing.Size(181, 237);
            this.RTable.TabIndex = 0;
            // 
            // Hops
            // 
            this.Hops.HeaderText = "Hops";
            this.Hops.Name = "Hops";
            this.Hops.ReadOnly = true;
            this.Hops.Width = 55;
            // 
            // To
            // 
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            this.To.Width = 43;
            // 
            // Through
            // 
            this.Through.HeaderText = "Through";
            this.Through.Name = "Through";
            this.Through.ReadOnly = true;
            this.Through.Width = 70;
            // 
            // RoutingTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 261);
            this.Controls.Add(this.RTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RoutingTableView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoutingTableView";
            ((System.ComponentModel.ISupportInitialize)(this.RTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hops;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Through;
    }
}