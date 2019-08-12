using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToIntObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToInt().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToInt(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToInt().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToInt().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToInt().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToInt().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToInt().Should().Be(0x31);
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToInt().Should().Be(255);
        }
        
        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToInt().Should().Be(32767);
        }

        [Fact]
        public void Long_more_than_int_size()
        {
            long i = long.MaxValue;
            Func<int> action = () => i.ToInt();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for an Int32.");
        }

        [Fact]
        public void Long_negative()
        {
            long l = -10;
            l.ToInt().Should().Be(-10);
        }

        [Fact]
        public void Long()
        {
            long l = 9;
            l.ToInt().Should().Be(9);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToInt().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToInt().Should().Be(7);
        }
    }
}