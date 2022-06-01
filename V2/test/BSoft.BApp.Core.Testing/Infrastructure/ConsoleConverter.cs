// Copyright (c) BonaSoft, Inc. All rights reserved.

using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace BSoft.BApp.Core.Testing.Infrastructure
{
    internal class ConsoleConverter : TextWriter
    {
        private readonly ITestOutputHelper _output;

        private readonly StringBuilder _lineBuilder = new StringBuilder();

        public ConsoleConverter(ITestOutputHelper output) => _output = output;

        public override Encoding Encoding => Encoding.UTF8;

        public override void Write(string message) => _lineBuilder.Append(message);

        public override void WriteLine(string message) => _output.WriteLine(message);

        public override void WriteLine(string format, params object[] args) => _output.WriteLine(format, args);

        public override void Flush()
        {
            if (_lineBuilder.Length > 0)
            {
                _output.WriteLine(_lineBuilder.ToString().TrimEnd());

                _lineBuilder.Clear();
            }

            base.Flush();
        }
    }
}
