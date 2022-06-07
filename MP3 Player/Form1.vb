Imports System.IO
Imports Id3

Public Class mainForm
    Dim frmLirik As New frmLirik
    Dim frmTagEditor As New frmTagEditor
    Public folderPath As String
    Dim startpath As String = Application.StartupPath
    Dim rnd As New Random

    Dim isShuffle As Boolean = False
    Dim isRepeatSong As Boolean = False
    Dim isRepeatPlaylist As Boolean = False
    Dim isStop As Boolean = True
    Dim isEnded As Boolean = False
    Dim idxSongBefore As Integer

    Public filePlaylist As String
    Public playlistOri As New List(Of String)
    Dim lstShuffle As New List(Of String)
    Dim queueShuffle As New List(Of String)

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbVolume.Value = 30
        lblEndDuration.Text = "00:00"
        lblStartDuration.Text = "00:00"
        disableAllButton()
    End Sub

    Private Sub enableAllButton()
        btnStop.Enabled = True
        btnNext.Enabled = True
        btnPrev.Enabled = True
        TrackBar1.Enabled = True
        btnRepeatPlaylist.Enabled = True
        btnRepeatSong.Enabled = True
        btnShuffle.Enabled = True
    End Sub

    Private Sub disableAllButton()
        btnStop.Enabled = False
        btnNext.Enabled = False
        btnPrev.Enabled = False
        TrackBar1.Enabled = False
        btnRepeatPlaylist.Enabled = False
        btnRepeatSong.Enabled = False
        btnShuffle.Enabled = False
    End Sub

    Private Sub AddFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPlaylistToolStripMenuItem.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            folderPath = FolderBrowserDialog1.SelectedPath
            playlistOri.Clear()
            queueShuffle.Clear()
            lstShuffle.Clear()
            getFiles()

            enableAllButton()
        End If
    End Sub

    Private Sub loadPlaylist()
        Dim StreamReader As New StreamReader(filePlaylist)
        Dim LineCount As Integer = File.ReadAllLines(filePlaylist).Length

        playlistOri.Clear()
        lstShuffle.Clear()

        For i = 0 To LineCount - 1
            Dim song As String = StreamReader.ReadLine()
            Dim tag As Id3Tag = New Id3Tag
            Dim lItem As New ListViewItem()
            Dim file As Mp3 = New Mp3(song, Mp3Permissions.Read)
            Dim fileName As String = Path.GetFileNameWithoutExtension(song)
            playlistOri.Add(song)
            lstShuffle.Add(song)
        Next

        loadToLv(playlistOri.Count)
        StreamReader.Close()
    End Sub

    Private Sub loadToLv(count As Integer)
        lvPlaylist.Items.Clear()
        lvPlaylist.View = View.Details
        lvPlaylist.BeginUpdate()
        For i = 0 To count - 1
            Dim song As String = playlistOri(i)
            Dim tag As Id3Tag = New Id3Tag
            Dim lItem As New ListViewItem()
            Dim file As Mp3 = New Mp3(song, Mp3Permissions.Read)
            Dim fileName As String = Path.GetFileNameWithoutExtension(song)

            If file.HasTags Then
                If file.HasTagOfVersion(Id3Version.V1X) Then
                    tag = file.GetTag(Id3TagFamily.Version1X)
                ElseIf file.HasTagOfVersion(Id3Version.V23) Then
                    tag = file.GetTag(Id3TagFamily.Version2X)
                End If
            End If

            With lItem
                .SubItems(0).Text = fileName
                .SubItems.Add(tag.Artists)
                .SubItems.Add(tag.Album)
            End With

            lvPlaylist.Items.Add(lItem)
        Next
        lvPlaylist.EndUpdate()
        lvPlaylist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub


    Private Sub getFiles()
        If System.IO.File.Exists(filePlaylist) = False Then
            MessageBox.Show("File Does Not Exist")
        End If
        lvPlaylist.Items.Clear()

        Dim tag As Id3Tag = New Id3Tag
        Dim hasil As String() = Directory.GetFiles(folderPath, "*.mp3", SearchOption.TopDirectoryOnly)

        For i As Integer = 0 To hasil.Length - 1
            'Dim lItem As New ListViewItem()
            'Dim fileName As String = Path.GetFileNameWithoutExtension(hasil(i))
            'Dim objWriter As New System.IO.StreamWriter(filePlaylist, True)
            'objWriter.WriteLine(folderPath & "\" & fileName & ".mp3")
            'objWriter.Close()
            playlistOri.Add(hasil(i))
            lstShuffle.Add(hasil(i))
        Next
        loadToLv(playlistOri.Count)
    End Sub

    Private Sub shuffleAlgo()
        queueShuffle.Clear()
        Dim shuffleIndex As Integer
        For i As Integer = 0 To lstShuffle.Count - 1
            shuffleIndex = rnd.Next(0, lstShuffle.Count)
            queueShuffle.Add(lstShuffle(shuffleIndex))
            lstShuffle.RemoveAt(shuffleIndex)
        Next

        'Dim hasil As String() = Directory.GetFiles(folderPath, "*.mp3", SearchOption.TopDirectoryOnly)
        For i As Integer = 0 To playlistOri.Count - 1
            Dim file As Mp3 = New Mp3(playlistOri(i), Mp3Permissions.Read)
            Dim fileName As String = Path.GetFileNameWithoutExtension(playlistOri(i))
            'lstShuffle.Add(folderPath & "\" & fileName & ".mp3")
            lstShuffle.Add(playlistOri(i))

        Next
    End Sub

    Private Sub tampilJudul()
        'Menampilkan judul dan artis
        Dim file As Mp3 = New Mp3(AxWindowsMediaPlayer1.URL, Mp3Permissions.Read)
        Dim tag As Id3Tag = New Id3Tag()
        If file.HasTags Then
            If file.HasTagOfVersion(Id3Version.V1X) Then
                tag = file.GetTag(Id3TagFamily.Version1X)
            ElseIf file.HasTagOfVersion(Id3Version.V23) Then
                tag = file.GetTag(Id3TagFamily.Version2X)
            End If
            lblJudul.Text = tag.Title
            lblArtis.Text = tag.Artists
        Else
            lblJudul.Text = AxWindowsMediaPlayer1.currentMedia.name 'AxWindowsMediaPlayer1.URL.Split("\")(AxWindowsMediaPlayer1.URL.Split("\").Count - 1)
            lblArtis.Text = "Unknown Artist"
        End If
        lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
        lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)

        TimerJudul.Enabled = True
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        'Menandakan play
        If btnPlay.Text = "play" And Not AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused And isStop = True And isEnded = False Then
            If playlistOri.Count <> 0 Then
                btnPlay.Image = Image.FromFile("Images/pause.png")
                btnPlay.Text = "pause"

                'Play sesuai pilihan di list
                If lvPlaylist.SelectedItems.Count = 1 And isShuffle = False Then
                    Dim pathSong As String
                    For Each song In playlistOri
                        If song.Contains(lvPlaylist.SelectedItems(0).Text) Then
                            pathSong = song
                            Exit For
                        End If
                    Next
                    AxWindowsMediaPlayer1.URL = pathSong
                    'AxWindowsMediaPlayer1.URL = folderPath & "\" & lvPlaylist.SelectedItems(0).Text & ".mp3"
                    lvPlaylist.SelectedItems.Clear()
                ElseIf isShuffle = True Then
                    ShufflePlay(sender, e)
                ElseIf AxWindowsMediaPlayer1.currentMedia Is Nothing Then
                    AxWindowsMediaPlayer1.URL = playlistOri(0)
                End If

                tampilJudul() 'tampilin judul
                Timer1.Enabled = True
                isStop = False
                isEnded = False
            Else
                MsgBox("Please add the song first.",, "Play")
            End If

        ElseIf isEnded And playlistOri.Count <> 0 Then ' kalau playlist end tapi orgnya mau 
            If isShuffle = True Then
                AxWindowsMediaPlayer1.URL = queueShuffle(0)
            Else
                AxWindowsMediaPlayer1.URL = playlistOri(playlistOri.Count - 1)
            End If

            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"
            tampilJudul()
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            TimerJudul.Enabled = True
            Timer1.Enabled = True
            isStop = False
            isEnded = False
            'MessageBox.Show("Play Button Pressed : End Play", "DEBUG btnPlay_Click()") ' DEBUG

        ElseIf (btnPlay.Text = "play" And AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused) Then 'buat ngeplay setelah di pause 
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            TimerJudul.Enabled = True
            Timer1.Enabled = True
            isStop = False
            'MessageBox.Show("Play Button Stop/Pause to Play", "DEBUG btnPlay_Click()") 'DEBUG
        ElseIf btnPlay.Text = "pause" And AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then 'buat pause
            btnPlay.Image = Image.FromFile("Images/play.png")
            btnPlay.Text = "play"
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
            TimerJudul.Enabled = False
        End If
    End Sub

    Private Sub btnRepeatPlaylist_Click(sender As Object, e As EventArgs) Handles btnRepeatPlaylist.Click
        If isRepeatPlaylist = False Then 'klik nyalain repeatplaylist
            isRepeatPlaylist = True
            isRepeatSong = False

            btnRepeatSong.Enabled = False
            btnRepeatPlaylist.FlatStyle = FlatStyle.Flat

            btnRepeatPlaylist.FlatStyle = FlatStyle.Standard
            btnRepeatPlaylist.FlatAppearance.BorderSize = 1
        ElseIf isRepeatPlaylist = True Then 'klik matiin repeatplaylist
            isRepeatPlaylist = False

            btnRepeatSong.Enabled = True

            btnRepeatPlaylist.FlatStyle = FlatStyle.Flat
            btnRepeatPlaylist.FlatAppearance.BorderSize = 0
        End If
    End Sub

    Private Sub btnRepeatSong_Click(sender As Object, e As EventArgs) Handles btnRepeatSong.Click
        If isRepeatSong = False Then 'klik nyalain repeatsong
            isRepeatSong = True
            isRepeatPlaylist = False
            isShuffle = False

            btnRepeatPlaylist.Enabled = False 'biar tombol repeatplaylist gbs di klik
            btnRepeatSong.FlatStyle = FlatStyle.Flat

            btnShuffle.Enabled = False 'matiin tombol shuffle
            btnShuffle.FlatStyle = FlatStyle.Flat

            btnRepeatSong.FlatStyle = FlatStyle.Standard
        ElseIf isRepeatSong = True Then 'klik matiin repeatsong
            isRepeatSong = False

            btnRepeatPlaylist.Enabled = True
            btnShuffle.Enabled = True

            btnRepeatSong.FlatStyle = FlatStyle.Flat
        End If
    End Sub

    Private Sub btnShuffle_Click(sender As Object, e As EventArgs) Handles btnShuffle.Click
        If AxWindowsMediaPlayer1.currentMedia Is Nothing Then
            shuffleAlgo()
            isShuffle = True
            btnShuffle.FlatStyle = FlatStyle.Standard
            isEnded = True
            MsgBox("Shuffle Created")
            'outqShuffle()

            isRepeatSong = False
            btnRepeatSong.Enabled = False
        Else
            If isShuffle = True Then
                isShuffle = False
                btnShuffle.FlatStyle = FlatStyle.Flat

                btnRepeatSong.Enabled = True
                btnRepeatSong.FlatStyle = FlatStyle.Flat
            ElseIf isShuffle = False Then
                isShuffle = True
                btnShuffle.FlatStyle = FlatStyle.Standard
                shuffleAlgo()

                isRepeatSong = False
                btnRepeatSong.Enabled = False
                btnRepeatSong.FlatStyle = FlatStyle.Standard
            End If
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        lblStartDuration.Text = "00:00"
        btnPlay.Image = Image.FromFile("Images/play.png")
        btnPlay.Text = "play"
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        TrackBar1.Value = 0
        Timer1.Enabled = False
        TimerJudul.Enabled = False
        isStop = True

        ' biar stop judulnya ditengah
        lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
        lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)

    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim indexLaguSkrg As Integer = playlistOri.IndexOf(AxWindowsMediaPlayer1.URL)
        If playlistOri.Count = 0 Then
            MsgBox("Please add the song first.",, "Previous")
        ElseIf isShuffle = False Then
            Try
                AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg - 1)
            Catch
                AxWindowsMediaPlayer1.URL = playlistOri(playlistOri.Count - 1)
            End Try

            Timer1.Enabled = True
            isStop = False
            isEnded = False
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"

            'Menampilkan judul dan artis
            tampilJudul()

        ElseIf isShuffle = True Then
            'Dim shuffleIndex As Integer = rnd.Next(0, playlistOri.Count)
            'While shuffleIndex = indexLaguSkrg
            '    shuffleIndex = rnd.Next(0, playlistOri.Count)
            'End While
            'AxWindowsMediaPlayer1.URL = playlistOri(shuffleIndex)

            indexLaguSkrg = queueShuffle.IndexOf(AxWindowsMediaPlayer1.URL)
            Try
                AxWindowsMediaPlayer1.URL = queueShuffle(indexLaguSkrg - 1)
            Catch
                shuffleAlgo()
                AxWindowsMediaPlayer1.URL = queueShuffle(queueShuffle.Count - 1)
            End Try

            Timer1.Enabled = True
            isStop = False
            isEnded = False
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"

            If queueShuffle.Count <= 1 Then
                shuffleAlgo()
            End If

            tampilJudul() 'Menampilkan judul dan artis
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim indexLaguSkrg As Integer = playlistOri.IndexOf(AxWindowsMediaPlayer1.URL)
        If playlistOri.Count = 0 Then
            MsgBox("Please add the song first.",, "Next")
        ElseIf isShuffle = False Then
            Try
                AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
            Catch
                AxWindowsMediaPlayer1.URL = playlistOri(0)
            End Try

            Timer1.Enabled = True
            isStop = False
            isEnded = False
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"

            'Menampilkan judul dan artis
            tampilJudul()
        ElseIf isShuffle = True Then
            'Dim shuffleIndex As Integer = rnd.Next(0, playlistOri.Count)
            'While shuffleIndex = indexLaguSkrg
            '    shuffleIndex = rnd.Next(0, playlistOri.Count)
            'End While
            'AxWindowsMediaPlayer1.URL = playlistOri(shuffleIndex)
            indexLaguSkrg = queueShuffle.IndexOf(AxWindowsMediaPlayer1.URL)
            Try
                AxWindowsMediaPlayer1.URL = queueShuffle(indexLaguSkrg + 1)
            Catch
                shuffleAlgo()
                AxWindowsMediaPlayer1.URL = queueShuffle(0)
            End Try

            Timer1.Enabled = True
            isStop = False
            isEnded = False
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"

            If queueShuffle.Count <= 1 Then
                shuffleAlgo()
            End If

            tampilJudul() 'Menampilkan judul dan artis
        End If
    End Sub

    Private Sub timerjudul_tick(sender As Object, e As EventArgs) Handles TimerJudul.Tick
        'running Text judul
        If lblJudul.Left >= Me.Width Then
            lblJudul.Left = -lblJudul.Width
        Else
            lblJudul.Left = lblJudul.Left + 10
        End If
    End Sub
    Sub outqShuffle()
        Dim out As String = ""
        For i = 0 To queueShuffle.Count() - 1
            out += queueShuffle(i) & vbCrLf
        Next
        MessageBox.Show(out)
    End Sub

    Sub outqOri()
        Dim out As String = ""
        For i = 0 To playlistOri.Count() - 1
            out += playlistOri(i) & vbCrLf
        Next
        MessageBox.Show(out)
    End Sub
    Private Sub NormalPlaySong(sender As Object, e As EventArgs, indexLaguSkrg As Integer) 'kalau lagu abis lgsg next song. kalau udah ga ada lagu lagi stop playing.
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsUndefined Or
        AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            If playlistOri.Count > 0 And isStop = False Then
                'If playlistOri.Count > 0 Then
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
                    tampilJudul()
                Catch outRange As System.ArgumentOutOfRangeException
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg)
                    btnStop_Click(sender, e)
                    lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
                    lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)

                    TimerJudul.Enabled = False
                    Timer1.Enabled = False
                    btnPlay.Text = "play"
                    btnPlay.Image = Image.FromFile("images/play.png")

                    MessageBox.Show("End of Playlist", "DEBUG NormalPlaySong()")
                    isEnded = True
                End Try
            End If
        End If
    End Sub
    Private Sub RepeatPlaySong(indexLaguSkrg As Integer)
        AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg)
        tampilJudul()
    End Sub
    Private Sub RepeatPlaylistPlay(indexLaguSkrg As Integer) 'kalau lagu abis lgsg next song. kalau udah ga ada lagu lagi stop playing.
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsUndefined Or
        AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            If playlistOri.Count > 0 And isStop = False Then
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
                    tampilJudul()
                Catch outRange As System.ArgumentOutOfRangeException
                    AxWindowsMediaPlayer1.URL = playlistOri(0)
                    tampilJudul()
                End Try
            End If
        End If
    End Sub
    Private Sub ShufflePlay(sender As Object, e As EventArgs)
        If queueShuffle.Count = 0 Then
            shuffleAlgo()
            MessageBox.Show("Create Suffle Queue")
            outqShuffle()
        End If

        If (AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsUndefined Or
            AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped) And isStop = False Then

            Dim idxQueueShuffle As Integer
            If AxWindowsMediaPlayer1.currentMedia IsNot Nothing Then
                idxQueueShuffle = queueShuffle.IndexOf(AxWindowsMediaPlayer1.URL)
            End If

            Try
                If queueShuffle.Count > 1 Then
                    queueShuffle.RemoveAt(idxQueueShuffle)
                    AxWindowsMediaPlayer1.URL = queueShuffle(0)
                    tampilJudul()
                    MessageBox.Show("Next Shuffle Song")
                    outqShuffle()
                ElseIf queueShuffle.Count = 1 Then
                    If isRepeatPlaylist = True Then
                        AxWindowsMediaPlayer1.URL = queueShuffle(0)
                        tampilJudul()
                        queueShuffle.Clear()
                        shuffleAlgo()
                        MessageBox.Show("Repeat Shuffle")
                    ElseIf isRepeatPlaylist = False Then
                        AxWindowsMediaPlayer1.URL = queueShuffle(0)
                        tampilJudul()
                        btnStop_Click(sender, e)
                        lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
                        lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)

                        TimerJudul.Enabled = False
                        Timer1.Enabled = False
                        btnPlay.Text = "play"
                        btnPlay.Image = Image.FromFile("images/play.png")

                        outqShuffle()
                        MessageBox.Show("End of Playlist (isrepeat false)", "DEBUG ShufflePlay()")
                        isEnded = True
                    End If
                End If
            Catch outRange As System.ArgumentOutOfRangeException
                shuffleAlgo()
            End Try

        End If

    End Sub

    Private Sub DurationAndSeekBarSetter() 'buat set seekbar sama duration label
        If AxWindowsMediaPlayer1.currentMedia IsNot Nothing Then
            TrackBar1.Maximum = AxWindowsMediaPlayer1.currentMedia.duration
            TrackBar1.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition

            lblEndDuration.Text = AxWindowsMediaPlayer1.currentMedia.durationString
            lblStartDuration.Text = AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim indexLaguSkrg As Integer = playlistOri.IndexOf(AxWindowsMediaPlayer1.URL)
        AxWindowsMediaPlayer1.CreateControl()

        DurationAndSeekBarSetter() 'set seekbar & duration

        If isRepeatSong = True Then
            If AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying Then
                RepeatPlaySong(indexLaguSkrg) 'repeat song
            End If
        ElseIf isRepeatPlaylist = True And isShuffle = False Then
            RepeatPlaylistPlay(indexLaguSkrg)
        ElseIf isRepeatPlaylist = True And isShuffle = True Then
            ShufflePlay(sender, e)
        ElseIf isShuffle = True Then
            ShufflePlay(sender, e)
        Else
            NormalPlaySong(sender, e, indexLaguSkrg) 'normal play
        End If
    End Sub

    ' settingan buat volume
    Private Sub tbVolume_Scroll(sender As Object, e As EventArgs) Handles tbVolume.Scroll
        AxWindowsMediaPlayer1.settings.volume = tbVolume.Value
    End Sub

    'settingan buat seekbar
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim hms = TimeSpan.FromSeconds(TrackBar1.Value)
        If TrackBar1.Maximum > 3600 Then
            lblStartDuration.Text = $"{hms.Hours.ToString}:{hms.Minutes.ToString}:{hms.Seconds.ToString}"
        Else
            lblStartDuration.Text = $"{hms.Minutes.ToString}:{hms.Seconds.ToString}"
        End If
    End Sub

    'settingan buat seekbar
    Private Sub TrackBar1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseUp
        AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = TrackBar1.Value
        Timer1.Enabled = True
    End Sub

    'settingan buat seekbar
    Private Sub TrackBar1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseDown
        Timer1.Enabled = False
    End Sub

    Private Sub DownloadMusicToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DownloadMusicToolStripMenuItem1.Click
        frmDownload.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show($"This software built by {vbCrLf} Richard Lois Setiawan NIM.71200594 {vbCrLf} Haniif Ahmad Candraputra NIM. 71200660", "About this software", MessageBoxButtons.OK)
    End Sub

    Private Sub mainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub mainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.BalloonTipTitle = "MP3 Player"
            NotifyIcon1.Visible = True
            NotifyIcon1.Icon = Me.Icon
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            'Me.Hide()
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub MusicTagEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MusicTagEditorToolStripMenuItem.Click
        frmTagEditor.ShowDialog()
    End Sub

    Private Sub lvPlaylist_DoubleClick(sender As Object, e As EventArgs) Handles lvPlaylist.DoubleClick
        If lvPlaylist.SelectedItems.Count = 1 Then
            Dim pathSong As String
            For Each song In playlistOri
                If song.Contains(lvPlaylist.SelectedItems(0).Text) Then
                    pathSong = song
                    Exit For
                End If
            Next
            AxWindowsMediaPlayer1.URL = pathSong
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            lvPlaylist.SelectedItems.Clear()

            tampilJudul() 'tampilin judul
            Timer1.Enabled = True
            isStop = False
            isEnded = False
        End If
    End Sub

    Private Sub cmsDelete_Click(sender As Object, e As EventArgs) Handles cmsDelete.Click
        Try
            For Each song In playlistOri
                If song.Contains(lvPlaylist.SelectedItems(0).Text) Then
                    playlistOri.Remove(song)
                    lvPlaylist.SelectedItems.Clear()
                    Exit For
                End If
            Next
        Catch
        End Try
        'IO.File.WriteAllLines(filePlaylist, playlistOri)
        'loadPlaylist()
        loadToLv(playlistOri.Count)

        If playlistOri.Count = 0 Then
            ClearPlaylistToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

    End Sub

    Private Sub ClearPlaylistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearPlaylistToolStripMenuItem.Click
        'System.IO.File.WriteAllText(filePlaylist, "")
        'loadPlaylist()
        playlistOri.Clear()
        lstShuffle.Clear()
        lvPlaylist.Items.Clear()

        isShuffle = False
        isRepeatSong = False
        isRepeatPlaylist = False
        isStop = True
        isEnded = False

        btnRepeatPlaylist.FlatStyle = FlatStyle.Flat
        btnRepeatPlaylist.FlatAppearance.BorderSize = 0
        btnRepeatSong.FlatStyle = FlatStyle.Flat
        btnShuffle.FlatStyle = FlatStyle.Flat

        lblJudul.Text = "Judul"
        lblArtis.Text = "Artist"
        lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
        lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)
        btnStop.PerformClick()
        disableAllButton()
    End Sub

    Private Sub LyricsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LyricsToolStripMenuItem.Click
        If AxWindowsMediaPlayer1.currentMedia IsNot Nothing Then
            Try
                frmLirik.Show()
            Catch exDispose As System.ObjectDisposedException
                frmLirik = New frmLirik
                frmLirik.Show()
            End Try
        Else
            MessageBox.Show("Please play a song first before opening lyrics", "Error Message")
        End If
    End Sub

    Private Sub LoadPlaylistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadPlaylistToolStripMenuItem.Click
        If ofdPlaylist.ShowDialog = DialogResult.OK Then
            filePlaylist = ofdPlaylist.FileName
            enableAllButton()
            loadPlaylist()
        End If
    End Sub

    Private Sub SavePlaylistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavePlaylistToolStripMenuItem.Click
        If sfdPlaylist.ShowDialog = DialogResult.OK Then
            For i As Integer = 0 To playlistOri.Count - 1
                Dim objWriter As New System.IO.StreamWriter(sfdPlaylist.FileName, True)
                objWriter.WriteLine(playlistOri(i))
                objWriter.Close()
            Next
        End If
    End Sub
    Private Sub AddFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFileToolStripMenuItem.Click
        If ofd.ShowDialog = DialogResult.OK Then
            'For Each song In ofd.FileNames
            '    Dim objWriter As New System.IO.StreamWriter(filePlaylist, True)
            '    objWriter.WriteLine(song)
            '    objWriter.Close()
            'Next
            'loadPlaylist()
            Dim countAdd As Integer = 0
            For Each song In ofd.FileNames
                playlistOri.Add(song)
                lstShuffle.Add(song)
                countAdd += 1
            Next
            'loadToLv(countAdd)
            loadToLv(playlistOri.Count)

            enableAllButton()
        End If
    End Sub
End Class
