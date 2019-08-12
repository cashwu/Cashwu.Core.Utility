using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToSByteObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToSByte().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToSByte(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToSByte().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToSByte().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToSByte().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToSByte().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToSByte().Should().Be(0x31);
        }
        
        [Fact]
        public void Byte()
        {
            byte b = 8;
            b.ToSByte().Should().Be(8);
        }

        [Fact]
        public void Int()
        {
            int i = 8;
            i.ToSByte().Should().Be(8);
        }

        [Fact]
        public void Int_more_than_byte_size()
        {
            int i = int.MaxValue;
            Func<sbyte> action = () => i.ToSByte();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for a signed byte.");
        }

        [Fact]
        public void Int_negative()
        {
            int i = -10;
            i.ToSByte().Should().Be(-10);
        }

        [Fact]
        public void Long()
        {
            long l = 9;
            l.ToSByte().Should().Be(9);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToSByte().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToSByte().Should().Be(7);
        }
    }
}