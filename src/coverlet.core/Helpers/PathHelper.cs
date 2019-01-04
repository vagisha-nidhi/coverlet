// Code in this file is attributed to the CoreFX repo
// See: https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/IO/Path.cs

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Coverlet.Core.Helpers
{
    internal static class PathHelper
    {
        internal static bool IsDirectorySeparator(char separator)
        {
            char directorySeparator = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? '\\' : '/';
            char altDirectorySeparator = '/';

            return separator == directorySeparator || separator == altDirectorySeparator;
        }

        /// <summary>
        /// Get the common path length from the start of the string.
        /// </summary>
        internal static int GetCommonPathLength(string first, string second, bool ignoreCase)
        {
            int commonChars = EqualStartingCharacterCount(first, second, ignoreCase: ignoreCase);

            // If nothing matches
            if (commonChars == 0)
                return commonChars;

            // Or we're a full string and equal length or match to a separator
            if (commonChars == first.Length
                && (commonChars == second.Length || IsDirectorySeparator(second[commonChars])))
                return commonChars;

            if (commonChars == second.Length && IsDirectorySeparator(first[commonChars]))
                return commonChars;

            // It's possible we matched somewhere in the middle of a segment e.g. C:\Foodie and C:\Foobar.
            while (commonChars > 0 && !IsDirectorySeparator(first[commonChars - 1]))
                commonChars--;

            return commonChars;
        }

        /// <summary>
        /// Gets the count of common characters from the left optionally ignoring case
        /// </summary>
        internal static unsafe int EqualStartingCharacterCount(string first, string second, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second)) return 0;

            int commonChars = 0;

            fixed (char* f = first)
            fixed (char* s = second)
            {
                char* l = f;
                char* r = s;
                char* leftEnd = l + first.Length;
                char* rightEnd = r + second.Length;

                while (l != leftEnd && r != rightEnd
                    && (*l == *r || (ignoreCase && char.ToUpperInvariant((*l)) == char.ToUpperInvariant((*r)))))
                {
                    commonChars++;
                    l++;
                    r++;
                }
            }

            return commonChars;
        }

        internal static string GetRelativePath(string relativeTo, string path)
        {
            if (string.IsNullOrEmpty(relativeTo)) throw new ArgumentNullException(nameof(relativeTo));
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            relativeTo = Path.GetFullPath(relativeTo);
            path = Path.GetFullPath(path);

            StringComparison comparisonType = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            // Need to check if the roots are different- if they are we need to return the "to" path.
            if (!string.Equals(relativeTo.Substring(0, 1), path.Substring(0, 1), comparisonType))
                return path;

            int commonLength = GetCommonPathLength(relativeTo, path, ignoreCase: comparisonType == StringComparison.OrdinalIgnoreCase);

            // If there is nothing in common they can't share the same root, return the "to" path as is.
            if (commonLength == 0)
                return path;

            // Trailing separators aren't significant for comparison
            int relativeToLength = relativeTo.Length;
            if (IsDirectorySeparator(relativeTo[relativeToLength - 1]))
                relativeToLength--;

            int pathLength = path.Length;
            bool pathEndsInSeparator = IsDirectorySeparator(path[pathLength - 1]);
            if (pathEndsInSeparator)
                pathLength--;

            // If we have effectively the same path, return "."
            if (relativeToLength == pathLength && commonLength >= relativeToLength) return ".";

            // We have the same root, we need to calculate the difference now using the
            // common Length and Segment count past the length.
            //
            // Some examples:
            //
            //  C:\Foo C:\Bar L3, S1 -> ..\Bar
            //  C:\Foo C:\Foo\Bar L6, S0 -> Bar
            //  C:\Foo\Bar C:\Bar\Bar L3, S2 -> ..\..\Bar\Bar
            //  C:\Foo\Foo C:\Foo\Bar L7, S1 -> ..\Bar

            StringBuilder sb = new StringBuilder(Math.Max(relativeTo.Length, path.Length));

            // Add parent segments for segments past the common on the "from" path
            if (commonLength < relativeToLength)
            {
                sb.Append("..");

                for (int i = commonLength + 1; i < relativeToLength; i++)
                {
                    if (IsDirectorySeparator(relativeTo[i]))
                    {
                        sb.Append(Path.DirectorySeparatorChar);
                        sb.Append("..");
                    }
                }
            }
            else if (IsDirectorySeparator(path[commonLength]))
            {
                // No parent segments and we need to eat the initial separator
                //  (C:\Foo C:\Foo\Bar case)
                commonLength++;
            }

            // Now add the rest of the "to" path, adding back the trailing separator
            int differenceLength = pathLength - commonLength;
            if (pathEndsInSeparator)
                differenceLength++;

            if (differenceLength > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(Path.DirectorySeparatorChar);
                }

                sb.Append(path, commonLength, differenceLength);
            }

            return sb.ToString();
        }
    }
}