// Copyright (c) Zenfolio, Inc. All rights reserved.

using Xunit;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    public sealed class DebugTheoryAttribute : TheoryAttribute
    {
        public DebugTheoryAttribute()
        {
#if !DEBUG
            Skip = "Skipped in Release mode";
#endif
        }
    }
}
