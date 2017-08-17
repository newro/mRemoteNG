using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace sharphook
{
    public class SharpHook : IDisposable
    {
        private IntPtr keyboardHook = IntPtr.Zero;
        private IntPtr mouseHook = IntPtr.Zero;

        private Win32API.HookProc keyboardHookProc = null;
        private Win32API.HookProc mouseHookProc = null;

        private int lastClick = 0;

        // Keyboard events
        public event KeyEventHandler KeyDown;
        public event KeyPressEventHandler KeyPress;
        public event KeyEventHandler KeyUp;

        // Mouse events
        public event MouseEventHandler MouseDown;
        public event MouseEventHandler Click;
        public event MouseEventHandler DoubleClick;
        public event MouseEventHandler MouseUp;
        public event MouseEventHandler MouseWheel;
        public event MouseEventHandler MouseMove;

        [Flags]
        public enum HookType
        {
            None = 0x0,
            Keyboard = 0x1,
            Mouse = 0x2
        }

        public SharpHook(HookType hookType)
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                IntPtr hModule = Win32API.GetModuleHandle(module.ModuleName);

                if ((hookType & HookType.Keyboard) > 0)
                {
                    keyboardHookProc = new Win32API.HookProc(KeyboardHookProc);
                    keyboardHook = Win32API.SetWindowsHookEx(Win32API.HookType.WH_KEYBOARD_LL, keyboardHookProc, hModule, 0);
                }

                if ((hookType & HookType.Mouse) > 0)
                {
                    Debug.WriteLine("DoubleClickTime: " + Win32API.GetDoubleClickTime());

                    mouseHookProc = new Win32API.HookProc(MouseHookProc);
                    mouseHook = Win32API.SetWindowsHookEx(Win32API.HookType.WH_MOUSE_LL, mouseHookProc, hModule, 0);
                }
            }
        }

        public SharpHook()
            : this(HookType.Keyboard | HookType.Mouse)
        {
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (keyboardHook != IntPtr.Zero)
            {
                Win32API.UnhookWindowsHookEx(keyboardHook);
            }
            if (mouseHook != IntPtr.Zero)
            {
                Win32API.UnhookWindowsHookEx(mouseHook);
            }
        }

        #endregion

        private int KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if ((code >= 0) && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                Win32API.KBDLLHOOKSTRUCT hookStruct = (Win32API.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32API.KBDLLHOOKSTRUCT));

                if (KeyDown != null && (wParam.ToInt32() == (int)Win32API.WM.KEYDOWN || wParam.ToInt32() == (int)Win32API.WM.SYSKEYDOWN))
                {
                    Keys keyData = (Keys)hookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDown(this, e);
                }

                if (KeyPress != null && wParam.ToInt32() == (int)Win32API.WM.KEYDOWN)
                {
                    byte[] lpKeyState = new byte[256];

                    // Remarks: The status does not change as keyboard messages are posted to or retrieved from message queues of other threads.
                    // Win32API.GetKeyboardState(lpKeyState);

                    for (int i = 0; i < lpKeyState.Length; i++)
                    {
                        byte b = Win32API.HIBYTE(Win32API.GetAsyncKeyState(i));
                        lpKeyState[i] = b;
                    }

                    StringBuilder lpChar = new StringBuilder(2);
                    if (Win32API.ToAscii(hookStruct.vkCode, hookStruct.scanCode, lpKeyState, lpChar, (uint)hookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)lpChar.ToString()[0]);
                        KeyPress(this, e);
                    }
                }

                if (KeyUp != null && (wParam.ToInt32() == (int)Win32API.WM.KEYUP || wParam.ToInt32() == (int)Win32API.WM.SYSKEYUP))
                {
                    Keys keyData = (Keys)hookStruct.vkCode;

                    if (Convert.ToBoolean(Win32API.GetAsyncKeyState((int)Keys.Menu) & 0x8000))
                    {
                        keyData = keyData | Keys.Alt;
                    }

                    if (Convert.ToBoolean(Win32API.GetAsyncKeyState((int)Keys.ControlKey) & 0x8000))
                    {
                        keyData = keyData | Keys.Control;
                    }

                    if (Convert.ToBoolean(Win32API.GetAsyncKeyState((int)Keys.ShiftKey) & 0x8000))
                    {
                        keyData = keyData | Keys.Shift;
                    }

                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUp(this, e);
                }
            }
            return Win32API.CallNextHookEx(keyboardHook, code, wParam, lParam);
        }

        private int MouseHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if ((code >= 0) && (MouseDown != null || MouseUp != null || Click != null || DoubleClick != null || MouseWheel != null || MouseMove != null))
            {
                short delta = 0;
                int clicks = 0;
                Win32API.MOUSELLHOOKSTRUCT hookStruct = (Win32API.MOUSELLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32API.MOUSELLHOOKSTRUCT));

                // Check which button has been pressed
                MouseButtons buttons = MouseButtons.None;
                if (wParam.ToInt32() == (int)Win32API.WM.LBUTTONDOWN || wParam.ToInt32() == (int)Win32API.WM.LBUTTONUP) buttons |= MouseButtons.Left;
                else if (wParam.ToInt32() == (int)Win32API.WM.MBUTTONDOWN || wParam.ToInt32() == (int)Win32API.WM.MBUTTONUP) buttons |= MouseButtons.Middle;
                else if (wParam.ToInt32() == (int)Win32API.WM.RBUTTONDOWN || wParam.ToInt32() == (int)Win32API.WM.RBUTTONUP) buttons |= MouseButtons.Right;
                else if (wParam.ToInt32() == (int)Win32API.WM.XBUTTONDOWN || wParam.ToInt32() == (int)Win32API.WM.XBUTTONUP)
                {
                    if (Win32API.GetAsyncKeyState((int)Win32API.VirtualKeyStates.VK_XBUTTON1) == 0) buttons |= MouseButtons.XButton1;
                    else buttons |= MouseButtons.XButton2;
                }

                // Check the number of clicks
                // It seems *BUTTONDCLK messages never get fired
                //if (
                //    wParam.ToInt32() == (int)Win32API.WM.LBUTTONDBLCLK ||
                //    wParam.ToInt32() == (int)Win32API.WM.MBUTTONDBLCLK ||
                //    wParam.ToInt32() == (int)Win32API.WM.RBUTTONDBLCLK ||
                //    wParam.ToInt32() == (int)Win32API.WM.XBUTTONDBLCLK)
                //{
                //    clicks = 2;
                //}
                if (
                    wParam.ToInt32() == (int)Win32API.WM.LBUTTONUP ||
                    wParam.ToInt32() == (int)Win32API.WM.MBUTTONUP ||
                    wParam.ToInt32() == (int)Win32API.WM.RBUTTONUP ||
                    wParam.ToInt32() == (int)Win32API.WM.XBUTTONUP)
                {
                    if (hookStruct.time - lastClick < Win32API.GetDoubleClickTime())
                    {
                        clicks = 2;
                    }
                    else
                    {
                        clicks = 1;
                    }
                }

                // Check mouse wheel movement
                if (wParam.ToInt32() == (int)Win32API.WM.MOUSEWHEEL)
                {
                    delta = Win32API.HIWORD(hookStruct.mouseData);
                    //Debug.WriteLine("Mouse wheel: " + delta);
                }

                // Check mouse movement
                if (wParam.ToInt32() == (int)Win32API.WM.MOUSEMOVE)
                {
                }

                // Create event args
                MouseEventArgs e = new MouseEventArgs(buttons, clicks, hookStruct.pt.X, hookStruct.pt.Y, delta);

                if (MouseDown != null && (
                    wParam.ToInt32() == (int)Win32API.WM.LBUTTONDOWN ||
                    wParam.ToInt32() == (int)Win32API.WM.MBUTTONDOWN ||
                    wParam.ToInt32() == (int)Win32API.WM.RBUTTONDOWN ||
                    wParam.ToInt32() == (int)Win32API.WM.XBUTTONDOWN))
                {
                    MouseDown(this, e);
                }

                if ((MouseUp != null || Click != null || DoubleClick != null) && (
                    wParam.ToInt32() == (int)Win32API.WM.LBUTTONUP ||
                    wParam.ToInt32() == (int)Win32API.WM.MBUTTONUP ||
                    wParam.ToInt32() == (int)Win32API.WM.RBUTTONUP ||
                    wParam.ToInt32() == (int)Win32API.WM.XBUTTONUP))
                {
                    if (DoubleClick != null && clicks == 2)
                    {
                        DoubleClick(this, e);
                    }
                    if (Click != null && clicks == 1)
                    {
                        lastClick = hookStruct.time;
                        Debug.WriteLine("Time: " + lastClick);
                        Click(this, e);
                    }
                    if (MouseUp != null) MouseUp(this, e);
                }

                if (MouseWheel != null && wParam.ToInt32() == (int)Win32API.WM.MOUSEWHEEL)
                {
                    MouseWheel(this, e);
                }

                if (MouseMove != null && wParam.ToInt32() == (int)Win32API.WM.MOUSEMOVE)
                {
                    MouseMove(this, e);
                }
            }
            return Win32API.CallNextHookEx(mouseHook, code, wParam, lParam);
        }
    }
}
