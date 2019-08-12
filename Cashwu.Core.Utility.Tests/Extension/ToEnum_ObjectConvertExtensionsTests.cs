using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToEnumObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToEnum<NumberEnum>().Should().Be(NumberEnum.None);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToEnum(NumberEnum.One).Should().Be(NumberEnum.One);
        }

        [Fact]
        public void Another_enum()
        {
            AnotherNumberEnum.One.ToEnum<NumberEnum>().Should().Be(NumberEnum.One);
            AnotherNumberEnum.Two.ToEnum<NumberEnum>().Should().Be(NumberEnum.Two);
        }

        [Fact]
        public void Number()
        {
            0.ToEnum<NumberEnum>().Should().Be(NumberEnum.None);
            1.ToEnum<NumberEnum>().Should().Be(NumberEnum.One);
            2.ToEnum<NumberEnum>().Should().Be(NumberEnum.Two);
        }

        [Fact]
        public void String()
        {
            "None".ToEnum<NumberEnum>().Should().Be(NumberEnum.None);
            "One".ToEnum<NumberEnum>().Should().Be(NumberEnum.One);
            "Two".ToEnum<NumberEnum>().Should().Be(NumberEnum.Two);
            
            "NONE".ToEnum<NumberEnum>().Should().Be(NumberEnum.None);
            "ONE".ToEnum<NumberEnum>().Should().Be(NumberEnum.None);
            "TWO".ToEnum<NumberEnum>().Should().Be(NumberEnum.None);
        }
    }

    public enum NumberEnum
    {
        None = 0,
        One = 1,
        Two = 2
    }

    public enum AnotherNumberEnum
    {
        None = 0,
        One = 1,
        Two = 2
    }
}