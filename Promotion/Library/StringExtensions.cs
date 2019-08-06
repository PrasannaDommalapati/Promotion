using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Promotion.Library
{
    public static class StringExtensions
    {
        public static string ValidateNotEmpty(this string value, string nameOf = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameOf);
            }
            return value;
        }

        public static string CombineUri(
            this string uri,
            string relativeUri)
        {
            relativeUri.ValidateNotEmpty();

            uri = uri.Replace("/", "\\").Trim(new[] { '\\' });
            relativeUri = relativeUri.Replace("/", "\\").Trim(new[] { '\\' });

            return Path.Combine(uri, relativeUri).Replace("\\", "/").TrimEnd(new[] { '/' });
        }

        public static string CombineUri(
           this string uri,
           params string[] relativeUris)
        {
            var forwardSlash = new[] { '/' };

            var uris = relativeUris.Select(u => u.TrimStart(forwardSlash)).ToArray();
            var result = uri.Replace("/", "\\").Trim(new[] { '\\' });
            result = Path.Combine(result, Path.Combine(uris));
            return result.Replace("\\", "/").TrimEnd(forwardSlash);
        }

        public static string SplitCamelCase(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            str = str.Replace(" ", "");
            return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        public static string ToTitleCase(this string str)
        {
            if (str == null)
            {
                throw new System.ArgumentNullException(nameof(str));
            }

            return CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(str);
        }
    }
}
