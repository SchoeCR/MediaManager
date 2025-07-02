using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaManager
{
    public partial class VideoPreview : Form
    {

        List<string> filteredFiles = new List<string>(); // list of strings to store video files loaded from folder
        FolderBrowserDialog browser = new FolderBrowserDialog(); // object to display explorer window to select folder to load
        int currentFile = 0; // the current selected file

        public VideoPreview()
        {
            InitializeComponent();
        }

        private void LoadFolderEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.stop(); // stop any file currently playing

            if (filteredFiles.Count > 1) // check if files already exist in list, clear if true
            { 
                filteredFiles.Clear();
                filteredFiles = null;

                PlayList.Items.Clear(); // clear the listbox "PlayList"

                currentFile = 0; // reset current file back to zero
            }

            DialogResult result = browser.ShowDialog();

            if (result == DialogResult.OK) 
            {
                filteredFiles = Directory.GetFiles(browser.SelectedPath, "*.*").Where(file => file.ToLower
                ().EndsWith("webm") || file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("wmv") ||
                file.ToLower().EndsWith("mkv") || file.ToLower().EndsWith("avi")).ToList();

                LoadPlaylist();
            }
        }

        private void ShowAboutEvent(object sender, EventArgs e)
        {
            MessageBox.Show("This app is made by following instructions supplied by MOO ICT" + Environment.NewLine + "Hope you enjoyed the simple " +
                "media player" + Environment.NewLine + "Click on Open Folder Button to load the video folder to the" +
                "app and it will start auto playing" + Environment.NewLine + "Enjoy");
        }

        private void MediaPlayerStateChangeEvent(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 0)
            {
                // undefined loaded
                lblDuration.Text = "Media Player is Ready to be loaded";
            }
            else if (e.newState == 1)
            {
                // if the file is stopped
                lblDuration.Text = "Media Player stopped";
            }
            else if (e.newState == 3)
            {
                // if the file is playing
                lblDuration.Text = "Duration: " + VideoPlayer.currentMedia.durationString;
            }
            else if (e.newState == 8)
            {
                // media has ended here

                if (currentFile >= filteredFiles.Count -1)
                {
                    currentFile = 0;
                }
                else
                {
                    currentFile += 1;
                }

                PlayList.SelectedIndex = currentFile;

                ShowFileName(lblFilename);

            }
            else if (e.newState == 10)
            {
                // media is ready to play again
                timer1.Start();
            }



        }

        private void PlayListChanged(object sender, EventArgs e)
        {
            currentFile = PlayList.SelectedIndex;
            PlayFile(PlayList.SelectedItem.ToString());
            ShowFileName(lblFilename);
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.play();
            timer1.Stop();
        }

        private void LoadPlaylist()
        {
            VideoPlayer.currentPlaylist = VideoPlayer.newPlaylist("PlayList", "");

            foreach (string videos in filteredFiles)
            {
                VideoPlayer.currentPlaylist.appendItem(VideoPlayer.newMedia(videos));
                PlayList.Items.Add(videos);
            }

            if (filteredFiles.Count > 0) 
            {
                lblFilename.Text = "Files Found " + filteredFiles.Count;

                PlayList.SelectedIndex = currentFile;

                PlayFile(PlayList.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("No Video Files Found in this folder");
            }
        }

        private void PlayFile(string url)
        {
            VideoPlayer.URL = url;
        }

        private void ShowFileName(Label name)
        {
            string file = Path.GetFileName(PlayList.SelectedItem.ToString());
            name.Text = "Currently Playing: " + file;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var query = txtSearchString.Text;
            if (string.IsNullOrEmpty(query))
            {
                Console.Beep(500,750);
                MessageBox.Show("Please enter a search value.");
                return;
            }
            else
            {
                Console.WriteLine(query);
            }
            var URL = "https://api.themoviedb.org/3/search/multi?include_adult=false&language=en-US&page=1";
            var qry_Str = "&query=" + Uri.EscapeDataString(query);
            var API_Str = URL + qry_Str;
            var options = new RestClientOptions(API_Str);
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzZGU0Zjc2NzBhMGNhYzE4NjA5NTBiOTQ5YWY3ZTA1ZCIsIm5iZiI6MTc0MDI2MzYzMi45MTkwMDAxLCJzdWIiOiI2N2JhNTBkMGEyMzkyOWFjMjhiZWMwNTkiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.Id-gzv0aD8dGSAAyNj88XTC2UJaHdnuPhfeWcdPa4Ro");
            var response = await client.GetAsync(request);

            Console.WriteLine("{0}", response.Content);

            if (response.IsSuccessful && response.Content != null)
            {
                var jsonResponse = JsonConvert.DeserializeObject<TMDBResponse>(response.Content);

                lstSearchResults.Items.Clear(); // Clear any existing items in lstSearchResults

                foreach (var item in jsonResponse.results)
                {
                    string title = item.Title ?? item.Name; // movie or TV show
                    string date = item.Release_date ?? item.First_air_date;
                    string year = "";
                    if (!string.IsNullOrEmpty(date) && date.Length >= 4)
                    {
                        year = date.Substring(0, 4);
                    }

                    lstSearchResults.Items.Add($"{title} ({year})");
                }
                if (jsonResponse != null && jsonResponse.results != null)
                {
                    var resultForm = new SearchResults(jsonResponse.results);
                    resultForm.Show(); // or ShowDialog() if you want it modal
                }
            }
            else
            {
                MessageBox.Show("API call failed.");
                Console.WriteLine(response.ErrorMessage);
            }
        }

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            if (PlayList.SelectedItem != null)
            {
                string selected_result = PlayList.SelectedItem.ToString();
                txtFileCurrName.Text = selected_result;
            }
        }
      
        private void RenameEvent(object sender, EventArgs e)
        {
            
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDlg = new FolderBrowserDialog())
            {
                folderDlg.ShowNewFolderButton = false;
                folderDlg.Description = "Select root folder";
                DialogResult dialogResult = folderDlg.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string folderName = txtFileNewName.Text;
                    string folderRoot = folderDlg.SelectedPath.ToString();

                    if (folderName.Length > 0)
                    {
                        if (folderName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                        {
                            MessageBox.Show("Folder name contains invalid characters.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a desired folder name.");
                        return;
                    }

                            string folderPath = Path.Combine(folderRoot, folderName);
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    if (Directory.Exists(folderPath))
                    {
                        txtFolderDestination.Text = folderPath;
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void optShow_CheckedChanged(object sender, EventArgs e)
        {
            if (optShow.Checked)
            {
                numSeason.Enabled = true;
                numEpisode.Enabled = true;
            }
            else
            {
                numSeason.Enabled = false;
                numEpisode.Enabled = false;
            }
        }

        private void lstSearchResults_MouseDblClick(object sender, MouseEventArgs e)
        {
            string curr_Selection = lstSearchResults.SelectedItem.ToString();
            txtFileNewName.Text = curr_Selection;
        }

        private void txtSearchString_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtSearchString.Text == "Movie/TV Show name") 
            {
                txtSearchString.Clear();
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDlg = new FolderBrowserDialog())
            {
                DialogResult dialogResult = folderDlg.ShowDialog();
                // Show the FolderBrowserDialog.
                if (dialogResult == DialogResult.OK)
                {
                    txtFolderDestination.Text = folderDlg.SelectedPath;
                }
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            if (optMovie.Checked) 
            { Rename_Movie(); }
            else 
            { Rename_Show(); }
        }

        private void Rename_Movie()
        {
            if (lstSearchResults.SelectedItem != null)
            {
                string selected_result = lstSearchResults.SelectedItem.ToString();

                if (txtFileCurrName != null && txtFileCurrName.Text == PlayList.SelectedItem.ToString())
                {
                    DialogResult result = MessageBox.Show("Do you wish to rename current file?", "Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string originalFile = PlayList.SelectedItem.ToString();
                        string directoryPath = Path.GetDirectoryName(PlayList.SelectedItem.ToString());
                        string extension = Path.GetExtension(PlayList.SelectedItem.ToString()).ToLower();
                        string filenameWithExt = selected_result + extension;
                        if (!Directory.Exists(directoryPath))
                        {
                            MessageBox.Show("File directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string newName = Path.Combine(directoryPath, filenameWithExt);
                        Console.WriteLine(newName);

                        if (Directory.Exists(newName))
                        {
                            MessageBox.Show("A file with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        File.Move(originalFile, newName);
                        requeryPlaylist(directoryPath);
                        MessageBox.Show("File successfully renamed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Rename_Show()
        {
            if (lstSearchResults.SelectedItem != null)
            {
                string selected_result = lstSearchResults.SelectedItem.ToString();

                if (txtFileCurrName != null && txtFileCurrName.Text == PlayList.SelectedItem.ToString())
                {
                    DialogResult result = MessageBox.Show("Do you wish to rename current file?", "Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string originalFile = PlayList.SelectedItem.ToString();
                        string directoryPath = Path.GetDirectoryName(PlayList.SelectedItem.ToString());
                        string trim_selected_result = Regex.Replace(selected_result, @"\s*\(.*\)", "");
                        string formattedSeason = "S" + ((int)numSeason.Value).ToString("D2");
                        string formattedEpisode = "E" + ((int)numEpisode.Value).ToString("D2");
                        string extension = Path.GetExtension(PlayList.SelectedItem.ToString()).ToLower();
                        string filenameWithExt = trim_selected_result + " " + formattedSeason + formattedEpisode + extension;
                        
                        if (!Directory.Exists(directoryPath))
                        {
                            MessageBox.Show("File directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string newName = Path.Combine(directoryPath, filenameWithExt);
                        Console.WriteLine(newName);

                        if (Directory.Exists(newName))
                        {
                            MessageBox.Show("A file with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        File.Move(originalFile, newName);
                        requeryPlaylist(directoryPath);
                        MessageBox.Show("File successfully renamed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void requeryPlaylist(string directoryPath)
        {
            string[] extensions = new[] { "*.mp4", "*.wmv", "*.mkv", "*.webm", "*.avi" };
            List<string> mediaFiles = new List<string>();

            foreach (string ext in extensions)
            {
                mediaFiles.AddRange(Directory.GetFiles(directoryPath, ext));
            }

            PlayList.Items.Clear();
            foreach (string file in mediaFiles)
            {
                PlayList.Items.Add(file);
            }
        }

        private void btnMoveFile_Click(object sender, EventArgs e)
        {
            try
            {
                string fileCurrentPath = txtFileCurrName.Text;
                string directoryPath = Path.GetDirectoryName(fileCurrentPath);
                string destinationFolder = txtFolderDestination.Text;
                string fileName = Path.GetFileName(fileCurrentPath);
                string fileDestinationPath = Path.Combine(destinationFolder, fileName);

                if (!File.Exists(fileCurrentPath))
                {
                    MessageBox.Show("Source file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (File.Exists(fileDestinationPath))
                {
                    MessageBox.Show("A file with the same name already exists in the destination.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Do you wish to move the file into the destination folder?", "Move", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Move(fileCurrentPath, fileDestinationPath);
                    requeryPlaylist(directoryPath);
                    MessageBox.Show("File moved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred:\n" + ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
