using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Formatter.Serialization;
using Microsoft.OData;

namespace Boomerang.OData
{
    public class CustomODataEdmTypeSerializer : ODataEdmTypeSerializer
    {
        protected CustomODataEdmTypeSerializer(ODataPayloadKind payloadKind) : base(payloadKind)
        {
        }
    }
}