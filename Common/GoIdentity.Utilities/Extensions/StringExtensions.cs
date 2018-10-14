using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;

namespace GoIdentity.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        public static List<int> ToIntList(this string input)
        {
            var result = new List<int>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var inputArray = input.Trim().Split(',');
                foreach (var item in inputArray)
                {
                    var rawValue = default(int);
                    if (int.TryParse(item, out rawValue))
                    {
                        result.Add(rawValue);
                    }
                }
            }
            return result;
        }

        public static List<short> ToShortList(this string input)
        {
            var result = new List<short>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var inputArray = input.Trim().Split(',');
                foreach (var item in inputArray)
                {
                    var rawValue = default(short);
                    if (short.TryParse(item, out rawValue))
                    {
                        result.Add(rawValue);
                    }
                }
            }
            return result;
        }

        public static List<byte> ToByteList(this string input)
        {
            var result = new List<byte>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var inputArray = input.Trim().Split(',');
                foreach (var item in inputArray)
                {
                    var rawValue = default(byte);
                    if (byte.TryParse(item, out rawValue))
                    {
                        result.Add(rawValue);
                    }
                }
            }
            return result;
        }

        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            if (oldValue == null)
                throw new ArgumentNullException("oldValue");
            if (oldValue.Length == 0)
                throw new ArgumentException("String cannot be of zero length.", "oldValue");

            StringBuilder sb = null;

            int startIndex = 0;
            int foundIndex = str.IndexOf(oldValue, comparison);
            while (foundIndex != -1)
            {
                if (sb == null)
                    sb = new StringBuilder(str.Length + (newValue != null ? Math.Max(0, 5 * (newValue.Length - oldValue.Length)) : 0));
                sb.Append(str, startIndex, foundIndex - startIndex);
                sb.Append(newValue);

                startIndex = foundIndex + oldValue.Length;
                foundIndex = str.IndexOf(oldValue, startIndex, comparison);
            }

            if (startIndex == 0)
                return str;
            sb.Append(str, startIndex, str.Length - startIndex);
            return sb.ToString();
        }

        public static string ParmFieldName(this string value, string aliasName)
        {
            int posA = value.IndexOf(aliasName + ".");
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + aliasName.Length + 1;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }

            return value.IndexOf(" ", adjustedPosA) > 0 ? value.Substring(adjustedPosA, value.IndexOf(" ", adjustedPosA)) : value.Substring(adjustedPosA);
        }

        #region Number to words
        public static String ChangeToWords(this string numb, bool isCurrency, string change)
        {
            var inputValue = double.Parse(numb);
            var parsedValueString = inputValue.ToString();
            var parts = parsedValueString.Split('.');
            long leftNum = long.Parse(parts[0]);
            long rightNum = (parts.Length > 1) ? long.Parse(parts[1]) : 0;

            var numToWordConverter = new EnglishNumberToWordsConverter();
            var words = numToWordConverter.Convert(leftNum);

            if (rightNum > 0)
            {
                words = words + " and "+ change+" " + numToWordConverter.Convert(rightNum);
            }
            else
            {
                words=words + " " + change;
            }
            return words;

            //var point = numb.IndexOf(".") > -1 ? ((numb.Substring(numb.LastIndexOf(".") + 1, 1)[0] == '0') ? "zero" : "") : "";
            //return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(numb.IndexOf(".") > -1 ?
            //         Convert.ToInt32(Math.Floor(Convert.ToDecimal(numb))).ToString(cultureInfo) +
            //         (Convert.ToInt32(numb.Substring(numb.LastIndexOf(".") + 1, 2)).ToString(cultureInfo) == "zero" ? " " : " and " + point + " " + Convert.ToInt32(numb.Substring(numb.LastIndexOf(".") + 1, 2)).ToString(cultureInfo) + " " + change)
            //         : int.Parse(numb).ToString(cultureInfo));
            //Convert.ToInt32(Math.Floor(Convert.ToDecimal(numb))).ToWords() 
            //         : int.Parse(numb).ToWords();
        }

        #endregion

        public static string GetContentType(this string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types.ContainsKey(ext) ? types[ext] : string.Empty;
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        #region Serial Number
        public static Dictionary<string, string> ToSerialDictionary(this string value)
        {
            var dictionary = new Dictionary<string, string>();

            if (value.IndexOf("[") > -1)
            {
                var queryParts = value.Split('[');
                foreach (var part in queryParts)
                {
                    if (part.IndexOf("]") > -1)
                    {
                        var expression = part.Substring(0, part.IndexOf("]"));
                        var expressionParts = expression.Split(':');
                        var query = string.Format("select cast((select top 1 {0} from {1} where {2}) as varchar(20))",
                            expressionParts[0],
                            expressionParts[1],
                            expressionParts[2]);
                        dictionary.Add(expression, query);
                    }
                }
            }

            return dictionary;
        }
        #endregion

        public static DateTime ToServerTime(this DateTime dateTime, short timezoneOffset = 0)
        {
            return dateTime.AddMinutes(timezoneOffset * -1);
        }

        public static DateTime ToServerTime(this string dateTimeValue, short timezoneOffset = 0)
        {
            if (timezoneOffset == 0) timezoneOffset = (short)TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Minutes;

            return ToServerTime(DateTime.Parse(dateTimeValue), timezoneOffset);
        }

        private static Type[] GetNumberDataColumnTypes()
        {
            return new[] { typeof(Byte), typeof(Decimal), typeof(Double),
                typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte),
                typeof(Single), typeof(UInt16), typeof(UInt32), typeof(UInt64)};
        }

    }
}
