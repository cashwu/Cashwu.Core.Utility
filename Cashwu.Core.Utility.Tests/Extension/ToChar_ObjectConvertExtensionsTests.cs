using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToCharObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToChar().Should().Be('\0');
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToChar('a').Should().Be('a');
        }

        [Fact]
        public void Empty()
        {
            '\0'.ToChar().Should().Be('\0');
        }

        [Fact]
        public void Not_1_char_string()
        {
            "abc".ToChar().Should().Be('\0');
        }

        [Fact]
        public void One_char_string()
        {
            "a".ToChar().Should().Be('a');
        }

        [Fact]
        public void Number()
        {
            35.ToChar().Should().Be('#');
        }
    }
}