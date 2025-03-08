using System;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
	public static T GetAttribute<T>(this Enum value) where T : Attribute
	{
		Type type = value.GetType();
		MemberInfo[] memberInfo = type.GetMember(value.ToString());
		object[] attributes = memberInfo[0].GetCustomAttributes(typeof(T), inherit: false);
		return (attributes.Length != 0) ? ((T)attributes[0]) : null;
	}

	public static string DescriptionToString(this Enum value)
	{
		DescriptionAttribute attribute = value.GetAttribute<DescriptionAttribute>();
		return (attribute == null) ? value.ToString() : attribute.Description;
	}

	public static string CategoryToString(this Enum value)
	{
		CategoryAttribute attribute = value.GetAttribute<CategoryAttribute>();
		return (attribute == null) ? value.ToString() : attribute.Category;
	}
}
