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

            foreach (string item in movieListCb.Items)
            {
                index++;

                if (item == selectedMovie)
                {
                    movieListCb.SelectedIndex = index;
                    break;
                }
            }

            if (movieListCb.SelectedIndex == -1)
            {
                movieListCb.SelectedIndex = 0;
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
        }

        private void SetSelectedMinute()
        {
            minuteUd.Value = Config.GetSelectedMinute(movieListCb.Text, seasonsCb.Text, episodesCb.Text);
        }

        private void GetMovies()
        {
            List<String> titles = scanner.GetMovieTitles();

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
        }

        private void pathTi_TextChanged(object sender, EventArgs e)
        {
            Config.SavePath(pathTi.Text);
        }
    }
}
