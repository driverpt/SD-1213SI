namespace Client
{
    partial class JobManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobManager));
            this._tlp_Form = new System.Windows.Forms.TableLayoutPanel();
            this._lbl_Command = new System.Windows.Forms.Label();
            this._txb_Command = new System.Windows.Forms.TextBox();
            this._btn_Exec = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._dgv_Jobs = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bsrc_Jobs = new System.Windows.Forms.BindingSource(this.components);
            this._tstrip_Jobs = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsb_RefreshAll = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this._txb_Output = new System.Windows.Forms.TextBox();
            this._tstrip_Output = new System.Windows.Forms.ToolStrip();
            this._tsl_Output = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._tsb_Clear = new System.Windows.Forms.ToolStripButton();
            this._tlp_Form.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv_Jobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsrc_Jobs)).BeginInit();
            this._tstrip_Jobs.SuspendLayout();
            this.panel2.SuspendLayout();
            this._tstrip_Output.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlp_Form
            // 
            this._tlp_Form.ColumnCount = 3;
            this._tlp_Form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tlp_Form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlp_Form.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tlp_Form.Controls.Add(this._lbl_Command, 0, 0);
            this._tlp_Form.Controls.Add(this._txb_Command, 1, 0);
            this._tlp_Form.Controls.Add(this._btn_Exec, 2, 0);
            this._tlp_Form.Controls.Add(this.panel1, 0, 1);
            this._tlp_Form.Controls.Add(this.panel2, 0, 2);
            this._tlp_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlp_Form.Location = new System.Drawing.Point(0, 0);
            this._tlp_Form.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._tlp_Form.Name = "_tlp_Form";
            this._tlp_Form.RowCount = 3;
            this._tlp_Form.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tlp_Form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlp_Form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tlp_Form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlp_Form.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlp_Form.Size = new System.Drawing.Size(884, 666);
            this._tlp_Form.TabIndex = 0;
            // 
            // _lbl_Command
            // 
            this._lbl_Command.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lbl_Command.AutoSize = true;
            this._lbl_Command.Location = new System.Drawing.Point(3, 9);
            this._lbl_Command.Name = "_lbl_Command";
            this._lbl_Command.Size = new System.Drawing.Size(100, 25);
            this._lbl_Command.TabIndex = 4;
            this._lbl_Command.Text = "Command:";
            // 
            // _txb_Command
            // 
            this._txb_Command.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._txb_Command.Location = new System.Drawing.Point(109, 6);
            this._txb_Command.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txb_Command.Name = "_txb_Command";
            this._txb_Command.Size = new System.Drawing.Size(645, 30);
            this._txb_Command.TabIndex = 1;
            // 
            // _btn_Exec
            // 
            this._btn_Exec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_Exec.AutoSize = true;
            this._btn_Exec.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._btn_Exec.Location = new System.Drawing.Point(760, 4);
            this._btn_Exec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btn_Exec.Name = "_btn_Exec";
            this._btn_Exec.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this._btn_Exec.Size = new System.Drawing.Size(121, 35);
            this._btn_Exec.TabIndex = 2;
            this._btn_Exec.Text = "Execute";
            this._btn_Exec.UseVisualStyleBackColor = true;
            this._btn_Exec.Click += new System.EventHandler(this._btn_Exec_Click);
            // 
            // panel1
            // 
            this._tlp_Form.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this._dgv_Jobs);
            this.panel1.Controls.Add(this._tstrip_Jobs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 305);
            this.panel1.TabIndex = 7;
            // 
            // _dgv_Jobs
            // 
            this._dgv_Jobs.AllowUserToAddRows = false;
            this._dgv_Jobs.AllowUserToDeleteRows = false;
            this._dgv_Jobs.AllowUserToOrderColumns = true;
            this._dgv_Jobs.AutoGenerateColumns = false;
            this._dgv_Jobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._dgv_Jobs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._dgv_Jobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgv_Jobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this._dgv_Jobs.DataSource = this._bsrc_Jobs;
            this._dgv_Jobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgv_Jobs.Location = new System.Drawing.Point(0, 32);
            this._dgv_Jobs.Name = "_dgv_Jobs";
            this._dgv_Jobs.ReadOnly = true;
            this._dgv_Jobs.RowTemplate.Height = 24;
            this._dgv_Jobs.Size = new System.Drawing.Size(878, 273);
            this._dgv_Jobs.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Executable";
            this.dataGridViewTextBoxColumn1.HeaderText = "Executable";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Arguments";
            this.dataGridViewTextBoxColumn2.HeaderText = "Arguments";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn3.HeaderText = "Status";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // _bsrc_Jobs
            // 
            this._bsrc_Jobs.DataSource = typeof(Client.JobAdapter);
            // 
            // _tstrip_Jobs
            // 
            this._tstrip_Jobs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._tstrip_Jobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this._tsb_RefreshAll});
            this._tstrip_Jobs.Location = new System.Drawing.Point(0, 0);
            this._tstrip_Jobs.Name = "_tstrip_Jobs";
            this._tstrip_Jobs.Size = new System.Drawing.Size(878, 32);
            this._tstrip_Jobs.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(134, 29);
            this.toolStripLabel1.Text = "Submitted jobs";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // _tsb_RefreshAll
            // 
            this._tsb_RefreshAll.Image = ((System.Drawing.Image)(resources.GetObject("_tsb_RefreshAll.Image")));
            this._tsb_RefreshAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsb_RefreshAll.Name = "_tsb_RefreshAll";
            this._tsb_RefreshAll.Size = new System.Drawing.Size(201, 29);
            this._tsb_RefreshAll.Text = "Refresh pending jobs";
            this._tsb_RefreshAll.Click += new System.EventHandler(this._tsb_RefreshAll_Click);
            // 
            // panel2
            // 
            this._tlp_Form.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this._txb_Output);
            this.panel2.Controls.Add(this._tstrip_Output);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 306);
            this.panel2.TabIndex = 9;
            // 
            // _txb_Output
            // 
            this._txb_Output.BackColor = System.Drawing.Color.White;
            this._txb_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txb_Output.Location = new System.Drawing.Point(0, 32);
            this._txb_Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txb_Output.Multiline = true;
            this._txb_Output.Name = "_txb_Output";
            this._txb_Output.ReadOnly = true;
            this._txb_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txb_Output.Size = new System.Drawing.Size(878, 274);
            this._txb_Output.TabIndex = 4;
            // 
            // _tstrip_Output
            // 
            this._tstrip_Output.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._tstrip_Output.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsl_Output,
            this.toolStripSeparator2,
            this._tsb_Clear});
            this._tstrip_Output.Location = new System.Drawing.Point(0, 0);
            this._tstrip_Output.Name = "_tstrip_Output";
            this._tstrip_Output.Size = new System.Drawing.Size(878, 32);
            this._tstrip_Output.TabIndex = 8;
            this._tstrip_Output.Text = "toolStrip1";
            // 
            // _tsl_Output
            // 
            this._tsl_Output.Name = "_tsl_Output";
            this._tsl_Output.Size = new System.Drawing.Size(69, 29);
            this._tsl_Output.Text = "Output";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // _tsb_Clear
            // 
            this._tsb_Clear.Image = ((System.Drawing.Image)(resources.GetObject("_tsb_Clear.Image")));
            this._tsb_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsb_Clear.Name = "_tsb_Clear";
            this._tsb_Clear.Size = new System.Drawing.Size(71, 29);
            this._tsb_Clear.Text = "Clear";
            this._tsb_Clear.Click += new System.EventHandler(this._tsb_Clear_Click);
            // 
            // JobManager
            // 
            this.AcceptButton = this._btn_Exec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 666);
            this.Controls.Add(this._tlp_Form);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JobManager";
            this.ShowIcon = false;
            this.Text = "Job Manager";
            this._tlp_Form.ResumeLayout(false);
            this._tlp_Form.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv_Jobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsrc_Jobs)).EndInit();
            this._tstrip_Jobs.ResumeLayout(false);
            this._tstrip_Jobs.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this._tstrip_Output.ResumeLayout(false);
            this._tstrip_Output.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlp_Form;
        private System.Windows.Forms.TextBox _txb_Command;
        private System.Windows.Forms.Button _btn_Exec;
        private System.Windows.Forms.TextBox _txb_Output;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip _tstrip_Jobs;
        private System.Windows.Forms.ToolStripButton _tsb_RefreshAll;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip _tstrip_Output;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripLabel _tsl_Output;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _tsb_Clear;
        private System.Windows.Forms.Label _lbl_Command;
        private System.Windows.Forms.DataGridView _dgv_Jobs;
        private System.Windows.Forms.BindingSource _bsrc_Jobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn executableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn argumentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}