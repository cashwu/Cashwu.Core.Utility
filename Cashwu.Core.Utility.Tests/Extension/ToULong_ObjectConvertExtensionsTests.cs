using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToULongObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToULong().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToULong(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToULong().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToULong().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToULong().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToULong().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToULong().Should().Be(0x31);
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToULong().Should().Be(255);
        }

        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToULong().Should().Be(32767);
        }

        [Fact]
        public void Int()
        {
            int i = int.MaxValue;
            i.ToULong().Should().Be(2_147_483_647);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToULong().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToULong().Should().Be(7);
        }

        [Fact]
        public void Decimal_more_than_ulong_max()
        {
            decimal i = decimal.MaxValue;
            Func<ulong> action = () => i.ToULong();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for a UInt64.");
        }
    }
}