using System;

public class EnumDescription
{
    public static string GetDescription(Enum en)
    {
        Type type = en.GetType();
        System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
            }
        }

        return en.ToString();
    }
}