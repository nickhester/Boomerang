using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Formatter.Serialization;
using Microsoft.OData.Edm;

namespace Boomerang.OData
{
    public class CustomODataSerializerProvider : DefaultODataSerializerProvider
    {
        private CustomODataResourceSerializer _customODataSerializer;

        public CustomODataSerializerProvider(IServiceProvider rootContainer) : base(rootContainer)
        {
            _customODataSerializer = new CustomODataResourceSerializer(this);
        }

        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.Definition.TypeKind == EdmTypeKind.Entity)
                return _customODataSerializer;

            return base.GetEdmTypeSerializer(edmType);
        }
    }
}