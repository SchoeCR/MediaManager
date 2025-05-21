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
using System.Diagnostics.Eventing.Reader;

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

        private void ShowNameEvent(object sender, EventArgs e)
        {

            if (PlayList.SelectedItem != null)
            {
                string selected_file = PlayList.SelectedItem.ToString();
                MessageBox.Show("Selected file:" + selected_file, "File name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No file selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
