using log4net;
using XPEssentials.Logger;

namespace XPEssentials
{
    public class BaseClass
    {
        public static ILog Logger => LoggerFactory.Logger;
    }
}
