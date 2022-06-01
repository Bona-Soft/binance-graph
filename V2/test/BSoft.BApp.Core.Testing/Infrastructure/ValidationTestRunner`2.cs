// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using EnsureThat;
using Zenfolio.Common.API.Validation;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public class ValidationTestRunner<TValidator, TModel>
        where TValidator : BaseValidator<TModel>
        where TModel : class, new()
    {
        private readonly TValidator _validator;

        internal ValidationTestRunner(TValidator validator)
        {
            Ensure.Any.IsNotNull(validator, nameof(validator));

            _validator = validator;
        }

        public ValidationTestResult<TValidator, TModel> For(Action<TModel> init)
        {
            Ensure.Any.IsNotNull(init, nameof(init));

            var model = new TModel();
            init(model);

            return new ValidationTestResult<TValidator, TModel>(_validator).Validate(model);
        }

        public ValidationTestResult<TValidator, TModel> For(TModel model)
        {
            Ensure.Any.IsNotNull(model, nameof(model));

            return new ValidationTestResult<TValidator, TModel>(_validator).Validate(model);
        }
    }
}
