using log4net;
using log4net.Config;

namespace TestTask1.framework
{
    public class BaseEntity
    {
        public static Logger Log;
        public static Browser Browser;
        protected BaseEntity()
        {
           XmlConfigurator.Configure();
            Log = new Logger(LogManager.GetLogger(typeof(BaseEntity)));
        }
        
    }
}
