using System;
using System.Collections.Generic;
using System.Text;
using TravelAgent.Tool;
using TravelAgent.IDAL;

namespace TravelAgent.DALSQL
{
    public class WebInfo:IWebInfo
    {
        private static object lockHelper = new object();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public TravelAgent.Model.WebInfo loadConfig(string configFilePath)
        {
            return (TravelAgent.Model.WebInfo)SerializationHelper.Load(typeof(TravelAgent.Model.WebInfo), configFilePath);
        }
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public TravelAgent.Model.WebInfo saveConifg(TravelAgent.Model.WebInfo mode, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(mode, configFilePath);
                //JGK.Dal.Providers.webSetProvider.SetInstance(mode);
            }
            return mode;
        }
    }
}
