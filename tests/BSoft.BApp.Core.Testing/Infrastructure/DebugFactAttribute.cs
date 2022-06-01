// Copyright (c) Zenfolio, Inc. All rights reserved.

using Xunit;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public sealed class DebugFactAttribute : FactAttribute
    {
        public DebugFactAttribute()
        {
#if !DEBUG
            Skip = "Skipped in Release mode";
#endif
        }
    }
}
