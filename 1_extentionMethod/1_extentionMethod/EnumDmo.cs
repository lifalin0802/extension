using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    class EnumDmo
    {
    }

    public class EnumDescription : Attribute
    {
        public string Text
        {
            get { return _text; }
        }
        private string _text;

        public EnumDescription(string text)
        {
            _text = text;
        }
    }

    public static class EnumExtensions
    {
        public static string ToDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());

            if (null != memInfo && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (null != attrs && attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Text;
            }

            return enumeration.ToString();
        }
    }

    public enum AssessmentAnswer
    {
        [EnumDescription("强烈的反对")]
        Strongly_Disagree = 1,

        [EnumDescription("反对")]
        Disagree = 2,
        Neutral = 3,
        Agree = 4,
        [EnumDescription("完全的同意")]
        Strongly_Agree = 5
    }
}
