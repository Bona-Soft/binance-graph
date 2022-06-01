// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Automapper.Interfaces;
using BSoft.BApp.Core.Controller;
using BSoft.DemoApp.API.Validators;
using MediatR;

namespace BSoft.DemoApp.API.Application.Requests
{
    public record AddPersonRequest
        (string Name,
        string Surname,
        string DocumentNumber,
        DateTime BirthDate) 
        : BaseRequest, IRequest, IBaseMappeable
    {
    }
}
