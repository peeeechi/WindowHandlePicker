using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowHandlePicker.Models;

namespace WindowHandlePicker.ViewModels
{
    public class WindowInfoViewModel : BindableBase
    {
        /// <summary>
        /// Window Handle
        /// </summary>
        private IntPtr _hWnd = IntPtr.Zero;
        public IntPtr HWnd 
        { 
            get => _hWnd;
            set
            {
                SetProperty(ref _hWnd, value);
                UpdateStatus();
            }
        }

        private string _className = "";
        public string ClassName { get => _className; private set => SetProperty(ref _className, value); }

        private string _windowText = "";
        public string WindowText { get => _windowText; private set => SetProperty(ref _windowText, value); }

        private WINDOWINFO _wi = new WINDOWINFO();
        
        private Int32 _pid;
        public Int32 Pid { get => _pid; private set => SetProperty(ref _pid, value); }

        public WindowInfoViewModel() { }

        public WindowInfoViewModel(IntPtr hWnd)
        {
            HWnd = hWnd;
        }

        public void UpdateStatus()
        {
            int retCode;
            ClassName = User32Util.GetClassName(_hWnd, out retCode);
            WindowText = User32Util.GetTextBySendMessage(_hWnd, out retCode);
            var info = User32Util.GetWindowInfo(_hWnd, out bool ret);
            if (!ret)
            {
               throw new Exception("GetWindowInfo returns 0.");
            }
            SetProperty(ref _wi, info);
            NativeMethods.GetWindowThreadProcessId(_hWnd, out Int32 pid);
            Pid = pid;
        }

        public void Click()
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                User32Util.Click(HWnd);
            });
           
        }

        public void SendText(string text)
        {
            bool isSuccess = User32Util.SetTextBySendMessage(HWnd, text, out int retCode);
        }
    }
}
