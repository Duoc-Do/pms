using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Services.Tasks;
using System.Net;
using WebApp.Services.Caching;

namespace WebApp.Services.Caching
{
    /// <summary>
    /// Clear cache schedueled task implementation
    /// </summary>
    public partial class ClearCacheTask : ITask
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            var cacheManager = new MemoryCacheManager();
            cacheManager.Clear();
        }
    }
}
