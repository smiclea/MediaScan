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
        static public string ConfigTxt;

        static private string FileName = "scan.config";

        static public void BuildConfigFile()
        {
            if (File.Exists(FileName))
            {
                return;
            }

            ConfigTxt = @"$selected_movie=";
            ConfigTxt += Environment.NewLine + @"$path=";

            File.WriteAllText(FileName, ConfigTxt);
        }

        static public void ReadConfig()
        {
            BuildConfigFile();
            ConfigTxt = File.ReadAllText(FileName);
        }

        static public string GetScanDirPath(bool skipTrim = false)
        {
            string result = @"";
            result = ReadConfigProp(@"path", skipTrim);

            return result;
        }

        public static void SavePath(string path)
        {
            Regex pathEx = new Regex(@"\$path=.*");
            ConfigTxt = ConfigTxt.Replace(pathEx.Match(ConfigTxt).Groups[0].Value, @"$path=" + path);
            File.WriteAllText(FileName, ConfigTxt);
        }

        public static string GetMovie()
        {
            string result = @"";
            result = ReadConfigProp(@"selected_movie");

            return result;
        }

        private static string ReadConfigProp(string prop, bool skipTrim = false)
        {
            string result = @"";
            Regex pathEx = new Regex(@"\$" + prop + "=(.*)");
            Match match = pathEx.Match(ConfigTxt);

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
            Match match = exp.Match(ConfigTxt);

            if (exp.IsMatch(ConfigTxt))
            {
                result = int.Parse(match.Groups[1].Value);
            }

            return result;
        }

        public static int GetEpisode(string movie, string season)
        {
            int result = -1;
            Regex exp = new Regex(@"#" + movie +  @"\|S" + season + @"\|E(\d{1,})");
            Match match = exp.Match(ConfigTxt);

            if (exp.IsMatch(ConfigTxt))
            {
                result = int.Parse(match.Groups[1].Value);
            }

            return result;
        }

        public static int GetSelectedMinute(string movie, string season, string episode)
        {
            int result = 0;
            Regex exp = new Regex(@"#" + movie + @"\|S" + season + @"\|E" + episode + @"\|M(\d{1,})");
            Match match = exp.Match(ConfigTxt);

            if (exp.IsMatch(ConfigTxt))
            {
                result = int.Parse(match.Groups[1].Value);
            }

            return result;
        }

        public static void SaveMovie(string name, string season, string episode, string minute)
        {
            Regex movieInfoEx = new Regex(@"#" + name + @".*");
            Match movieInfoMatch = movieInfoEx.Match(ConfigTxt);
            string movieText = "#" + name + "|S" + season + "|E" + episode + "|M" + minute;

            if (movieInfoMatch.Groups[0].Value != "")
            {
                ConfigTxt = ConfigTxt.Replace(movieInfoMatch.Groups[0].Value, movieText);
            }
            else
            {
                ConfigTxt += Environment.NewLine + movieText;
            }

            Regex selectedMovieEx = new Regex(@"\$selected_movie=.*");
            Match selectedMovieMatch = selectedMovieEx.Match(ConfigTxt);
            ConfigTxt = ConfigTxt.Replace(selectedMovieMatch.Groups[0].Value, @"$selected_movie=" + name);
            

            File.WriteAllText(FileName, ConfigTxt);

        }
    }
}
