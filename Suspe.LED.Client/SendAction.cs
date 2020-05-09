using EQ2008_DataStruct;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Client
{
   public class SendAction
    {
        readonly ILog log = LogManager.GetLogger(typeof(SendAction));
        public void PageDailyPlan(ScreenCfg scrn, bool bNext, bool bRefresh,DataTable dt)
        {
            if (bRefresh)
            {
                if (scrn.TblInfo != null)
                {
                    scrn.TblInfo.Clear();
                }
                else
                {
                    scrn.TblInfo = dt; //new DataTable("tInfoDetail");
                }
                //using (SqlCommand sqlCommand = new SqlCommand("LD_LED_DailyOutputV2"))
                //{
                //    sqlCommand.CommandType = CommandType.StoredProcedure;
                //    sqlCommand.Parameters.AddWithValue("@lineguid", scrn.Line_guid);
                //    LdBLLCommon.FillDataTable(scrn.TblInfo, sqlCommand);
                //}
                scrn.RowIdx = 0;
            }
            if (scrn.TblInfo == null)
            {
                scrn.IsFinish = true;
                return;
            }
            if (bNext)
            {
                scrn.RowIdx += 3;
            }
            int num = scrn.TblInfo.Rows.Count - scrn.RowIdx;
            if (num > 3)
            {
                num = 3;
            }
            if (num <= 0)
            {
                scrn.IsFinish = true;
                log.InfoFormat("{0}号屏, 日目标达成率内容为空", new object[]
                {
                    scrn.ScreenNo
                });
                return;
            }
            if (scrn.RowIdx + num >= scrn.TblInfo.Rows.Count)
            {
                scrn.IsFinish = true;
            }
            if (this.LEDIsOnline(scrn) && EQ2008.User_RealtimeConnect(scrn.ScreenNo))
            {
                string format = string.Format("打开{0}号屏，日目标达成率", scrn.ScreenNo);
                log.InfoFormat(format, new object[0]);
                User_FontSet user_FontSet = default(User_FontSet);
                user_FontSet.bFontBold = false;
                user_FontSet.bFontItaic = false;
                user_FontSet.bFontUnderline = false;
                user_FontSet.colorFont = 255;
                user_FontSet.strFontName = "宋体";
                user_FontSet.iAlignStyle = 0;
                user_FontSet.iVAlignerStyle = 0;
                user_FontSet.iRowSpace = 0;
                user_FontSet.iFontSize = 12;
                int iHeight = 64;
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 0, 320, 64, "   ", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 0, 184, iHeight, "制单号", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 192, 0, 32, iHeight, "目标", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 232, 0, 32, iHeight, "产量", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 272, 0, 48, iHeight, "达成率", ref user_FontSet);
                log.InfoFormat("制单号  目标  产量  达成率", new object[0]);
                for (int i = 0; i < 3; i++)
                {
                    if (i < num)
                    {
                        DataRow dataRow = scrn.TblInfo.Rows[scrn.RowIdx + i];
                        user_FontSet.iAlignStyle = 0;
                        string text = string.Format("{0}", dataRow["MONo"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 16 + i * 16, 184, iHeight, text, ref user_FontSet);
                        user_FontSet.iAlignStyle = 2;
                        string text2 = string.Format("{0}", dataRow["TAim"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 192, 16 + i * 16, 32, iHeight, text2, ref user_FontSet);
                        string text3 = string.Format("{0}", dataRow["TOutput"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 232, 16 + i * 16, 32, iHeight, text3, ref user_FontSet);
                        string text4 = string.Format("{0:P2}", dataRow["TEff"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 272, 16 + i * 16, 48, iHeight, text4, ref user_FontSet);
                        log.InfoFormat(string.Format("{0} {1} {2} {3}", new object[]
                        {
                            text,
                            text2,
                            text3,
                            text4
                        }), new object[0]);
                    }
                    else
                    {
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 16 + i * 16, 320, iHeight, "   ", ref user_FontSet);
                    }
                }
                EQ2008.User_RealtimeDisConnect(scrn.ScreenNo);
                format = string.Format("关闭{0}号屏", scrn.ScreenNo);
                log.InfoFormat(format, new object[0]);
                return;
            }
            scrn.IsFinish = true;
        }
        private bool LEDIsOnline(ScreenCfg scrn)
        {
            bool result = false;
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(scrn.IpAdress, 120);
            if (pingReply.Status == IPStatus.Success)
            {
                result = true;
            }
            else
            {
                string format = string.Format("{0}号屏，IP：{1}不通", scrn.ScreenNo, scrn.IpAdress);
                log.InfoFormat(format, new object[0]);
            }
            return result;
        }
        // Token: 0x06000082 RID: 130 RVA: 0x00003850 File Offset: 0x00001A50
        public void PageHourPlanV2(ScreenCfg scrn, bool bNext, bool bRefresh,DataTable dt)
        {
            if (bRefresh)
            {
                if (scrn.TblHourPlan != null)
                {
                    scrn.TblHourPlan.Clear();
                }
                else
                {
                    scrn.TblHourPlan = dt;//new DataTable("tLEDHourPlan");
                }
                //using (SqlCommand sqlCommand = new SqlCommand("LD_LED_HourOutputV2"))
                //{
                //    sqlCommand.CommandType = CommandType.StoredProcedure;
                //    sqlCommand.Parameters.AddWithValue("@lineguid", scrn.Line_guid);
                //    LdBLLCommon.FillDataTable(scrn.TblHourPlan, sqlCommand);
                //}
                scrn.RowIdx = 0;
            }
            if (scrn.TblHourPlan == null)
            {
                scrn.IsFinish = true;
                return;
            }
            if (bNext)
            {
                scrn.RowIdx += 2;
            }
            int num = scrn.TblHourPlan.Rows.Count - scrn.RowIdx;
            if (num > 2)
            {
                num = 2;
            }
            if (num <= 0)
            {
                scrn.IsFinish = true;
                log.InfoFormat("{0}号屏, 小时计划达成率V2内容为空", new object[]
                {
                    scrn.ScreenNo
                });
                return;
            }
            if (scrn.RowIdx + num >= scrn.TblHourPlan.Rows.Count)
            {
                scrn.IsFinish = true;
            }
            if (this.LEDIsOnline(scrn) && EQ2008.User_RealtimeConnect(scrn.ScreenNo))
            {
                string format = string.Format("打开{0}号屏, 小时计划达成率V2", scrn.ScreenNo);
                log.InfoFormat(format, new object[0]);
                User_FontSet user_FontSet = default(User_FontSet);
                user_FontSet.bFontBold = false;
                user_FontSet.bFontItaic = false;
                user_FontSet.bFontUnderline = false;
                user_FontSet.colorFont = 255;
                user_FontSet.strFontName = "宋体";
                user_FontSet.iAlignStyle = 0;
                user_FontSet.iVAlignerStyle = 0;
                user_FontSet.iRowSpace = 0;
                user_FontSet.iFontSize = 12;
                int iHeight = 64;
                user_FontSet.iAlignStyle = 0;
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 0, 320, 64, "   ", ref user_FontSet);
                user_FontSet.iAlignStyle = 1;
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 0, 72, iHeight, "Time", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 80, 0, 32, iHeight, "Plan", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 120, 0, 48, iHeight, "Actual", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 176, 0, 56, iHeight, "Fulfill", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 240, 0, 80, iHeight, "FPY", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 16, 72, iHeight, "时间", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 80, 16, 32, iHeight, "计划", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 120, 16, 48, iHeight, "实际", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 176, 16, 56, iHeight, "达成率", ref user_FontSet);
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 240, 16, 80, iHeight, "一次通过率", ref user_FontSet);
                log.InfoFormat("Time Plan Actual Fulfill FPY", new object[0]);
                log.InfoFormat("时间 计划 实际 达成率 一次通过率", new object[0]);
                for (int i = 0; i < 2; i++)
                {
                    if (i < num)
                    {
                        DataRow dataRow = scrn.TblHourPlan.Rows[scrn.RowIdx + i];
                        user_FontSet.iAlignStyle = 1;
                        string text = string.Format("{0}", dataRow["vRow"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 32 + i * 16, 72, iHeight, text, ref user_FontSet);
                        string text2 = string.Format("{0}", dataRow["PlanQty"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 80, 32 + i * 16, 32, iHeight, text2, ref user_FontSet);
                        string text3 = string.Format("{0}", dataRow["TOutput"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 120, 32 + i * 16, 48, iHeight, text3, ref user_FontSet);
                        string text4 = string.Format("{0:P1}", dataRow["Eff"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 176, 32 + i * 16, 56, iHeight, text4, ref user_FontSet);
                        string text5 = string.Format("{0:P1}", dataRow["EffFail"]);
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 240, 32 + i * 16, 80, iHeight, text5, ref user_FontSet);
                        log.InfoFormat(string.Format("{0} {1} {2} {3} {4}", new object[]
                        {
                            text,
                            text2,
                            text3,
                            text4,
                            text5
                        }), new object[0]);
                    }
                    else
                    {
                        user_FontSet.iAlignStyle = 0;
                        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 32 + i * 16, 320, iHeight, "   ", ref user_FontSet);
                    }
                }
                EQ2008.User_RealtimeDisConnect(scrn.ScreenNo);
                format = string.Format("关闭{0}号屏", scrn.ScreenNo);
                log.InfoFormat(format, new object[0]);
                log.InfoFormat(" ", new object[0]);
                return;
            }
            scrn.IsFinish = true;
        }
        public void sendCustInfo(ScreenCfg scrn,string text,string productName) {


            int fnt = 12;
            if (string.IsNullOrEmpty(text))
            {
                text = string.Format("{0}\r\n{1}", productName, DateTime.Now.ToString("yyyy年M月d日 hh:mm:ss"));
            }
            else
            {
                int num8 = text.IndexOf('\\');
                if (num8 > 0)
                {
                    string s = text.Substring(0, num8);
                    int num9 = 0;
                    if (int.TryParse(s, out num9))
                    {
                        fnt = num9;
                    }
                    text = text.Substring(num8 + 1);
                }
                text = text.Replace("date", DateTime.Now.ToString("yyyy年M月d日"));
                text = text.Replace("time", DateTime.Now.ToString("hh:mm:ss"));
            }
            this.PrintInfo(scrn, fnt, text);
           
            return;
        }
        private void PrintInfo(ScreenCfg scrn, int fnt, string strInfo)
        {
            if (this.LEDIsOnline(scrn) && EQ2008.User_RealtimeConnect(scrn.ScreenNo))
            {
                string format = string.Format("打开{0}号屏", scrn.ScreenNo);
                log.InfoFormat(format, new object[0]);
                User_FontSet user_FontSet = default(User_FontSet);
                user_FontSet.bFontBold = false;
                user_FontSet.bFontItaic = false;
                user_FontSet.bFontUnderline = false;
                user_FontSet.colorFont = 255;
                user_FontSet.strFontName = "宋体";
                user_FontSet.iAlignStyle = 0;
                user_FontSet.iVAlignerStyle = 0;
                user_FontSet.iRowSpace = 0;
                user_FontSet.iFontSize = fnt;
                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 0, 320, 64, strInfo, ref user_FontSet);
                EQ2008.User_RealtimeDisConnect(scrn.ScreenNo);
                format = string.Format("关闭{0}号屏", scrn.ScreenNo);
                log.InfoFormat(format, new object[0]);
                return;
            }
            scrn.IsFinish = true;
        }
        //// Token: 0x06000083 RID: 131 RVA: 0x00003D74 File Offset: 0x00001F74
        //private void PageHourPlanV3(ScreenCfg scrn, bool bNext, bool bRefresh)
        //{
        //    if (bRefresh)
        //    {
        //        if (scrn.TblHourPlanV3 != null)
        //        {
        //            scrn.TblHourPlanV3.Clear();
        //        }
        //        else
        //        {
        //            scrn.TblHourPlanV3 = new DataTable("tLEDHourPlan");
        //        }
        //        using (SqlCommand sqlCommand = new SqlCommand("LD_LED_HourOutputV3"))
        //        {
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.AddWithValue("@lineguid", scrn.Line_guid);
        //            LdBLLCommon.FillDataTable(scrn.TblHourPlanV3, sqlCommand);
        //        }
        //        scrn.RowIdx = 0;
        //    }
        //    if (scrn.TblHourPlanV3 == null)
        //    {
        //        scrn.IsFinish = true;
        //        return;
        //    }
        //    if (bNext)
        //    {
        //        scrn.RowIdx += 4;
        //    }
        //    int num = scrn.TblHourPlanV3.Rows.Count - scrn.RowIdx;
        //    if (num > 4)
        //    {
        //        num = 4;
        //    }
        //    if (num <= 0)
        //    {
        //        scrn.IsFinish = true;
        //        LdLogManager.WriteLog("{0}号屏, 小时计划达成率V3内容为空", new object[]
        //        {
        //            scrn.ScreenNo
        //        });
        //        return;
        //    }
        //    if (scrn.RowIdx + num >= scrn.TblHourPlanV3.Rows.Count)
        //    {
        //        scrn.IsFinish = true;
        //    }
        //    if (this.LEDIsOnline(scrn) && EQ2008.User_RealtimeConnect(scrn.ScreenNo))
        //    {
        //        string format = string.Format("打开{0}号屏, 小时计划达成率V3", scrn.ScreenNo);
        //        log.InfoFormat(format, new object[0]);
        //        User_FontSet user_FontSet = default(User_FontSet);
        //        user_FontSet.bFontBold = false;
        //        user_FontSet.bFontItaic = false;
        //        user_FontSet.bFontUnderline = false;
        //        user_FontSet.colorFont = 255;
        //        user_FontSet.strFontName = "宋体";
        //        user_FontSet.iAlignStyle = 0;
        //        user_FontSet.iVAlignerStyle = 0;
        //        user_FontSet.iRowSpace = 0;
        //        user_FontSet.iFontSize = 12;
        //        int iHeight = 64;
        //        user_FontSet.iAlignStyle = 0;
        //        EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, 0, 320, 64, "   ", ref user_FontSet);
        //        for (int i = 0; i < 4; i++)
        //        {
        //            if (i < num)
        //            {
        //                DataRow dr = scrn.TblHourPlanV3.Rows[scrn.RowIdx + i];
        //                user_FontSet.iAlignStyle = 1;
        //                string text = dr.LdToString("ColA");
        //                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, i * 16, 72, iHeight, text, ref user_FontSet);
        //                string text2 = dr.LdToString("ColB");
        //                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 80, i * 16, 32, iHeight, text2, ref user_FontSet);
        //                string text3 = dr.LdToString("ColC");
        //                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 120, i * 16, 48, iHeight, text3, ref user_FontSet);
        //                string text4 = dr.LdToString("ColD");
        //                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 176, i * 16, 56, iHeight, text4, ref user_FontSet);
        //                string text5 = dr.LdToString("ColE");
        //                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 240, i * 16, 80, iHeight, text5, ref user_FontSet);
        //                LdLogManager.WriteLog(string.Format("{0} {1} {2} {3} {4}", new object[]
        //                {
        //                    text,
        //                    text2,
        //                    text3,
        //                    text4,
        //                    text5
        //                }), new object[0]);
        //            }
        //            else
        //            {
        //                user_FontSet.iAlignStyle = 0;
        //                EQ2008.User_RealtimeSendText(scrn.ScreenNo, 0, i * 16, 320, iHeight, "   ", ref user_FontSet);
        //            }
        //        }
        //        EQ2008.User_RealtimeDisConnect(scrn.ScreenNo);
        //        format = string.Format("关闭{0}号屏", scrn.ScreenNo);
        //        log.InfoFormat(format, new object[0]);
        //        log.InfoFormat(" ", new object[0]);
        //        return;
        //    }
        //    scrn.IsFinish = true;
        //}
    }
}
