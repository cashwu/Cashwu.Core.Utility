using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToByteObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToByte().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToByte(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToByte().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToByte().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToByte().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToByte().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToByte().Should().Be(0x31);
        }

        [Fact]
        public void Long()
        {
            long l = 9;
            l.ToByte().Should().Be(9);
        }

        [Fact]
        public void Int()
        {
            int i = 8;
            i.ToByte().Should().Be(8);
        }

        [Fact]
        public void Int_more_than_byte_size()
        {
            int i = int.MaxValue;
            Func<byte> action = () => i.ToByte();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for an unsigned byte.");
        }
        
        [Fact]
        public void Int_negative()
        {
            int i = -10;
            Func<byte> action = () => i.ToByte();
            
            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for an unsigned byte.");
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToByte().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToByte().Should().Be(7);
        }
    }
}