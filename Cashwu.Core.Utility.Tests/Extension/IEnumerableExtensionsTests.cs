using System.Collections.Generic;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void Null_list_to_join_string()
        {
            ((List<int>)null).ToJoinString(",").Should().Be("");
        }

        [Fact]
        public void Empty_list_to_join_string()
        {
            new List<int>().ToJoinString(",").Should().Be("");
        }

        [Fact]
        public void List_to_join_string()
        {
            new List<int> { 1, 2, 3 }.ToJoinString(",").Should().Be("1,2,3");
        }

        [Fact]
        public void Array_to_join_string()
        {
            new[] { 1, 2, 3 }.ToJoinString(",").Should().Be("1,2,3");
        }

        [Fact]
        public void Null_collection_count_or_default()
        {
            ((List<string>)null).CountOrDefault().Should().Be(0);
        }

        [Fact]
        public void Empty_collection_count_or_default()
        {
            new List<string>().CountOrDefault().Should().Be(0);
        }

        [Fact]
        public void Not_empty_collection_count_or_default()
        {
            new List<int> { 1, 2, 3 }.CountOrDefault().Should().Be(3);
        }

        [Fact]
        public void Null_collection_count_or_default_have_predicate()
        {
            ((List<int>)null).CountOrDefault(a => a > 4).Should().Be(0);
        }

        [Fact]
        public void Empty_collection_count_or_default_have_predicate()
        {
            new List<int>().CountOrDefault(a => a > 4).Should().Be(0);
        }

        [Fact]
        public void Not_empty_collection_count_or_default_have_predicate()
        {
            new List<int> { 1, 2, 3 }.CountOrDefault(a => a > 4).Should().Be(0);
        }

        [Fact]
        public void Null_collection_any_item()
        {
            ((List<int>)null).AnyItem().Should().BeFalse();
        }

        [Fact]
        public void Empty_collection_any_item()
        {
            new List<int>().AnyItem().Should().BeFalse();
        }

        [Fact]
        public void Not_empty_collection_any_item()
        {
            new List<int> { 1, 2, 3 }.AnyItem().Should().BeTrue();
        }
        
        [Fact]
        public void Null_collection_any_item_and_predicate()
        {
            ((List<int>)null).AnyItem(a => a > 4).Should().BeFalse();
        }
        
        [Fact]
        public void Empty_collection_any_item_and_predicate()
        {
            new List<int>().AnyItem(a => a > 4).Should().BeFalse();
        }

        [Fact]
        public void Not_empty_collection_any_item_and_predicate()
        {
            new List<int> { 1, 2, 3 }.AnyItem(a => a > 4).Should().BeFalse();
        }
    }
}