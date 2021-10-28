using Prism.Mvvm;
using Prism.Commands;
using WindowHandlePicker.Models;
using System;
using System.Threading;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowHandlePicker.ViewModels
{
    [ValueConversion(typeof(string), typeof(int))]
    public class StrCnvInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool ret = int.TryParse(value.ToString(), out int v);

            return ret ? v : 0;
        }
    }

    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Window Handle Picker";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private int mouseX = 0;
        private int mouseY = 0;

        private int targetX = 0;
        private int targetY = 0;

        public int TargetX 
        { 
            get => targetX;
            set
            {
                SetProperty(ref targetX, value);
                FindWindow();
            }
        }

        public int TargetY
        {
            get => targetY;
            set
            {
                SetProperty(ref targetY, value);
                FindWindow();
            }
        }

        // デリゲート
        private NativeMethods.HOOKPROC _mouseProc;

        // メソッドを識別するID
        private IntPtr _mouseHookId = IntPtr.Zero;

        private int _hwnd = 0;
        public int Hwnd { get => _hwnd; private set => SetProperty(ref _hwnd, value); }

        public int MouseX { get => mouseX; private set => SetProperty(ref mouseX, value); }
        public int MouseY { get => mouseY; private set => SetProperty(ref mouseY, value); }

        private Task watchLoop;
        private bool isStop = false;

        private IntPtr hHook;

        private WindowInfoViewModel _windowInfoViewModel = new WindowInfoViewModel();
        public WindowInfoViewModel WindowInfoViewModel { get => _windowInfoViewModel; set => SetProperty(ref _windowInfoViewModel, value); }

        /// <summary>
        /// root Window のハンドル
        /// </summary>
        private WindowInfoViewModel _rootWindow = new WindowInfoViewModel();
        public WindowInfoViewModel RootWindowHandle { get => _rootWindow; private set => SetProperty(ref _rootWindow, value); }

        private void SendClickMessage()
        {
            if (WindowInfoViewModel.HWnd != IntPtr.Zero)
            {
                WindowInfoViewModel.Click();
            }
        }

        private void SendWriteTextMessage()
        {
            if (WindowInfoViewModel.HWnd != IntPtr.Zero)
            {
                WindowInfoViewModel.SendText(SendText);
            }
        }

        public DelegateCommand ClickExecute { get; private set; }

        private string sendText = "";
        public string SendText { get => sendText; set => SetProperty(ref sendText, value); }
        public DelegateCommand SendTextExecute { get; private set; }

        private void FindWindow()
        {
            POINT p = new POINT { x = TargetX, y = TargetY };

            var hwnd = NativeMethods.WindowFromPoint(p);

            if (hwnd.ToInt32() != 0)
            {
                WindowInfoViewModel = new WindowInfoViewModel(hwnd);

                IntPtr parentHWnd = NativeMethods.GetAncestor(hwnd, GaFlags.GA_ROOT);

                if (parentHWnd.ToInt32() != 0)
                {
                    RootWindowHandle = new WindowInfoViewModel(parentHWnd);
                }
            }
        }

        // マウス操作のイベントが発生したら実行されるメソッド
        private IntPtr MouseInputCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                // マウスのイベントに紐付けられた次のメソッドを実行する。メソッドがなければ処理終了。
                return NativeMethods.CallNextHookEx(_mouseHookId, nCode, wParam, lParam);
            }

            MSLLHOOKSTRUCT param = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);

            POINT p = new POINT();
            NativeMethods.GetCursorPos(out p);

            this.MouseX = p.x;
            this.MouseY = p.y;

            var h = NativeMethods.WindowFromPoint(p);
            Hwnd = h.ToInt32();

            // マウスのどのようなイベントが発生したのかで処理を分岐する。
            switch ((MouseMessage)wParam)
            {
                case MouseMessage.WM_LBUTTONDOWN:
                    // マウスの左ボタンが押し下げられたときに実行したい処理をここに書く。
                    break;
                case MouseMessage.WM_LBUTTONUP:
                    // マウスの左ボタンが押し上げられたときに実行したい処理をここに書く。
                    break;
                case MouseMessage.WM_MOUSEMOVE:
                    // マウスポインタが移動したときに実行したい処理をここに書く。
                    break;
                case MouseMessage.WM_MOUSEWHEEL:
                    // マウスホイールが回転されたときに実行したい処理をここに書く。

                    // 例
                    int wheelAmount = (param.mouseData >> 16) / 120;
                    // ホイールの回転量はparam.mouseDataの値を見れば分かる。
                    // wheelAmountの値が2の場合、ホイールが上（手前から奥）へカクカクッと2段階回転したことを意味する。
                    // wheelAmountの値が-1の場合、ホイールが下（奥から手前）へカクッと1段階回転したことを意味する。

                    break;
                case MouseMessage.WM_RBUTTONDOWN:
                    // マウスの右ボタンが押し下げられたときに実行したい処理をここに書く。

                    TargetX = p.x;
                    TargetY = p.y;

                    //if (Hwnd > 0)
                    //{
                    //    WindowInfoViewModel = new WindowInfoViewModel(h);
                    //}
                    

                    break;
                case MouseMessage.WM_RBUTTONUP:
                    // マウスの右ボタンが押し上げられたときに実行したい処理をここに書く。
                    break;
                case MouseMessage.WM_MBUTTONDOWN:
                    // マウスの中央ボタンが押し下げられたときに実行したい処理をここに書く。
                    break;
                case MouseMessage.WM_MBUTTONUP:
                    // マウスの中央ボタンが押し上げられたときに実行したい処理をここに書く。
                    break;
                default:
                    break;
            }

            // マウスのイベントに紐付けられた次のメソッドを実行する。メソッドがなければ処理終了。
            return NativeMethods.CallNextHookEx(_mouseHookId, nCode, wParam, lParam);
        }

        public MainWindowViewModel()
        {
            //SetHook();

            _mouseProc = new NativeMethods.HOOKPROC(MouseInputCallback);

            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                // メソッドをマウスのイベントに紐づける。
                _mouseHookId = NativeMethods.SetWindowsHookEx(HookType.WH_MOUSE_LL, _mouseProc, NativeMethods.GetModuleHandle(currentModule.ModuleName), IntPtr.Zero);
            }

            ClickExecute = new DelegateCommand(() => SendClickMessage());
            SendTextExecute = new DelegateCommand(() => SendWriteTextMessage());

            //watchLoop = Task.Run(() => {

            //    while (!isStop)
            //    {
            //        POINT p = new POINT();
            //        NativeMethods.GetCursorPos(out p);

            //        this.MouseX = p.x;
            //        this.MouseY = p.y;

            //        Hwnd = NativeMethods.WindowFromPoint(p).ToInt32();
            //    }

            //});
        }

        ~MainWindowViewModel()
        {
            //isStop = true;

            NativeMethods.UnhookWindowsHookEx(_mouseHookId);
        }
    }
}
