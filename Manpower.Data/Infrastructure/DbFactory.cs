using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manpower.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ManpowerContext dbContext;

        public ManpowerContext Init()
        {
            return dbContext ?? (dbContext = new ManpowerContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
