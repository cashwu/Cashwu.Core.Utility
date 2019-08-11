using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests
{
    public class EnumerationTests
    {
        [Fact]
        public void Value()
        {
            TestEnum.One.Value.Should().Be(1);
            TestEnum.Two.Value.Should().Be(2);
        }

        [Fact]
        public void Name()
        {
            TestEnum.One.DisplayName.Should().Be("one");
            TestEnum.Two.DisplayName.Should().Be("two");
        }

        [Fact]
        public void GetAll()
        {
            var exptected = new List<TestEnum>
            {
                new TestEnum(1, "one"),
                new TestEnum(2, "two"),
            };
            TestEnum.GetAll().Should().Equal(exptected);
        }

        [Fact]
        public void FromValue()
        {
            TestEnum.FromValue(1).Should().Be(new TestEnum(1, "one"));
            TestEnum.FromValue(2).Should().Be(new TestEnum(2, "two"));
            TestEnum.FromValue(3).Should().BeNull();
        }

        [Fact]
        public void FromDisplayName()
        {
            TestEnum.FromDisplayName("one").Should().Be(new TestEnum(1, "one"));
            TestEnum.FromDisplayName("two").Should().Be(new TestEnum(2, "two"));
            TestEnum.FromDisplayName("three").Should().BeNull();
        }

        [Fact]
        public void CompareTo()
        {
            TestEnum.One.CompareTo(TestEnum.One).Should().Be(0);
            TestEnum.One.CompareTo(new TestEnum(1, "one")).Should().Be(0);
            
            TestEnum.One.CompareTo(TestEnum.Two).Should().Be(-1);
            TestEnum.One.CompareTo(new TestEnum(2, "two")).Should().Be(-1);
            
            TestEnum.Two.CompareTo(TestEnum.One).Should().Be(1);
            TestEnum.Two.CompareTo(new TestEnum(1, "one")).Should().Be(1);
        }

        [Fact]
        public void ObjectToString()
        {
            TestEnum.One.ToString().Should().Be("one");
            TestEnum.Two.ToString().Should().Be("two");
        }

        [Fact]
        public void ObjectEqual()
        {
            TestEnum.One.Equals(new TestEnum(1, "one")).Should().BeTrue();
            // ReSharper disable once EqualExpressionComparison
            TestEnum.One.Equals(TestEnum.One).Should().BeTrue();

            TestEnum.One.Equals(new TestEnum(2, "two")).Should().BeFalse();
            TestEnum.One.Equals(TestEnum.Two).Should().BeFalse();

            TestEnum.One.Equals(new object()).Should().BeFalse();
        }
        
        [Fact]
        public void ObjectGetHashCode()
        {
            TestEnum.One.GetHashCode().Should().NotBe(0);
            TestEnum.One.GetHashCode().Should().NotBe(TestEnum.Two.GetHashCode());

            TestEnum.One.GetHashCode().Should().Be(new TestEnum(1, "one").GetHashCode());
            TestEnum.One.GetHashCode().Should().Be(new TestEnum(1, "two").GetHashCode());
            TestEnum.One.GetHashCode().Should().NotBe(new TestEnum(2, "one").GetHashCode());
        }
    }

    public class TestEnum : Enumeration<TestEnum>
    {
        public static readonly TestEnum One = new TestEnum(1, "one");
        public static readonly TestEnum Two = new TestEnum(2, "two");

        public TestEnum(int value, string displayName)
                : base(value, displayName)
        {
        }
    }
}