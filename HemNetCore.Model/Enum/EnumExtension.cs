using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace HemNetCore.Model.Enum
{
    /// <summary>
    /// 枚举属性扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举中Description
        /// </summary>
        /// <param name="enumname"></param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum enumname)
        {
            var descriotin = string.Empty;
            var infofield = enumname.GetType().GetField(enumname.ToString());
            var attributes = infofield != null ? (DescriptionAttribute[])infofield.GetCustomAttributes(typeof(DescriptionAttribute), false) : null;
            return attributes != null ? attributes[0].Description : enumname.ToString();
        }

       
        /// <summary>
        /// 获取枚举名以及对应的Description
        /// </summary>
        /// <param name="type">枚举类型typeof(T)</param>
        /// <returns>返回Dictionary  ,Key为枚举名，  Value为枚举对应的Description</returns>
        public static Dictionary<object, object> GetNameAndDescriptions(this Type type)
        {
            if (type.IsEnum)
            {
                var dic = new Dictionary<object, object>();
                var enumValues = System.Enum.GetValues(type);
                foreach (System.Enum value in enumValues)
                {
                    dic.Add(value, GetDescription(value));
                }
                return dic;
            }
            return null;
        }

        /// <summary>
        /// 获取枚举名以及对应的Value
        /// </summary>
        /// <param name="type">枚举类型typeof(T)</param>
        /// <returns>返回Dictionary  ,Key为描述名，  Value为枚举对应的值</returns>
        public static Dictionary<object, object> GetNameAndValue(this Type type)
        {
            if (type.IsEnum)
            {
                var dic = new Dictionary<object, object>();
                var enumValues = System.Enum.GetValues(type);
                foreach (System.Enum value in enumValues)
                {
                    dic.Add(GetDescription(value), value.GetHashCode());
                }
                return dic;
            }
            return null;
        }
    }
}
