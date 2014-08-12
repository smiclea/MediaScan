using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Windows.Forms;

namespace Media_Scan
{
    class MovieScanner
    {
        public List<Movie> movies = new List<Movie>();

        // The name is parsed by considering the string from 0 to the index of season and episode info
        // if the name contains torrent keys (usually these keys are found AFTER season and episode info - but just to be safe), remove them
        private string[] torrentKeys = new string[] {"hdtv", "dimension", "720p"};
        private string[] extensions = new string[] {"avi", "mkv", "mp4"};
        private Regex movieEx = new Regex(@"(.*)(?:s|S)(\d{1,2})\.?(?:e|E)(\d{1,2})");

        public void ScanDirectoryPath(string dirPath)
        {
            movies.Clear();

            if (dirPath.Trim() == "")
            {
                return;
            }

            try
            {
                foreach (string file in Directory.GetFiles(dirPath, @"*.*", SearchOption.AllDirectories))
                {
                    if (!IsMovieExtension(file))
                    {
                        continue;
                    }

                    string fileName = GetFileNameFromPath(file);

                    if (!IsMovieFile(fileName))
                    {
                        continue;
                    }

                    Movie movie = new Movie()
                    {
                        Path = file,
                        FileName = fileName
                    };

                    SetMovieInfo(movie);

                    movies.Add(movie);
                }

                movies = movies.OrderBy(m => m.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsMovieExtension(string file)
        {
            return extensions.Contains(file.Substring(file.Length - 3));
        }

        private bool IsMovieFile(string fileName)
        {
            return movieEx.IsMatch(fileName);
        }

        private void SetMovieInfo(Movie movie)
        {
            Match match = movieEx.Match(movie.FileName);

            movie.Name = ParseMovieName(match.Groups[1].Value);
            movie.Season = int.Parse(match.Groups[2].Value);
            movie.Episode = int.Parse(match.Groups[3].Value);

            //WebClient client = new WebClient();

            //client.DownloadStringCompleted += (sender, e) =>
            //{
            //    Regex posterUrl = new Regex(@"src=""(http:\/\/t\d\.gstatic.com\/images\?q=.*?)""");
            //    Match posterMatch = posterUrl.Match(e.Result);
            //    movie.PosterUrl = posterMatch.Groups[1].Value;
            //};
            
            //client.DownloadStringAsync(new Uri(@"http://www.google.com/search?q=" + movie.Name + @" poster&tbm=isch"));
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

        public List<int> GetMovieEpisodes(string movieName, int movieSeason)
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

        public Movie GetMovie(string name, int season, int episode)
        {
            Movie result = null;

            foreach (Movie movie in movies)
            {
                if (movie.Name == name && movie.Season == season && movie.Episode == episode)
                {
                    result = movie;
                    break;
                }
            }

            return result;
        }
    }
}
