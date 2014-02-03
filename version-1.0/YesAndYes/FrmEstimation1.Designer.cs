namespace YesAndYes
{
    partial class FrmEstimation1
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
            this.components = new System.ComponentModel.Container();
            this.ItemTemplate = new Microsoft.VisualBasic.PowerPacks.DataRepeaterItem();
            this.pEstimation = new System.Windows.Forms.Panel();
            this.dgvEstimation = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.tbUnits = new System.Windows.Forms.TextBox();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorUnits = new System.Windows.Forms.ErrorProvider(this.components);
            this.ErrorRate = new System.Windows.Forms.ErrorProvider(this.components);
            this.ErrorQuality = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnRights = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pEstimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemTemplate
            // 
            this.ItemTemplate.Size = new System.Drawing.Size(232, 100);
            // 
            // pEstimation
            // 
            this.pEstimation.Controls.Add(this.btnRights);
            this.pEstimation.Controls.Add(this.btnView);
            this.pEstimation.Controls.Add(this.btnReset);
            this.pEstimation.Controls.Add(this.btnSave);
            this.pEstimation.Controls.Add(this.dgvEstimation);
            this.pEstimation.Controls.Add(this.button1);
            this.pEstimation.Controls.Add(this.tbRate);
            this.pEstimation.Controls.Add(this.tbUnits);
            this.pEstimation.Controls.Add(this.label1);
            this.pEstimation.Controls.Add(this.cbQuality);
            this.pEstimation.Controls.Add(this.label2);
            this.pEstimation.Controls.Add(this.label3);
            this.pEstimation.Location = new System.Drawing.Point(5, 33);
            this.pEstimation.Name = "pEstimation";
            this.pEstimation.Size = new System.Drawing.Size(751, 377);
            this.pEstimation.TabIndex = 0;
            // 
            // dgvEstimation
            // 
            this.dgvEstimation.AllowUserToAddRows = false;
            this.dgvEstimation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstimation.Location = new System.Drawing.Point(299, 21);
            this.dgvEstimation.Name = "dgvEstimation";
            this.dgvEstimation.ReadOnly = true;
            this.dgvEstimation.Size = new System.Drawing.Size(330, 161);
            this.dgvEstimation.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(140, 117);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(100, 20);
            this.tbRate.TabIndex = 6;
            // 
            // tbUnits
            // 
            this.tbUnits.Location = new System.Drawing.Point(140, 83);
            this.tbUnits.Name = "tbUnits";
            this.tbUnits.Size = new System.Drawing.Size(100, 20);
            this.tbUnits.TabIndex = 5;
            // 
            // cbQuality
            // 
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "Type 1",
            "Type 2",
            "Type 3",
            "Type 4"});
            this.cbQuality.Location = new System.Drawing.Point(140, 45);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(121, 21);
            this.cbQuality.TabIndex = 4;
            this.cbQuality.Text = "Type 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rate/Units";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Units";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quality";
            // 
            // ErrorUnits
            // 
            this.ErrorUnits.ContainerControl = this;
            // 
            // ErrorRate
            // 
            this.ErrorRate.ContainerControl = this;
            // 
            // ErrorQuality
            // 
            this.ErrorQuality.ContainerControl = this;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(764, 30);
            this.lblHeader.TabIndex = 5;
            this.lblHeader.Text = "lblHeader";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRights
            // 
            this.btnRights.Location = new System.Drawing.Point(545, 188);
            this.btnRights.Name = "btnRights";
            this.btnRights.Size = new System.Drawing.Size(75, 23);
            this.btnRights.TabIndex = 14;
            this.btnRights.Text = "Rights";
            this.btnRights.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(463, 188);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(381, 188);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 188);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmEstimation1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 610);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pEstimation);
            this.Name = "FrmEstimation1";
            this.Text = "FrmEstimation1";
            this.Load += new System.EventHandler(this.FrmEstimation1_Load);
            this.pEstimation.ResumeLayout(false);
            this.pEstimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeaterItem ItemTemplate;
        private System.Windows.Forms.Panel pEstimation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.TextBox tbUnits;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider ErrorUnits;
        private System.Windows.Forms.ErrorProvider ErrorRate;
        private System.Windows.Forms.DataGridView dgvEstimation;
        private System.Windows.Forms.ErrorProvider ErrorQuality;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnRights;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
    }
}