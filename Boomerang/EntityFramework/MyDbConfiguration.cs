using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Boomerang.EntityFramework
{
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            AddInterceptor(new SoftDeleteDbCommandTreeInterceptor());
            AddInterceptor(new TenantAwareDbCommandTreeInterceptor());
            AddInterceptor(new AddExpandDbCommandInterceptor());
        }
    }
}