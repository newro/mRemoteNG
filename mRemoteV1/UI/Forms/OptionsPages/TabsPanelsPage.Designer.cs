

namespace mRemoteNG.UI.Forms.OptionsPages
{
	
    public partial class TabsPanelsPage : OptionsPage
	{
			
		//UserControl overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
			
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
			
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabsPanelsPage));
            this.chkAlwaysShowPanelTabs = new System.Windows.Forms.CheckBox();
            this.chkIdentifyQuickConnectTabs = new System.Windows.Forms.CheckBox();
            this.chkOpenNewTabRightOfSelected = new System.Windows.Forms.CheckBox();
            this.chkAlwaysShowPanelSelectionDlg = new System.Windows.Forms.CheckBox();
            this.chkShowLogonInfoOnTabs = new System.Windows.Forms.CheckBox();
            this.chkDoubleClickClosesTab = new System.Windows.Forms.CheckBox();
            this.chkShowProtocolOnTabs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPanelLMove = new System.Windows.Forms.TextBox();
            this.txtPanelRMove = new System.Windows.Forms.TextBox();
            this.txtTabLMove = new System.Windows.Forms.TextBox();
            this.txtTabRMove = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkAlwaysShowPanelTabs
            // 
            this.chkAlwaysShowPanelTabs.AutoSize = true;
            this.chkAlwaysShowPanelTabs.Location = new System.Drawing.Point(3, 0);
            this.chkAlwaysShowPanelTabs.Name = "chkAlwaysShowPanelTabs";
            this.chkAlwaysShowPanelTabs.Size = new System.Drawing.Size(164, 16);
            this.chkAlwaysShowPanelTabs.TabIndex = 12;
            this.chkAlwaysShowPanelTabs.Text = "Always show panel tabs";
            this.chkAlwaysShowPanelTabs.UseVisualStyleBackColor = true;
            // 
            // chkIdentifyQuickConnectTabs
            // 
            this.chkIdentifyQuickConnectTabs.AutoSize = true;
            this.chkIdentifyQuickConnectTabs.Location = new System.Drawing.Point(3, 85);
            this.chkIdentifyQuickConnectTabs.Name = "chkIdentifyQuickConnectTabs";
            this.chkIdentifyQuickConnectTabs.Size = new System.Drawing.Size(339, 16);
            this.chkIdentifyQuickConnectTabs.TabIndex = 16;
            this.chkIdentifyQuickConnectTabs.Text = global::mRemoteNG.Language.strIdentifyQuickConnectTabs;
            this.chkIdentifyQuickConnectTabs.UseVisualStyleBackColor = true;
            // 
            // chkOpenNewTabRightOfSelected
            // 
            this.chkOpenNewTabRightOfSelected.AutoSize = true;
            this.chkOpenNewTabRightOfSelected.Location = new System.Drawing.Point(3, 21);
            this.chkOpenNewTabRightOfSelected.Name = "chkOpenNewTabRightOfSelected";
            this.chkOpenNewTabRightOfSelected.Size = new System.Drawing.Size(327, 16);
            this.chkOpenNewTabRightOfSelected.TabIndex = 13;
            this.chkOpenNewTabRightOfSelected.Text = "Open new tab to the right of the currently selected tab";
            this.chkOpenNewTabRightOfSelected.UseVisualStyleBackColor = true;
            // 
            // chkAlwaysShowPanelSelectionDlg
            // 
            this.chkAlwaysShowPanelSelectionDlg.AutoSize = true;
            this.chkAlwaysShowPanelSelectionDlg.Location = new System.Drawing.Point(3, 127);
            this.chkAlwaysShowPanelSelectionDlg.Name = "chkAlwaysShowPanelSelectionDlg";
            this.chkAlwaysShowPanelSelectionDlg.Size = new System.Drawing.Size(379, 16);
            this.chkAlwaysShowPanelSelectionDlg.TabIndex = 18;
            this.chkAlwaysShowPanelSelectionDlg.Text = "Always show panel selection dialog when opening connectins";
            this.chkAlwaysShowPanelSelectionDlg.UseVisualStyleBackColor = true;
            // 
            // chkShowLogonInfoOnTabs
            // 
            this.chkShowLogonInfoOnTabs.AutoSize = true;
            this.chkShowLogonInfoOnTabs.Location = new System.Drawing.Point(3, 42);
            this.chkShowLogonInfoOnTabs.Name = "chkShowLogonInfoOnTabs";
            this.chkShowLogonInfoOnTabs.Size = new System.Drawing.Size(239, 16);
            this.chkShowLogonInfoOnTabs.TabIndex = 14;
            this.chkShowLogonInfoOnTabs.Text = "Show logon information on tab names";
            this.chkShowLogonInfoOnTabs.UseVisualStyleBackColor = true;
            // 
            // chkDoubleClickClosesTab
            // 
            this.chkDoubleClickClosesTab.AutoSize = true;
            this.chkDoubleClickClosesTab.Location = new System.Drawing.Point(3, 106);
            this.chkDoubleClickClosesTab.Name = "chkDoubleClickClosesTab";
            this.chkDoubleClickClosesTab.Size = new System.Drawing.Size(184, 16);
            this.chkDoubleClickClosesTab.TabIndex = 17;
            this.chkDoubleClickClosesTab.Text = "Double click on tab closes it";
            this.chkDoubleClickClosesTab.UseVisualStyleBackColor = true;
            // 
            // chkShowProtocolOnTabs
            // 
            this.chkShowProtocolOnTabs.AutoSize = true;
            this.chkShowProtocolOnTabs.Location = new System.Drawing.Point(3, 64);
            this.chkShowProtocolOnTabs.Name = "chkShowProtocolOnTabs";
            this.chkShowProtocolOnTabs.Size = new System.Drawing.Size(194, 16);
            this.chkShowProtocolOnTabs.TabIndex = 15;
            this.chkShowProtocolOnTabs.Text = "Show protocols on tab names";
            this.chkShowProtocolOnTabs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Panel Move";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tab Move";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "Move Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "Move Right";
            // 
            // txtPanelLMove
            // 
            this.txtPanelLMove.Location = new System.Drawing.Point(117, 173);
            this.txtPanelLMove.Name = "txtPanelLMove";
            this.txtPanelLMove.Size = new System.Drawing.Size(145, 21);
            this.txtPanelLMove.TabIndex = 19;
            this.txtPanelLMove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPanelLMove_KeyDown);
            // 
            // txtPanelRMove
            // 
            this.txtPanelRMove.Location = new System.Drawing.Point(284, 173);
            this.txtPanelRMove.Name = "txtPanelRMove";
            this.txtPanelRMove.Size = new System.Drawing.Size(145, 21);
            this.txtPanelRMove.TabIndex = 20;
            // 
            // txtTabLMove
            // 
            this.txtTabLMove.Location = new System.Drawing.Point(117, 199);
            this.txtTabLMove.Name = "txtTabLMove";
            this.txtTabLMove.Size = new System.Drawing.Size(145, 21);
            this.txtTabLMove.TabIndex = 21;
            // 
            // txtTabRMove
            // 
            this.txtTabRMove.Location = new System.Drawing.Point(284, 199);
            this.txtTabRMove.Name = "txtTabRMove";
            this.txtTabRMove.Size = new System.Drawing.Size(145, 21);
            this.txtTabRMove.TabIndex = 22;
            // 
            // TabsPanelsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTabRMove);
            this.Controls.Add(this.txtTabLMove);
            this.Controls.Add(this.txtPanelRMove);
            this.Controls.Add(this.txtPanelLMove);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAlwaysShowPanelTabs);
            this.Controls.Add(this.chkIdentifyQuickConnectTabs);
            this.Controls.Add(this.chkOpenNewTabRightOfSelected);
            this.Controls.Add(this.chkAlwaysShowPanelSelectionDlg);
            this.Controls.Add(this.chkShowLogonInfoOnTabs);
            this.Controls.Add(this.chkDoubleClickClosesTab);
            this.Controls.Add(this.chkShowProtocolOnTabs);
            this.Name = "TabsPanelsPage";
            this.PageIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PageIcon")));
            this.Size = new System.Drawing.Size(712, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.CheckBox chkAlwaysShowPanelTabs;
		internal System.Windows.Forms.CheckBox chkIdentifyQuickConnectTabs;
		internal System.Windows.Forms.CheckBox chkOpenNewTabRightOfSelected;
		internal System.Windows.Forms.CheckBox chkAlwaysShowPanelSelectionDlg;
		internal System.Windows.Forms.CheckBox chkShowLogonInfoOnTabs;
		internal System.Windows.Forms.CheckBox chkDoubleClickClosesTab;
		internal System.Windows.Forms.CheckBox chkShowProtocolOnTabs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPanelLMove;
        private System.Windows.Forms.TextBox txtPanelRMove;
        private System.Windows.Forms.TextBox txtTabLMove;
        private System.Windows.Forms.TextBox txtTabRMove;
    }
}
