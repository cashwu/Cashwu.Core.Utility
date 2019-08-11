using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToNullStringObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((string)null).ToNotNullString().Should().BeEmpty();
        }

        [Fact]
        public void Empty()
        {
            string.Empty.ToNotNullString().Should().BeEmpty();
        }

        [Fact]
        public void Not_string()
        {
            1.ToNotNullString().Should().Be("1");
        }

        [Fact]
        public void Null_default_value()
        {
            ((string)null).ToNotNullString("default").Should().Be("default");
        }
    }
}