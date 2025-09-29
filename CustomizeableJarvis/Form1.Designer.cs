namespace JarvisReiven
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.ShutdownTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AlarmTimer = new System.Windows.Forms.Timer(this.components);
            this.MusicFBD = new System.Windows.Forms.FolderBrowserDialog();
            this.VideoFBD = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrMailCheck = new System.Windows.Forms.Timer(this.components);
            this.lblLanguage = new System.Windows.Forms.Label();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.lblMusicTime = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tbarMusicTime = new System.Windows.Forms.TrackBar();
            this.tbarVolume = new System.Windows.Forms.TrackBar();
            this.tmrBgPic = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pbMicrophoneLevel = new System.Windows.Forms.ProgressBar();
            this.tmrSpeech = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMusicTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCommands
            // 
            this.lstCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCommands.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCommands.Font = new System.Drawing.Font("AR DESTINE", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCommands.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.HorizontalScrollbar = true;
            this.lstCommands.ItemHeight = 18;
            this.lstCommands.Location = new System.Drawing.Point(12, 31);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstCommands.Size = new System.Drawing.Size(424, 216);
            this.lstCommands.TabIndex = 1;
            this.lstCommands.Visible = false;
            this.lstCommands.SelectedIndexChanged += new System.EventHandler(this.lstCommands_SelectedIndexChanged);
            // 
            // ShutdownTimer
            // 
            this.ShutdownTimer.Interval = 1000;
            this.ShutdownTimer.Tick += new System.EventHandler(this.ShutdownTimer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Black;
            this.lblTimer.Font = new System.Drawing.Font("AR ESSENCE", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblTimer.Location = new System.Drawing.Point(216, 123);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(38, 36);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "10";
            this.lblTimer.Visible = false;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.BackColor = System.Drawing.Color.Transparent;
            this.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblAdd.Location = new System.Drawing.Point(411, 246);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(25, 25);
            this.lblAdd.TabIndex = 3;
            this.lblAdd.Text = "+";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::JarvisReiven.Properties.Resources.NotSpeaking;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(447, 282);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AlarmTimer
            // 
            this.AlarmTimer.Interval = 1000;
            this.AlarmTimer.Tick += new System.EventHandler(this.AlarmTimer_Tick);
            // 
            // MusicFBD
            // 
            this.MusicFBD.ShowNewFolderButton = false;
            // 
            // VideoFBD
            // 
            this.VideoFBD.ShowNewFolderButton = false;
            // 
            // tmrMailCheck
            // 
            this.tmrMailCheck.Enabled = true;
            this.tmrMailCheck.Interval = 300000;
            this.tmrMailCheck.Tick += new System.EventHandler(this.tmrMailCheck_Tick);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblLanguage.Location = new System.Drawing.Point(365, 253);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(39, 15);
            this.lblLanguage.TabIndex = 4;
            this.lblLanguage.Text = "LANG";
            this.lblLanguage.Click += new System.EventHandler(this.lblLanguage_Click);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Interval = 10;
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // lblMusicTime
            // 
            this.lblMusicTime.BackColor = System.Drawing.Color.Black;
            this.lblMusicTime.Font = new System.Drawing.Font("AR ESSENCE", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicTime.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblMusicTime.Location = new System.Drawing.Point(299, 126);
            this.lblMusicTime.Name = "lblMusicTime";
            this.lblMusicTime.Size = new System.Drawing.Size(40, 17);
            this.lblMusicTime.TabIndex = 6;
            this.lblMusicTime.Text = "00:00";
            this.lblMusicTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMusicTime.Visible = false;
            // 
            // lblVolume
            // 
            this.lblVolume.BackColor = System.Drawing.Color.Black;
            this.lblVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVolume.Font = new System.Drawing.Font("AR ESSENCE", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblVolume.Location = new System.Drawing.Point(299, 143);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(40, 17);
            this.lblVolume.TabIndex = 7;
            this.lblVolume.Text = "50%";
            this.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVolume.Visible = false;
            this.lblVolume.Click += new System.EventHandler(this.lblVolume_Click);
            // 
            // tbarMusicTime
            // 
            this.tbarMusicTime.AutoSize = false;
            this.tbarMusicTime.BackColor = System.Drawing.Color.Black;
            this.tbarMusicTime.Location = new System.Drawing.Point(164, 145);
            this.tbarMusicTime.Maximum = 3600;
            this.tbarMusicTime.Name = "tbarMusicTime";
            this.tbarMusicTime.Size = new System.Drawing.Size(138, 15);
            this.tbarMusicTime.TabIndex = 8;
            this.tbarMusicTime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarMusicTime.Visible = false;
            this.tbarMusicTime.Scroll += new System.EventHandler(this.tbarMusicTime_Scroll);
            // 
            // tbarVolume
            // 
            this.tbarVolume.AutoSize = false;
            this.tbarVolume.BackColor = System.Drawing.Color.Black;
            this.tbarVolume.Location = new System.Drawing.Point(338, 93);
            this.tbarVolume.Maximum = 100;
            this.tbarVolume.Name = "tbarVolume";
            this.tbarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbarVolume.Size = new System.Drawing.Size(13, 67);
            this.tbarVolume.TabIndex = 9;
            this.tbarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarVolume.Visible = false;
            this.tbarVolume.Scroll += new System.EventHandler(this.tbarVolume_Scroll);
            // 
            // tmrBgPic
            // 
            this.tmrBgPic.Interval = 50;
            this.tmrBgPic.Tick += new System.EventHandler(this.tmrBgPic_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(164, 126);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(138, 23);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            this.axWindowsMediaPlayer1.Visible = false;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // pbMicrophoneLevel
            // 
            this.pbMicrophoneLevel.Location = new System.Drawing.Point(348, 275);
            this.pbMicrophoneLevel.Name = "pbMicrophoneLevel";
            this.pbMicrophoneLevel.Size = new System.Drawing.Size(100, 5);
            this.pbMicrophoneLevel.TabIndex = 10;
            // 
            // tmrSpeech
            // 
            this.tmrSpeech.Interval = 2000;
            this.tmrSpeech.Tick += new System.EventHandler(this.tmrSpeech_Tick);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::JarvisReiven.Properties.Resources.NotSpeaking;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(448, 280);
            this.Controls.Add(this.pbMicrophoneLevel);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lstCommands);
            this.Controls.Add(this.tbarVolume);
            this.Controls.Add(this.lblMusicTime);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.tbarMusicTime);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(464, 318);
            this.MinimumSize = new System.Drawing.Size(464, 318);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jarvis REíVEN (v.1.0.1)";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMusicTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ShutdownTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer AlarmTimer;
        private System.Windows.Forms.FolderBrowserDialog MusicFBD;
        private System.Windows.Forms.FolderBrowserDialog VideoFBD;
        private System.Windows.Forms.Timer tmrMailCheck;
        private System.Windows.Forms.Label lblLanguage;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer tmrMusic;
        private System.Windows.Forms.Label lblMusicTime;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar tbarMusicTime;
        private System.Windows.Forms.TrackBar tbarVolume;
        private System.Windows.Forms.Timer tmrBgPic;
        public System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.ProgressBar pbMicrophoneLevel;
        private System.Windows.Forms.Timer tmrSpeech;
    }
}

