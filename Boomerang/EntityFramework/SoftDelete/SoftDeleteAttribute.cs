using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Metadata.Edm;

namespace Boomerang.EntityFramework
{
    public class SoftDeleteAttribute : Attribute
    {
        public const string SoftDeleteAnnotation = "SoftDeleteAnnotation";
        //public const string SoftDeleteParameterName = "IsDeleted";

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string ColumnName { get; private set; }

        public SoftDeleteAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public static string GetColumnName(EdmType type)
        {
            var annotation = type.MetadataProperties.SingleOrDefault(
                p => p.Name.EndsWith($"customannotation:{SoftDeleteAnnotation}"));

            return (string)annotation?.Value;
        }
    }
}