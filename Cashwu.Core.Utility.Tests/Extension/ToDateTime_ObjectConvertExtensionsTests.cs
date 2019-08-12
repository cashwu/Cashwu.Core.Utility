using System;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ToDateTimeObjectConvertExtensionsTests
    {
        [Fact]
        public void Null()
        {
            ((object)null).ToDateTime().Should().Be(DateTime.MinValue);
        }

        [Fact]
        public void Null_default_value()
        {
            var defaultValue = new DateTime(2019, 1, 1, 10, 10, 9);
            ((object)null).ToDateTime(defaultValue)
                          .Should()
                          .Be(defaultValue);
        }
        
        [Fact]
        public void DateTimes()
        {
            var dt = DateTime.Now;
            dt.ToDateTime().Should().Be(dt);
        }
        
        [Fact]
        public void String_datetime_format()
        {
            "2019-10-10 10:55:12".ToDateTime()
                                 .Should().Be(new DateTime(2019, 10, 10, 10, 55, 12));
        }
        
        [Fact]
        public void String_date_format()
        {
            "2019-1-1".ToDateTime().Should().Be(new DateTime(2019, 1, 1));
        }
        
        [Fact]
        public void String_not_datetime_format()
        {
            "2019".ToDateTime().Should().Be(DateTime.MinValue);
        }
    }
}