namespace YesAndYes
{
    partial class FrmCompany
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
            this.gbName = new System.Windows.Forms.GroupBox();
            this.btnRights = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.gv = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.ErrName = new System.Windows.Forms.ErrorProvider(this.components);
            this.ErrCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.gbName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.btnRights);
            this.gbName.Controls.Add(this.btnView);
            this.gbName.Controls.Add(this.btnReset);
            this.gbName.Controls.Add(this.btnSave);
            this.gbName.Controls.Add(this.chkIsActive);
            this.gbName.Controls.Add(this.txtName);
            this.gbName.Controls.Add(this.txtCode);
            this.gbName.Controls.Add(this.lblName);
            this.gbName.Controls.Add(this.lblCode);
            this.gbName.Location = new System.Drawing.Point(12, 45);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(641, 145);
            this.gbName.TabIndex = 0;
            this.gbName.TabStop = false;
            this.gbName.Text = "Company Type";
            // 
            // btnRights
            // 
            this.btnRights.Location = new System.Drawing.Point(399, 106);
            this.btnRights.Name = "btnRights";
            this.btnRights.Size = new System.Drawing.Size(75, 23);
            this.btnRights.TabIndex = 10;
            this.btnRights.Text = "Rights";
            this.btnRights.UseVisualStyleBackColor = true;
            this.btnRights.Click += new System.EventHandler(this.btnRights_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(317, 106);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(235, 106);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(480, 32);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(69, 24);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(157, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(392, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(157, 36);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(70, 77);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(70, 43);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Location = new System.Drawing.Point(12, 210);
            this.gv.MultiSelect = false;
            this.gv.Name = "gv";
            this.gv.ReadOnly = true;
            this.gv.ShowEditingIcon = false;
            this.gv.Size = new System.Drawing.Size(641, 222);
            this.gv.TabIndex = 3;
            this.gv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_CellDoubleClick);
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(666, 30);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "lblHeader";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ErrName
            // 
            this.ErrName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.ErrName.ContainerControl = this;
            // 
            // ErrCode
            // 
            this.ErrCode.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.ErrCode.ContainerControl = this;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(412, 210);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 5;
            this.lblID.Visible = false;
            // 
            // FrmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 452);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gv);
            this.Controls.Add(this.gbName);
            this.Name = "FrmCompany";
            this.Text = "FrmCompany";
            this.Load += new System.EventHandler(this.FrmCompany_Load);
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnRights;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ErrorProvider ErrName;
        private System.Windows.Forms.ErrorProvider ErrCode;
        private System.Windows.Forms.Label lblID;
    }
}