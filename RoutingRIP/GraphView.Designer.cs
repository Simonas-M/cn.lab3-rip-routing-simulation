using System;
using System.Windows.Forms;

namespace RoutingRIP
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
            this.graphImage = new System.Windows.Forms.PictureBox();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnDeleteLink = new System.Windows.Forms.Button();
            this.BtnDeleteNode = new System.Windows.Forms.Button();
            this.BtnAddLink = new System.Windows.Forms.Button();
            this.BtnAddNode = new System.Windows.Forms.Button();
            this.TxtNode = new System.Windows.Forms.TextBox();
            this.LblNode = new System.Windows.Forms.Label();
            this.LblLink = new System.Windows.Forms.Label();
            this.TxtLinkFrom = new System.Windows.Forms.TextBox();
            this.TxtLinkTo = new System.Windows.Forms.TextBox();
            this.TxtTable = new System.Windows.Forms.TextBox();
            this.BtnTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphImage)).BeginInit();
            this.SuspendLayout();
            // 
            // graphImage
            // 
            this.graphImage.Location = new System.Drawing.Point(12, 12);
            this.graphImage.Name = "graphImage";
            this.graphImage.Size = new System.Drawing.Size(500, 500);
            this.graphImage.TabIndex = 0;
            this.graphImage.TabStop = false;
            // 
            // BtnNext
            // 
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnNext.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BtnNext.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnNext.Location = new System.Drawing.Point(519, 12);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(233, 70);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.Text = "NEXT";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            this.BtnNext.Click += new System.EventHandler(this.GraphUpdated);
            // 
            // BtnDeleteLink
            // 
            this.BtnDeleteLink.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BtnDeleteLink.Location = new System.Drawing.Point(636, 475);
            this.BtnDeleteLink.Name = "BtnDeleteLink";
            this.BtnDeleteLink.Size = new System.Drawing.Size(116, 35);
            this.BtnDeleteLink.TabIndex = 2;
            this.BtnDeleteLink.Text = "Delete";
            this.BtnDeleteLink.UseVisualStyleBackColor = true;
            this.BtnDeleteLink.Click += new System.EventHandler(this.BtnDeleteLink_Click);
            // 
            // BtnDeleteNode
            // 
            this.BtnDeleteNode.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BtnDeleteNode.Location = new System.Drawing.Point(636, 365);
            this.BtnDeleteNode.Name = "BtnDeleteNode";
            this.BtnDeleteNode.Size = new System.Drawing.Size(116, 35);
            this.BtnDeleteNode.TabIndex = 2;
            this.BtnDeleteNode.Text = "Delete";
            this.BtnDeleteNode.UseVisualStyleBackColor = true;
            this.BtnDeleteNode.Click += new System.EventHandler(this.BtnDeleteNode_Click);
            // 
            // BtnAddLink
            // 
            this.BtnAddLink.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BtnAddLink.Location = new System.Drawing.Point(636, 434);
            this.BtnAddLink.Name = "BtnAddLink";
            this.BtnAddLink.Size = new System.Drawing.Size(116, 35);
            this.BtnAddLink.TabIndex = 2;
            this.BtnAddLink.Text = "Add";
            this.BtnAddLink.UseVisualStyleBackColor = true;
            this.BtnAddLink.Click += new System.EventHandler(this.BtnAddLink_Click);
            // 
            // BtnAddNode
            // 
            this.BtnAddNode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnAddNode.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BtnAddNode.Location = new System.Drawing.Point(519, 365);
            this.BtnAddNode.Name = "BtnAddNode";
            this.BtnAddNode.Size = new System.Drawing.Size(116, 35);
            this.BtnAddNode.TabIndex = 2;
            this.BtnAddNode.Text = "Add";
            this.BtnAddNode.UseVisualStyleBackColor = true;
            this.BtnAddNode.Click += new System.EventHandler(this.BtnAddNode_Click);
            // 
            // TxtNode
            // 
            this.TxtNode.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TxtNode.Location = new System.Drawing.Point(519, 324);
            this.TxtNode.Name = "TxtNode";
            this.TxtNode.Size = new System.Drawing.Size(233, 36);
            this.TxtNode.TabIndex = 3;
            this.TxtNode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtNode_MouseClick);
            this.TxtNode.Leave += new System.EventHandler(this.TxtNode_Leave);
            // 
            // LblNode
            // 
            this.LblNode.AutoSize = true;
            this.LblNode.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LblNode.Location = new System.Drawing.Point(519, 293);
            this.LblNode.Name = "LblNode";
            this.LblNode.Size = new System.Drawing.Size(70, 24);
            this.LblNode.TabIndex = 4;
            this.LblNode.Text = "Node:";
            // 
            // LblLink
            // 
            this.LblLink.AutoSize = true;
            this.LblLink.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.LblLink.Location = new System.Drawing.Point(519, 403);
            this.LblLink.Name = "LblLink";
            this.LblLink.Size = new System.Drawing.Size(70, 24);
            this.LblLink.TabIndex = 4;
            this.LblLink.Text = "Link:";
            // 
            // TxtLinkFrom
            // 
            this.TxtLinkFrom.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TxtLinkFrom.Location = new System.Drawing.Point(519, 434);
            this.TxtLinkFrom.Name = "TxtLinkFrom";
            this.TxtLinkFrom.Size = new System.Drawing.Size(116, 36);
            this.TxtLinkFrom.TabIndex = 3;
            this.TxtLinkFrom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtLinkFrom_MouseClick);
            this.TxtLinkFrom.Leave += new System.EventHandler(this.TxtLinkFrom_Leave);
            // 
            // TxtLinkTo
            // 
            this.TxtLinkTo.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TxtLinkTo.Location = new System.Drawing.Point(519, 475);
            this.TxtLinkTo.Name = "TxtLinkTo";
            this.TxtLinkTo.Size = new System.Drawing.Size(116, 36);
            this.TxtLinkTo.TabIndex = 3;
            this.TxtLinkTo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtLinkTo_MouseClick);
            this.TxtLinkTo.Leave += new System.EventHandler(this.TxtLinkTo_Leave);
            // 
            // TxtTable
            // 
            this.TxtTable.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TxtTable.Location = new System.Drawing.Point(518, 88);
            this.TxtTable.Name = "TxtTable";
            this.TxtTable.Size = new System.Drawing.Size(128, 36);
            this.TxtTable.TabIndex = 3;
            this.TxtTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtTable_MouseClick);
            this.TxtTable.Leave += new System.EventHandler(this.TxtTable_Leave);
            // 
            // BtnTable
            // 
            this.BtnTable.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BtnTable.Location = new System.Drawing.Point(652, 89);
            this.BtnTable.Name = "BtnTable";
            this.BtnTable.Size = new System.Drawing.Size(100, 35);
            this.BtnTable.TabIndex = 2;
            this.BtnTable.Text = "Show routing table";
            this.BtnTable.UseVisualStyleBackColor = true;
            this.BtnTable.Click += new System.EventHandler(this.BtnTable_Click);
            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 522);
            this.Controls.Add(this.LblLink);
            this.Controls.Add(this.LblNode);
            this.Controls.Add(this.TxtLinkTo);
            this.Controls.Add(this.TxtTable);
            this.Controls.Add(this.TxtLinkFrom);
            this.Controls.Add(this.TxtNode);
            this.Controls.Add(this.BtnAddNode);
            this.Controls.Add(this.BtnTable);
            this.Controls.Add(this.BtnAddLink);
            this.Controls.Add(this.BtnDeleteNode);
            this.Controls.Add(this.BtnDeleteLink);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.graphImage);
            this.Name = "GraphView";
            this.Text = "GraphView";
            ((System.ComponentModel.ISupportInitialize)(this.graphImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphImage;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnDeleteLink;
        private System.Windows.Forms.Button BtnDeleteNode;
        private System.Windows.Forms.Button BtnAddLink;
        private System.Windows.Forms.Button BtnAddNode;
        private System.Windows.Forms.TextBox TxtNode;
        private System.Windows.Forms.Label LblNode;
        private System.Windows.Forms.Label LblLink;
        private System.Windows.Forms.TextBox TxtLinkFrom;
        private System.Windows.Forms.TextBox TxtLinkTo;
        private TextBox TxtTable;
        private Button BtnTable;
    }
}