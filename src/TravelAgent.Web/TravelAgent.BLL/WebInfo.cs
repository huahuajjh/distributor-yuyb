using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class WebInfo
    {
        private readonly TravelAgent.IDAL.IWebInfo dal = DALBuild.CreateWebInfo();
        public WebInfo()
		{}
        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public TravelAgent.Model.WebInfo loadConfig(string configFilePath)
        {
            return dal.loadConfig(configFilePath);
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public TravelAgent.Model.WebInfo saveConifg(TravelAgent.Model.WebInfo mode, string configFilePath)
        {
            return dal.saveConifg(mode, configFilePath);
        }
    }
}
