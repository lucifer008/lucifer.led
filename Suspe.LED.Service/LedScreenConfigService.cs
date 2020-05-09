using log4net;
using Suspe.LED.Model;
using SuspeSys.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Service
{
    public class LedScreenConfigService
    {
        readonly static ILog log = LogManager.GetLogger(typeof(LedScreenConfigService));
        private LedScreenConfigService() { }
        public static readonly LedScreenConfigService Instance = new LedScreenConfigService();
        public IList<ScreenCfg> GetLedScreenConfigList()
        {
            IList<ScreenCfg> scList = new List<ScreenCfg>();
            try
            {
                var sql = "select * from LEDScreenConfig where Enable=@Enable";
                var ledsConfigList = DapperHelp.Query<LedScreenConfig>(sql, new { Enable = 1 }).ToList<LedScreenConfig>();
                if (ledsConfigList.Count == 0)
                {
                    log.InfoFormat("未找到屏幕配置");
                }
                foreach (var lc in ledsConfigList)
                {
                    var sc = new ScreenCfg();
                    sc.Id = lc.Id;
                    sc.ColorType = null != lc.ColorType ? lc.ColorType.Value : 0;
                    sc.CommType = null != lc.CommunicationWay ? lc.CommunicationWay.Value : 0;
                    sc.Height = null != lc.SHeight ? lc.SHeight.Value : 0;
                    sc.Width = null != lc.SWidth ? lc.SWidth.Value : 0;
                    sc.ScreenNo = !string.IsNullOrEmpty(lc.ScreenNo) ? int.Parse(lc.ScreenNo) : 0;
                    sc.ScreenType = !string.IsNullOrEmpty(lc.ControllerKey) ? int.Parse(lc.ControllerKey) : 0;
                    sc.NetPort = null != lc.Port ? lc.Port.Value : 0;
                    sc.IpAdress = lc.IpAddress;
                    //页面
                    var scPageList = GetLedScreenPageList(lc.Id);
                    sc.TblSchedule = new System.Data.DataTable();
                    sc.TblSchedule.Columns.Add("Duration");
                    sc.TblSchedule.Columns.Add("RefreshCycle");
                    sc.TblSchedule.Columns.Add("InfoType");
                    sc.TblSchedule.Columns.Add("InfoDetail");
                    sc.TblSchedule.Columns.Add("GroupNo");
                    sc.GroupNo = lc.GroupNo?.Trim();

                    if (scPageList.Count == 0)
                    {
                        log.ErrorFormat("GetLedScreenConfigList--->屏幕页面为空:{0}", lc.Id);
                        continue;
                    }
                    foreach (var page in scPageList)
                    {
                        DataRow dr = sc.TblSchedule.NewRow();
                        dr["Duration"] = page.Times;
                        dr["RefreshCycle"] = page.RefreshCycle;
                        dr["InfoType"] = page.InfoType;
                        dr["InfoDetail"] = page.CusContent;
                        dr["GroupNo"] = page.GroupNo?.Trim();
                        sc.TblSchedule.Rows.Add(dr);
                    }
                    scList.Add(sc);
                }

            }
            catch (Exception ex)
            {
                log.ErrorFormat("GetLedScreenConfigList--->异常:{0}", ex);
            }
            return scList;
        }
        public IList<LedScreenPage> GetLedScreenPageList(string screenConfigId)
        {
            var sql = "select Sp.*,SC.GroupNo from LEDScreenConfig SC INNER JOIN LEDScreenPage  SP ON SP.LEDSCREENCONFIG_Id=SC.Id where SP.LEDSCREENCONFIG_Id=@screenConfigId AND SP.Enabled=1";
            var ledScreenPageList = DapperHelp.Query<LedScreenPage>(sql, new { screenConfigId = screenConfigId }).ToList<LedScreenPage>();
            return ledScreenPageList;
        }
        public DataTable GetTodayProcessOrderYield(string groupNo)
        {
            string sql = string.Format(@"SELECT ProcessOrderNo, ProcessOrderCount
,ISNULL(TotalProdOutNum,0) TotlOutCount,ISNULL(TodayCount,0)TodayCount,ISNULL(TPlan,0) TPlan
 FROM (
	SELECT ProcessOrderNo,T_TotalProdOutNum.TotalProdOutNum,T_TodayCount.TodayCount,T_Main.TPlan,
	(
  SELECT 
	  SUM(CONVERT(INT ,ISNULL(t3.Total,0)))  ProcessOrderCount
	  FROM dbo.ProcessOrder t1
	  LEFT JOIN ProcessOrderColorItem t2 ON t1.Id=t2.PROCESSORDER_Id
	  LEFT JOIN dbo.ProcessOrderColorSizeItem t3 ON t3.PROCESSORDERCOLORITEM_Id = t2.Id
	  WHERE t1.Id=T_Main.ProcessOrder_Id
)ProcessOrderCount
	 FROM 
	(	SELECT  ProcessOrder_Id,ProcessOrderNo,SUM(TargetNum) TPlan FROM(
		 SELECT  ProcessOrder_Id,ProcessOrderNo,PROCESSFLOWCHART_Id,T2.TargetNum FROM Products TP
		 LEFT JOIN ProcessFlowChart T2 ON TP.PROCESSFLOWCHART_Id=T2.ID)T_Main
		 GROUP BY ProcessOrder_Id,ProcessOrderNo
	) T_Main
	 LEFT JOIN(
	 SELECT  ProcessOrderId,SUM(ISNULL(SizeNum, 0)) AS TotalProdOutNum
	  FROM       dbo.SucessProcessOrderHanger where GroupNo='{0}' 
		Group BY ProcessOrderId
	) AS T_TotalProdOutNum ON T_TotalProdOutNum.ProcessOrderId = T_Main.ProcessOrder_Id
	 LEFT JOIN
	(
		SELECT ProcessOrderId,COUNT(ProcessFlowCode) TodayCount FROM SucessProcessOrderHanger 
		WHERE InsertDateTime BETWEEN CONVERT(varchar(10), GETDATE(), 120) AND 
																   CONVERT(varchar(10), DATEADD(day, 1, GETDATE()), 120) AND GroupNo='{0}' 
		GROUP BY ProcessOrderId
	) T_TodayCount ON T_TodayCount.ProcessOrderId=T_Main.ProcessOrder_Id
	
)Res
", groupNo);

            return DapperHelp.Query(sql);
        }
        /// <summary>
        /// 小时计划
        /// </summary>
        public DataTable HoursPlanInfo(string groupNo)
        {

            var sqlWhereData = string.Empty;
            var sqlWhereSet = string.Empty;
            var sqlCheckData = string.Format($@" SELECT FlowCode,InsertDateTime FROM dbo.HangerProductFlowChart WHERE InsertDateTime  BETWEEN CONVERT(varchar(100), GETDATE(), 111) AND GETDATE() AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}'
 UNION ALL
                    SELECT FlowCode,InsertDateTime FROM dbo.SuccessHangerProductFlowChart WHERE InsertDateTime BETWEEN CONVERT(varchar(100), GETDATE(), 111) AND GETDATE() AND FlowType=1 AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}' ");
            var dtCheck = DapperHelp.Query(sqlCheckData);
            if (dtCheck.Rows.Count != 0)
            {
                sqlWhereData += $" InsertDateTime  BETWEEN CONVERT(varchar(100), GETDATE(), 111) AND GETDATE()";
            }
            else
            {
                var sqlMax = $"SELECT MAX(InsertDateTime) InsertDateTime FROM dbo.HangerProductFlowChart";
                var maxDate = DapperHelp.QueryForObject<DateTime?>(sqlMax);
                if (maxDate == null) return null;
                sqlWhereData += $" InsertDateTime  BETWEEN '{maxDate.Value.ToString("yyyy-MM-dd")}' AND '{maxDate.Value.AddDays(1).ToString("yyyy-MM-dd")}'";
            }
            var sqlCheckSet = string.Format(@"SELECT TOP 2 * FROM  [dbo].[LEDHoursPlanTableItem] WHERE
		BeginDate>=CONVERT(varchar(100), GETDATE(), 111) AND EndDate<GETDATE()
		OR (GETDATE() BETWEEN BeginDate AND EndDate)");
            var dtCheckSet = DapperHelp.Query(sqlCheckSet);
            if (dtCheckSet.Rows.Count != 0)
            {
                sqlWhereSet = "BeginDate>=CONVERT(varchar(100), GETDATE(), 111) AND EndDate<GETDATE() OR (GETDATE() BETWEEN BeginDate AND EndDate)";
            }
            else
            {
                var sqlCheckSet2 = string.Format(@"SELECT max(BeginDate) BeginDate FROM  [dbo].[LEDHoursPlanTableItem]");
                var maxDate = DapperHelp.QueryForObject<DateTime?>(sqlCheckSet2);
                if (maxDate == null) return null;
                sqlWhereSet += $" BeginDate  BETWEEN '{maxDate.Value.ToString("yyyy-MM-dd")}' AND '{maxDate.Value.AddDays(1).ToString("yyyy-MM-dd")}'";
            }

            var sqlInfo = string.Format($@"SELECT ISNULL(Res.PlanNum,0)PlanNum,FORMAT(Res.BeginDate,'tt-HH') BTime,FORMAT(Res.EndDate,'tt-HH') ENDTimes,RealiyCount,Res.DefectCount FROM(
	                    SELECT T_Times.BeginDate,T_Times.EndDate,T_Times.PlanNum,
	                    (
		                    SELECT	COUNT(FlowCode) TodayCount FROM HangerProductFlowChart WHERE {sqlWhereData} AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}'
	                    ) RealiyCount
	                    ,(
		                    SELECT COUNT(FlowCode) DefectCount FROM(
                    SELECT FlowCode,InsertDateTime FROM dbo.HangerProductFlowChart WHERE  {sqlWhereData} AND FlowType=1 AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}'
                    UNION ALL
                    SELECT FlowCode,InsertDateTime FROM dbo.SuccessHangerProductFlowChart WHERE {sqlWhereData} AND FlowType=1 AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}' 
                    )T_FlowCode
	                    ) DefectCount
	                     From(
		                    SELECT TOP 2 * FROM  [dbo].[LEDHoursPlanTableItem] WHERE
		                    {sqlWhereSet}
		                    ORDER BY BeginDate DESC,EndDate DESC
	                    )T_Times
	
                )Res");
            var sqlInfoTotal = string.Format($@"SELECT SUM(ISNULL(Res.PlanNum,0))PlanNum,SUM(ISNULL(RealiyCount,0)) RealiyCount,SUM(ISNULL(Res.DefectCount,0)) DefectCount FROM(
	SELECT T_Times.BeginDate,T_Times.EndDate,T_Times.PlanNum,
	(
		SELECT	COUNT(FlowCode) TodayCount FROM HangerProductFlowChart WHERE {sqlWhereData}  AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}'
	) RealiyCount
	,(
		SELECT COUNT(FlowCode) DefectCount FROM(
SELECT FlowCode,InsertDateTime FROM dbo.HangerProductFlowChart WHERE {sqlWhereData} AND FlowType=1  AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}' 
UNION ALL
SELECT FlowCode,InsertDateTime FROM dbo.SuccessHangerProductFlowChart WHERE {sqlWhereData} AND FlowType=1 AND CAST(HangerNo AS INT) > 0 AND GroupNo='{groupNo}' 
)T_FlowCode
	) DefectCount
	 From(
		SELECT TOP 2 * FROM  [dbo].[LEDHoursPlanTableItem] WHERE
		{sqlWhereSet}
		ORDER BY BeginDate DESC,EndDate DESC
	)T_Times
	
)Res
");
            var dtResult = new DataTable();
            dtResult.Columns.Add("Times");
            dtResult.Columns.Add("PlanQty");
            dtResult.Columns.Add("TOutput");
            dtResult.Columns.Add("Eff", typeof(decimal));
            dtResult.Columns.Add("TFail");
            dtResult.Columns.Add("EffFail", typeof(decimal));
            var dtInfo = DapperHelp.Query(sqlInfo);
            var dtInfoTotal = DapperHelp.Query(sqlInfoTotal);
            if (dtInfo.Rows.Count == 0)
            {
                log.Info($"组【{groupNo}】 无数据!");
                return null;
            }
            if (dtInfo.Rows.Count == 2)
            {
                DataRow drFisrt = dtResult.NewRow();
                var drrrInfo1 = dtInfo.Rows[1];
                var beginTimeFirst = Convert.ToString(drrrInfo1["BTime"]);
                var endTimeFirst = Convert.ToString(drrrInfo1["ENDTimes"]);
                var begTimesArrsFirst = beginTimeFirst.Split('-');
                var endTimesArrsFirst = endTimeFirst.Split('-');
                drFisrt["Times"] = string.Format("{0}-{1}", begTimesArrsFirst[0] + begTimesArrsFirst[1], endTimesArrsFirst[1]);
                drFisrt["PlanQty"] = drrrInfo1["PlanNum"];
                drFisrt["TOutput"] = drrrInfo1["RealiyCount"];
                var tEff1 = decimal.Parse("0");
                if (int.Parse(string.IsNullOrEmpty(Convert.ToString(drrrInfo1["PlanNum"])) ? "0" : Convert.ToString(drrrInfo1["PlanNum"])) != 0)
                {
                    tEff1 = decimal.Parse(Convert.ToString(drrrInfo1["RealiyCount"])) / Int64.Parse(string.IsNullOrEmpty(Convert.ToString(drrrInfo1["PlanNum"])) ? "0" : Convert.ToString(drrrInfo1["PlanNum"]));
                }
                drFisrt["Eff"] = tEff1;//.ToString("{0:P2}");
                drFisrt["TFail"] = drrrInfo1["DefectCount"];

                drFisrt["EffFail"] = (1 - tEff1 < 0 ? 0 : (1 - tEff1));
                dtResult.Rows.Add(drFisrt);

                DataRow drSecond = dtResult.NewRow();
                var drrrInfo2 = dtInfo.Rows[0];

                var beginTimeSecond = Convert.ToString(drrrInfo2["BTime"]);
                var endTimeSecond = Convert.ToString(drrrInfo2["ENDTimes"]);
                var begTimesArrsSecond = beginTimeSecond.Split('-');
                var endTimesArrsSecond = endTimeSecond.Split('-');
                drSecond["Times"] = string.Format("{0}-{1}", begTimesArrsSecond[0] + begTimesArrsSecond[1], endTimesArrsSecond[1]);//string.Format("{0}-{1}", Convert.ToString(drrrInfo2["BTime"]), Convert.ToString(drrrInfo2["ENDTimes"]));
                drSecond["PlanQty"] = drrrInfo2["PlanNum"];
                drSecond["TOutput"] = drrrInfo2["RealiyCount"];
                var tEff2 = decimal.Parse("0");
                if (int.Parse(string.IsNullOrEmpty(Convert.ToString(drrrInfo2["PlanNum"])) ? "0" : Convert.ToString(drrrInfo2["PlanNum"])) != 0)
                {
                    tEff2 = decimal.Parse(Convert.ToString(drrrInfo2["RealiyCount"])) / Int64.Parse(string.IsNullOrEmpty(Convert.ToString(drrrInfo2["PlanNum"])) ? "0" : Convert.ToString(drrrInfo2["PlanNum"]));
                }
                drSecond["Eff"] = tEff2;//.ToString("{0:P2}");
                drSecond["TFail"] = drrrInfo2["DefectCount"];

                drSecond["EffFail"] = (1 - tEff2 < 0 ? 0 : (1 - tEff2));
                dtResult.Rows.Add(drSecond);
            }
            else
            {

                DataRow drSecond = dtResult.NewRow();
                var drrrInfo2 = dtInfo.Rows[0];
                var beginTimeSecond = Convert.ToString(drrrInfo2["BTime"]);
                var endTimeSecond = Convert.ToString(drrrInfo2["ENDTimes"]);
                var begTimesArrsSecond = beginTimeSecond.Split('-');
                var endTimesArrsSecond = endTimeSecond.Split('-');

                drSecond["Times"] = string.Format("{0}-{1}", begTimesArrsSecond[0] + begTimesArrsSecond[1], endTimesArrsSecond[1]);//string.Format("{0}-{1}", Convert.ToString(drrrInfo2["BTime"]), Convert.ToString(drrrInfo2["ENDTimes"]));
                drSecond["PlanQty"] = drrrInfo2["PlanNum"];
                drSecond["TOutput"] = drrrInfo2["RealiyCount"];
                var tEff2 = decimal.Parse("0");
                if (int.Parse(string.IsNullOrEmpty(Convert.ToString(drrrInfo2["PlanNum"])) ? "0" : Convert.ToString(drrrInfo2["PlanNum"])) != 0)
                {
                    tEff2 = decimal.Parse(Convert.ToString(drrrInfo2["RealiyCount"])) / Int64.Parse(string.IsNullOrEmpty(Convert.ToString(drrrInfo2["PlanNum"])) ? "0" : Convert.ToString(drrrInfo2["PlanNum"]));
                }
                drSecond["Eff"] = tEff2;//.ToString("{0:P2}");
                drSecond["TFail"] = drrrInfo2["DefectCount"];

                drSecond["EffFail"] = (1 - tEff2 < 0 ? 0 : (1 - tEff2));
                dtResult.Rows.Add(drSecond);
            }
            var drrrTotal = dtInfoTotal.Rows[0];
            DataRow totalRows = dtResult.NewRow();
            totalRows["Times"] = "Total累计";
            totalRows["PlanQty"] = drrrTotal["PlanNum"];
            totalRows["TOutput"] = drrrTotal["RealiyCount"];
            var tEff = decimal.Parse("0");
            if (int.Parse(string.IsNullOrEmpty(Convert.ToString(drrrTotal["PlanNum"])) ? "0" : Convert.ToString(drrrTotal["PlanNum"])) != 0)
            {
                tEff = decimal.Parse(Convert.ToString(drrrTotal["RealiyCount"])) / Int64.Parse(string.IsNullOrEmpty(Convert.ToString(drrrTotal["PlanNum"])) ? "0" : Convert.ToString(drrrTotal["PlanNum"]));
            }
            totalRows["Eff"] = tEff;
            totalRows["TFail"] = drrrTotal["DefectCount"];

            totalRows["EffFail"] = (1 - tEff < 0 ? 0 : (1 - tEff));
            dtResult.Rows.Add(totalRows);

            return dtResult;
        }
    }
}
