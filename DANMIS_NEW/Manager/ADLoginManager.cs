using System;
using System.Collections.Concurrent;
using System.DirectoryServices;
using System.Linq;
using DANMIS_NEW.Models;

namespace DANMIS_NEW.Manager
{
    public static class ADLoginManager
    {
        #region CheckADPasswordAndGetADLogin
        public static bool CheckADPasswordAndGetADLogin(string sEMail, string sPassword, string sDCName, out string sADLogin)
        {
            sADLogin = "";
            string sComputerName = Environment.MachineName;
            string account = sEMail;
            string password = sPassword;
            string ip = sDCName;
            string domain = "ap.media.global.loc";
            string[] SplitStr = null;
            string DomainName = "";
            bool bResult = false;

            if (domain.Contains("."))
            {
                SplitStr = domain.Split('.');

                foreach (string item in SplitStr)
                {
                    if (DomainName == "")
                        DomainName += "DC=" + item;
                    else
                        DomainName += ",DC=" + item;
                }
            }
            else
                DomainName = "DC=" + domain;

            string QueryString = "LDAP://" + ip + "/" + DomainName;

            DirectoryEntry de;// = new DirectoryEntry(QueryString, account, password);
            DirectorySearcher ds;// = new DirectorySearcher(de);

            try
            {
                de = new DirectoryEntry(QueryString, account, password);
                ds = new DirectorySearcher(de);

                ds.Filter = "(mail=" + sEMail + ")";
                ds.PropertiesToLoad.Add("SAMAccountName");
                //SearchResult sr = ds.FindOne();

                SearchResultCollection sr = ds.FindAll();

                if (sr != null)
                {
                    bResult = true;
                    //sADLogin = sr.ToString();
                    foreach (SearchResult subSr in sr)
                    {
                        if (subSr.Properties["SAMAccountName"].Count != 0)
                        {
                            //bResult = true;
                            sADLogin = subSr.Properties["SAMAccountName"][0].ToString();
                        }
                    }
                }

                ds = null;
                de = null;
            }
            catch (Exception ex)
            {
                ds = null;
                de = null;
                return bResult;
            }

            return bResult;
        }
        #endregion
    }
}