using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Service.Ext
{
    public static class LdAPI
    {
        // Token: 0x0600003F RID: 63
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        // Token: 0x06000040 RID: 64
        [DllImport("Winmm.dll")]
        public static extern bool sndPlaySound(string lpszSound, uint fuSound);

        // Token: 0x06000041 RID: 65
        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, uint msg, uint wParam, ref LdAPI.COPYDATASTRUCT lParam);

        // Token: 0x06000042 RID: 66
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        // Token: 0x06000043 RID: 67
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Token: 0x06000044 RID: 68
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Token: 0x06000045 RID: 69
        [DllImport("User32.dll")]
        public static extern bool SendMessageTimeout(IntPtr hWnd, uint msg, uint wParam, ref LdAPI.COPYDATASTRUCT lParam, uint flag, uint timeout, ref uint rlt);

        // Token: 0x06000046 RID: 70
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);

        // Token: 0x06000047 RID: 71
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);

        // Token: 0x06000048 RID: 72
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);

        // Token: 0x06000049 RID: 73
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);

        // Token: 0x0600004A RID: 74
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);

        // Token: 0x0600004B RID: 75
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        // Token: 0x0600004C RID: 76
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        // Token: 0x0600004D RID: 77
        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        // Token: 0x0600004E RID: 78
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        /// <summary>
        /// 获取系统运行时间毫秒级别
        /// </summary>
        /// <returns></returns>
        ////获取系统运行时间毫秒级别  
        // Token: 0x0600004F RID: 79
        [DllImport("kernel32.dll")]
        public static extern uint GetTickCount();

        // Token: 0x06000050 RID: 80
        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, LdAPI.ShowCommands nShowCmd);

        // Token: 0x06000051 RID: 81
        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref LdAPI.SYSTEMTIME time);

        // Token: 0x06000052 RID: 82
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref LdAPI.SYSTEMTIME time);

        // Token: 0x06000053 RID: 83
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref LdAPI.SYSTEMTIME time);

        // Token: 0x06000054 RID: 84
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref LdAPI.SYSTEMTIME time);

        // Token: 0x06000055 RID: 85
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);

        // Token: 0x06000056 RID: 86
        [DllImport("kernel32")]
        public static extern int SetThreadExecutionState(uint esFlags);

        // Token: 0x06000057 RID: 87
        [DllImport("kernel32.dll")]
        public static extern int GetSystemDefaultLCID();

        // Token: 0x06000058 RID: 88
        [DllImport("kernel32.dll", EntryPoint = "SetLocaleInfoA")]
        public static extern int SetLocaleInfo(int Locale, int LCType, string lpLCData);

        // Token: 0x06000059 RID: 89 RVA: 0x00002DC0 File Offset: 0x00000FC0
        public static void SetDateTimeFormat()
        {
            try
            {
                int systemDefaultLCID = LdAPI.GetSystemDefaultLCID();
                LdAPI.SetLocaleInfo(systemDefaultLCID, 4099, "HH:mm:ss");
                LdAPI.SetLocaleInfo(systemDefaultLCID, 31, "yyyy-MM-dd");
                LdAPI.SetLocaleInfo(systemDefaultLCID, 32, "yyyy-MM-dd");
            }
            catch
            {
            }
        }

        // Token: 0x04000065 RID: 101
        public const uint SND_SYNC = 0u;

        // Token: 0x04000066 RID: 102
        public const uint SND_ASYNC = 1u;

        // Token: 0x04000067 RID: 103
        public const uint SND_NODEFAULT = 2u;

        // Token: 0x04000068 RID: 104
        public const uint SND_MEMORY = 4u;

        // Token: 0x04000069 RID: 105
        public const uint SND_LOOP = 8u;

        // Token: 0x0400006A RID: 106
        public const uint SND_NOSTOP = 16u;

        // Token: 0x0400006B RID: 107
        public const int WM_COPYDATA = 74;

        // Token: 0x0400006C RID: 108
        public const uint SMTO_ABORTIFHUNG = 2u;

        // Token: 0x0400006D RID: 109
        public const uint SMTO_BLOCK = 1u;

        // Token: 0x0400006E RID: 110
        public const uint SMTO_NORMAL = 0u;

        // Token: 0x0400006F RID: 111
        public const uint SMTO_NOTIMEOUTIFNOTHUNG = 8u;

        // Token: 0x04000070 RID: 112
        public const uint SMTO_ERRORONEXIT = 32u;

        // Token: 0x04000071 RID: 113
        public const int IME_CMODE_FULLSHAPE = 8;

        // Token: 0x04000072 RID: 114
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 17;

        // Token: 0x04000073 RID: 115
        public const int WM_CONTEXTMENU = 123;

        // Token: 0x04000074 RID: 116
        public const int WM_KEYDOWN = 256;

        // Token: 0x04000075 RID: 117
        public const int WM_KEYUP = 257;

        // Token: 0x04000076 RID: 118
        public const int WM_CHAR = 258;

        // Token: 0x04000077 RID: 119
        public const int WM_SYSKEYDOWN = 260;

        // Token: 0x04000078 RID: 120
        public const int WM_SYSCHAR = 262;

        // Token: 0x04000079 RID: 121
        public const int WM_CUT = 768;

        // Token: 0x0400007A RID: 122
        public const int WM_COPY = 769;

        // Token: 0x0400007B RID: 123
        public const int WM_PASTE = 770;

        // Token: 0x0400007C RID: 124
        public const int WM_CLEAR = 771;

        // Token: 0x0400007D RID: 125
        public const int WM_UNDO = 772;

        // Token: 0x0400007E RID: 126
        public const int VK_F2 = 113;

        // Token: 0x0400007F RID: 127
        public const uint SPI_SETSCREENSAVEACTIVE = 17u;

        // Token: 0x04000080 RID: 128
        public const uint ES_SYSTEM_REQUIRED = 1u;

        // Token: 0x04000081 RID: 129
        public const uint ES_DISPLAY_REQUIRED = 2u;

        // Token: 0x04000082 RID: 130
        public const uint ES_CONTINUOUS = 2147483648u;

        // Token: 0x04000083 RID: 131
        public const int LOCALE_SLONGDATE = 32;

        // Token: 0x04000084 RID: 132
        public const int LOCALE_SSHORTDATE = 31;

        // Token: 0x04000085 RID: 133
        public const int LOCALE_STIME = 4099;

        // Token: 0x02000017 RID: 23
        public struct COPYDATASTRUCT
        {
            // Token: 0x04000086 RID: 134
            public IntPtr dwData;

            // Token: 0x04000087 RID: 135
            public int cbData;

            // Token: 0x04000088 RID: 136
            public IntPtr lpData;
        }

        // Token: 0x02000018 RID: 24
        public enum ShowCommands
        {
            // Token: 0x0400008A RID: 138
            SW_HIDE,
            // Token: 0x0400008B RID: 139
            SW_SHOWNORMAL,
            // Token: 0x0400008C RID: 140
            SW_NORMAL = 1,
            // Token: 0x0400008D RID: 141
            SW_SHOWMINIMIZED,
            // Token: 0x0400008E RID: 142
            SW_SHOWMAXIMIZED,
            // Token: 0x0400008F RID: 143
            SW_MAXIMIZE = 3,
            // Token: 0x04000090 RID: 144
            SW_SHOWNOACTIVATE,
            // Token: 0x04000091 RID: 145
            SW_SHOW,
            // Token: 0x04000092 RID: 146
            SW_MINIMIZE,
            // Token: 0x04000093 RID: 147
            SW_SHOWMINNOACTIVE,
            // Token: 0x04000094 RID: 148
            SW_SHOWNA,
            // Token: 0x04000095 RID: 149
            SW_RESTORE,
            // Token: 0x04000096 RID: 150
            SW_SHOWDEFAULT,
            // Token: 0x04000097 RID: 151
            SW_FORCEMINIMIZE,
            // Token: 0x04000098 RID: 152
            SW_MAX = 11
        }

        // Token: 0x02000019 RID: 25
        public struct SYSTEMTIME
        {
            // Token: 0x0600005A RID: 90 RVA: 0x00002E18 File Offset: 0x00001018
            public void FromDateTime(DateTime dateTime)
            {
                this.wYear = (ushort)dateTime.Year;
                this.wMonth = (ushort)dateTime.Month;
                this.wDayOfWeek = (ushort)dateTime.DayOfWeek;
                this.wDay = (ushort)dateTime.Day;
                this.wHour = (ushort)dateTime.Hour;
                this.wMinute = (ushort)dateTime.Minute;
                this.wSecond = (ushort)dateTime.Second;
                this.wMilliseconds = (ushort)dateTime.Millisecond;
            }

            // Token: 0x0600005B RID: 91 RVA: 0x00002E95 File Offset: 0x00001095
            public DateTime ToDateTime()
            {
                return new DateTime((int)this.wYear, (int)this.wMonth, (int)this.wDay, (int)this.wHour, (int)this.wMinute, (int)this.wSecond);
            }

            // Token: 0x04000099 RID: 153
            public ushort wYear;

            // Token: 0x0400009A RID: 154
            public ushort wMonth;

            // Token: 0x0400009B RID: 155
            public ushort wDayOfWeek;

            // Token: 0x0400009C RID: 156
            public ushort wDay;

            // Token: 0x0400009D RID: 157
            public ushort wHour;

            // Token: 0x0400009E RID: 158
            public ushort wMinute;

            // Token: 0x0400009F RID: 159
            public ushort wSecond;

            // Token: 0x040000A0 RID: 160
            public ushort wMilliseconds;
        }
    }
}
