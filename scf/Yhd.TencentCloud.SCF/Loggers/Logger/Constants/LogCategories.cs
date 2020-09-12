using System;
using System.Collections.Generic;
using System.Text;

namespace Yhd.TencentCloud.SCF.Loggers.Logger.Constants
{
    public static class LogCategories
    {
        /// <summary>
        /// The category for all logs written by the function host during startup and shutdown. This
        /// includes indexing and configuration logs.
        /// </summary>
        public const string Startup = "Host.Startup";
    }
}
