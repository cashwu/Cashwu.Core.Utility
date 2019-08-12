using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToBoolObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToBool().Should().Be(false);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToBool(true).Should().Be(true);
        }

        [Fact]
        public void Bool()
        {
            true.ToBool().Should().Be(true);
            false.ToBool().Should().Be(false);
        }

        [Fact]
        public void Numeric_not_zero()
        {
            1.ToBool().Should().Be(true);
            1.1.ToBool().Should().Be(true);
            (-1m).ToBool().Should().Be(true);
        }

        [Fact]
        public void Numeric_zero()
        {
            0.ToBool().Should().Be(false);
        }

        [Fact]
        public void Bool_string()
        {
            "true".ToBool().Should().Be(true);
            "True".ToBool().Should().Be(true);
            "TRUE".ToBool().Should().Be(true);
            "false".ToBool().Should().Be(false);
            "False".ToBool().Should().Be(false);
            "FALSE".ToBool().Should().Be(false);
        }

        [Fact]
        public void Not_bool_string()
        {
            "abc".ToBool().Should().Be(false);
            "123".ToBool().Should().Be(false);
        }

        [Fact]
        public void Char()
        {
            'a'.ToBool().Should().Be(true);
            '1'.ToBool().Should().Be(true);
        }
    }
}