using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowHandlePicker.Models
{
    // https://qiita.com/kob58im/items/34724e36603351d78596#1-2-findwindowex

    /// <summary>
    /// POINT構造体は、ポイントのx座標とy座標を定義します
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/previous-versions/dd162805(v=vs.85)"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        /// ポイントのx座標
        /// </summary>
        public Int32 x;

        /// <summary>
        /// ポイントのy座標
        /// </summary>
        public Int32 y;

    }

    /// <summary>
    /// RECT構造は、左上隅と右下隅の座標によって長方形を定義します
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// 長方形の左上隅のx座標を指定します
        /// </summary>
        public Int32 left;
        /// <summary>
        /// 長方形の左上隅のy座標を指定します
        /// </summary>
        public Int32 top;
        /// <summary>
        /// 長方形の右下隅のx座標を指定します
        /// </summary>
        public Int32 right;
        /// <summary>
        /// 長方形の右下隅のy座標を指定します
        /// </summary>
        public Int32 bottom;
        /// <summary>
        /// 長方形の幅を取得します
        /// </summary>
        // public Int32 width { get => right-left; }
        /// <summary>
        /// 長方形の高さを取得します
        /// </summary>
        // public Int32 height { get => bottom-top; }
    }

    /// <summary>
    /// ウィンドウ情報が含まれています
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-windowinfo"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWINFO
    {
        /// <summary>
        /// 構造体のサイズ（バイト単位）<br/>
        /// 呼び出し元は、このメンバーをsizeof（WINDOWINFO）に設定する必要があります
        /// </summary>
        public Int32 cbSize;
        /// <summary>
        /// ウィンドウの座標
        /// </summary>
        public RECT rcWindow;
        /// <summary>
        /// クライアントエリアの座標
        /// </summary>
        public RECT rcClient;
        /// <summary>
        /// ウィンドウスタイル
        /// </summary>
        //public UInt32 dwStyle;
        public WindowStyles dwStyle;

        /// <summary>
        /// 拡張ウィンドウスタイル<br/>
        /// 拡張ウィンドウスタイルの表については、拡張ウィンドウスタイルを参照してください<br/>
        /// </summary>
        //public UInt32 dwExStyle;
        public ExtendedWindowStyles dwExStyle;

        /// <summary>
        /// ウィンドウのステータス<br/>このメンバーがWS_ACTIVECAPTION(0x0001)の場合、ウィンドウはアクティブです<br/>それ以外の場合、このメンバーは(0x0000)です<br/>
        /// </summary>
        public UInt32 dwWindowStatus;

        /// <summary>
        /// ウィンドウの境界線の幅（ピクセル単位）
        /// </summary>
        public UInt32 cxWindowBorders;
        /// <summary>
        /// ウィンドウの境界線の高さ（ピクセル単位）
        /// </summary>
        public UInt32 cyWindowBorders;
        /// <summary>
        /// ウィンドウクラスアトム
        /// </summary>
        public UInt16 atomWindowType;
        /// <summary>
        /// ウィンドウを作成したアプリケーションのWindowsバージョン
        /// </summary>
        public UInt16 wCreatorVersion;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class MOUSEHOOKSTRUCT
    {
        public POINT pt;
        public int hwnd;
        public int wHitTestCode;
        public int dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEHOOKSTRUCTEX
    {
        public MOUSEHOOKSTRUCT mouseHookStruct;
        public int MouseData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public UIntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Win32Point
    {
        public Int32 X;
        public Int32 Y;
    }

    
    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    //internal const int WHEEL_DELTA              = 120;

    //internal const int KEYEVENTF_KEYDOWN        = 0x00000000;
    //internal const int KEYEVENTF_KEYUP          = 0x00000002;
    //internal const int KEYEVENTF_EXTENDEDKEY    = 0x000000001;


    /// <summary>
    /// マウスの動きとボタンのクリックのさまざまな側面を制御します<br/>このパラメーターは、次の値の特定の組み合わせにすることができます<br/>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event
    /// </summary>
    [Flags]
    public enum MouseEventFlgs: UInt32
    {
        /// <summary>
        /// DX及び DYのパラメータが正規化された絶対座標を含みます<br/>設定されていない場合、これらのパラメーターには相対データ（最後に報告された位置以降の位置の変化）が含まれます<br/>このフラグは、システムに接続されているマウスまたはマウスのようなデバイスの種類に関係なく、設定することも設定しないこともできます<br/>マウスの相対的な動きの詳細については、次の「備考」セクションを参照してください<br/>
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000,
        /// <summary>
        /// 左ボタンが下がっています<br/>
        /// </summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        /// <summary>
        /// 左ボタンが上がっています<br/>
        /// </summary>
        MOUSEEVENTF_LEFTUP = 0x0004,
        /// <summary>
        /// 真ん中のボタンが下がっています<br/>
        /// </summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        /// <summary>
        /// 真ん中のボタンが上がっています<br/>
        /// </summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        /// <summary>
        /// 動きが発生しました<br/>
        /// </summary>
        MOUSEEVENTF_MOVE = 0x0001,
        /// <summary>
        /// 右ボタンが下がっています<br/>
        /// </summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        /// <summary>
        /// 右ボタンが上がっています<br/>
        /// </summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,
        /// <summary>
        /// マウスにホイールがある場合は、ホイールが移動しています<br/>移動量はdwDataで指定されます
        /// </summary>
        MOUSEEVENTF_WHEEL = 0x0800,
        /// <summary>
        /// Xボタンが押されました<br/>
        /// </summary>
        MOUSEEVENTF_XDOWN = 0x0080,
        /// <summary>
        /// Xボタンが離されました<br/>
        /// </summary>
        MOUSEEVENTF_XUP = 0x0100,
        /// <summary>
        /// ホイールボタンが傾いています<br/>
        /// </summary>
        MOUSEEVENTF_HWHEEL = 0x01000,
    }

    internal enum MouseMessage
    {
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_MOUSEMOVE = 0x0200,
        WM_MOUSEWHEEL = 0x020A,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208
    }

    /// <summary>
    /// SendMessage, SendMessageTimeoutで使用するメッセージ<br/>
    /// https://docs.microsoft.com/en-us/windows/win32/winmsg/about-messages-and-message-queues#windows-messages
    /// </summary>
    public enum WindowsMessage : UInt32
    {
        /// <summary>
        /// ウィンドウのテキストを設定します<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-settext
        /// </summary>
        WM_SETTEXT = 0x000C,
        /// <summary>
        /// ウィンドウに対応するテキストを、呼び出し元によって提供されたバッファーにコピーします<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-gettext 
        /// </summary>
        WM_GETTEXT = 0x000D,
        /// <summary>
        /// ウィンドウに関連付けられたテキストの長さを文字数で決定します<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-gettextlength 
        /// </summary>
        WM_GETTEXTLENGTH = 0x000E,
        /// <summary>
        /// ユーザーがボタンをクリックするのをシミュレートします<br/>
        /// このメッセージにより、ボタンはWM_LBUTTONDOWNおよびWM_LBUTTONUPメッセージを受信し、ボタンの親ウィンドウはBN_CLICKED通知コードを受信します<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/controls/bm-click
        /// </summary>
        BM_CLICK = 0x00F5,
    }

    /// <summary>
    /// 以下はウィンドウスタイルです<br/>
    /// ウィンドウが作成された後は、特に明記されている場合を除き、これらのスタイルを変更することはできません<br/>
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/winmsg/window-styles"/>
    public enum WindowStyles : UInt32
    {
        /// <summary>
        ///  ウィンドウには細い線の境界線があります<br/>
        /// </summary>
        WS_BORDER = 0x00800000,
        /// <summary>
        ///  ウィンドウにはタイトルバーがあります（WS_BORDERスタイルを含みます）<br/>
        /// </summary>
        WS_CAPTION = 0x00C00000,
        /// <summary>
        ///  ウィンドウは子ウィンドウです<br/>このスタイルのウィンドウにはメニューバーを含めることはできません<br/>このスタイルは、WS_POPUPスタイルでは使用できません<br/>
        /// </summary>
        WS_CHILD = 0x40000000,
        /// <summary>
        ///  WS_CHILDスタイルと同じです<br/>
        /// </summary>
        WS_CHILDWINDOW = 0x40000000,
        /// <summary>
        ///  親ウィンドウ内で描画が行われるときに子ウィンドウが占める領域を除外します<br/>このスタイルは、親ウィンドウを作成するときに使用されます<br/>
        /// </summary>
        WS_CLIPCHILDREN = 0x02000000,
        /// <summary>
        ///  子ウィンドウを相互に関連してクリップします<br/>つまり、特定の子ウィンドウがWM_PAINTメッセージを受信すると、WS_CLIPSIBLINGSスタイルは、更新される子ウィンドウの領域から他のすべての重複する子ウィンドウをクリップします<br/>場合はWS_CLIPSIBLINGSが指定されていないと、子ウィンドウが重なって隣の子ウィンドウのクライアント領域内に描画するために、子ウィンドウのクライアント領域内に描画するとき、それは、可能です<br/>
        /// </summary>
        WS_CLIPSIBLINGS = 0x04000000,
        /// <summary>
        ///  ウィンドウは最初は無効になっています<br/>無効にされたウィンドウは、ユーザーからの入力を受け取ることができません<br/>ウィンドウの作成後にこれを変更するには、EnableWindow関数を使用します<br/>
        /// </summary>
        WS_DISABLED = 0x08000000,
        /// <summary>
        ///  ウィンドウには、ダイアログボックスで通常使用されるスタイルの境界線があります<br/>このスタイルのウィンドウには、タイトルバーを含めることはできません<br/>
        /// </summary>
        WS_DLGFRAME = 0x00400000,
        /// <summary>
        ///  ウィンドウは、コントロールのグループの最初のコントロールです<br/>グループは、この最初のコントロールとその後に定義されたすべてのコントロールで構成され、WS_GROUPスタイルの次のコントロールまで続きます<br/>各グループの最初のコントロールは通常、ユーザーがグループ間を移動できるようにWS_TABSTOPスタイルを持っています<br/>その後、ユーザーは方向キーを使用して、キーボードのフォーカスをグループ内の1つのコントロールからグループ内の次のコントロールに変更できます<br/>このスタイルのオンとオフを切り替えて、ダイアログボックスのナビゲーションを変更できます<br/>ウィンドウの作成後にこのスタイルを変更するには、SetWindowLong関数を使用します<br/>
        /// </summary>
        WS_GROUP = 0x00020000,
        /// <summary>
        ///  ウィンドウには水平スクロールバーがあります<br/>
        /// </summary>
        WS_HSCROLL = 0x00100000,
        /// <summary>
        ///  ウィンドウは最初は最小化されています<br/>WS_MINIMIZEスタイルと同じです<br/>
        /// </summary>
        WS_ICONIC = 0x20000000,
        /// <summary>
        ///  ウィンドウは最初に最大化されます<br/>
        /// </summary>
        WS_MAXIMIZE = 0x01000000,
        /// <summary>
        ///  ウィンドウには最大化ボタンがあります<br/>WS_EX_CONTEXTHELPスタイルと組み合わせることはできません<br/>WS_SYSMENUのスタイルも指定する必要があります<br/>
        /// </summary>
        WS_MAXIMIZEBOX = 0x00010000,
        /// <summary>
        ///  ウィンドウは最初は最小化されています<br/>WS_ICONICスタイルと同じです<br/>
        /// </summary>
        WS_MINIMIZE = 0x20000000,
        /// <summary>
        ///  ウィンドウには最小化ボタンがあります<br/>WS_EX_CONTEXTHELPスタイルと組み合わせることはできません<br/>WS_SYSMENUのスタイルも指定する必要があります<br/>
        /// </summary>
        WS_MINIMIZEBOX = 0x00020000,
        /// <summary>
        ///  ウィンドウはオーバーラップしたウィンドウです<br/>重なったウィンドウには、タイトルバーと境界線があります<br/>WS_TILEDスタイルと同じです<br/>
        /// </summary>
        WS_OVERLAPPED = 0x00000000,

        /// <summary>
        ///  ウィンドウはオーバーラップしたウィンドウです<br/>WS_TILEDWINDOWスタイルと同じです<br/>
        /// </summary>
        WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),

        /// <summary>
        ///  ウィンドウはポップアップウィンドウです<br/>このスタイルは、WS_CHILDスタイルでは使用できません<br/>
        /// </summary>
        WS_POPUP = 0x80000000,

        /// <summary>
        ///  ウィンドウはポップアップウィンドウです<br/>WS_CAPTIONとWS_POPUPWINDOWスタイルは、ウィンドウメニューが表示されるように組み合わせる必要があります<br/>
        /// </summary>
        WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
        /// <summary>
        ///  ウィンドウにはサイズの境界線があります<br/>WS_THICKFRAMEスタイルと同じです<br/>
        /// </summary>
        WS_SIZEBOX = 0x00040000,
        /// <summary>
        ///  ウィンドウのタイトルバーにはウィンドウメニューがあります<br/>WS_CAPTIONのスタイルも指定する必要があります<br/>
        /// </summary>
        WS_SYSMENU = 0x00080000,
        /// <summary>
        ///  ウィンドウは、ユーザーがTabキーを押したときにキーボードフォーカスを受け取ることができるコントロールです<br/>Tabキーを押すと、キーボードのフォーカスがWS_TABSTOPスタイルの次のコントロールに変わります<br/>このスタイルのオンとオフを切り替えて、ダイアログボックスのナビゲーションを変更できます<br/>ウィンドウの作成後にこのスタイルを変更するには、SetWindowLong関数を使用します<br/>ユーザーが作成したウィンドウとモードレスダイアログがタブストップで機能するようにするには、メッセージループを変更してIsDialogMessage関数を呼び出します<br/>
        /// </summary>
        WS_TABSTOP = 0x00010000,

        /// <summary>
        ///  ウィンドウにはサイズの境界線があります<br/>WS_SIZEBOXスタイルと同じです<br/>
        /// </summary>
        WS_THICKFRAME = 0x00040000,

        /// <summary>
        ///  ウィンドウはオーバーラップしたウィンドウです<br/>重なったウィンドウには、タイトルバーと境界線があります<br/>WS_OVERLAPPEDスタイルと同じです<br/>
        /// </summary>
        WS_TILED = 0x00000000,

        /// <summary>
        ///  ウィンドウはオーバーラップしたウィンドウです<br/>WS_OVERLAPPEDWINDOWスタイルと同じです<br/>
        /// </summary>
        WS_TILEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),

        /// <summary>
        ///  ウィンドウは最初に表示されます<br/>このスタイルは、ShowWindowまたはSetWindowPos関数を使用してオンとオフを切り替えることができます<br/>
        /// </summary>
        WS_VISIBLE = 0x10000000,

        /// <summary>
        ///  ウィンドウには垂直スクロールバーがあります<br/>
        /// </summary>
        WS_VSCROLL = 0x00200000,
    }

    /// <summary>
    /// 以下は、拡張ウィンドウスタイルです<br/>
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/winmsg/extended-window-styles"/>
    public enum ExtendedWindowStyles : UInt32
    {
        /// <summary>
        ///  ウィンドウはドラッグアンドドロップファイルを受け入れます<br/>
        /// </summary>
        WS_EX_ACCEPTFILES = 0x00000010,
        /// <summary>
        ///  ウィンドウが表示されているときに、トップレベルウィンドウをタスクバーに強制します<br/>
        /// </summary>
        WS_EX_APPWINDOW = 0x00040000,
        /// <summary>
        ///  窓には縁がくぼんだ境界線があります<br/>
        /// </summary>
        WS_EX_CLIENTEDGE = 0x00000200,
        /// <summary>
        ///  ダブルバッファリングを使用して、ウィンドウのすべての子孫を下から上にペイントする順序でペイントします<br/>下から上へのペイント順序により、子孫ウィンドウに半透明（アルファ）および透明（カラーキー）効果を持たせることができますが、子孫ウィンドウにもWS_EX_TRANSPARENTビットが設定されている場合に限ります<br/>ダブルバッファリングにより、ウィンドウとその子孫をちらつきなくペイントできます<br/>ウィンドウのクラススタイルがCS_OWNDCまたはCS_CLASSDCの場合、これは使用できません<br/>Windows 2000：このスタイルはサポートされていません<br/>
        /// </summary>
        WS_EX_COMPOSITED = 0x02000000,
        /// <summary>
        ///  ウィンドウのタイトルバーには疑問符が含まれています<br/>ユーザーが疑問符をクリックすると、カーソルがポインター付きの疑問符に変わります<br/>その後、ユーザーが子ウィンドウをクリックすると、子はWM_HELPメッセージを受け取ります<br/>子ウィンドウはメッセージを親ウィンドウプロシージャに渡す必要があります<br/>親ウィンドウプロシージャは、HELP_WM_HELPコマンドを使用してWinHelp関数を呼び出す必要があります<br/>ヘルプアプリケーションは、通常、子ウィンドウのヘルプを含むポップアップウィンドウを表示します<br/>WS_EX_CONTEXTHELPは、WS_MAXIMIZEBOXまたはWS_MINIMIZEBOXスタイルでは使用できません<br/>
        /// </summary>
        WS_EX_CONTEXTHELP = 0x00000400,

        /// <summary>
        ///  ウィンドウ自体には、ダイアログボックスのナビゲーションに参加する必要のある子ウィンドウが含まれています<br/>このスタイルが指定されている場合、Tabキー、矢印キー、またはキーボードニーモニックの処理などのナビゲーション操作を実行すると、ダイアログマネージャーはこのウィンドウの子に戻ります<br/>
        /// </summary>
        WS_EX_CONTROLPARENT = 0x00010000,
        /// <summary>
        ///  ウィンドウには二重の境界線があります<br/>オプションで、dwStyleパラメーターでWS_CAPTIONスタイルを指定することにより、タイトルバーを使用してウィンドウを作成できます<br/>
        /// </summary>
        WS_EX_DLGMODALFRAME = 0x00000001,
        /// <summary>
        ///  ウィンドウは階層化されたウィンドウです<br/>ウィンドウのクラススタイルがCS_OWNDCまたはCS_CLASSDCの場合、このスタイルは使用できません<br/>Windowsの8：WS_EX_LAYEREDスタイルがトップレベルウィンドウと子ウィンドウのためにサポートされています<br/>以前のWindowsバージョンは、トップレベルウィンドウに対してのみWS_EX_LAYEREDをサポートします<br/>
        /// </summary>
        WS_EX_LAYERED = 0x00080000,
        /// <summary>
        ///  シェル言語がヘブライ語、アラビア語、または読み取り順序の配置をサポートする別の言語である場合、ウィンドウの水平方向の原点は右端にあります<br/>水平方向の値を大きくすると、左に進みます<br/>
        /// </summary>
        WS_EX_LAYOUTRTL = 0x00400000,
        /// <summary>
        ///  ウィンドウには、一般的な左揃えのプロパティがあります<br/>これがデフォルトです<br/>
        /// </summary>
        WS_EX_LEFT = 0x00000000,
        /// <summary>
        ///  シェル言語がヘブライ語、アラビア語、または読み取り順序の配置をサポートする別の言語の場合、垂直スクロールバー（存在する場合）はクライアント領域の左側にあります<br/>他の言語の場合、スタイルは無視されます<br/>
        /// </summary>
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        /// <summary>
        ///  ウィンドウテキストは、左から右への読み取り順序プロパティを使用して表示されます<br/>これがデフォルトです<br/>
        /// </summary>
        WS_EX_LTRREADING = 0x00000000,
        /// <summary>
        ///  ウィンドウはMDI子ウィンドウです<br/>
        /// </summary>
        WS_EX_MDICHILD = 0x00000040,
        /// <summary>
        ///  このスタイルで作成されたトップレベルウィンドウは、ユーザーがクリックしてもフォアグラウンドウィンドウにはなりません<br/>ユーザーがフォアグラウンドウィンドウを最小化または閉じたときに、システムはこのウィンドウをフォアグラウンドに移動しません<br/>ウィンドウは、プログラムによるアクセスや、ナレーターなどのアクセシブルなテクノロジーによるキーボードナビゲーションを介してアクティブ化しないでください<br/>ウィンドウをアクティブにするには、SetActiveWindowまたはSetForegroundWindow関数を使用します<br/>デフォルトでは、ウィンドウはタスクバーに表示されません<br/>ウィンドウをタスクバーに強制的に表示するには、WS_EX_APPWINDOWスタイルを使用します<br/>
        /// </summary>
        WS_EX_NOACTIVATE = 0x08000000,
        /// <summary>
        ///  ウィンドウは、ウィンドウレイアウトを子ウィンドウに渡しません<br/>
        /// </summary>
        WS_EX_NOINHERITLAYOUT = 0x00100000,
        /// <summary>
        ///  このスタイルで作成された子ウィンドウは、作成または破棄されたときに、WM_PARENTNOTIFYメッセージを親ウィンドウに送信しません<br/>
        /// </summary>
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        /// <summary>
        ///  ウィンドウはリダイレクトサーフェスにレンダリングされません<br/>これは、目に見えるコンテンツがないウィンドウ、またはサーフェス以外のメカニズムを使用してビジュアルを提供するウィンドウ用です<br/>
        /// </summary>
        WS_EX_NOREDIRECTIONBITMAP = 0x00200000,
        /// <summary>
        ///  ウィンドウはオーバーラップしたウィンドウです
        /// </summary>
        WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
        /// <summary>
        ///  ウィンドウはパレットウィンドウで、コマンドの配列を表示するモードレスダイアログボックスです<br/>
        /// </summary>
        WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),
        /// <summary>
        ///  ウィンドウには、一般的な「右揃え」プロパティがあります<br/>これはウィンドウクラスによって異なります<br/>このスタイルは、シェル言語がヘブライ語、アラビア語、または読み順の配置をサポートする別の言語である場合にのみ効果があります<br/>それ以外の場合、スタイルは無視されます<br/>静的コントロールまたは編集コントロールにWS_EX_RIGHTスタイルを使用すると、それぞれSS_RIGHTまたはES_RIGHTスタイルを使用した場合と同じ効果があります<br/>このスタイルをボタンコントロールで使用すると、BS_RIGHTおよびBS_RIGHTBUTTONスタイルを使用するのと同じ効果があります<br/>
        /// </summary>
        WS_EX_RIGHT = 0x00001000,
        /// <summary>
        ///  垂直スクロールバー（存在する場合）は、クライアント領域の右側にあります<br/>これがデフォルトです<br/>
        /// </summary>
        WS_EX_RIGHTSCROLLBAR = 0x00000000,
        /// <summary>
        ///  シェル言語がヘブライ語、アラビア語、または読み順の配置をサポートする別の言語の場合、ウィンドウのテキストは右から左への読み順のプロパティを使用して表示されます<br/>他の言語の場合、スタイルは無視されます<br/>
        /// </summary>
        WS_EX_RTLREADING = 0x00002000,
        /// <summary>
        ///  ウィンドウには、ユーザー入力を受け入れないアイテムに使用することを目的とした3次元の境界線スタイルがあります<br/>
        /// </summary>
        WS_EX_STATICEDGE = 0x00020000,
        /// <summary>
        ///  このウィンドウは、フローティングツールバーとして使用することを目的としています<br/>ツールウィンドウには、通常のタイトルバーよりも短いタイトルバーがあり、ウィンドウのタイトルは小さいフォントを使用して描画されます<br/>ツールウィンドウは、タスクバーまたはユーザーがALT + TABを押したときに表示されるダイアログには表示されません<br/>ツールウィンドウにシステムメニューがある場合、そのアイコンはタイトルバーに表示されません<br/>ただし、右クリックするか、ALT + SPACEと入力すると、システムメニューを表示できます<br/>
        /// </summary>
        WS_EX_TOOLWINDOW = 0x00000080,
        /// <summary>
        ///  ウィンドウは、最上位以外のすべてのウィンドウの上に配置し、ウィンドウが非アクティブ化されている場合でも、その上にとどまる必要があります<br/>このスタイルを追加または削除するには、SetWindowPos関数を使用します<br/>
        /// </summary>
        WS_EX_TOPMOST = 0x00000008,
        /// <summary>
        ///  ウィンドウの下の兄弟（同じスレッドによって作成されたもの）がペイントされるまで、ウィンドウはペイントされるべきではありません<br/>下にある兄弟ウィンドウのビットがすでにペイントされているため、ウィンドウは透明に見えます<br/>これらの制限なしに透過性を実現するには、SetWindowRgn関数を使用します<br/>
        /// </summary>
        WS_EX_TRANSPARENT = 0x00000020,
        /// <summary>
        ///  ウィンドウには、隆起したエッジのある境界線があります<br/>
        /// </summary>
        WS_EX_WINDOWEDGE = 0x00000100,
    }

    public enum GaFlags : UInt32
    {
        /// <summary>
        /// 親ウィンドウを取得します<br/> GetParent関数の場合のように、これには所有者は含まれません<br/>
        /// </summary>
        GA_PARENT = 0x0001,
        /// <summary>
        /// 親ウィンドウのチェーンをたどってルートウィンドウを取得します<br/>
        /// </summary>
        GA_ROOT = 0x0002,
        /// <summary>
        /// GetParentによって返された親ウィンドウと所有者ウィンドウのチェーンをたどって、所有されているルートウィンドウを取得します<br/>
        /// </summary>
        GA_ROOTOWNER = 0x0003
    }

    public enum SendMessageTimeoutFlgs : UInt32
    {
        /// <summary>
        /// 受信スレッドが応答しない、または「ハング」しているように見える場合、関数はタイムアウト期間が経過するのを待たずに戻ります<br/>
        /// </summary>
        SMTO_ABORTIFHUNG = 0x0002,

        /// <summary>
        /// 関数が戻るまで、呼び出し元のスレッドが他の要求を処理しないようにします<br/>
        /// </summary>
        SMTO_BLOCK = 0x0001,

        /// <summary>
        /// 呼び出し元のスレッドは、関数が戻るのを待っている間、他の要求を処理することを妨げられません<br/>
        /// </summary>
        SMTO_NORMAL = 0x0000,

        /// <summary>
        /// この関数は、受信スレッドがメッセージを処理している限り、タイムアウト期間を強制しません<br/>
        /// </summary>
        SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,

        /// <summary>
        /// メッセージの処理中に受信ウィンドウが破壊された場合、または所有しているスレッドが停止した場合、関数は0を返す必要があります<br/>
        /// </summary>
        SMTO_ERRORONEXIT = 0x0020,

    }

    public enum WindowLongParam
    {
        GWL_WNDPROC = -4,
        GWLP_HINSTANCE = -6,
        GWLP_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_EXSTYLE = -20,
        GWL_USERDATA = -21,
        DWLP_MSGRESULT = 0,
        DWLP_USER = 8,
        DWLP_DLGPROC = 4
    }

    [Flags()]
    public enum SetWindowPosFlags : UInt32
    {
        SWP_ASYNCWINDOWPOS = 0x4000,
        SWP_DEFERERASE = 0x2000,
        SWP_DRAWFRAME = 0x0020,
        SWP_FRAMECHANGED = 0x0020,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOACTIVATE = 0x0010,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOMOVE = 0x0002,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOREDRAW = 0x0008,
        SWP_NOREPOSITION = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_NOSIZE = 0x0001,
        SWP_NOZORDER = 0x0004,
        SWP_SHOWWINDOW = 0x0040,
    }

    public enum HCBT : Int32
    {
        HCBT_MOVESIZE = 0,
        HCBT_MINMAX = 1,
        HCBT_QS = 2,
        HCBT_CREATEWND = 3,
        HCBT_DESTROYWND = 4,
        HCBT_ACTIVATE = 5,
        HCBT_CLICKSKIPPED = 6,
        HCBT_KEYSKIPPED = 7,
        HCBT_SYSCOMMAND = 8,
        HCBT_SETFOCUS = 9,
    }

    /// <summary>
    /// インストールするフック手順のタイプ<br/>このパラメーターは、次のいずれかの値になります<br/>
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa
    /// </summary>
    public enum HookType : Int32
    {
        /// <summary>
        /// システムがメッセージを宛先ウィンドウプロシージャに送信する前にメッセージを監視するフックプロシージャをインストールします<br/>詳細については、CallWndProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// メッセージが宛先ウィンドウプロシージャによって処理された後にメッセージを監視するフックプロシージャをインストールします<br/>詳細については、CallWndRetProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// CBTアプリケーションに役立つ通知を受信するフックプロシージャをインストールします<br/>詳細については、CBTProcフック手順を参照してください<br/>
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// 他のフックプロシージャのデバッグに役立つフックプロシージャをインストールします<br/>詳細については、DebugProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// アプリケーションのフォアグラウンドスレッドがアイドル状態になりそうなときに呼び出されるフックプロシージャをインストールします<br/>このフックは、アイドル時間中に優先度の低いタスクを実行する場合に役立ちます<br/>詳細については、ForegroundIdleProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// メッセージキューに投稿されたメッセージを監視するフックプロシージャをインストールします<br/>詳細については、GetMsgProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// WH_JOURNALRECORDフックプロシージャ によって以前に記録されたメッセージを投稿するフックプロシージャをインストールします<br/>詳細については、JournalPlaybackProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// システムメッセージキューに投稿された入力メッセージを記録するフックプロシージャをインストールします<br/>このフックは、マクロの記録に役立ちます<br/>詳細については、JournalRecordProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// キーストロークメッセージを監視するフックプロシージャをインストールします<br/>詳細については、KeyboardProcフック手順を参照してください<br/>
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// 低レベルのキーボード入力イベントを監視するフックプロシージャをインストールします<br/>詳細については、LowLevelKeyboardProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// マウスメッセージを監視するフックプロシージャをインストールします<br/>詳細については、MouseProcフック手順を参照してください<br/>
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// 低レベルのマウス入力イベントを監視するフックプロシージャをインストールします<br/>詳細については、LowLevelMouseProcフックプロシージャを参照してください<br/>
        /// </summary>
        WH_MOUSE_LL = 14,
        /// <summary>
        /// ダイアログボックス、メッセージボックス、メニュー、またはスクロールバーでの入力イベントの結果として生成されたメッセージを監視するフックプロシージャをインストールします<br/>詳細については、MessageProcフック手順を参照してください<br/>
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// シェルアプリケーションに役立つ通知を受け取るフックプロシージャをインストールします<br/>詳細については、ShellProcフック手順を参照してください<br/>
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// ダイアログボックス、メッセージボックス、メニュー、またはスクロールバーでの入力イベントの結果として生成されたメッセージを監視するフックプロシージャをインストールします<br/>フックプロシージャは、呼び出し元のスレッドと同じデスクトップ内のすべてのアプリケーションについて、これらのメッセージを監視します<br/>詳細については、SysMsgProcフック手順を参照してください<br/>
        /// </summary>
        WH_SYSMSGFILTER = 6,
    }

    public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

    /// <summary>
    /// User32.dllのラップ関数群
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// 画面座標でのマウスカーソルの位置を取得します
        /// </summary>
        /// <param name="lpPoint">カーソルの画面座標を受け取るPOINT構造体へのポインター</param>
        /// <returns>成功した場合はゼロ以外を返し、そうでない場合はゼロを返します<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します</returns>
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos([Out] out POINT lpPoint);

        /// <summary>
        /// ウィンドウをアクティブにします<br/>ウィンドウは、呼び出し元のスレッドのメッセージキューに接続する必要があります<br/>
        /// 備考: <br/>
        /// SetActiveWindow関数は、アプリケーションがバックグラウンドにある場合はウィンドウをアクティブにしません<br/>
        /// ウィンドウは、システムがウィンドウをアクティブにしたときに、そのアプリケーションがフォアグラウンドにある場合、前面(Z オーダーの上部) に表示されます<br/>
        /// hWndパラメータで識別されたウィンドウが呼び出し元のスレッドによって作成された場合、呼び出しスレッドのアクティブ ウィンドウの状態はhWndに設定されます<br/>
        /// それ以外の場合、呼び出し元スレッドのアクティブ ウィンドウの状態はNULLに設定されます
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setactivewindow"/> 
        /// <param name="hWnd">アクティブ化するトップレベルウィンドウへのハンドル</param>
        /// <returns>関数が成功した場合、戻り値は以前アクティブだったウィンドウへのハンドルです</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetActiveWindow([In] IntPtr hWnd);

        /// <summary>
        /// 指定されたポイントを含むウィンドウへのハンドルを取得します<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-windowfrompoint"/>
        /// <param name="point">チェックするポイント</param>
        /// <returns>戻り値は、ポイントを含むウィンドウへのハンドルです<br/>
        /// 指定されたポイントにウィンドウが存在しない場合、戻り値はNULLです<br/>
        /// ポイントが静的テキストコントロール上にある場合、戻り値は静的テキストコントロールの下のウィンドウへのハンドルです</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr WindowFromPoint([In] POINT point);

        /// <summary>
        /// クラス名とウィンドウ名が指定された文字列と一致するウィンドウへのハンドルを取得します<br/>この関数は、指定された子ウィンドウの次のウィンドウから始めて、子ウィンドウを検索します<br/>この関数は、大文字と小文字を区別する検索を実行しません<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowexa"/>
        /// <param name="hWndParent">子ウィンドウが検索される親ウィンドウへのハンドル<br/>hwndParentがNULLの場合、関数はデスクトップウィンドウを親ウィンドウとして使用します<br/>この関数は、デスクトップの子ウィンドウであるウィンドウを検索します<br/>hwndParentがHWND_MESSAGEの場合、関数はすべてのメッセージのみのウィンドウを検索します<br/></param>
        /// <param name="hWndChildAfter">子ウィンドウへのハンドル<br/>検索は、Zオーダーの次の子ウィンドウから始まります<br/>子ウィンドウは、子孫ウィンドウだけでなく、hwndParentの直接の子ウィンドウである必要があります<br/>        hwndChildAfterがNULLの場合、検索はhwndParentの最初の子ウィンドウから始まります<br/></param>
        /// <param name="lpszClass">RegisterClassまたはRegisterClassEx関数への以前の呼び出しによって作成されたクラス名またはクラスアトム<br/>アトムは、lpszClassの下位ワードに配置する必要があります<br/>上位ワードはゼロでなければなりません<br/>        lpszClassが文字列の場合、ウィンドウクラス名を指定します<br/>クラス名は、RegisterClassまたはRegisterClassExに登録されている任意の名前、または事前定義された制御クラス名のいずれか、またはMAKEINTATOM（0x8000）にすることができます<br/>この後者の場合、0x8000はメニュークラスのアトムです<br/>詳細については、このトピックの「備考」セクションを参照してください<br/></param>
        /// <param name="lpszWindow">ウィンドウ名（ウィンドウのタイトル）<br/>このパラメーターがNULLの場合、すべてのウィンドウ名が一致します<br/></param>
        /// <returns>関数が成功した場合、戻り値は、指定されたクラス名とウィンドウ名を持つウィンドウへのハンドルです<br/>関数が失敗した場合、戻り値はNULLです<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx([In] IntPtr hWndParent, [In] IntPtr hWndChildAfter, [In] string lpszClass, [In] string lpszWindow);
        // public static extern IntPtr FindWindowExA([In]IntPtr hWndParent, [In]IntPtr hWndChildAfter, [In]string lpszClass, [In]string lpszWindow);

        /// <summary>
        /// 指定されたウィンドウの祖先へのハンドルを取得します<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getancestor"/>
        /// <param name="hWnd">祖先を取得するウィンドウへのハンドル<br/>このパラメータがデスクトップウィンドウの場合、関数はNULLを返します<br/></param>
        /// <param name="gaFlags">取得する祖先<br/>このパラメーターは、次のいずれかの値になります<br/></param>
        /// <returns>戻り値は、祖先ウィンドウへのハンドルです<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetAncestor([In] IntPtr hWnd, [In] GaFlags gaFlags);

        /// <summary>
        /// フォアグラウンドウィンドウ（ユーザーが現在作業しているウィンドウ）へのハンドルを取得します<br/>システムは、フォアグラウンドウィンドウを作成するスレッドに、他のスレッドよりもわずかに高い優先度を割り当てます
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getforegroundwindow"/>
        /// <returns>戻り値は、フォアグラウンドウィンドウへのハンドルです<br/>ウィンドウがアクティブ化を失っている場合など、特定の状況では、フォアグラウンドウィンドウがNULLになる可能性があります<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 各ウィンドウへのハンドルをアプリケーション定義のコールバック関数に渡すことにより、画面上のすべてのトップレベルウィンドウを列挙します<br/> EnumWindowsは、最後の最上位ウィンドウが列挙されるか、コールバック関数がFALSEを返すまで続きます<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-enumwindows"/>
        /// <param name="lpEnumFunc">アプリケーション定義のコールバック関数へのポインター<br/>詳細については、EnumWindowsProcを参照してください<br/></param>
        /// <param name="lParam">コールバック関数に渡されるアプリケーション定義の値<br/></param>
        /// <returns>関数が成功した場合、戻り値はゼロ以外です<br/>関数が失敗した場合、戻り値はゼロです<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/>EnumWindowsProcがゼロを返す場合、戻り値もゼロです<br/>この場合、コールバック関数はSetLastErrorを呼び出して、EnumWindowsの呼び出し元に返される意味のあるエラーコードを取得する必要があります<br/></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows([In] EnumWindowsDelegate lpEnumFunc, [In] IntPtr lParam);

        /// <summary>
        /// 各子ウィンドウへのハンドルをアプリケーション定義のコールバック関数に渡すことにより、指定された親ウィンドウに属する子ウィンドウを列挙します<br/> EnumChildWindowsは、最後の子ウィンドウが列挙されるか、コールバック関数がFALSEを返すまで続きます<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-enumchildwindows"/>
        /// <param name="hWndParent">子ウィンドウが列挙される親ウィンドウへのハンドル<br/>このパラメーターがNULLの場合、この関数はEnumWindowsと同等です<br/></param>
        /// <param name="lpEnumFunc">アプリケーション定義のコールバック関数へのポインター<br/>詳細については、EnumChildProcを参照してください<br/></param>
        /// <param name="lParam">コールバック関数に渡されるアプリケーション定義の値<br/></param>
        /// <returns>戻り値は使用されません<br/></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows([In] IntPtr hWndParent, [In] EnumWindowsDelegate lpEnumFunc, [In] IntPtr lParam);

        /// <summary>
        /// 指定されたウィンドウが属するクラスの名前を取得します<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getclassname"/>
        /// <param name="hWnd">ウィンドウへのハンドル、および間接的に、ウィンドウが属するクラス</param>
        /// <param name="lpClassName">クラス名の文字列</param>
        /// <param name="nMaxCount">lpClassNameバッファーの長さ（文字数）<br/>バッファは、終了ヌル文字を含めるのに十分な大きさである必要があります<br/>それ以外の場合、クラス名の文字列はnMaxCount-1文字に切り捨てられます</param>
        /// <returns>関数が成功した場合、戻り値はバッファーにコピーされた文字数であり、終了ヌル文字は含まれません<br/>関数が失敗した場合、戻り値はゼロです<br/>拡張エラー情報を取得するには、GetLastError関数を呼び出します<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClassName([In] IntPtr hWnd, [Out] StringBuilder lpClassName, [In] int nMaxCount);

        /// <summary>
        /// 指定されたウィンドウのタイトルバーテキストの長さを文字数で取得します（ウィンドウにタイトルバーがある場合）<br/>指定されたウィンドウがコントロールの場合、関数はコントロール内のテキストの長さを取得します<br/>ただし、GetWindowTextLengthは、別のアプリケーションの編集コントロールのテキストの長さを取得できません<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getwindowtextlengtha"/>
        /// <param name="hWnd">ウィンドウまたはコントロールへのハンドル<br/></param>
        /// <returns>関数が成功した場合、戻り値はテキストの長さ（文字数）です<br/>特定の条件下では、この値はテキストの長さよりも長くなる場合があります（備考を参照）<br/>ウィンドウにテキストがない場合、戻り値はゼロです<br/>関数の失敗は、戻り値がゼロで、GetLastErrorの結果がゼロ以外であることで示されます<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength([In] IntPtr hWnd);
        // public static extern int GetWindowTextLengthA([In] IntPtr hWnd);

        /// <summary>
        /// 指定されたウィンドウのタイトルバー（ある場合）のテキストをバッファにコピーします<br/>指定したウィンドウがコントロールの場合、コントロールのテキストがコピーされます<br/>ただし、GetWindowTextは、別のアプリケーションのコントロールのテキストを取得できません<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getwindowtexta?redirectedfrom=MSDN"/>
        /// <param name="hWnd">テキストを含むウィンドウまたはコントロールへのハンドル</param>
        /// <param name="lpString">テキストを受信するバッファ<br/>文字列がバッファと同じかそれより長い場合、文字列は切り捨てられ、ヌル文字で終了します<br/></param>
        /// <param name="nMaxCount">ヌル文字を含む、バッファーにコピーする最大文字数<br/>テキストがこの制限を超えると、切り捨てられます<br/></param>
        /// <returns>関数が成功した場合、戻り値はコピーされた文字列の長さ（文字数）であり、終了ヌル文字は含まれません<br/>ウィンドウにタイトルバーまたはテキストがない場合、タイトルバーが空の場合、またはウィンドウまたはコントロールハンドルが無効な場合、戻り値はゼロです<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/>この関数は、別のアプリケーションの編集コントロールのテキストを取得できません<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText([In] IntPtr hWnd, [In] StringBuilder lpString, [In] int nMaxCount);
        /// <summary>
        /// 指定されたウィンドウを作成したスレッドの識別子と、オプションで、ウィンドウを作成したプロセスの識別子を取得します<br/>
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getwindowthreadprocessid"/>
        /// <param name="hWnd">ウィンドウへのハンドル</param>
        /// <param name="lpdwProcessId">プロセス識別子を受け取る変数へのポインタ<br/>このパラメーターがNULLでない場合、GetWindowThreadProcessIdはプロセスの識別子を変数にコピーします<br/>それ以外の場合は、そうではありません</param>
        /// <returns>戻り値は、ウィンドウを作成したスレッドの識別子です</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId([In] IntPtr hWnd, [Out] out int lpdwProcessId);

        /// <summary>
        /// 指定されたウィンドウに関する情報を取得します
        /// </summary>
        /// <see cref="https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getwindowinfo"/>
        /// <param name="hwnd">情報を取得するウィンドウへのハンドル</param>
        /// <param name="pwi">情報を受け取るためのWINDOWINFO構造体へのポインター<br/>この関数を呼び出す前に、cbSizeメンバーをsizeof（WINDOWINFO）に設定する必要があることに注意してください</param>
        /// <returns>関数が成功した場合、戻り値はゼロ以外です<br/>関数が失敗した場合、戻り値はゼロです</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowInfo([In] IntPtr hwnd, [In, Out] ref WINDOWINFO pwi);


        /// <summary>
        /// 指定されたメッセージを1つ以上のウィンドウに送信します<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessagetimeouta
        /// </summary>
        /// <param name="hWnd">ウィンドウプロシージャがメッセージを受信するウィンドウへのハンドル<br/>このパラメーターがHWND_BROADCAST（（HWND）0xffff）の場合、メッセージは、無効または非表示の所有されていないウィンドウを含む、システム内のすべての最上位ウィンドウに送信されます<br/>この関数は、各ウィンドウがタイムアウトするまで戻りません<br/>したがって、合計待機時間は、uTimeoutの値にトップレベルウィンドウの数を掛けた値までになる可能性があります<br/></param>
        /// <param name="Msg">送信するメッセージ<br/>システム提供メッセージのリストについては、「システム定義メッセージ」を参照してください<br/></param>
        /// <param name="wParam">追加のメッセージ固有の情報<br/></param>
        /// <param name="lParam">追加のメッセージ固有の情報<br/></param>
        /// <param name="fuFlags">この関数の動作<br/>このパラメーターは、次の1つ以上の値にすることができます<br/></param>
        /// <param name="uTimeout">タイムアウト期間の期間（ミリ秒単位）<br/>メッセージがブロードキャストメッセージの場合、各ウィンドウは完全なタイムアウト期間を使用できます<br/>たとえば、5秒のタイムアウト期間を指定し、メッセージの処理に失敗するトップレベルウィンドウが3つある場合、最大15秒の遅延が発生する可能性があります</param>
        /// <param name="lpdwResult">メッセージ処理の結果<br/>このパラメーターの値は、指定されたメッセージによって異なります</param>
        /// <returns>関数が成功した場合、戻り値はゼロ以外です<br/>SendMessageTimeoutは、HWND_BROADCASTが使用されている場合にタイムアウトする個々のウィンドウに関する情報を提供しません<br/>関数が失敗するかタイムアウトした場合、戻り値は0です<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/>GetLastErrorがERROR_TIMEOUTを返す場合、関数はタイムアウトしました<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout([In] IntPtr hWnd, [In] WindowsMessage Msg, [In] IntPtr wParam, [In] IntPtr lParam, [In] SendMessageTimeoutFlgs fuFlags, [In] UInt32 uTimeout, [In, Out] ref IntPtr lpdwResult);

        /// <summary>
        /// 指定されたメッセージを1つ以上のウィンドウに送信します<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessagetimeouta
        /// </summary>
        /// <param name="hWnd">ウィンドウプロシージャがメッセージを受信するウィンドウへのハンドル<br/>このパラメーターがHWND_BROADCAST（（HWND）0xffff）の場合、メッセージは、無効または非表示の所有されていないウィンドウを含む、システム内のすべての最上位ウィンドウに送信されます<br/>この関数は、各ウィンドウがタイムアウトするまで戻りません<br/>したがって、合計待機時間は、uTimeoutの値にトップレベルウィンドウの数を掛けた値までになる可能性があります<br/></param>
        /// <param name="Msg">送信するメッセージ<br/>システム提供メッセージのリストについては、「システム定義メッセージ」を参照してください<br/></param>
        /// <param name="wParam">追加のメッセージ固有の情報<br/></param>
        /// <param name="lParam">追加のメッセージ固有の情報<br/></param>
        /// <param name="fuFlags">この関数の動作<br/>このパラメーターは、次の1つ以上の値にすることができます<br/></param>
        /// <param name="uTimeout">タイムアウト期間の期間（ミリ秒単位）<br/>メッセージがブロードキャストメッセージの場合、各ウィンドウは完全なタイムアウト期間を使用できます<br/>たとえば、5秒のタイムアウト期間を指定し、メッセージの処理に失敗するトップレベルウィンドウが3つある場合、最大15秒の遅延が発生する可能性があります</param>
        /// <param name="lpdwResult">メッセージ処理の結果<br/>このパラメーターの値は、指定されたメッセージによって異なります</param>
        /// <returns>関数が成功した場合、戻り値はゼロ以外です<br/>SendMessageTimeoutは、HWND_BROADCASTが使用されている場合にタイムアウトする個々のウィンドウに関する情報を提供しません<br/>関数が失敗するかタイムアウトした場合、戻り値は0です<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/>GetLastErrorがERROR_TIMEOUTを返す場合、関数はタイムアウトしました<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout([In] IntPtr hWnd, [In] WindowsMessage Msg, [In] IntPtr wParam, [In, Out] StringBuilder lParam, [In] SendMessageTimeoutFlgs fuFlags, [In] UInt32 uTimeout, [In, Out] ref IntPtr lpdwResult);

        /// <summary>
        /// 指定されたメッセージを1つまたは複数のウィンドウに送信します<br/> SendMessage関数は、指定されたウィンドウのウィンドウプロシージャを呼び出し、ウィンドウプロシージャがメッセージを処理するまで戻りません<br/>メッセージを送信してすぐに戻るには、SendMessageCallback関数またはSendNotifyMessage関数を使用します<br/>メッセージをスレッドのメッセージキューに投稿してすぐに返すには、PostMessage関数またはPostThreadMessage関数を使用します
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage"/>
        /// <param name="hWnd">ウィンドウプロシージャがメッセージを受信するウィンドウへのハンドル<br/>このパラメータがHWND_BROADCAST（（HWND）0xffff）の場合、メッセージは、無効または非表示の所有されていないウィンドウ、オーバーラップしたウィンドウ、ポップアップウィンドウなど、システム内のすべての最上位ウィンドウに送信されます<br/>ただし、メッセージは子ウィンドウには送信されません</param>
        /// <param name="Msg">送信するメッセージ<br/>システム提供メッセージのリストについては、「システム定義メッセージ」(https://docs.microsoft.com/en-us/windows/win32/winmsg/about-messages-and-message-queues)を参照してください<br/></param>
        /// <param name="wParam">追加のメッセージ固有の情報</param>
        /// <param name="lParam">追加のメッセージ固有の情報</param>
        /// <returns>戻り値は、メッセージ処理の結果を指定します<br/>送信されるメッセージによって異なります</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage([In] IntPtr hWnd, [In] WindowsMessage Msg, [In] IntPtr wParam, [In] IntPtr lParam);

        /// 指定されたメッセージを1つまたは複数のウィンドウに送信します<br/> SendMessage関数は、指定されたウィンドウのウィンドウプロシージャを呼び出し、ウィンドウプロシージャがメッセージを処理するまで戻りません<br/>メッセージを送信してすぐに戻るには、SendMessageCallback関数またはSendNotifyMessage関数を使用します<br/>メッセージをスレッドのメッセージキューに投稿してすぐに返すには、PostMessage関数またはPostThreadMessage関数を使用します
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage"/>
        /// <param name="hWnd">ウィンドウプロシージャがメッセージを受信するウィンドウへのハンドル<br/>このパラメータがHWND_BROADCAST（（HWND）0xffff）の場合、メッセージは、無効または非表示の所有されていないウィンドウ、オーバーラップしたウィンドウ、ポップアップウィンドウなど、システム内のすべての最上位ウィンドウに送信されます<br/>ただし、メッセージは子ウィンドウには送信されません</param>
        /// <param name="Msg">送信するメッセージ<br/>システム提供メッセージのリストについては、「システム定義メッセージ」(https://docs.microsoft.com/en-us/windows/win32/winmsg/about-messages-and-message-queues)を参照してください<br/></param>
        /// <param name="wParam">追加のメッセージ固有の情報</param>
        /// <param name="lParam">追加のメッセージ固有の情報</param>
        /// <returns>戻り値は、メッセージ処理の結果を指定します<br/>送信されるメッセージによって異なります</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage([In] IntPtr hWnd, [In] WindowsMessage Msg, [In] IntPtr wParam, [In, Out] StringBuilder lParam);

        /// <summary>
        /// 呼び出し元のスレッドの最後のエラーコード値を取得します<br/>最後のエラーコードはスレッドごとに維持されます<br/>複数のスレッドが互いの最後のエラーコードを上書きすることはありません<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror
        /// </summary>
        /// <returns>戻り値は、呼び出し元のスレッドの最後のエラーコードです<br/>最後のエラーコードを設定する各関数のドキュメントの「戻り値」セクションには、関数が最後のエラーコードを設定する条件が記載されています<br/>スレッドの最後のエラーコードを設定するほとんどの関数は、失敗したときにそれを設定します<br/>ただし、一部の関数は、成功したときに最後のエラーコードも設定します<br/>関数が最後のエラーコードを設定するように文書化されていない場合、この関数によって返される値は、設定された最新の最後のエラーコードにすぎません<br/>一部の関数は、成功時に最後のエラーコードを0に設定し、他の関数はそうではありません<br/></returns>
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern UInt32 GetLastError();

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// <summary>
        /// アプリケーション定義のフックプロシージャをフックチェーンにインストールします<br/>フックプロシージャをインストールして、特定のタイプのイベントについてシステムを監視します<br/>これらのイベントは、特定のスレッド、または呼び出し元のスレッドと同じデスクトップ内のすべてのスレッドに関連付けられています<br/><br/>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa
        /// </summary>
        /// <param name="idHook">インストールするフック手順のタイプ<br/>このパラメーターは、次のいずれかの値になります<br/></param>
        /// <param name="lpfn">フックプロシージャへのポインタ<br/>場合のdwThreadIdパラメータがゼロであるか又は異なるプロセスによって作成されたスレッドの識別子を指定し、lpfnパラメータは、DLLにフックプロシージャを指していなければなりません<br/>それ以外の場合、lpfnは、現在のプロセスに関連付けられているコード内のフックプロシージャを指すことができます<br/></param>
        /// <param name="hMod">lpfnパラメータが指すフックプロシージャを含むDLLへのハンドル<br/>HMODのパラメータに設定する必要がNULL場合のdwThreadIdパラメータは、現在のプロセスによって、およびフックプロシージャは、現在のプロセスに関連付けられたコード内にある場合に作成されたスレッドを指定します<br/></param>
        /// <param name="dwThreadId">フックプロシージャが関連付けられるスレッドの識別子<br/>デスクトップアプリの場合、このパラメーターがゼロの場合、フックプロシージャは、呼び出し元のスレッドと同じデスクトップで実行されているすべての既存のスレッドに関連付けられます<br/>Windows Storeアプリについては、「備考」セクションを参照してください<br/></param>
        /// <returns>関数が成功した場合、戻り値はフックプロシージャへのハンドルです<br/>関数が失敗した場合、戻り値はNULLです<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(HookType idHook, HOOKPROC lpfn, IntPtr hMod, IntPtr dwThreadId);

        public const int HC_ACTION = 0;

        /// <summary>
        /// SetWindowsHookEx関数で使用されるアプリケーション定義またはライブラリ定義のコールバック関数<br/>SendMessage関数が呼び出された後、システムはこの関数を呼び出します<br/>フックプロシージャはメッセージを調べることができます<br/>変更することはできません<br/>HOOKPROCのタイプは、このコールバック関数へのポインタを定義します<br/>CallWndRetProcは、アプリケーション定義またはライブラリ定義の関数名のプレースホルダーです<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-hookproc
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam">メッセージが現在のプロセスによって送信されるかどうかを指定します<br/>メッセージが現在のプロセスによって送信された場合、それはゼロ以外です<br/>それ以外の場合はNULLです<br/></param>
        /// <param name="lParam">メッセージに関する詳細を含むCWPRETSTRUCT構造体へのポインター<br/></param>
        /// <returns>nCodeがゼロ未満の場合、フックプロシージャは、CallNextHookExによって返される値を返す必要があります<br/>nCodeがゼロ以上の場合は、CallNextHookExを呼び出して、返される値を返すことを強くお勧めします<br/>そうしないと、WH_CALLWNDPROCRETフックをインストールした他のアプリケーションがフック通知を受信せず、結果として正しく動作しない可能性があります<br/>フックプロシージャがCallNextHookExを呼び出さない場合、戻り値はゼロである必要があります<br/></returns>
        public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// SetWindowsHookEx関数によってフックチェーンにインストールされたフックプロシージャを削除します<br/>
        /// https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-unhookwindowshookex
        /// </summary>
        /// <param name="hhk">取り外すフックのハンドル<br/>このパラメーターは、SetWindowsHookExへの前回の呼び出しによって取得されたフックハンドルです<br/></param>
        /// <returns>関数が成功した場合、戻り値はゼロ以外です<br/>関数が失敗した場合、戻り値はゼロです<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します<br/>備考:<br/>UnhookWindowsHookExが戻った後でも、フックプロシージャは別のスレッドによって呼び出された状態になる可能性があります<br/>フックプロシージャが同時に呼び出されていない場合、フックプロシージャはUnhookWindowsHookExが戻る直前に削除されます<br/></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        /// フック情報を現在のフックチェーンの次のフックプロシージャに渡します<br/>フックプロシージャは、フック情報を処理する前または後にこの関数を呼び出すことができます<br/>
        /// </summary>
        /// <param name="hhk">このパラメーターは無視されます</param>
        /// <param name="nCode">現在のフックプロシージャに渡されるフックコード<br/>次のフックプロシージャは、このコードを使用して、フック情報の処理方法を決定します<br/></param>
        /// <param name="wParam">wParamにの値は、現在のフックプロシージャに渡されます<br/>このパラメーターの意味は、現在のフックチェーンに関連付けられているフックのタイプによって異なります</param>
        /// <param name="lParam">lParamには現在のフックプロシージャに渡される値<br/>このパラメーターの意味は、現在のフックチェーンに関連付けられているフックのタイプによって異なります</param>
        /// <returns>この値は、チェーン内の次のフックプロシージャによって返されます<br/>現在のフックプロシージャもこの値を返す必要があります<br/>戻り値の意味は、フックの種類によって異なります<br/>詳細については、個々のフック手順の説明を参照してください<br/>備考:<br/>フック手順は、特定のフックタイプのチェーンにインストールされます<br/>CallNextHookExは、チェーン内の次のフックを呼び出します<br/>CallNextHookExの呼び出しはオプションですが、強くお勧めします<br/>そうしないと、フックがインストールされている他のアプリケーションがフック通知を受信せず、結果として正しく動作しない可能性があります<br/>通知が他のアプリケーションに表示されないようにする必要が絶対にない限り、CallNextHookExを呼び出す必要があります</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, Int32 nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 指定されたモジュールのモジュールハンドルを取得します<br/>モジュールは、呼び出しプロセスによってロードされている必要があります<br/>備考セクションで説明されている競合状態を回避するには、GetModuleHandleEx関数を使用します<br/>
        /// https://docs.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlea
        /// </summary>
        /// <param name="lpModuleName">ロードされたモジュールの名前（.dllまたは.exeファイルのいずれか）<br/>ファイル名拡張子を省略すると、デフォルトのライブラリ拡張子.dllが追加されます<br/>ファイル名の文字列には、モジュール名に拡張子がないことを示す末尾の文字（<br/>）を含めることができます<br/>文字列はパスを指定する必要はありません<br/>パスを指定するときは、スラッシュ（/）ではなく、必ず円記号（\）を使用してください<br/>名前は、呼び出し元のプロセスのアドレス空間に現在マップされているモジュールの名前と（大文字と小文字が区別されないように）比較されます<br/>このパラメーターがNULLの場合、 GetModuleHandleは、呼び出しプロセスの作成に使用されたファイル（.exeファイル）へのハンドルを返します<br/>GetModuleHandle関数は、使用してロードされたモジュールのハンドル取得しませんLOAD_LIBRARY_AS_DATAFILEのフラグを<br/>詳細については、LoadLibraryExを参照してください<br/></param>
        /// <returns>関数が成功した場合、戻り値は指定されたモジュールへのハンドルです<br/>関数が失敗した場合、戻り値はNULLです<br/>拡張エラー情報を取得するには、GetLastErrorを呼び出します <br/>備考:<br/>返されるハンドルはグローバルでも継承可能でもありません<br/>複製したり、別のプロセスで使用したりすることはできません<br/>場合lpModuleNameにはパスが含まれていないと同じベース名と拡張子を持つ複数のロードされたモジュールがあり、あなたが返されるモジュールのハンドルを予測することはできません<br/>この問題を回避するには、パスを指定するか、サイドバイサイドアセンブリを使用するか、GetModuleHandleExを使用してDLL名ではなくメモリの場所を指定します<br/>GetModuleHandle関数は、その参照カウントをインクリメントすることなく、マップされたモジュールへのハンドルを返します<br/>ただし、このハンドルがFreeLibrary関数に渡されると、マップされたモジュールの参照カウントが減少します<br/>そのため、返されたハンドル通らないのGetModuleHandleに FreeLibraryの機能を<br/>これを行うと、DLLモジュールが時期尚早にマップ解除される可能性があります<br/>この関数は、マルチスレッドアプリケーションで慎重に使用する必要があります<br/>この関数がハンドルを返すまでの間、モジュールハンドルが有効であるという保証はありません<br/>たとえば、スレッドがモジュールハンドルを取得したが、ハンドルを使用する前に、2番目のスレッドがモジュールを解放するとします<br/>システムが別のモジュールをロードすると、最近解放されたモジュールハンドルを再利用できます<br/>したがって、最初のスレッドには、意図したものとは異なるモジュールへのハンドルがあります</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        //[DllImport("kernel32.dll", EntryPoint = "GetModuleHandleW", SetLastError = true)]
        //public static extern IntPtr GetModuleHandle(string moduleName);




    }

    public static class User32Util
    {
        const int MAX_TEXT_LENGTH = 500;
        const UInt32 TIMEOUT_MSEC = 1000;
        /// <summary>
        /// クラス名を取得します
        /// </summary>
        /// <param name="hWnd">取得する</param>
        /// <param name="retCode"></param>
        /// <param name="maxTextLength"></param>
        /// <returns></returns>
        public static string GetClassName(IntPtr hWnd, out int retCode, int maxTextLength=MAX_TEXT_LENGTH)
        {
            StringBuilder csb = new StringBuilder(maxTextLength);
            retCode = NativeMethods.GetClassName(hWnd, csb, csb.Capacity);
            return (retCode > 0) ? csb.ToString() : string.Empty;
        }

        /// <summary>
        /// Window のtitleを取得します(他プロセスのテキストは取得出来ません)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="retCode"></param>
        /// <param name="maxTextLength"></param>
        /// <returns></returns>
        public static string GetWindowText(IntPtr hWnd, out int retCode, int maxTextLength = MAX_TEXT_LENGTH)
        {
            StringBuilder tsb = new StringBuilder(maxTextLength);
            retCode = NativeMethods.GetWindowText(hWnd, tsb, tsb.Capacity);

            return (retCode > 0) ? tsb.ToString() : string.Empty;
        }

        /// <summary>
        /// SendMessage を使用してWindowのTextを読み取ります<br/>他プロセスのテキストも読み取れます
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="retCode"></param>
        /// <param name="flags"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool SetTextBySendMessage(IntPtr hWnd, string sendText, out int retCode, SendMessageTimeoutFlgs flags = SendMessageTimeoutFlgs.SMTO_NORMAL, UInt32 timeout = TIMEOUT_MSEC)
        {
            var ret = new IntPtr(0);
            StringBuilder tsb = new StringBuilder(sendText);


            var timeoutResult = (int)NativeMethods.SendMessageTimeout(hWnd, WindowsMessage.WM_SETTEXT, IntPtr.Zero, tsb, flags, 1000, ref ret);
            retCode = ret.ToInt32();

            return (timeoutResult > 0 && retCode > 0);
        }

        /// <summary>
        /// SendMessage を使用してWindowのTextを読み取ります<br/>他プロセスのテキストも読み取れます
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="retCode"></param>
        /// <param name="flags"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool SetTextBySendMessage(POINT p, string sendText, out int retCode, SendMessageTimeoutFlgs flags = SendMessageTimeoutFlgs.SMTO_NORMAL, UInt32 timeout = TIMEOUT_MSEC)
        {
            var hWnd = NativeMethods.WindowFromPoint(p);
            if (hWnd.ToInt32() == 0)
            {
                throw new Exception("target button is not found.");
            }

            return SetTextBySendMessage(hWnd, sendText, out retCode, flags, timeout);
        }

        /// <summary>
        /// SendMessage を使用してWindowのTextを読み取ります<br/>他プロセスのテキストも読み取れます
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="retCode"></param>
        /// <param name="flags"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static string GetTextBySendMessage(IntPtr hWnd, out int retCode, SendMessageTimeoutFlgs flags = SendMessageTimeoutFlgs.SMTO_NORMAL, UInt32 timeout=TIMEOUT_MSEC)
        {
            var ret = new IntPtr(0);
            int text_length = 0;
            var is_success = (int)NativeMethods.SendMessageTimeout(hWnd, WindowsMessage.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero, flags, timeout, ref ret);

            if (is_success == 0)
            {
                retCode = 0;
                return string.Empty;
            }
            else
            {
                text_length = (int)ret + 1;
            }
            StringBuilder tsb = new StringBuilder(text_length);

            retCode = (int)NativeMethods.SendMessageTimeout(hWnd, WindowsMessage.WM_GETTEXT, new IntPtr(text_length), tsb, flags, 1000, ref ret);

            return retCode > 0 ? tsb.ToString() : "";
        }

        /// <summary>
        /// SendMessage を使用してWindowのTextを読み取ります<br/>他プロセスのテキストも読み取れます
        /// </summary>
        /// <param name="p"></param>
        /// <param name="retCode"></param>
        /// <param name="flags"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static string GetTextBySendMessage(POINT p, out int retCode, SendMessageTimeoutFlgs flags = SendMessageTimeoutFlgs.SMTO_NORMAL, UInt32 timeout = TIMEOUT_MSEC)
        {
            var hWnd = NativeMethods.WindowFromPoint(p);
            if (hWnd.ToInt32() == 0)
            {
                throw new Exception("target button is not found.");
            }

            return GetTextBySendMessage(hWnd, out retCode, flags, timeout);
        }

        /// <summary>
        /// 対象のWindowへクリックのメッセージを送信します
        /// </summary>
        public static void Click(IntPtr hWnd)
        {
            // ボタン操作するウィンドウをアクティブにする
            var parenthWnd = NativeMethods.GetAncestor(hWnd, GaFlags.GA_ROOT);
            IntPtr ret = IntPtr.Zero;
            if (parenthWnd == IntPtr.Zero)
            {
                ret = NativeMethods.SetActiveWindow(hWnd);
            }
            else
            {
                ret = NativeMethods.SetActiveWindow(parenthWnd);
            }
            var retcode = NativeMethods.SendMessage(hWnd, WindowsMessage.BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// 指定された位置に存在する対象のWindowへクリックのメッセージを送信します
        /// </summary>
        public static void Click(POINT p)
        {
            var hWnd = NativeMethods.WindowFromPoint(p);
            if (hWnd.ToInt32() == 0)
            {
                throw new Exception("target button is not found.");
            }

            Click(hWnd);
        }

        /// <summary>
        /// WindowInfo を取得します
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="retCode"></param>
        /// <returns></returns>
        public static WINDOWINFO GetWindowInfo(IntPtr hWnd, out bool retCode)
        {
            var wi = new WINDOWINFO();
            wi.cbSize = Marshal.SizeOf(wi);  // sizeof(WINDOWINFO);でもよいようだが sizeof()を使う場合は unsafe{}が必要
            retCode = NativeMethods.GetWindowInfo(hWnd, ref wi);
            return wi;
        }

        /// <summary>
        /// WindowInfo を取得します
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="retCode"></param>
        /// <returns></returns>
        public static WINDOWINFO GetWindowInfo(POINT p, out bool retCode)
        {
            var hWnd = NativeMethods.WindowFromPoint(p);
            if (hWnd.ToInt32() == 0)
            {
                throw new Exception("target button is not found.");
            }

            return GetWindowInfo(hWnd, out retCode);
        }
    }
}
