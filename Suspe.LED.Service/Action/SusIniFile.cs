using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Service
{
    class SusIniFile
    {
        // Token: 0x0600001D RID: 29
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        // Token: 0x0600001E RID: 30
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        // Token: 0x0600001F RID: 31
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        // Token: 0x06000020 RID: 32 RVA: 0x00002FE0 File Offset: 0x000011E0
        public SusIniFile(string filename)
        {
            this._filename = filename;
        }

        // Token: 0x06000021 RID: 33 RVA: 0x00002FEF File Offset: 0x000011EF
        public int GetInt(string section, string key, int def)
        {
            return SusIniFile.GetPrivateProfileInt(section, key, def, this._filename);
        }

        // Token: 0x06000022 RID: 34 RVA: 0x00003000 File Offset: 0x00001200
        public string GetString(string section, string key, string def)
        {
            StringBuilder stringBuilder = new StringBuilder(1024);
            SusIniFile.GetPrivateProfileString(section, key, def, stringBuilder, 1024, this._filename);
            return stringBuilder.ToString();
        }

        // Token: 0x06000023 RID: 35 RVA: 0x00003035 File Offset: 0x00001235
        public void WriteInt(string section, string key, int iVal)
        {
            SusIniFile.WritePrivateProfileString(section, key, iVal.ToString(), this._filename);
        }

        // Token: 0x06000024 RID: 36 RVA: 0x0000304C File Offset: 0x0000124C
        public void WriteString(string section, string key, string strVal)
        {
            SusIniFile.WritePrivateProfileString(section, key, strVal, this._filename);
        }

        // Token: 0x06000025 RID: 37 RVA: 0x0000305D File Offset: 0x0000125D
        public void DelKey(string section, string key)
        {
            SusIniFile.WritePrivateProfileString(section, key, null, this._filename);
        }

        // Token: 0x06000026 RID: 38 RVA: 0x0000306E File Offset: 0x0000126E
        public void DelSection(string section)
        {
            SusIniFile.WritePrivateProfileString(section, null, null, this._filename);
        }

        // Token: 0x04000005 RID: 5
        private string _filename;
    }
}
