using System;
using log4net;

namespace TestTask1.framework
{
    
        public class Logger
        {
            private ILog logger;
            public Logger(ILog logger)
            {
                this.logger = logger;
            }

            public void Step(int number, string description)
            {
                logger.Info(String.Format("== Step {0}: {1} ==",number,description));
            }

            public void Info(String info)
            {
                logger.Info(info);
               //BaseEntity.ReportFile.WriteLine(info);
            }

            public void Fatal(String fatal)
            {
                logger.Fatal(fatal);
            }
        }
    }

