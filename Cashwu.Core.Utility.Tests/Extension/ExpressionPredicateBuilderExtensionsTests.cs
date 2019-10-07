using System;
using System.Linq;
using System.Linq.Expressions;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class ExpressionPredicateBuilderExtensionsTests
    {
        [Fact]
        public void AndTest()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Expression<Func<int, bool>> predicate = a => a >= 5;
            predicate = predicate.And(a => a <= 8);

            var result = data.Where(predicate.Compile());

            result.Should().BeEquivalentTo(new[] { 5, 6, 7, 8 });
        }

        [Fact]
        public void OrTest()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Expression<Func<int, bool>> predicate = a => a < 5;
            predicate = predicate.Or(a => a > 8);

            var result = data.Where(predicate.Compile());

            result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 9, 10 });
        }
    }
}