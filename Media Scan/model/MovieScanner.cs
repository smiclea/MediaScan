using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Media_Scan
{
    class MovieScanner
    {
        public List<Movie> movies = new List<Movie>();

        private string[] torrentKeys = new string[] {"hdtv", "dimension", "720p"};

        public void ScanDirectoryPath(string dirPath)
        {
            foreach (string file in Directory.GetFiles(dirPath, @"*.*", SearchOption.AllDirectories))
            {
                Movie movie = new Movie()
                {
                    Path = file,
                    FileName = GetFileNameFromPath(file)
                };

                SetMovieInfo(movie);

                movies.Add(movie);
            }
        }

        private void SetMovieInfo(Movie movie)
        {
            Regex info = new Regex(@"(.*)(?:s|S)(\d{1,2})\.?(?:e|E)(\d{1,2})");
            Match match = info.Match(movie.FileName);

            movie.Name = ParseMovieName(match.Groups[1].Value);
            movie.Season = int.Parse(match.Groups[2].Value);
            movie.Episode = int.Parse(match.Groups[3].Value);
        }

        private string ParseMovieName(string movieName)
        {
            foreach (string key in torrentKeys)
            {
                movieName = movieName.ToUpper().Replace(key.ToUpper(), @"");
            }

            Regex dots = new Regex(@"\.{1,}");
            movieName = dots.Replace(movieName, @" ").Trim();

            return movieName;
        }

        private string GetFileNameFromPath(string file)
        {
            string fileName = file.Substring(file.LastIndexOf(@"\") + 1);
            return fileName;
        }

        public List<string> GetMovieTitles()
        {
            List<string> result = new List<string>();

            foreach (Movie movie in movies)
            {
                if (result.IndexOf(movie.Name) == -1)
                {
                    result.Add(movie.Name);
                }
            }

            return result;
        }

        public List<int> GetMovieSeasonsByName(string name)
        {
            List<int> seasons = new List<int>();

            foreach (Movie movie in movies)
            {
                if (movie.Name == name && seasons.IndexOf(movie.Season) == -1)
                {
                    seasons.Add(movie.Season);
                }
            }
            seasons.Sort();
            return seasons;
        }

        internal List<int> GetMovieEpisodes(string movieName, int movieSeason)
        {
            List<int> episodes = new List<int>();

            foreach (Movie movie in movies)
            {
                if (movie.Name == movieName && movie.Season == movieSeason && episodes.IndexOf(movie.Episode) == -1)
                {
                    episodes.Add(movie.Episode);
                }
            }

            episodes.Sort();
            return episodes;
        }
    }
}
