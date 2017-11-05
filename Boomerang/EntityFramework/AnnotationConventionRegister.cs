using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Boomerang.EntityFramework
{
    public static class AnnotationConventionRegister
    {
        public static void RegisterAnnotationConventions(ref DbModelBuilder modelBuilder)
        {
            var conv = new AttributeToTableAnnotationConvention<EntityFramework.SoftDeleteAttribute, string>(
                SoftDeleteAttribute.SoftDeleteAnnotation,
                (type, attributes) => attributes.Single().ColumnName);
            modelBuilder.Conventions.Add(conv);

            var conv2 = new AttributeToTableAnnotationConvention<EntityFramework.TenantAwareAttribute, string>(
                TenantAwareAttribute.TenantAwareAnnotation,
                (type, attributes) => attributes.Single().ColumnName);
            modelBuilder.Conventions.Add(conv2);
        }
    }
}