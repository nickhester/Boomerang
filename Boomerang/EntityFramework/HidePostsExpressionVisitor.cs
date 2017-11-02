using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Common.CommandTrees;

namespace Boomerang.EntityFramework
{
    public class HidePostsExpressionVisitor : DefaultExpressionVisitor
    {
        public override DbExpression Visit(DbScanExpression expression)
        {
            return null;
        }
    }
}