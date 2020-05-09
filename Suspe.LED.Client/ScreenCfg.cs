using System;
using System.Data;

namespace Suspe.LED.Client
{
	// Token: 0x02000016 RID: 22
	public class ScreenCfg
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021E4 File Offset: 0x000003E4
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000021EC File Offset: 0x000003EC
		public Guid guid { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000021F5 File Offset: 0x000003F5
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000021FD File Offset: 0x000003FD
		public int ScreenNo { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002206 File Offset: 0x00000406
		// (set) Token: 0x06000020 RID: 32 RVA: 0x0000220E File Offset: 0x0000040E
		public int ScreenType { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002217 File Offset: 0x00000417
		// (set) Token: 0x06000022 RID: 34 RVA: 0x0000221F File Offset: 0x0000041F
		public int CommType { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002228 File Offset: 0x00000428
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002230 File Offset: 0x00000430
		public int Width { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002239 File Offset: 0x00000439
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002241 File Offset: 0x00000441
		public int Height { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000224A File Offset: 0x0000044A
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002252 File Offset: 0x00000452
		public string IpAdress { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000225B File Offset: 0x0000045B
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002263 File Offset: 0x00000463
		public int NetPort { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000226C File Offset: 0x0000046C
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002274 File Offset: 0x00000474
		public int ColorType { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000227D File Offset: 0x0000047D
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002285 File Offset: 0x00000485
		public Guid Line_guid { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000228E File Offset: 0x0000048E
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002296 File Offset: 0x00000496
		public bool IsConn { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000031 RID: 49 RVA: 0x0000229F File Offset: 0x0000049F
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000022A7 File Offset: 0x000004A7
		public int SchIdx { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000022B0 File Offset: 0x000004B0
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000022B8 File Offset: 0x000004B8
		public uint TickDura { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000022C1 File Offset: 0x000004C1
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000022C9 File Offset: 0x000004C9
		public uint TickRefresh { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000022D2 File Offset: 0x000004D2
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000022DA File Offset: 0x000004DA
		public bool IsFinish { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000022E3 File Offset: 0x000004E3
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000022EB File Offset: 0x000004EB
		public int RowIdx { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000022F4 File Offset: 0x000004F4
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000022FC File Offset: 0x000004FC
		public DataTable TblSchedule { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002305 File Offset: 0x00000505
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000230D File Offset: 0x0000050D
		public DataTable TblInfo { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002316 File Offset: 0x00000516
		// (set) Token: 0x06000040 RID: 64 RVA: 0x0000231E File Offset: 0x0000051E
		public DataTable TblHourPlan { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002327 File Offset: 0x00000527
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000232F File Offset: 0x0000052F
		public DataTable TblHourPlanV2 { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002338 File Offset: 0x00000538
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002340 File Offset: 0x00000540
		public DataTable TblHourPlanV3 { get; set; }
	}
}
