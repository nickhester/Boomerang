using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Metadata.Edm;

namespace Boomerang.EntityFramework
{
    public class TenantAwareAttribute : Attribute
    {
        public const string TenantAwareAnnotation = "TenantAwareAnnotation";
        //public const string TenantAwareParameterName = "DomainId";

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string ColumnName { get; private set; }

        public TenantAwareAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public static string GetColumnName(EdmType type)
        {
            var annotation = type.MetadataProperties.SingleOrDefault(
                p => p.Name.EndsWith($"customannotation:{TenantAwareAnnotation}"));

            return (string)annotation?.Value;
        }
    }
}