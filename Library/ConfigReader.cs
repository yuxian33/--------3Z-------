using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    public static class ConfigReader
    {
        private static readonly Regex HeaderRegex = new Regex("^\\[(?<Header>.+)\\]$", RegexOptions.Compiled);
        private static readonly Regex EntryRegex = new Regex("^(?<Key>.*?)=(?<Value>.*)$", RegexOptions.Compiled);
        private static readonly Regex ColorRegex = new Regex("\\[A:\\s?(?<A>[0-9]{1,3}),\\s?R:\\s?(?<R>[0-9]{1,3}),\\s?G:\\s?(?<G>[0-9]{1,3}),\\s?B:\\s?(?<B>[0-9]{1,3})\\]", RegexOptions.Compiled);
        private static readonly Regex MagicRegex = new Regex("\\[N:\\s?(?<N>[A-Za-z0-9\\u4e00-\\u9fa5]{0,16}),\\s?T:\\s?(?<T>[0-9]{1,3}),\\s?K:\\s?(?<K>[0-9]{1,3}),\\s?P:\\s?(?<P>[0-9]{1,3}),\\s?M:\\s?(?<M>[0-9]{1,3}),\\s?A:\\s?(?<A>[0-9-]{1,3})\\]", RegexOptions.Compiled);
        public static readonly Dictionary<Type, object> ConfigObjects = new Dictionary<Type, object>();
        private static readonly Dictionary<Type, Dictionary<string, Dictionary<string, string>>> ConfigContents = new Dictionary<Type, Dictionary<string, Dictionary<string, string>>>();

        public static void Load()
        {
            Type[] types = Assembly.GetEntryAssembly().GetTypes();

            foreach (Type type in types)
            {
                ConfigPath config = type.GetCustomAttribute<ConfigPath>();

                if (config == null) continue;

                object ob = null;
                if (!type.IsAbstract || !type.IsSealed)
                    ConfigObjects[type] = ob = Activator.CreateInstance(type);

                ReadConfig(type, config.Path, ob);
            }
        }

        public static void Save()
        {
            Type[] types = Assembly.GetEntryAssembly().GetTypes();

            foreach (Type type in types)
            {

                ConfigPath config = type.GetCustomAttribute<ConfigPath>();

                if (config == null) continue;

                object ob = null;

                if (!type.IsAbstract || !type.IsSealed)
                    ob = ConfigObjects[type];

                SaveConfig(type, config.Path, ob);
            }
        }

        private static void ReadConfig(Type type, string path, object ob)
        {
            if (!File.Exists(path))
                return;
            PropertyInfo[] properties = type.GetProperties();
            Dictionary<string, Dictionary<string, string>> dictionary1 = ConfigReader.ConfigContents[type] = new Dictionary<string, Dictionary<string, string>>();
            string[] strArray = File.ReadAllLines(path);
            Dictionary<string, string> dictionary2 = (Dictionary<string, string>)null;
            foreach (string input in strArray)
            {
                Match match1 = ConfigReader.HeaderRegex.Match(input);
                if (match1.Success)
                {
                    dictionary2 = new Dictionary<string, string>();
                    dictionary1[match1.Groups["Header"].Value] = dictionary2;
                }
                else if (dictionary2 != null)
                {
                    Match match2 = ConfigReader.EntryRegex.Match(input);
                    if (match2.Success)
                        dictionary2[match2.Groups["Key"].Value] = match2.Groups["Value"].Value;
                }
            }
            string str = (string)null;
            foreach (PropertyInfo element in properties)
            {
                ConfigSection customAttribute = element.GetCustomAttribute<ConfigSection>();
                if (customAttribute != null)
                    str = customAttribute.Section;
                if (str != null)
                {
                    MethodInfo method = typeof(ConfigReader).GetMethod("Read", new Type[4] { typeof(Type), typeof(string), typeof(string), element.PropertyType });
                    element.SetValue(ob, method.Invoke((object)null, new object[4]
                    {
            (object) type,
            (object) str,
            (object) element.Name,
            element.GetValue(ob)
                    }));
                }
            }
        }

        private static void SaveConfig(Type type, string path, object ob)
        {
            PropertyInfo[] properties = type.GetProperties();
            Dictionary<string, Dictionary<string, string>> dictionary = ConfigReader.ConfigContents[type] = new Dictionary<string, Dictionary<string, string>>();
            string str = (string)null;
            foreach (PropertyInfo element in properties)
            {
                ConfigSection customAttribute = element.GetCustomAttribute<ConfigSection>();
                if (customAttribute != null)
                    str = customAttribute.Section;
                if (str != null)
                    typeof(ConfigReader).GetMethod("Write", new Type[4]
                    {
            typeof (Type),
            typeof (string),
            typeof (string),
            element.PropertyType
                    }).Invoke(ob, new object[4]
                    {
            (object) type,
            (object) str,
            (object) element.Name,
            element.GetValue(ob)
                    });
            }
            List<string> stringList = new List<string>();
            foreach (KeyValuePair<string, Dictionary<string, string>> keyValuePair1 in dictionary)
            {
                stringList.Add("[" + keyValuePair1.Key + "]");
                foreach (KeyValuePair<string, string> keyValuePair2 in keyValuePair1.Value)
                    stringList.Add(keyValuePair2.Key + "=" + keyValuePair2.Value);
                stringList.Add(string.Empty);
            }
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllLines(path, (IEnumerable<string>)stringList, Encoding.Unicode);
        }

        private static bool TryGetEntry(Type type, string section, string key, out string value)
        {
            value = (string)null;
            Dictionary<string, Dictionary<string, string>> dictionary1;
            if (!ConfigReader.ConfigContents.TryGetValue(type, out dictionary1))
                ConfigReader.ConfigContents[type] = dictionary1 = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> dictionary2;
            if (dictionary1.TryGetValue(section, out dictionary2))
                return dictionary2.TryGetValue(key, out value);
            Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
            dictionary1[section] = dictionary3;
            return false;
        }

        public static bool Read(Type type, string section, string key, bool value)
        {
            string str;
            bool result;
            if (ConfigReader.TryGetEntry(type, section, key, out str) && bool.TryParse(str, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static byte Read(Type type, string section, string key, byte value)
        {
            string s;
            byte result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && byte.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static short Read(Type type, string section, string key, short value)
        {
            string s;
            short result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && short.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static int Read(Type type, string section, string key, int value)
        {
            string s;
            int result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && int.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static long Read(Type type, string section, string key, long value)
        {
            string s;
            long result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && long.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static sbyte Read(Type type, string section, string key, sbyte value)
        {
            string s;
            sbyte result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && sbyte.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static ushort Read(Type type, string section, string key, ushort value)
        {
            string s;
            ushort result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && ushort.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static uint Read(Type type, string section, string key, uint value)
        {
            string s;
            uint result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && uint.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static ulong Read(Type type, string section, string key, ulong value)
        {
            string s;
            ulong result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && ulong.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static float Read(Type type, string section, string key, float value)
        {
            string s;
            float result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && float.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            return value;
        }

        public static double Read(Type type, string section, string key, double value)
        {
            string s;
            double result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && double.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            return value;
        }

        public static Decimal Read(Type type, string section, string key, Decimal value)
        {
            string s;
            Decimal result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && Decimal.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            return value;
        }

        public static char Read(Type type, string section, string key, char value)
        {
            string s;
            char result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && char.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static string Read(Type type, string section, string key, string value)
        {
            string str;
            if (ConfigReader.TryGetEntry(type, section, key, out str))
                return str;
            ConfigReader.ConfigContents[type][section][key] = value;
            return value;
        }

        public static Point Read(Type type, string section, string key, Point value)
        {
            string str;
            if (ConfigReader.TryGetEntry(type, section, key, out str))
            {
                string[] strArray = str.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int result1;
                int result2;
                if (strArray.Length == 2 && int.TryParse(strArray[0], out result1) && int.TryParse(strArray[1], out result2))
                    return new Point(result1, result2);
            }
            ConfigReader.ConfigContents[type][section][key] = string.Format("{0}, {1}", (object)value.X, (object)value.Y);
            return value;
        }

        public static Size Read(Type type, string section, string key, Size value)
        {
            string str;
            if (ConfigReader.TryGetEntry(type, section, key, out str))
            {
                string[] strArray = str.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int result1;
                int result2;
                if (strArray.Length == 2 && int.TryParse(strArray[0], out result1) && int.TryParse(strArray[1], out result2))
                    return new Size(result1, result2);
            }
            ConfigReader.ConfigContents[type][section][key] = string.Format("{0}, {1}", (object)value.Width, (object)value.Height);
            return value;
        }

        public static SizeF Read(Type type, string section, string key, SizeF value)
        {
            string str;
            if (ConfigReader.TryGetEntry(type, section, key, out str))
            {
                string[] strArray = str.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                float result1;
                float result2;
                if (strArray.Length == 2 && float.TryParse(strArray[0], out result1) && float.TryParse(strArray[1], out result2))
                    return new SizeF(result1, result2);
            }
            ConfigReader.ConfigContents[type][section][key] = string.Format("{0}, {1}", (object)value.Width, (object)value.Height);
            return value;
        }

        public static TimeSpan Read(Type type, string section, string key, TimeSpan value)
        {
            string s;
            TimeSpan result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && TimeSpan.TryParse(s, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static DateTime Read(Type type, string section, string key, DateTime value)
        {
            string s;
            DateTime result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && DateTime.TryParse(s, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                return result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            return value;
        }

        public static Color Read(Type type, string section, string key, Color value)
        {
            string input;
            if (ConfigReader.TryGetEntry(type, section, key, out input))
            {
                Match match = ConfigReader.ColorRegex.Match(input);
                if (match.Success)
                    return Color.FromArgb(Math.Min((int)byte.MaxValue, Math.Max(0, int.Parse(match.Groups["A"].Value))), Math.Min((int)byte.MaxValue, Math.Max(0, int.Parse(match.Groups["R"].Value))), Math.Min((int)byte.MaxValue, Math.Max(0, int.Parse(match.Groups["G"].Value))), Math.Min((int)byte.MaxValue, Math.Max(0, int.Parse(match.Groups["B"].Value))));
            }
            ConfigReader.ConfigContents[type][section][key] = string.Format("[A:{0}, R:{1}, G:{2}, B:{3}]", new object[4]
            {
        (object) value.A,
        (object) value.R,
        (object) value.G,
        (object) value.B
            });
            return value;
        }

        public static MagicType Read(Type type, string section, string key, MagicType value)
        {
            string s;
            ushort result;
            if (ConfigReader.TryGetEntry(type, section, key, out s) && ushort.TryParse(s, out result))
                return (MagicType)result;
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static List<MagicHelper> Read(Type type, string section, string key, List<MagicHelper> value)
        {
            string str;
            if (ConfigReader.TryGetEntry(type, section, key, out str))
            {
                char[] separator = new char[1] { '|' };
                List<MagicHelper> magicHelperList = new List<MagicHelper>();
                foreach (string input in str.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                {
                    MagicHelper magicHelper = new MagicHelper();
                    Match match = ConfigReader.MagicRegex.Match(input);
                    if (match.Success)
                    {
                        magicHelper.Name = match.Groups[78].Value;
                        magicHelper.TypeID = (MagicType)int.Parse(match.Groups["T"].Value);
                        magicHelper.Key = (SpellKey)int.Parse(match.Groups["K"].Value);
                        magicHelper.LockPlayer = int.Parse(match.Groups["P"].Value) > 0;
                        magicHelper.LockMonster = int.Parse(match.Groups["M"].Value) > 0;
                        magicHelper.Amulet = int.Parse(match.Groups["A"].Value);
                        magicHelperList.Add(magicHelper);
                    }
                }
                return magicHelperList;
            }
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static List<string> Read(Type type, string section, string key, List<string> value)
        {
            string str1;
            if (ConfigReader.TryGetEntry(type, section, key, out str1))
            {
                string[] separator = new string[1] { "\\r\\n" };
                List<string> stringList = new List<string>();
                foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                {
                    string str3 = str2.Replace("\\\\", "\\");
                    stringList.Add(str3);
                }
                return stringList;
            }
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
            return value;
        }

        public static void Write(Type type, string section, string key, bool value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, byte value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, short value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, int value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, long value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, sbyte value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, ushort value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, uint value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, ulong value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, float value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
        }

        public static void Write(Type type, string section, string key, double value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
        }

        public static void Write(Type type, string section, string key, Decimal value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
        }

        public static void Write(Type type, string section, string key, char value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, string value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value;
        }

        public static void Write(Type type, string section, string key, Point value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = string.Format("{0}, {1}", (object)value.X, (object)value.Y);
        }

        public static void Write(Type type, string section, string key, Size value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = string.Format("{0}, {1}", (object)value.Width, (object)value.Height);
        }

        public static void Write(Type type, string section, string key, TimeSpan value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString();
        }

        public static void Write(Type type, string section, string key, DateTime value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = value.ToString((IFormatProvider)CultureInfo.InvariantCulture);
        }

        public static void Write(Type type, string section, string key, Color value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = string.Format("[A:{0}, R:{1}, G:{2}, B:{3}]", new object[4]
            {
        (object) value.A,
        (object) value.R,
        (object) value.G,
        (object) value.B
            });
        }

        public static void Write(Type type, string section, string key, MagicType value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            ConfigReader.ConfigContents[type][section][key] = ((ushort)value).ToString();
        }

        public static void Write(Type type, string section, string key, List<MagicHelper> value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            string str = (string)null;
            for (int index = 0; index < value.Count; ++index)
                str = (str == null ? "" : str + "|") + string.Format("[N:{0},T:{1},K:{2},P:{3},M:{4},A:{5}]", (object)value[index].Name, (object)(int)value[index].TypeID, (object)(int)value[index].Key, (object)(value[index].LockPlayer ? 1 : 0), (object)(value[index].LockMonster ? 1 : 0), (object)value[index].Amulet);
            ConfigReader.ConfigContents[type][section][key] = str;
        }
        
        public static void Write(Type type, string section, string key, List<string> value)
        {
            if (!ConfigReader.ConfigContents[type].ContainsKey(section))
                ConfigReader.ConfigContents[type][section] = new Dictionary<string, string>();
            string str = (string)null;
            for (int index = 0; index < value.Count; ++index)
            {
                if (value[index] != null && value[index].Length != 0)
                    str = (str == null ? "" : str + "\\r\\n") + value[index].Replace("\\", "\\\\");
            }
            if (str == null)
                str = "";
            ConfigReader.ConfigContents[type][section][key] = str;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigPath : Attribute
    {
        public string Path { get; set; }

        public ConfigPath(string path)
        {
            this.Path = path;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigSection : Attribute
    {
        public string Section { get; set; }

        public ConfigSection(string section)
        {
            this.Section = section;
        }
    }
}
