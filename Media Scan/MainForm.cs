using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Media_Scan.model;
using System.Diagnostics;


namespace Media_Scan
{
    public partial class MainForm : Form
    {
        private MovieScanner scanner = new MovieScanner();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Config.ReadConfig();

            pathTi.Text = Config.GetScanDirPath();

            scanner.ScanDirectoryPath(pathTi.Text);

            GetMovies();
            SetSelectedMovie();
        }

        private void SetSelectedSeason()
        {
            int selectedSeason = Config.GetSeasonForMovie(movieListCb.Text);
            int index = -1;

            foreach (int item in seasonsCb.Items)
            {
                index++;

                if (item == selectedSeason)
                {
                    seasonsCb.SelectedIndex = index;
                    break;
                }
            }

            if (seasonsCb.SelectedIndex == -1)
            {
                seasonsCb.SelectedIndex = 0;
            }
        }

        private void SetSelectedMovie()
        {
            string selectedMovie = Config.GetMovie();
            int index = -1;

            minuteUd.Enabled = true;
            playBtn.Enabled = true;
            saveBtn.Enabled = true;

            foreach (string item in movieListCb.Items)
            {
                index++;

                if (item == selectedMovie)
                {
                    movieListCb.SelectedIndex = index;
                    break;
                }
            }

            if (movieListCb.SelectedIndex == -1 && movieListCb.Items.Count > 0)
            {
                movieListCb.SelectedIndex = 0;
            }
            else if (movieListCb.Items.Count == 0)
            {
                seasonsCb.Items.Clear();
                episodesCb.Items.Clear();
                minuteUd.Value = 0;
                minuteUd.Enabled = false;
                playBtn.Enabled = false;
                saveBtn.Enabled = false;
            }
        }

        private void SetSelectedEpisode()
        {
            int selectedEpisode = Config.GetEpisode(movieListCb.Text, seasonsCb.Text);
            int index = -1;

            foreach (int item in episodesCb.Items)
            {
                index++;

                if (item == selectedEpisode)
                {
                    episodesCb.SelectedIndex = index;
                    break;
                }
            }

            if (episodesCb.SelectedIndex == -1)
            {
                episodesCb.SelectedIndex = 0;
            }

            SetSelectedMinute();
        }

        private void SetSelectedMinute()
        {
            minuteUd.Value = Config.GetSelectedMinute(movieListCb.Text, seasonsCb.Text, episodesCb.Text);
        }

        private void GetMovies()
        {
            List<String> titles = scanner.GetMovieTitles();

            movieListCb.Items.Clear();
            foreach (string title in titles)
            {
                movieListCb.Items.Add(title);
            }
        }

        private void GetSeasonsInfo()
        {
            List<int> seasons = scanner.GetMovieSeasonsByName(movieListCb.Text);

            seasonsCb.Items.Clear();
            foreach (int season in seasons)
            {
                seasonsCb.Items.Add(season);
            }
        }

        private void movieListCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSeasonsInfo();
            SetSelectedSeason();
            SetSelectedEpisode();
            SetSelectedMinute();
        }

        private void GetEpisodesInfo()
        {
            List<int> episodes = scanner.GetMovieEpisodes(movieListCb.Text, int.Parse(seasonsCb.Text));

            episodesCb.Items.Clear();
            foreach (int episode in episodes)
            {
                episodesCb.Items.Add(episode);
            }

            episodesCb.SelectedIndex = 0;
        }

        private void seasonsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEpisodesInfo();
            SetSelectedEpisode();
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            Config.SavePath(pathTi.Text);
            scanner.ScanDirectoryPath(Config.GetScanDirPath());
            GetMovies();
            SetSelectedMovie();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            Movie movie = SaveMovie();
            Process.Start(movie.Path);
        }

        private Movie SaveMovie()
        {
            Movie movie = scanner.GetMovie(movieListCb.Text, int.Parse(seasonsCb.Text), int.Parse(episodesCb.Text));
            Config.SaveMovie(movie.Name, seasonsCb.Text, episodesCb.Text, minuteUd.Value.ToString(@"0"));

            return movie;
        }

        private void episodesCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedMinute();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveMovie();
        }

        private void pathTi_TextChanged(object sender, EventArgs e)
        {
            scanBtn.Enabled = pathTi.Text.Length > 0;
        }
    }
}
