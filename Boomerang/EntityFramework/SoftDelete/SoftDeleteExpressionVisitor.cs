using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Boomerang.EntityFramework
{
    public class SoftDeleteExpressionVisitor : DefaultExpressionVisitor
    {
        public override DbExpression Visit(DbScanExpression expression)
        {
            var column = SoftDeleteAttribute.GetColumnName(expression.Target.ElementType);
            if (column != null)
            {
                var binding = DbExpressionBuilder.Bind(expression);
                return DbExpressionBuilder.Filter(
                    binding,
                    DbExpressionBuilder.NotEqual(
                        DbExpressionBuilder.Property(
                            DbExpressionBuilder.Variable(binding.VariableType, binding.VariableName),
                            column),
                        DbExpression.FromBoolean(true)));
            }
            else
            {
                return base.Visit(expression);
            }
        }
    }
}