using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToLongObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToLong().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToLong(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToLong().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToLong().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToLong().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToLong().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToLong().Should().Be(0x31);
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToLong().Should().Be(255);
        }

        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToLong().Should().Be(32767);
        }

        [Fact]
        public void Int()
        {
            int i = int.MaxValue;
            i.ToLong().Should().Be(2_147_483_647);
        }

        [Fact]
        public void Int_negative()
        {
            int i = -10;
            i.ToLong().Should().Be(-10);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToLong().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToLong().Should().Be(7);
        }

        [Fact]
        public void Decimal()
        {
            decimal i = decimal.MaxValue;
            Func<long> action = () => i.ToLong();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for an Int64.");
        }
    }
}