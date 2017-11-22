using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net;
using log4net.Config;

namespace GISApp
{
    class LogHelper
    {
        public static void writeLog(string msg){
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
            var logger = LogManager.GetLogger(typeof(Program));
            logger.Info(msg);
        }
    }
}
