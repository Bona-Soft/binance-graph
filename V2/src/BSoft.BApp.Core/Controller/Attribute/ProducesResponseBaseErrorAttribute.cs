// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BSoft.BApp.Core.Controller.Attribute
{
    public class ProducesResponseBaseErrorAttribute : ProducesResponseTypeAttribute, IApiResponseMetadataProvider, IFilterMetadata
    {
        public ProducesResponseBaseErrorAttribute(int statusCode)
            : base(typeof(BaseError), statusCode)
        {
        }
    }
}
