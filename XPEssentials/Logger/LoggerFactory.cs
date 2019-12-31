using log4net;

namespace XPEssentials.Logger
{
    /// <summary>
    /// Logger class with all the logging mechnisms provided by Log4Net
    /// </summary>
    public static class LoggerFactory
    {
        /// <summary>
        /// The logger service
        /// </summary>
        private static ILog _loggerService;

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public static ILog Logger
        {
            get
            {
                return _loggerService ??
                    (_loggerService =
                    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name));
            }
        }
    }
}