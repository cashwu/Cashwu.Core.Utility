using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToUShortObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToUShort().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToUShort(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToUShort().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToUShort().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToUShort().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToUShort().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToUShort().Should().Be(0x31);
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToUShort().Should().Be(255);
        }
        
        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToUShort().Should().Be(32767);
        }

        [Fact]
        public void Int()
        {
            int i = 8;
            i.ToUShort().Should().Be(8);
        }

        [Fact]
        public void Int_more_than_byte_size()
        {
            int i = int.MaxValue;
            Func<ushort> action = () => i.ToUShort();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for a UInt16.");
        }

        [Fact]
        public void Int_negative()
        {
            int i = -10;
            Func<ushort> action = () => i.ToUShort();
            
            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for a UInt16.");
        }

        [Fact]
        public void Long()
        {
            long l = 9;
            l.ToUShort().Should().Be(9);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToUShort().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToUShort().Should().Be(7);
        }
    }
}