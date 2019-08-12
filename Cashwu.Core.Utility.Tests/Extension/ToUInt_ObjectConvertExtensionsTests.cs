using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToUIntObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToUInt().Should().Be(0);
        }

        [Fact]
        public void Null_default_value()
        {
            ((object)null).ToUInt(1).Should().Be(1);
        }

        [Fact]
        public void Empty_string()
        {
            "".ToUInt().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_not_numeric()
        {
            "a".ToUInt().Should().Be(0);
        }

        [Fact]
        public void Not_empty_string_is_numeric()
        {
            "2".ToUInt().Should().Be(2);
        }

        [Fact]
        public void Char_not_numeric()
        {
            'a'.ToUInt().Should().Be(0x61);
        }

        [Fact]
        public void Char_is_numeric()
        {
            '1'.ToUInt().Should().Be(0x31);
        }

        [Fact]
        public void Byte()
        {
            byte b = byte.MaxValue;
            b.ToUInt().Should().Be(255);
        }
        
        [Fact]
        public void Short()
        {
            short s = short.MaxValue;
            s.ToUInt().Should().Be(32767);
        }
        
        [Fact]
        public void INt()
        {
            int i = int.MaxValue;
            i.ToUInt().Should().Be(2_147_483_647);
        }

        [Fact]
        public void Long_more_than_uint_size()
        {
            long i = long.MaxValue;
            Func<uint> action = () => i.ToUInt();

            action.Should()
                  .Throw<OverflowException>()
                  .And
                  .Message.Should()
                  .Be("Value was either too large or too small for a UInt32.");
        }

        [Fact]
        public void Long()
        {
            long l = 9;
            l.ToUInt().Should().Be(9);
        }

        [Fact]
        public void Double()
        {
            double d = 8.1;
            d.ToUInt().Should().Be(8);
        }

        [Fact]
        public void Float()
        {
            float f = 7.1f;
            f.ToUInt().Should().Be(7);
        }
    }
}