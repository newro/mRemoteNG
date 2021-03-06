﻿namespace mRemoteNG.UI.Forms
{
    partial class CompositeCredentialRepoUnlockerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompositeCredentialRepoUnlockerForm));
            this.objectListViewRepos = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStatusIcon = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.labelUnlocking = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelRepoTitle = new System.Windows.Forms.Label();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelRepoType = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelRepoSource = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelPasswordError = new System.Windows.Forms.Label();
            this.imgPasswordError = new System.Windows.Forms.PictureBox();
            this.imgUnlocked = new System.Windows.Forms.PictureBox();
            this.labelUnlocked = new System.Windows.Forms.Label();
            this.secureTextBoxPassword = new mRemoteNG.UI.Controls.SecureTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewRepos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPasswordError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUnlocked)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListViewRepos
            // 
            this.objectListViewRepos.AllColumns.Add(this.olvColumnName);
            this.objectListViewRepos.AllColumns.Add(this.olvColumnStatusIcon);
            this.objectListViewRepos.CellEditUseWholeCell = false;
            this.objectListViewRepos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnStatusIcon});
            this.objectListViewRepos.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewRepos.Dock = System.Windows.Forms.DockStyle.Left;
            this.objectListViewRepos.EmptyListMsg = "No Credential Repositories Found";
            this.objectListViewRepos.HasCollapsibleGroups = false;
            this.objectListViewRepos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.objectListViewRepos.HideSelection = false;
            this.objectListViewRepos.Location = new System.Drawing.Point(0, 0);
            this.objectListViewRepos.MultiSelect = false;
            this.objectListViewRepos.Name = "objectListViewRepos";
            this.objectListViewRepos.SelectAllOnControlA = false;
            this.objectListViewRepos.ShowGroups = false;
            this.objectListViewRepos.Size = new System.Drawing.Size(175, 272);
            this.objectListViewRepos.TabIndex = 3;
            this.objectListViewRepos.UseCompatibleStateImageBehavior = false;
            this.objectListViewRepos.UseOverlays = false;
            this.objectListViewRepos.View = System.Windows.Forms.View.Details;
            this.objectListViewRepos.SelectionChanged += new System.EventHandler(this.objectListViewRepos_SelectionChanged);
            // 
            // olvColumnName
            // 
            this.olvColumnName.FillsFreeSpace = true;
            this.olvColumnName.Groupable = false;
            this.olvColumnName.Hideable = false;
            this.olvColumnName.IsEditable = false;
            this.olvColumnName.Searchable = false;
            this.olvColumnName.Sortable = false;
            // 
            // olvColumnStatusIcon
            // 
            this.olvColumnStatusIcon.Groupable = false;
            this.olvColumnStatusIcon.IsEditable = false;
            this.olvColumnStatusIcon.Searchable = false;
            this.olvColumnStatusIcon.Sortable = false;
            this.olvColumnStatusIcon.Text = "";
            this.olvColumnStatusIcon.Width = 20;
            // 
            // labelUnlocking
            // 
            this.labelUnlocking.AutoSize = true;
            this.labelUnlocking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnlocking.Location = new System.Drawing.Point(181, 9);
            this.labelUnlocking.Name = "labelUnlocking";
            this.labelUnlocking.Size = new System.Drawing.Size(77, 16);
            this.labelUnlocking.TabIndex = 1;
            this.labelUnlocking.Text = "Unlocking";
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(190, 174);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnlock.Location = new System.Drawing.Point(386, 237);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 1;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(467, 237);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelRepoTitle
            // 
            this.labelRepoTitle.AutoSize = true;
            this.labelRepoTitle.Location = new System.Drawing.Point(190, 64);
            this.labelRepoTitle.Name = "labelRepoTitle";
            this.labelRepoTitle.Size = new System.Drawing.Size(27, 13);
            this.labelRepoTitle.TabIndex = 6;
            this.labelRepoTitle.Text = "Title";
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxType.Location = new System.Drawing.Point(237, 90);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(306, 20);
            this.textBoxType.TabIndex = 9;
            this.textBoxType.TabStop = false;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Location = new System.Drawing.Point(237, 64);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(306, 20);
            this.textBoxTitle.TabIndex = 8;
            this.textBoxTitle.TabStop = false;
            // 
            // labelRepoType
            // 
            this.labelRepoType.AutoSize = true;
            this.labelRepoType.Location = new System.Drawing.Point(190, 90);
            this.labelRepoType.Name = "labelRepoType";
            this.labelRepoType.Size = new System.Drawing.Size(31, 13);
            this.labelRepoType.TabIndex = 7;
            this.labelRepoType.Text = "Type";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSource.Location = new System.Drawing.Point(237, 116);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.Size = new System.Drawing.Size(306, 46);
            this.textBoxSource.TabIndex = 11;
            this.textBoxSource.TabStop = false;
            // 
            // labelRepoSource
            // 
            this.labelRepoSource.AutoSize = true;
            this.labelRepoSource.Location = new System.Drawing.Point(190, 116);
            this.labelRepoSource.Name = "labelRepoSource";
            this.labelRepoSource.Size = new System.Drawing.Size(41, 13);
            this.labelRepoSource.TabIndex = 10;
            this.labelRepoSource.Text = "Source";
            // 
            // textBoxId
            // 
            this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxId.Location = new System.Drawing.Point(237, 38);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(305, 20);
            this.textBoxId.TabIndex = 13;
            this.textBoxId.TabStop = false;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(191, 38);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 13);
            this.labelId.TabIndex = 12;
            this.labelId.Text = "ID";
            // 
            // labelPasswordError
            // 
            this.labelPasswordError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPasswordError.AutoSize = true;
            this.labelPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordError.ForeColor = System.Drawing.Color.DarkRed;
            this.labelPasswordError.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelPasswordError.Location = new System.Drawing.Point(191, 213);
            this.labelPasswordError.Name = "labelPasswordError";
            this.labelPasswordError.Size = new System.Drawing.Size(115, 13);
            this.labelPasswordError.TabIndex = 14;
            this.labelPasswordError.Text = "Incorrect password";
            this.labelPasswordError.Visible = false;
            // 
            // imgPasswordError
            // 
            this.imgPasswordError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgPasswordError.Image = global::mRemoteNG.Resources.exclamation;
            this.imgPasswordError.Location = new System.Drawing.Point(176, 192);
            this.imgPasswordError.Name = "imgPasswordError";
            this.imgPasswordError.Size = new System.Drawing.Size(16, 16);
            this.imgPasswordError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgPasswordError.TabIndex = 15;
            this.imgPasswordError.TabStop = false;
            this.imgPasswordError.Visible = false;
            // 
            // imgUnlocked
            // 
            this.imgUnlocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgUnlocked.Image = global::mRemoteNG.Resources.tick;
            this.imgUnlocked.Location = new System.Drawing.Point(188, 241);
            this.imgUnlocked.Name = "imgUnlocked";
            this.imgUnlocked.Size = new System.Drawing.Size(16, 16);
            this.imgUnlocked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgUnlocked.TabIndex = 16;
            this.imgUnlocked.TabStop = false;
            this.imgUnlocked.Visible = false;
            // 
            // labelUnlocked
            // 
            this.labelUnlocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUnlocked.AutoSize = true;
            this.labelUnlocked.Location = new System.Drawing.Point(204, 242);
            this.labelUnlocked.Name = "labelUnlocked";
            this.labelUnlocked.Size = new System.Drawing.Size(174, 13);
            this.labelUnlocked.TabIndex = 17;
            this.labelUnlocked.Text = "The selected repository is unlocked";
            this.labelUnlocked.Visible = false;
            // 
            // secureTextBoxPassword
            // 
            this.secureTextBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secureTextBoxPassword.Location = new System.Drawing.Point(193, 190);
            this.secureTextBoxPassword.Name = "secureTextBoxPassword";
            this.secureTextBoxPassword.Size = new System.Drawing.Size(348, 20);
            this.secureTextBoxPassword.TabIndex = 0;
            this.secureTextBoxPassword.UseSystemPasswordChar = true;
            // 
            // CompositeCredentialRepoUnlockerForm
            // 
            this.AcceptButton = this.buttonUnlock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(554, 272);
            this.Controls.Add(this.labelUnlocked);
            this.Controls.Add(this.imgUnlocked);
            this.Controls.Add(this.imgPasswordError);
            this.Controls.Add(this.labelPasswordError);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelRepoSource);
            this.Controls.Add(this.secureTextBoxPassword);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelRepoType);
            this.Controls.Add(this.objectListViewRepos);
            this.Controls.Add(this.labelUnlocking);
            this.Controls.Add(this.labelRepoTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 310);
            this.Name = "CompositeCredentialRepoUnlockerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unlock Credential Repository";
            this.Shown += new System.EventHandler(this.CompositeCredentialRepoUnlockerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewRepos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPasswordError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUnlocked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListViewRepos;
        private System.Windows.Forms.Label labelUnlocking;
        private System.Windows.Forms.Label labelPassword;
        private Controls.SecureTextBox secureTextBoxPassword;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelRepoTitle;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelRepoType;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelRepoSource;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelId;
        private BrightIdeasSoftware.OLVColumn olvColumnStatusIcon;
        private System.Windows.Forms.Label labelPasswordError;
        private System.Windows.Forms.PictureBox imgPasswordError;
        private System.Windows.Forms.PictureBox imgUnlocked;
        private System.Windows.Forms.Label labelUnlocked;
    }
}