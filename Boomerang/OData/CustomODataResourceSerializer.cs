using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Formatter.Serialization;
using Microsoft.OData;
using System.Web.OData;
using Microsoft.OData.Edm;

namespace Boomerang.OData
{
    public class CustomODataResourceSerializer : ODataResourceSerializer
    {
        bool isFirstTime = true;
        public CustomODataResourceSerializer(ODataSerializerProvider serializerProvider) : base(serializerProvider)
        {

        }

        public override Microsoft.OData.ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
        {
            Microsoft.OData.ODataProperty property = base.CreateStructuralProperty(structuralProperty, resourceContext);
            
            // find the class of the current property if it's in the list
            //List<string> classPropertiesToHide;
            //if (propertiesToHide.TryGetValue(resourceContext.StructuredType.FullTypeName(), out classPropertiesToHide))
            //{
            //    // if the current property is in the list of properties to hide
            //    if (classPropertiesToHide.Contains(property.Name))
            //    {
            //        // return null to not serialize the property
            //        // for future reference, if the desire was to set the field as null, you'd do "property.Value = null"
            //        return null;
            //    }
            //}
            return property;
        }

        public override void AppendDynamicProperties(ODataResource resource, SelectExpandNode selectExpandNode, ResourceContext resourceContext)
        {
            // add expanded field
            //public static EdmNavigationProperty CreateNavigationProperty(IEdmStructuredType declaringType, EdmNavigationPropertyInfo propertyInfo);
            if (isFirstTime)
            {
                selectExpandNode.SelectedNavigationProperties.Add(EdmNavigationProperty.CreateNavigationProperty(
                    new EdmEntityType("EntityTypeNamespace", "EntityTypeName"),
                    new EdmNavigationPropertyInfo()
                    {
                        Name = "PropertyInfoName",
                        Target = new EdmEntityType("EntityTypeNamespace", "EntityTypeName2"),
                        TargetMultiplicity = EdmMultiplicity.One
                    }
                    ));
                isFirstTime = false;
            }

            // add property
            var list = resource.Properties.ToList();
            list.Add(new ODataProperty() { Name = "MyCustomProp", Value = "This Thing" });
            resource.Properties = list.AsEnumerable();
            
            base.AppendDynamicProperties(resource, selectExpandNode, resourceContext);
        }
        public override ODataResource CreateResource(SelectExpandNode selectExpandNode, ResourceContext resourceContext)
        {
            return base.CreateResource(selectExpandNode, resourceContext);
        }
        public override SelectExpandNode CreateSelectExpandNode(ResourceContext resourceContext)
        {
            return base.CreateSelectExpandNode(resourceContext);
        }
        public override void WriteObject(object graph, Type type, ODataMessageWriter messageWriter, ODataSerializerContext writeContext)
        {
            base.WriteObject(graph, type, messageWriter, writeContext);
        }
    }
}