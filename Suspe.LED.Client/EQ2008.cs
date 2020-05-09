using System;
using System.Runtime.InteropServices;
using EQ2008_DataStruct;

namespace Suspe.LED.Client
{
	// Token: 0x02000017 RID: 23
	public static class EQ2008
	{
		// Token: 0x06000046 RID: 70
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddProgram(int CardNum, bool bWaitToEnd, int iPlayTime);

		// Token: 0x06000047 RID: 71
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_DelAllProgram(int CardNum);

		// Token: 0x06000048 RID: 72
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddSingleText(int CardNum, ref User_SingleText pSingleText, int iProgramIndex);

		// Token: 0x06000049 RID: 73
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddText(int CardNum, ref User_Text pText, int iProgramIndex);

		// Token: 0x0600004A RID: 74
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddTime(int CardNum, ref User_DateTime pdateTime, int iProgramIndex);

		// Token: 0x0600004B RID: 75
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddBmpZone(int CardNum, ref User_Bmp pBmp, int iProgramIndex);

		// Token: 0x0600004C RID: 76
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_AddBmp(int CardNum, int iBmpPartNum, IntPtr hBitmap, ref User_MoveSet pMoveSet, int iProgramIndex);

		// Token: 0x0600004D RID: 77
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_AddBmpFile(int CardNum, int iBmpPartNum, string strFileName, ref User_MoveSet pMoveSet, int iProgramIndex);

		// Token: 0x0600004E RID: 78
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddRTF(int CardNum, ref User_RTF pRTF, int iProgramIndex);

		// Token: 0x0600004F RID: 79
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddTimeCount(int CardNum, ref User_Timer pTimeCount, int iProgramIndex);

		// Token: 0x06000050 RID: 80
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern int User_AddTemperature(int CardNum, ref User_Temperature pTemperature, int iProgramIndex);

		// Token: 0x06000051 RID: 81
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_SendToScreen(int CardNum);

		// Token: 0x06000052 RID: 82
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_RealtimeConnect(int CardNum);

		// Token: 0x06000053 RID: 83
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_RealtimeSendData(int CardNum, int x, int y, int iWidth, int iHeight, IntPtr hBitmap);

		// Token: 0x06000054 RID: 84
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_RealtimeSendBmpData(int CardNum, int x, int y, int iWidth, int iHeight, string strFileName);

		// Token: 0x06000055 RID: 85
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_RealtimeSendText(int CardNum, int x, int y, int iWidth, int iHeight, string strText, ref User_FontSet pFontInfo);

		// Token: 0x06000056 RID: 86
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_RealtimeDisConnect(int CardNum);

		// Token: 0x06000057 RID: 87
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_RealtimeScreenClear(int CardNum);

		// Token: 0x06000058 RID: 88
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_AdjustTime(int CardNum);

		// Token: 0x06000059 RID: 89
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_OpenScreen(int CardNum);

		// Token: 0x0600005A RID: 90
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_CloseScreen(int CardNum);

		// Token: 0x0600005B RID: 91
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern bool User_SetScreenLight(int CardNum, int iLightDegreen);

		// Token: 0x0600005C RID: 92
		[DllImport("EQ2008_Dll.dll", CharSet = CharSet.Ansi)]
		public static extern void User_ReloadIniFile(string strEQ2008_Dll_Set_Path);

		// Token: 0x0600005D RID: 93
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x040000A8 RID: 168
		public static int g_iCardNum = 1;

		// Token: 0x040000A9 RID: 169
		public static int g_iGreen = 65280;

		// Token: 0x040000AA RID: 170
		public static int g_iYellow = 65535;

		// Token: 0x040000AB RID: 171
		public static int g_iRed = 255;

		// Token: 0x040000AC RID: 172
		public static int g_iProgramIndex = 0;

		// Token: 0x040000AD RID: 173
		public static int g_iProgramCount = 0;
	}
}
