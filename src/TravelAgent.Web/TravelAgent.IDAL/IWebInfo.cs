using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.IDAL
{
    public interface IWebInfo
    {
        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        TravelAgent.Model.WebInfo loadConfig(string configFilePath);
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        TravelAgent.Model.WebInfo saveConifg(TravelAgent.Model.WebInfo mode, string configFilePath);
    }
}
