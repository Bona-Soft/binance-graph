// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Exceptions;
using BSoft.BApp.Core.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BSoft.BApp.Core.Controller.Attribute
{
    public class ProducesResponseOkAttribute : ProducesResponseTypeAttribute, IApiResponseMetadataProvider, IFilterMetadata
    {
        public ProducesResponseOkAttribute()
            : base(StatusCodes.Status204_NoContent)
        {
        }

        public ProducesResponseOkAttribute(Type type)
            : base(type, StatusCodes.Status200_OK)
        {
        }
    }
}
