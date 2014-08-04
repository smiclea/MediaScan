using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Media_Scan.model
{
    class Config
    {
        static public string configTxt;

        static public void ReadConfig()
        {
            configTxt = File.ReadAllText(@"scan.config");
        }

        static public string GetScanDirPath(bool skipTrim = false)
        {
            string result = @"";
            result = ReadConfigProp(@"path", skipTrim);

            return result;
        }

        public static void SavePath(string path)
        {
            configTxt = configTxt.Replace(GetScanDirPath(true), path);
            File.WriteAllText(@"scan.config", configTxt);
        }

        public static string GetMovie(bool skipTrim = false)
        {
            string result = @"";
            result = ReadConfigProp(@"movie", skipTrim);

            return result;
        }

        private static string ReadConfigProp(string prop, bool skipTrim = false)
        {
            string result = @"";
            Regex pathEx = new Regex(@"\$" + prop + "=(.*)");
            Match match = pathEx.Match(configTxt);

            result = match.Groups[1].Value;

            if (!skipTrim)
            {
                result = result.Trim();
            }

            return result;
        }

        public static int GetSeasonForMovie(string movie)
        {
            int result = -1;
            Regex exp = new Regex(@"#" + movie + @"\|S(\d{1,})");
            Match match = exp.Match(configTxt);

            if (exp.IsMatch(configTxt))
            {
                result = int.Parse(match.Groups[1].Value);
            }

            return result;
        }

        public static int GetEpisode(string movie, string season)
        {
            int result = -1;
            Regex exp = new Regex(@"#" + movie +  @"\|S" + season + @"\|E(\d{1,})");
            Match match = exp.Match(configTxt);

            if (exp.IsMatch(configTxt))
            {
                result = int.Parse(match.Groups[1].Value);
            }

            return result;
        }

        public static int GetSelectedMinute(string movie, string season, string episode)
        {
            int result = 0;
            Regex exp = new Regex(@"#" + movie + @"\|S" + season + @"\|E" + episode + @"\|M(\d{1,})");
            Match match = exp.Match(configTxt);

            if (exp.IsMatch(configTxt))
            {
                result = int.Parse(match.Groups[1].Value);
            }

            return result;
        }
    }
}
