using System;
using System.Collections.Generic;
using System.Linq;

namespace Cashwu.Core.Utility.Extension
{
    public static class EnumerableExtensions
    {
        public static string ToJoinString<TSource>(this IEnumerable<TSource> source, string separator)
        {
            return string.Join(separator, source);
        }

        public static int CountOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source?.Count() ?? 0;
        }

        public static int CountOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source?.Count(predicate) ?? 0;
        }

        public static bool AnyItem<TSource>(this IEnumerable<TSource> source)
        {
            return source != null && source.Any();
        }

        public static bool AnyItem<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source != null && source.Any(predicate);
        }
    }
}