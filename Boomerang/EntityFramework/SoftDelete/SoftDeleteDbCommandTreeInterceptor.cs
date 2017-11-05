using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;

namespace Boomerang.EntityFramework
{
    public class SoftDeleteDbCommandTreeInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                var queryCommand = interceptionContext.Result as DbQueryCommandTree;
                if (queryCommand != null)
                {
                    var newQuery = queryCommand.Query.Accept(new SoftDeleteExpressionVisitor());

                    interceptionContext.Result = new DbQueryCommandTree(
                        queryCommand.MetadataWorkspace,
                        queryCommand.DataSpace,
                        newQuery);
                }
            }
        }
    }
}