using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToDoubleObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToDouble().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToDouble(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToDouble().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToDouble().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToDouble().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            Func<double> action = () => 'a'.ToDouble();

            action.Should()
                  .Throw<InvalidCastException>()
                  .And
                  .Message.Should()
                  .Be("Invalid cast from 'Char' to 'Double'.");
        }

        [Fact]
        public void Char_is_numeric()
        {
            Func<double> action = () => '1'.ToDouble();

            action.Should()
                  .Throw<InvalidCastException>()
                  .And
                  .Message.Should()
                  .Be("Invalid cast from 'Char' to 'Double'.");
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToDouble().Should().Be(255);
        }

        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToDouble().Should().Be(32767);
        }

        [Fact]
        public void Int()
        {
            int i = int.MaxValue;
            i.ToDouble().Should().Be(2_147_483_647);
        }

        [Fact]
        public void Int_negative()
        {
            int i = -10;
            i.ToDouble().Should().Be(-10);
        }

        [Fact]
        public void Long_max()
        {
            long l = long.MaxValue;
            l.ToDouble().Should().Be(long.MaxValue);
        }
        
        [Fact]
        public void Decimal()
        {
            decimal d = 8.1m;
            d.ToDouble().Should().Be(8.1d);
        }

        [Fact]
        public void Float_max()
        {
            float f = float.MaxValue;
            f.ToDouble().Should().Be(float.MaxValue);
        }
    }
}