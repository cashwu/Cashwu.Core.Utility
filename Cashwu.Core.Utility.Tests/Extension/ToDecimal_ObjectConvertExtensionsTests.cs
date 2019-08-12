using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToDecimalObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToDecimal().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToDecimal(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToDecimal().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToDecimal().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToDecimal().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            Func<decimal> action = () => 'a'.ToDecimal();

            action.Should()
                  .Throw<InvalidCastException>()
                  .And
                  .Message.Should()
                  .Be("Invalid cast from 'Char' to 'Decimal'.");
        }

        [Fact]
        public void Char_is_numeric()
        {
            Func<decimal> action = () => '1'.ToDecimal();

            action.Should()
                  .Throw<InvalidCastException>()
                  .And
                  .Message.Should()
                  .Be("Invalid cast from 'Char' to 'Decimal'.");
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToDecimal().Should().Be(255);
        }

        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToDecimal().Should().Be(32767);
        }

        [Fact]
        public void Int()
        {
            int i = int.MaxValue;
            i.ToDecimal().Should().Be(2_147_483_647);
        }

        [Fact]
        public void Int_negative()
        {
            int i = -10;
            i.ToDecimal().Should().Be(-10);
        }

        [Fact]
        public void Long_max()
        {
            long l = long.MaxValue;
            l.ToDecimal().Should().Be(long.MaxValue);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToDecimal().Should().Be(8.1m);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToDecimal().Should().Be(7.1m);
        }
    }
}