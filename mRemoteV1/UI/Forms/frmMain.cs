using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.App.Info;
using mRemoteNG.App.Initialization;
using mRemoteNG.Config;
using mRemoteNG.Config.Putty;
using mRemoteNG.Config.Settings;
using mRemoteNG.Connection;
using mRemoteNG.Credential;
using mRemoteNG.Messages;
using mRemoteNG.Messages.MessageWriters;
using mRemoteNG.Themes;
using mRemoteNG.Tools;
using mRemoteNG.UI.Menu;
using mRemoteNG.UI.TaskDialog;
using mRemoteNG.UI.Window;
using Microsoft.Win32;
using WeifenLuo.WinFormsUI.Docking;
using sharphook;

// ReSharper disable MemberCanBePrivate.Global

namespace mRemoteNG.UI.Forms
{
    public partial class FrmMain
    {
        public static FrmMain Default { get; } = new FrmMain();

        private static ClipboardchangeEventHandler _clipboardChangedEvent;
        private bool _inSizeMove;
        private bool _inMouseActivate;
        private IntPtr _fpChainedWindowHandle;
        private bool _usingSqlServer;
        private string _connectionsFileName;
        private bool _showFullPathInTitle;
        private readonly ScreenSelectionSystemMenu _screenSystemMenu;
        private ConnectionInfo _selectedConnection;
        private readonly UnlockerFormFactory _credRepoUnlockerFormFactory = new UnlockerFormFactory();
        private readonly IList<IMessageWriter> _messageWriters = new List<IMessageWriter>();
        private readonly SharpHook hook = new SharpHook();

        internal FullscreenHandler Fullscreen { get; set; }

        private FrmMain()
		{
			_showFullPathInTitle = Settings.Default.ShowCompleteConsPathInTitle;
			InitializeComponent();
            Fullscreen = new FullscreenHandler(this);
            pnlDock.Theme = new VS2012LightTheme();
            _screenSystemMenu = new ScreenSelectionSystemMenu(this);
            hook.KeyUp += hook_KeyUp;
        }

        static FrmMain()
        {
        }

        #region Properties
        public FormWindowState PreviousWindowState { get; set; }

	    public bool IsClosing { get; private set; }

        public bool AreWeUsingSqlServerForSavingConnections
		{
			get { return _usingSqlServer; }
			set
			{
				if (_usingSqlServer == value)
				{
					return;
				}
				_usingSqlServer = value;
				UpdateWindowTitle();
			}
		}
		
        public string ConnectionsFileName
		{
			get { return _connectionsFileName; }
			set
			{
				if (_connectionsFileName == value)
				{
					return;
				}
				_connectionsFileName = value;
				UpdateWindowTitle();
			}
		}
		
        public bool ShowFullPathInTitle
		{
			get { return _showFullPathInTitle; }
			set
			{
				if (_showFullPathInTitle == value)
				{
					return;
				}
				_showFullPathInTitle = value;
				UpdateWindowTitle();
			}
		}
		
        public ConnectionInfo SelectedConnection
		{
			get { return _selectedConnection; }
			set
			{
				if (_selectedConnection == value)
				{
					return;
				}
				_selectedConnection = value;
				UpdateWindowTitle();
			}
		}

        private System.Windows.Forms.KeyEventArgs _PanelLMove;
        private System.Windows.Forms.KeyEventArgs _PanelRMove;
        private System.Windows.Forms.KeyEventArgs _TabLMove;
        private System.Windows.Forms.KeyEventArgs _TabRMove;
    

        #endregion

        #region Startup & Shutdown
        private void frmMain_Load(object sender, EventArgs e)
        {
            var messageCollector = Runtime.MessageCollector;
            MessageCollectorSetup.SetupMessageCollector(messageCollector, _messageWriters);
            MessageCollectorSetup.BuildMessageWritersFromSettings(_messageWriters);

            Startup.Instance.InitializeProgram(messageCollector);

            SetMenuDependencies();

            KeyboardHookOptionReload();

            var settingsLoader = new SettingsLoader(this, messageCollector, _quickConnectToolStrip, _externalToolsToolStrip);
            settingsLoader.LoadSettings();

            var uiLoader = new DockPanelLayoutLoader(this, messageCollector);
            uiLoader.LoadPanelsFromXml();

			ThemeManager.ThemeChanged += ApplyThemes;
			ApplyThemes();

			_fpChainedWindowHandle = NativeMethods.SetClipboardViewer(Handle);

            Runtime.WindowList = new WindowList();

            var credentialsService = new CredentialServiceFactory().Build();
            var credsAndConsSetup = new CredsAndConsSetup(credentialsService);
            credsAndConsSetup.LoadCredsAndCons();

            Windows.TreeForm.Focus();

            PuttySessionsManager.Instance.StartWatcher();
			if (Settings.Default.StartupComponentsCheck)
                Windows.Show(WindowType.ComponentsCheck);

            Startup.Instance.CreateConnectionsProvider(messageCollector);

            _screenSystemMenu.BuildScreenList();
			SystemEvents.DisplaySettingsChanged += _screenSystemMenu.OnDisplayChanged;

            Opacity = 1;
        }

        private void SetMenuDependencies()
        {
            var connectionInitiator = new ConnectionInitiator();
            mainFileMenu1.TreeWindow = Windows.TreeForm;
            mainFileMenu1.ConnectionInitiator = connectionInitiator;

            viewMenu1.TsExternalTools = _externalToolsToolStrip;
            viewMenu1.TsQuickConnect = _quickConnectToolStrip;
            viewMenu1.FullscreenHandler = Fullscreen;
            viewMenu1.MainForm = this;

            toolsMenu1.MainForm = this;
            toolsMenu1.CredentialProviderCatalog = Runtime.CredentialProviderCatalog;
            toolsMenu1.UnlockerFormFactory = _credRepoUnlockerFormFactory;

            _quickConnectToolStrip.ConnectionInitiator = connectionInitiator;
        }

        private void ApplyThemes()
		{
			pnlDock.DockBackColor = ThemeManager.ActiveTheme.WindowBackgroundColor;
			tsContainer.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			tsContainer.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			tsContainer.TopToolStripPanel.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			tsContainer.TopToolStripPanel.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			tsContainer.BottomToolStripPanel.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			tsContainer.BottomToolStripPanel.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			tsContainer.LeftToolStripPanel.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			tsContainer.LeftToolStripPanel.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			tsContainer.RightToolStripPanel.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			tsContainer.RightToolStripPanel.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			tsContainer.ContentPanel.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			tsContainer.ContentPanel.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			msMain.BackColor = ThemeManager.ActiveTheme.ToolbarBackgroundColor;
			msMain.ForeColor = ThemeManager.ActiveTheme.ToolbarTextColor;
			ApplyMenuColors(msMain.Items);
		}
		
		private static void ApplyMenuColors(IEnumerable itemCollection)
		{
		    foreach (ToolStripItem item in itemCollection)
			{
				item.BackColor = ThemeManager.ActiveTheme.MenuBackgroundColor;
				item.ForeColor = ThemeManager.ActiveTheme.MenuTextColor;
				
				var menuItem = item as ToolStripMenuItem;
				if (menuItem != null)
				{
					ApplyMenuColors(menuItem.DropDownItems);
				}
			}
		}

        private void frmMain_Shown(object sender, EventArgs e)
        {
            PromptForUpdatesPreference();
            CheckForUpdates();
            UnlockRepositories(Runtime.CredentialProviderCatalog, this);
        }

        private void PromptForUpdatesPreference()
        {
            if (Settings.Default.CheckForUpdatesAsked) return;
            string[] commandButtons =
            {
                Language.strAskUpdatesCommandRecommended,
                Language.strAskUpdatesCommandCustom,
                Language.strAskUpdatesCommandAskLater
            };

            CTaskDialog.ShowTaskDialogBox(this, GeneralAppInfo.ProductName, Language.strAskUpdatesMainInstruction, string.Format(Language.strAskUpdatesContent, GeneralAppInfo.ProductName),
                "", "", "", "", string.Join(" | ", commandButtons), ETaskDialogButtons.None, ESysIcons.Question, ESysIcons.Question);

            if (CTaskDialog.CommandButtonResult == 0 | CTaskDialog.CommandButtonResult == 1)
            {
                Settings.Default.CheckForUpdatesAsked = true;
            }

            if (CTaskDialog.CommandButtonResult != 1) return;

            using (var optionsForm = new frmOptions(Language.strTabUpdates))
            {
                optionsForm.ShowDialog(this);
            }
        }

        private void CheckForUpdates()
        {
            if (!Settings.Default.CheckForUpdatesOnStartup) return;

            var nextUpdateCheck = Convert.ToDateTime(
                    Settings.Default.CheckForUpdatesLastCheck.Add(
                        TimeSpan.FromDays(Convert.ToDouble(Settings.Default.CheckForUpdatesFrequencyDays))));

            if (!Settings.Default.UpdatePending && DateTime.UtcNow <= nextUpdateCheck) return;
            if (!IsHandleCreated) CreateHandle(); // Make sure the handle is created so that InvokeRequired returns the correct result

            Startup.Instance.CheckForUpdate();
        }

        private void UnlockRepositories(IEnumerable<ICredentialRepository> repositories, IWin32Window parentForm)
        {
            if (!Settings.Default.PromptUnlockCredReposOnStartup) return;
            var credentialUnlockerForm = _credRepoUnlockerFormFactory.Build(repositories);
            credentialUnlockerForm.ShowDialog(parentForm);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (!(Runtime.WindowList == null || Runtime.WindowList.Count == 0))
			{
			    var openConnections = 0;
                foreach (BaseWindow window in Runtime.WindowList)
                {
                    var connectionWindow = window as ConnectionWindow;
                    if (connectionWindow != null)
						openConnections = openConnections + connectionWindow.TabController.TabPages.Count;
                }

			    if (openConnections > 0 && (Settings.Default.ConfirmCloseConnection == (int)ConfirmCloseEnum.All | (Settings.Default.ConfirmCloseConnection == (int)ConfirmCloseEnum.Multiple & openConnections > 1) || Settings.Default.ConfirmCloseConnection == (int)ConfirmCloseEnum.Exit))
				{
					var result = CTaskDialog.MessageBox(this, Application.ProductName, Language.strConfirmExitMainInstruction, "", "", "", Language.strCheckboxDoNotShowThisMessageAgain, ETaskDialogButtons.YesNo, ESysIcons.Question, ESysIcons.Question);
					if (CTaskDialog.VerificationChecked)
					{
                        Settings.Default.ConfirmCloseConnection--;
					}
					if (result == DialogResult.No)
					{
						e.Cancel = true;
						return;
					}
				}
			}

            Shutdown.Cleanup(_quickConnectToolStrip, _externalToolsToolStrip, this);
									
			IsClosing = true;

            if (Runtime.WindowList != null)
			{
                foreach (BaseWindow window in Runtime.WindowList)
				{
					window.Close();
				}
			}

            Shutdown.StartUpdate();
									
			Debug.Print("[END] - " + Convert.ToString(DateTime.Now, CultureInfo.InvariantCulture));
		}
        #endregion
								
        #region Timer
		private void tmrAutoSave_Tick(object sender, EventArgs e)
		{
            Runtime.MessageCollector.AddMessage(MessageClass.DebugMsg, "Doing AutoSave");
			Runtime.SaveConnectionsAsync();
		}
        #endregion
		
        #region Window Overrides and DockPanel Stuff
        private void frmMain_ResizeBegin(object sender, EventArgs e)
		{
			_inSizeMove = true;
		}

        private void frmMain_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
			    if (!Settings.Default.MinimizeToTray) return;
			    if (Runtime.NotificationAreaIcon == null)
			    {
			        Runtime.NotificationAreaIcon = new NotificationAreaIcon();
			    }
			    Hide();
			}
			else
			{
				PreviousWindowState = WindowState;
			}
		}

        private void frmMain_ResizeEnd(object sender, EventArgs e)
		{
			_inSizeMove = false;			
			// This handles activations from clicks that started a size/move operation
			ActivateConnection();
		}				
		
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
            // Listen for and handle operating system messages
			try
			{
			    // ReSharper disable once SwitchStatementMissingSomeCases
				switch (m.Msg)
				{
				    case NativeMethods.WM_MOUSEACTIVATE:
				        _inMouseActivate = true;
				        break;
				    case NativeMethods.WM_ACTIVATEAPP:
				        _inMouseActivate = false;
				        break;
				    case NativeMethods.WM_ACTIVATE:
				        // Only handle this msg if it was triggered by a click
				        if (NativeMethods.LOWORD(m.WParam) == NativeMethods.WA_CLICKACTIVE)
				        {
				            var controlThatWasClicked = FromChildHandle(NativeMethods.WindowFromPoint(MousePosition));
				            if (controlThatWasClicked != null)
				            {
				                if (controlThatWasClicked.CanSelect || controlThatWasClicked is MenuStrip || 
                                         controlThatWasClicked is ToolStrip || controlThatWasClicked is Crownwood.Magic.Controls.TabControl || 
                                         controlThatWasClicked is Crownwood.Magic.Controls.InertButton)
				                {
				                    // Simulate a mouse event since one wasn't generated by Windows
				                    MouseClickSimulator.Click(controlThatWasClicked, MousePosition);
				                }
				            }

				            // This handles activations from clicks that did not start a size/move operation
				            ActivateConnection();
				        }
				        break;
				    case NativeMethods.WM_WINDOWPOSCHANGED:
				        // Ignore this message if the window wasn't activated
				        var windowPos = (NativeMethods.WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.WINDOWPOS));
				        if ((windowPos.flags & NativeMethods.SWP_NOACTIVATE) == 0)
				        {
				            if (!_inMouseActivate && !_inSizeMove)
				                ActivateConnection();
				        }
				        break;
				    case NativeMethods.WM_SYSCOMMAND:
				        var screen = _screenSystemMenu.GetScreenById(m.WParam.ToInt32());
                        if (screen != null)
                            Screens.SendFormToScreen(screen);
				        break;
				    case NativeMethods.WM_DRAWCLIPBOARD:
				        NativeMethods.SendMessage(_fpChainedWindowHandle, m.Msg, m.LParam, m.WParam);
				        _clipboardChangedEvent?.Invoke();
				        break;
				    case NativeMethods.WM_CHANGECBCHAIN:
				        //Send to the next window
				        NativeMethods.SendMessage(_fpChainedWindowHandle, m.Msg, m.LParam, m.WParam);
				        _fpChainedWindowHandle = m.LParam;
				        break;
				}
			}
			catch (Exception ex)
			{
                Runtime.MessageCollector.AddExceptionStackTrace("frmMain WndProc failed", ex);
            }
									
			base.WndProc(ref m);
		}
        
		private void ActivateConnection()
		{
		    var w = pnlDock.ActiveDocument as ConnectionWindow;
		    if (w?.TabController.SelectedTab == null) return;
		    var tab = w.TabController.SelectedTab;
		    var ifc = (InterfaceControl)tab.Tag;

		    if (ifc == null) return;

		    ifc.Protocol.Focus();
		    ((ConnectionWindow) ifc.FindForm())?.RefreshInterfaceController();
		}

        private bool IsActive()
        {
            var w = pnlDock.ActiveDocument as ConnectionWindow;
            if (w?.TabController.SelectedTab == null) return false;

            Crownwood.Magic.Controls.TabPage tab = w.TabController.SelectedTab;
            Connection.InterfaceControl ifc = (Connection.InterfaceControl)tab.Tag;
            if (ifc == null) return false;

            return ifc.Protocol.Focused;
        }

        private void pnlDock_ActiveDocumentChanged(object sender, EventArgs e)
		{
			ActivateConnection();
            var connectionWindow = pnlDock.ActiveDocument as ConnectionWindow;
		    connectionWindow?.UpdateSelectedConnection();
		}
		
		private void UpdateWindowTitle()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(UpdateWindowTitle));
				return;
			}
									
			var titleBuilder = new StringBuilder(Application.ProductName);
			const string separator = " - ";
									
			if (Runtime.ConnectionsService.IsConnectionsFileLoaded)
			{
				if (AreWeUsingSqlServerForSavingConnections)
				{
					titleBuilder.Append(separator);
					titleBuilder.Append(Language.strSQLServer.TrimEnd(':'));
				}
				else
				{
					if (!string.IsNullOrEmpty(ConnectionsFileName))
					{
					    titleBuilder.Append(separator);
					    titleBuilder.Append(Settings.Default.ShowCompleteConsPathInTitle
					        ? ConnectionsFileName
					        : Path.GetFileName(ConnectionsFileName));
					}
				}
			}
									
			if (!string.IsNullOrEmpty(SelectedConnection?.Name))
			{
				titleBuilder.Append(separator);
				titleBuilder.Append(SelectedConnection.Name);
			}

            Text = titleBuilder.ToString();
		}
		
		public void ShowHidePanelTabs(DockContent closingDocument = null)
		{
			DocumentStyle newDocumentStyle;
									
			if (Settings.Default.AlwaysShowPanelTabs)
			{
				newDocumentStyle = DocumentStyle.DockingWindow; // Show the panel tabs
			}
			else
			{
				var nonConnectionPanelCount = 0;
				foreach (var dockContent in pnlDock.Documents)
				{
				    var document = (DockContent) dockContent;
				    if ((closingDocument == null || document != closingDocument) && !(document is ConnectionWindow))
					{
						nonConnectionPanelCount++;
					}
				}

			    newDocumentStyle = nonConnectionPanelCount == 0 ? DocumentStyle.DockingSdi : DocumentStyle.DockingWindow;
			}

		    if (pnlDock.DocumentStyle == newDocumentStyle) return;
		    pnlDock.DocumentStyle = newDocumentStyle;
		    pnlDock.Size = new Size(1, 1);
		}

#if false
        private void SelectTabRelative(int relativeIndex)
		{
			if (!(pnlDock.ActiveDocument is ConnectionWindow))
			{
				return;
			}

            var connectionWindow = (ConnectionWindow)pnlDock.ActiveDocument;
			var tabController = connectionWindow.TabController;
									
			var newIndex = tabController.SelectedIndex + relativeIndex;
			while (newIndex < 0 | newIndex >= tabController.TabPages.Count)
			{
				if (newIndex < 0)
				{
					newIndex = tabController.TabPages.Count + newIndex;
				}
				if (newIndex >= tabController.TabPages.Count)
				{
					newIndex = newIndex - tabController.TabPages.Count;
				}
			}
									
			tabController.SelectedIndex = newIndex;
		}
#endif
        #endregion
		
        #region Screen Stuff
        public void SetDefaultLayout()
        {
            pnlDock.Visible = false;

            pnlDock.DockLeftPortion = pnlDock.Width * 0.2;
            pnlDock.DockRightPortion = pnlDock.Width * 0.2;
            pnlDock.DockTopPortion = pnlDock.Height * 0.25;
            pnlDock.DockBottomPortion = pnlDock.Height * 0.25;

            Windows.TreeForm.Show(pnlDock, DockState.DockLeft);
            Windows.ConfigForm.Show(pnlDock);
            Windows.ConfigForm.DockTo(Windows.TreeForm.Pane, DockStyle.Bottom, -1);
            Windows.ErrorsForm.Show(pnlDock, DockState.Document);

            Windows.ErrorsForm.Hide();
            Windows.ScreenshotForm.Hide();

            pnlDock.Visible = true;
        }
        #endregion

        #region Events
        public delegate void ClipboardchangeEventHandler();
        public static event ClipboardchangeEventHandler ClipboardChanged
        {
            add
            {
                _clipboardChangedEvent = (ClipboardchangeEventHandler)Delegate.Combine(_clipboardChangedEvent, value);
            }
            remove
            {
                _clipboardChangedEvent = (ClipboardchangeEventHandler)Delegate.Remove(_clipboardChangedEvent, value);
            }
        }
        #endregion

        #region Keyboard Event

        public void KeyboardHookOptionReload()
        {
            try
            {
                KeysConverter key_conv = new KeysConverter();

                _PanelLMove = new KeyEventArgs((Keys)key_conv.ConvertFromString(Settings.Default.PanelLMove));
                _PanelRMove = new KeyEventArgs((Keys)key_conv.ConvertFromString(Settings.Default.PanelRMove));
                _TabLMove = new KeyEventArgs((Keys)key_conv.ConvertFromString(Settings.Default.TabLMove));
                _TabRMove = new KeyEventArgs((Keys)key_conv.ConvertFromString(Settings.Default.TabRMove));
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("Invalid ShortCut", ex);
            }
        }

        private bool MoveKey_Match(System.Windows.Forms.KeyEventArgs e, System.Windows.Forms.KeyEventArgs shortcut)
        {
            if (e.Control == shortcut.Control && e.Shift == shortcut.Shift && e.Alt == shortcut.Alt &&
                e.KeyCode == shortcut.KeyCode)
            {
                return true;
            }
            return false;
        }

        private int PanelMove(ConnectionWindow currentCW, bool forward)
        {
            int targetIndex = 0;
            int winCount = Runtime.WindowList.Count;
            for (int i = 0; i < winCount; i++)
            {
                var connectionWindow = Runtime.WindowList[i] as ConnectionWindow;
                if (object.ReferenceEquals(connectionWindow, currentCW) == true)
                {
                    int nextStep = (forward) ? winCount - 1 : 1;
                    targetIndex = (i + nextStep) % winCount;
                    break;
                }
            }
            return targetIndex;
        }

        private void hook_KeyUp(object sender, KeyEventArgs e)
        {
            if (!IsActive())
            {
                return;
            }

            try
            {
                mRemoteNG.UI.Window.ConnectionWindow activeWC = (mRemoteNG.UI.Window.ConnectionWindow)pnlDock.ActiveDocument;

                if (MoveKey_Match(e, _TabLMove))
                {
                    activeWC.TabController.SelectedIndex = (activeWC.TabController.SelectedIndex + activeWC.TabController.TabPages.Count - 1) % activeWC.TabController.TabPages.Count;
                }
                else if (MoveKey_Match(e, _TabRMove))
                {
                    activeWC.TabController.SelectedIndex = (activeWC.TabController.SelectedIndex + 1) % activeWC.TabController.TabPages.Count;
                }
                else if (MoveKey_Match(e, _PanelLMove))
                {
                    int nextIndex = PanelMove(activeWC, true);
                    activeWC = (ConnectionWindow)Runtime.WindowList[nextIndex];
                }
                else if (MoveKey_Match(e, _PanelRMove))
                {
                    int nextIndex = PanelMove(activeWC, false);
                    activeWC = (ConnectionWindow)Runtime.WindowList[nextIndex];
                }
                else
                {
                    activeWC = null;
                }

                if (activeWC != null)
                {
                    activeWC.Show(pnlDock);
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("FocusIC failed", ex);
            }

        }
        
        #endregion

        private void ViewMenu_Opening(object sender, EventArgs e)
        {
            viewMenu1.mMenView_DropDownOpening(sender, e);
        }

        private void mainFileMenu1_DropDownOpening(object sender, EventArgs e)
        {
            mainFileMenu1.mMenFile_DropDownOpening(sender, e);
        }
    }
}
