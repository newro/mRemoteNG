using mRemoteNG.App;
using System;
using System.Windows.Forms;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    public partial class TabsPanelsPage
    {
        public TabsPanelsPage()
        {
            InitializeComponent();
        }

        public override string PageName
        {
            get { return Language.strTabsAndPanels.Replace("&&", "&"); }
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();

            chkAlwaysShowPanelTabs.Text = Language.strAlwaysShowPanelTabs;
            chkOpenNewTabRightOfSelected.Text = Language.strOpenNewTabRight;
            chkShowLogonInfoOnTabs.Text = Language.strShowLogonInfoOnTabs;
            chkShowProtocolOnTabs.Text = Language.strShowProtocolOnTabs;
            chkIdentifyQuickConnectTabs.Text = Language.strIdentifyQuickConnectTabs;
            chkDoubleClickClosesTab.Text = Language.strDoubleClickTabClosesIt;
            chkAlwaysShowPanelSelectionDlg.Text = Language.strAlwaysShowPanelSelection;
        }

        public override void LoadSettings()
        {
            base.SaveSettings();

            chkAlwaysShowPanelTabs.Checked = Settings.Default.AlwaysShowPanelTabs;
            chkOpenNewTabRightOfSelected.Checked = Settings.Default.OpenTabsRightOfSelected;
            chkShowLogonInfoOnTabs.Checked = Settings.Default.ShowLogonInfoOnTabs;
            chkShowProtocolOnTabs.Checked = Settings.Default.ShowProtocolOnTabs;
            chkIdentifyQuickConnectTabs.Checked = Settings.Default.IdentifyQuickConnectTabs;
            chkDoubleClickClosesTab.Checked = Settings.Default.DoubleClickOnTabClosesIt;
            chkAlwaysShowPanelSelectionDlg.Checked = Settings.Default.AlwaysShowPanelSelectionDlg;

            txtPanelLMove.Text = Settings.Default.PanelLMove;
            txtPanelRMove.Text = Settings.Default.PanelRMove;
            txtTabLMove.Text = Settings.Default.TabLMove;
            txtTabRMove.Text = Settings.Default.TabRMove;
        }

        public override void SaveSettings()
        {
            base.SaveSettings();

            Settings.Default.AlwaysShowPanelTabs = chkAlwaysShowPanelTabs.Checked;
            FrmMain.Default.ShowHidePanelTabs();

            Settings.Default.OpenTabsRightOfSelected = chkOpenNewTabRightOfSelected.Checked;
            Settings.Default.ShowLogonInfoOnTabs = chkShowLogonInfoOnTabs.Checked;
            Settings.Default.ShowProtocolOnTabs = chkShowProtocolOnTabs.Checked;
            Settings.Default.IdentifyQuickConnectTabs = chkIdentifyQuickConnectTabs.Checked;
            Settings.Default.DoubleClickOnTabClosesIt = chkDoubleClickClosesTab.Checked;
            Settings.Default.AlwaysShowPanelSelectionDlg = chkAlwaysShowPanelSelectionDlg.Checked;

            Settings.Default.PanelLMove = txtPanelLMove.Text;
            Settings.Default.PanelRMove = txtPanelRMove.Text;
            Settings.Default.TabLMove = txtTabLMove.Text;
            Settings.Default.TabRMove = txtTabRMove.Text;

            Settings.Default.Save();
        }

        private void txtPanelLMove_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyStroke(sender, e);
        }

        private void txtPanelRMove_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyStroke(sender, e);
        }
        private void txtTabLMove_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyStroke(sender, e);
        }
        private void txtTabRMove_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyStroke(sender, e);
        }

        private void KeyStroke(object sender, System.Windows.Forms.KeyEventArgs e)
        { 
            base.OnKeyDown(e);
            try
            {
                var txtBox = sender as System.Windows.Forms.TextBox;
                var txtStr = "" as string;
                
                if (e.Shift == true)
                {
                    txtStr += "Shift + ";
                }
                if (e.Control == true)
                {
                    txtStr += "Control + ";
                }
                if (e.Alt == true)
                {
                    txtStr += "Alt + ";
                }
                
                if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu)
                {
                    txtStr += e.KeyCode.ToString();
                }

                if (KeyStroke_Validate(sender, txtStr) == false)
                {
                    MessageBox.Show("Already defined key", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtBox.Text = txtStr;
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("TabsPanelsPage Key Down failed", ex);
            }
        }

        private bool KeyStroke_Validate(object sender, string changeKey)
        {
            try
            {
                var txtBox = sender as System.Windows.Forms.TextBox;

                if (!object.ReferenceEquals(txtBox, txtPanelLMove) & changeKey == txtPanelLMove.Text)
                {
                    return false;
                }
                if (!object.ReferenceEquals(txtBox, txtTabLMove) & changeKey == txtTabLMove.Text)
                {
                    return false;
                }
                if (!object.ReferenceEquals(txtBox, txtPanelRMove) & changeKey == txtPanelRMove.Text)
                {
                    return false;
                }
                if (!object.ReferenceEquals(txtBox, txtTabRMove) & changeKey == txtTabRMove.Text)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("Key Stroke Validate failed", ex);
                return false;
            }
        }

        //=======================================================
        //Service provided by Telerik (www.telerik.com)
        //Conversion powered by NRefactory.
        //Twitter: @telerik
        //Facebook: facebook.com/telerik
        //=======================================================

    }
}