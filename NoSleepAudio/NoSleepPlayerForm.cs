using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace NoSleepAudio
{
    public class NoSleepPlayerForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private WindowsMediaPlayer player;
        public NoSleepPlayerForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;

            trayMenu = new ContextMenuStrip();
            ToolStripMenuItem volumeMenu = new ToolStripMenuItem("Volume");
            ToolStripTrackBar volumeTrackBar = new ToolStripTrackBar();
            volumeTrackBar.TrackBar.Minimum = 0;
            volumeTrackBar.TrackBar.Maximum = 100;
            volumeTrackBar.TrackBar.Value = 50;
            volumeTrackBar.TrackBar.BackColor = SystemColors.Control;
            volumeTrackBar.TrackBar.TickStyle = TickStyle.None;
            volumeTrackBar.TrackBar.ValueChanged += VolumeTrackBar_ValueChanged;
            volumeMenu.DropDownItems.Add(volumeTrackBar);

            trayMenu.Items.Add(volumeMenu);
            trayMenu.Items.Add("Exit", null, OnExit);

            trayIcon = new NotifyIcon
            {
                Text = "No Sleep Audio",
                Icon = Properties.Resources.Player,
                ContextMenuStrip = trayMenu,
                Visible = true
            };


            string folderPath = AppInfo.AppPath + AppInfo.AppName + "Music";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string[] audioExtensions = { ".mid", ".midi", ".mp3", ".wma", ".wav" };
            var audioFiles = Directory.GetFiles(folderPath)
                        .Where(file => audioExtensions.Contains(Path.GetExtension(file).ToLower()))
                        .ToList();

            if (audioFiles.Count == 0) { return; }
            player = new WindowsMediaPlayer();
            IWMPPlaylist playlist = player.playlistCollection.newPlaylist("NoSleepAudioPlaylist");
            foreach (string audioFile in audioFiles)
            {
                IWMPMedia media = player.newMedia(audioFile);
                playlist.appendItem(media);
            }
            player.currentPlaylist = playlist;
            player.settings.setMode("loop", true);
            player.settings.volume = 50;
            player.PlayStateChange += (int newState) =>
            {
                WMPPlayState state = (WMPPlayState)newState;

                if (state == WMPPlayState.wmppsPaused)
                {
                    player.controls.play();
                }
                else if (state == WMPPlayState.wmppsStopped)
                {
                    player.controls.play();
                }
            };

            player.controls.play();
        }

        private void VolumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            player.settings.volume = trackBar.Value;
        }

        private void OnExit(object sender, EventArgs e)
        {
            player.controls.stop();
            trayIcon.Visible = false;
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                trayIcon?.Dispose();
                player?.controls.stop();
            }
            base.Dispose(disposing);
        }
    }

    public class ToolStripTrackBar : ToolStripControlHost
    {
        public TrackBar TrackBar { get; private set; }

        public ToolStripTrackBar() : base(new TrackBar())
        {
            TrackBar = (TrackBar)Control;
            TrackBar.AutoSize = false;
            TrackBar.Width = 150;
            TrackBar.Height = 20;
        }
    }
}
