using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Core.Common.CommandTrees;

namespace Boomerang.EntityFramework
{
    public class HidePostsDbCommandTreeInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            var queryCommand = interceptionContext.Result as DbQueryCommandTree;
            if (queryCommand == null)
            {
                return;
            }

            var newQuery = queryCommand.Query.Accept(new HidePostsExpressionVisitor());
        }
    }
}