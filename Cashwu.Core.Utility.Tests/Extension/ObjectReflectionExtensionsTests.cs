using System.Collections.Generic;
using System.Linq;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ObjectReflectionExtensionsTests
    {
        [Fact]
        public void Property()
        {
            var propertyDescriptors = new Person().GetProperties();

            var expected = new List<string>
            {
                "Id", "Name"
            };

            propertyDescriptors.Select(a => a.Name).Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Char_is_not_numeric()
        {
            '2'.IsNumeric().Should().BeFalse();
        }

        [Fact]
        public void String_is_not_numeric()
        {
            "1".IsNumeric().Should().BeFalse();
        }

        [Fact]
        public void Byte_is_numeric()
        {
            byte i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void short_is_numeric()
        {
            short i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Int_is_numeric()
        {
            int i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Long_is_numeric()
        {
            long i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Sbyte_is_numeric()
        {
            sbyte i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Ushort_is_numeric()
        {
            ushort i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Uint_is_numeric()
        {
            uint i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Ulong_is_numeric()
        {
            ulong i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Decimal_is_numeric()
        {
            decimal i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void Double_is_numeric()
        {
            double i = 1;
            i.IsNumeric().Should().BeTrue();
        }

        [Fact]
        public void float_is_numeric()
        {
            float i = 1;
            i.IsNumeric().Should().BeTrue();
        }
    }

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}