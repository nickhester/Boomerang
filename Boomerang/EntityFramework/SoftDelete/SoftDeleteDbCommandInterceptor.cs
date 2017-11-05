using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace Boomerang.EntityFramework
{
    //public class SoftDeleteDbCommandInterceptor : IDbCommandInterceptor
    //{
    //    public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    //    {
    //        AddAttribute(command);
    //    }

    //    public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    //    {
    //        AddAttribute(command);
    //    }

    //    public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    //    {
    //        AddAttribute(command);
    //    }

    //    public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    //    {
    //        AddAttribute(command);
    //    }

    //    public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    //    {
    //    }

    //    public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    //    {
    //    }
    //    private void AddAttribute(DbCommand command)
    //    {
    //        foreach (DbParameter param in command.Parameters)
    //        {
    //            //if (param.ParameterName != TenantAwareAttribute.TenantIdFilterParameterName)
    //            //{
    //            //    continue;
    //            //}
    //            //param.Value = domainId;
    //        }
    //    }
    //}
}