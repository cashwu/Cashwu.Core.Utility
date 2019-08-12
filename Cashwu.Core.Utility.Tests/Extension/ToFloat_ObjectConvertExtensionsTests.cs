using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToFloatObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToFloat().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToFloat(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToFloat().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToFloat().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToFloat().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            Func<float> action = () => 'a'.ToFloat();

            action.Should()
                  .Throw<InvalidCastException>()
                  .And
                  .Message.Should()
                  .Be("Invalid cast from 'Char' to 'Single'.");
        }

        [Fact]
        public void Char_is_numeric()
        {
            Func<float> action = () => '1'.ToFloat();

            action.Should()
                  .Throw<InvalidCastException>()
                  .And
                  .Message.Should()
                  .Be("Invalid cast from 'Char' to 'Single'.");
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToFloat().Should().Be(255);
        }

        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToFloat().Should().Be(32767);
        }

        [Fact]
        public void Int()
        {
            int i = int.MaxValue;
            i.ToFloat().Should().Be(2_147_483_647);
        }

        [Fact]
        public void Int_negative()
        {
            int i = -10;
            i.ToFloat().Should().Be(-10);
        }

        [Fact]
        public void Long_max()
        {
            long l = long.MaxValue;
            l.ToFloat().Should().Be(long.MaxValue);
        }
        
        [Fact]
        public void Decimal()
        {
            decimal d = 8.1m;
            d.ToFloat().Should().Be(8.1f);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToFloat().Should().Be(8.1f);
        }

        [Fact]
        public void Double_max()
        {
            double d = double.MaxValue;
            d.ToFloat().Should().Be(Single.PositiveInfinity);
        }
    }
}