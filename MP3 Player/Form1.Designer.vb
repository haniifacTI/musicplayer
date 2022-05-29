<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.btnRepeatPlaylist = New System.Windows.Forms.Button()
        Me.btnRepeatSong = New System.Windows.Forms.Button()
        Me.btnShuffle = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LyricsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadMusicToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicTagEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvPlaylist = New System.Windows.Forms.ListView()
        Me.chSong = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chArtist = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAlbum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsLVPlaylist = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.lblArtis = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tbVolume = New System.Windows.Forms.TrackBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TimerJudul = New System.Windows.Forms.Timer(Me.components)
        Me.lblStartDuration = New System.Windows.Forms.Label()
        Me.lblEndDuration = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.cmsLVPlaylist.SuspendLayout()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRepeatPlaylist
        '
        Me.btnRepeatPlaylist.FlatAppearance.BorderSize = 0
        Me.btnRepeatPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRepeatPlaylist.Image = CType(resources.GetObject("btnRepeatPlaylist.Image"), System.Drawing.Image)
        Me.btnRepeatPlaylist.Location = New System.Drawing.Point(23, 129)
        Me.btnRepeatPlaylist.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRepeatPlaylist.Name = "btnRepeatPlaylist"
        Me.btnRepeatPlaylist.Size = New System.Drawing.Size(37, 36)
        Me.btnRepeatPlaylist.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btnRepeatPlaylist, "Repeat Playlist")
        Me.btnRepeatPlaylist.UseVisualStyleBackColor = True
        '
        'btnRepeatSong
        '
        Me.btnRepeatSong.FlatAppearance.BorderSize = 0
        Me.btnRepeatSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRepeatSong.Image = CType(resources.GetObject("btnRepeatSong.Image"), System.Drawing.Image)
        Me.btnRepeatSong.Location = New System.Drawing.Point(75, 130)
        Me.btnRepeatSong.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRepeatSong.Name = "btnRepeatSong"
        Me.btnRepeatSong.Size = New System.Drawing.Size(37, 36)
        Me.btnRepeatSong.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnRepeatSong, "Repeat Song")
        Me.btnRepeatSong.UseVisualStyleBackColor = True
        '
        'btnShuffle
        '
        Me.btnShuffle.BackColor = System.Drawing.SystemColors.Control
        Me.btnShuffle.FlatAppearance.BorderSize = 0
        Me.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShuffle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnShuffle.Image = CType(resources.GetObject("btnShuffle.Image"), System.Drawing.Image)
        Me.btnShuffle.Location = New System.Drawing.Point(124, 129)
        Me.btnShuffle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShuffle.Name = "btnShuffle"
        Me.btnShuffle.Size = New System.Drawing.Size(45, 36)
        Me.btnShuffle.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnShuffle, "Shuffle Playlist")
        Me.btnShuffle.UseVisualStyleBackColor = False
        '
        'btnPrev
        '
        Me.btnPrev.FlatAppearance.BorderSize = 0
        Me.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.Location = New System.Drawing.Point(180, 124)
        Me.btnPrev.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(36, 49)
        Me.btnPrev.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnPrev, "Previous Song")
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.FlatAppearance.BorderSize = 0
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.Location = New System.Drawing.Point(224, 124)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(49, 48)
        Me.btnStop.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnStop, "Stop")
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(567, 28)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPlaylistToolStripMenuItem, Me.AddFileToolStripMenuItem, Me.ClearPlaylistToolStripMenuItem, Me.SettingToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AddPlaylistToolStripMenuItem
        '
        Me.AddPlaylistToolStripMenuItem.Name = "AddPlaylistToolStripMenuItem"
        Me.AddPlaylistToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.AddPlaylistToolStripMenuItem.Text = "Add Folder"
        '
        'AddFileToolStripMenuItem
        '
        Me.AddFileToolStripMenuItem.Name = "AddFileToolStripMenuItem"
        Me.AddFileToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.AddFileToolStripMenuItem.Text = "Add File"
        '
        'ClearPlaylistToolStripMenuItem
        '
        Me.ClearPlaylistToolStripMenuItem.Name = "ClearPlaylistToolStripMenuItem"
        Me.ClearPlaylistToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.ClearPlaylistToolStripMenuItem.Text = "Clear Playlist"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.SettingToolStripMenuItem.Text = "Settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LyricsToolStripMenuItem, Me.DownloadMusicToolStripMenuItem1, Me.MusicTagEditorToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'LyricsToolStripMenuItem
        '
        Me.LyricsToolStripMenuItem.Name = "LyricsToolStripMenuItem"
        Me.LyricsToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.LyricsToolStripMenuItem.Text = "Lyrics"
        '
        'DownloadMusicToolStripMenuItem1
        '
        Me.DownloadMusicToolStripMenuItem1.Name = "DownloadMusicToolStripMenuItem1"
        Me.DownloadMusicToolStripMenuItem1.Size = New System.Drawing.Size(224, 26)
        Me.DownloadMusicToolStripMenuItem1.Text = "Music Downloader"
        '
        'MusicTagEditorToolStripMenuItem
        '
        Me.MusicTagEditorToolStripMenuItem.Name = "MusicTagEditorToolStripMenuItem"
        Me.MusicTagEditorToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.MusicTagEditorToolStripMenuItem.Text = "Music Tag Editor"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'lvPlaylist
        '
        Me.lvPlaylist.BackColor = System.Drawing.SystemColors.Control
        Me.lvPlaylist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chSong, Me.chArtist, Me.chAlbum})
        Me.lvPlaylist.ContextMenuStrip = Me.cmsLVPlaylist
        Me.lvPlaylist.GridLines = True
        Me.lvPlaylist.HideSelection = False
        Me.lvPlaylist.Location = New System.Drawing.Point(16, 240)
        Me.lvPlaylist.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPlaylist.Name = "lvPlaylist"
        Me.lvPlaylist.Size = New System.Drawing.Size(529, 410)
        Me.lvPlaylist.TabIndex = 10
        Me.lvPlaylist.UseCompatibleStateImageBehavior = False
        Me.lvPlaylist.View = System.Windows.Forms.View.Details
        '
        'chSong
        '
        Me.chSong.Text = "Song"
        '
        'chArtist
        '
        Me.chArtist.Text = "Artist"
        '
        'chAlbum
        '
        Me.chAlbum.Text = "Album"
        '
        'cmsLVPlaylist
        '
        Me.cmsLVPlaylist.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsLVPlaylist.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsDelete})
        Me.cmsLVPlaylist.Name = "ContextMenuStrip1"
        Me.cmsLVPlaylist.Size = New System.Drawing.Size(123, 28)
        '
        'cmsDelete
        '
        Me.cmsDelete.Name = "cmsDelete"
        Me.cmsDelete.Size = New System.Drawing.Size(122, 24)
        Me.cmsDelete.Text = "Delete"
        '
        'lblJudul
        '
        Me.lblJudul.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.Location = New System.Drawing.Point(237, 36)
        Me.lblJudul.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(93, 37)
        Me.lblJudul.TabIndex = 11
        Me.lblJudul.Text = "Judul "
        Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArtis
        '
        Me.lblArtis.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblArtis.AutoSize = True
        Me.lblArtis.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtis.Location = New System.Drawing.Point(252, 71)
        Me.lblArtis.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArtis.Name = "lblArtis"
        Me.lblArtis.Size = New System.Drawing.Size(59, 28)
        Me.lblArtis.TabIndex = 12
        Me.lblArtis.Text = "Artist"
        Me.lblArtis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btnNext
        '
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.Location = New System.Drawing.Point(333, 123)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(41, 49)
        Me.btnNext.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.btnNext, "Next Song")
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.FlatAppearance.BorderSize = 0
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPlay.Image = CType(resources.GetObject("btnPlay.Image"), System.Drawing.Image)
        Me.btnPlay.Location = New System.Drawing.Point(280, 123)
        Me.btnPlay.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(41, 49)
        Me.btnPlay.TabIndex = 6
        Me.btnPlay.Text = "play"
        Me.ToolTip1.SetToolTip(Me.btnPlay, "Play / Pause")
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'tbVolume
        '
        Me.tbVolume.BackColor = System.Drawing.SystemColors.Control
        Me.tbVolume.Location = New System.Drawing.Point(393, 124)
        Me.tbVolume.Margin = New System.Windows.Forms.Padding(4)
        Me.tbVolume.Maximum = 100
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(152, 56)
        Me.tbVolume.TabIndex = 16
        Me.tbVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.ToolTip1.SetToolTip(Me.tbVolume, "Volume Bar")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Information"
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(11, 178)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(533, 56)
        Me.TrackBar1.TabIndex = 17
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ToolTip1.SetToolTip(Me.TrackBar1, "Seek Bar")
        '
        'TimerJudul
        '
        '
        'lblStartDuration
        '
        Me.lblStartDuration.AutoSize = True
        Me.lblStartDuration.Location = New System.Drawing.Point(13, 209)
        Me.lblStartDuration.Name = "lblStartDuration"
        Me.lblStartDuration.Size = New System.Drawing.Size(48, 16)
        Me.lblStartDuration.TabIndex = 19
        Me.lblStartDuration.Text = "Label2"
        '
        'lblEndDuration
        '
        Me.lblEndDuration.AutoSize = True
        Me.lblEndDuration.Location = New System.Drawing.Point(488, 209)
        Me.lblEndDuration.Name = "lblEndDuration"
        Me.lblEndDuration.Size = New System.Drawing.Size(48, 16)
        Me.lblEndDuration.TabIndex = 20
        Me.lblEndDuration.Text = "Label1"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "MP3 Player"
        Me.NotifyIcon1.Visible = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(220, 191)
        Me.AxWindowsMediaPlayer1.Margin = New System.Windows.Forms.Padding(4)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(190, 29)
        Me.AxWindowsMediaPlayer1.TabIndex = 13
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'ofd
        '
        Me.ofd.Filter = "MP3 | *.mp3"
        Me.ofd.Multiselect = True
        Me.ofd.Title = "Add Song"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(567, 663)
        Me.Controls.Add(Me.lblEndDuration)
        Me.Controls.Add(Me.lblStartDuration)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Controls.Add(Me.lblArtis)
        Me.Controls.Add(Me.lblJudul)
        Me.Controls.Add(Me.lvPlaylist)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnShuffle)
        Me.Controls.Add(Me.btnRepeatSong)
        Me.Controls.Add(Me.btnRepeatPlaylist)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tbVolume)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MP3 Player"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.cmsLVPlaylist.ResumeLayout(False)
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRepeatPlaylist As Button
    Friend WithEvents btnRepeatSong As Button
    Friend WithEvents btnShuffle As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnPlay As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddPlaylistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lvPlaylist As ListView
    Friend WithEvents lblJudul As Label
    Friend WithEvents lblArtis As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents chSong As ColumnHeader
    Friend WithEvents chArtist As ColumnHeader
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Private WithEvents btnNext As Button
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents chAlbum As ColumnHeader
    Friend WithEvents tbVolume As TrackBar
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TimerJudul As Timer
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents lblStartDuration As Label
    Friend WithEvents lblEndDuration As Label
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadMusicToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MusicTagEditorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmsLVPlaylist As ContextMenuStrip
    Friend WithEvents cmsDelete As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents AddFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents ClearPlaylistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LyricsToolStripMenuItem As ToolStripMenuItem
End Class
