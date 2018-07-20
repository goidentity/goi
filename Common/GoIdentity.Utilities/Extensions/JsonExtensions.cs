using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace GoIdentity.Utilities.Extensions
{
    public static class JsonExtensions
    {
        public static string GetFieldFromJson(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? null : parmObject[fieldName].ToString();
        }

        public static string GetDocNo(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? null : ((string)parmObject[fieldName].ToString());
        }

        public static DateTime GetDateTime(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(DateTime) : DateTime.Parse(parmObject[fieldName].ToString());
        }

        public static DateTime? TryDateTime(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(DateTime?) : DateTime.Parse(parmObject[fieldName].ToString());
        }

        public static Guid? TryGuid(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(Guid?) : Guid.Parse(parmObject[fieldName].ToString());
        }

        public static int? TryInt(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(int?) : int.Parse(parmObject[fieldName].ToString());
        }

        public static long? TryLong(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(long?) : long.Parse(parmObject[fieldName].ToString());
        }

        public static bool? TryBool(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(bool?) : bool.Parse(parmObject[fieldName].ToString());
        }

        public static int GetInt(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(int) : int.Parse(parmObject[fieldName].ToString());
        }

        public static long GetLong(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(long) : long.Parse(parmObject[fieldName].ToString());
        }

        public static decimal GetDecimal(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(decimal) : decimal.Parse(parmObject[fieldName].ToString());
        }

        public static decimal? TryDecimal(this string jsonFeed, string fieldName)
        {
            var parmObject = JsonConvert.DeserializeObject<dynamic>(jsonFeed);
            return parmObject[fieldName] == null ? default(decimal?) : decimal.Parse(parmObject[fieldName].ToString());
        }

        public static string ConcatenateRefFields(this string jsonFeed, string IS_Ref_UniqueId, string IS_Ref_LinkId = "", string IS_Ref_ArApId = "")
        {
            var parmObject = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonFeed);
            parmObject.Add("IS_Ref_UniqueId", IS_Ref_UniqueId);
            parmObject.Add("IS_Ref_LinkId", IS_Ref_LinkId);
            parmObject.Add("IS_Ref_ArApId", IS_Ref_ArApId);

            return SerializationHelper.Serialize<Newtonsoft.Json.Linq.JObject>(parmObject);
        }


        public static Newtonsoft.Json.Linq.JObject RemovePhyscialFields(this Newtonsoft.Json.Linq.JObject jsonObject, DataTable fieldsTable)
        {
            var fields = new List<string>();
            foreach (DataColumn col in fieldsTable.Columns) fields.Add(col.ColumnName);

            foreach (var field in fields)
            {
                if (jsonObject[field] != null) jsonObject.Property(field).Remove();
            }
            return jsonObject;
        }

    }
}
