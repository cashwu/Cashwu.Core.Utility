using System.Collections.Generic;
using Cashwu.Core.Utility.Extension;
using FluentAssertions;
using Xunit;

namespace Cashwu.Core.Utility.Tests.Extension
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Empty_string_to_SplitToList()
        {
            string.Empty.SplitToList().Should().BeEquivalentTo(new List<string>());
        }

        [Fact]
        public void Not_empty_string_to_SplitToList_default_separator()
        {
            var expected = new List<string>
            {
                "a", "b", "c"
            };
            "a,b,c,".SplitToList().Should().Equal(expected);
        }
        
        [Fact]
        public void Not_empty_string_to_SplitToList_not_default_separator()
        {
            var expected = new List<string>
            {
                "a", "b", "c"
            };
            "a.b.c.".SplitToList('.').Should().Equal(expected);
        }

        [Fact]
        public void Not_sam_case_same_char_equals_ignore_case()
        {
            "a".EqualsIgnoreCase("A").Should().BeTrue();
        } 
        
        [Fact]
        public void Same_case_same_char_equals_ignore_case()
        {
            "a".EqualsIgnoreCase("a").Should().BeTrue();
        } 
        
        [Fact]
        public void Not_same_case_not_same_char_equals_ignore_case()
        {
            "a".EqualsIgnoreCase("B").Should().BeFalse();
        } 
        [Fact]
        public void Same_case_not_same_char_equals_ignore_case()
        {
            "a".EqualsIgnoreCase("b").Should().BeFalse();
        } 
    }
}