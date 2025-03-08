using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace PatchManager
{
    [ConfigPath(@".\PatchManager.ini")]
    public static class Config
    {
        [ConfigSection("Patcher")]
        public static string CleanClient { get; set; } = @"";
        public static string Host { get; set; } = @"";
        public static bool UseLogin { get; set; } = true;
        public static string Username { get; set; } = @"REDACTED";
        public static string Password { get; set; } = @"REDACTED";
    }
}
