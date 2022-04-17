﻿Imports System.IO
Imports Id3

Public Class mainForm
    Dim frmLirik As New frmLirik
    Dim playlistPath As String
    Dim shuffle As Boolean = False
    Dim repeatOne As Boolean = False
    Dim repeatPlaylist As Boolean = False

    Dim playlistOri As New List(Of String)
    Dim lstShuffle As New List(Of String)
    Dim queueShuffle As New List(Of String)
    Dim Index As Integer = 1 ' untuk timer1

    Dim startpath As String = Application.StartupPath

    Private Sub getFiles()
        lvPlaylist.Items.Clear()
        lvPlaylist.View = View.Details
        lvPlaylist.BeginUpdate()

        Dim tag As Id3Tag = New Id3Tag
        Dim hasil As String() = Directory.GetFiles(playlistPath, "*.mp3", SearchOption.TopDirectoryOnly)

        For i As Integer = 0 To hasil.Length - 1
            Dim lItem As New ListViewItem()
            Dim file As Mp3 = New Mp3(hasil(i), Mp3Permissions.Read)
            Dim fileName As String = Path.GetFileNameWithoutExtension(hasil(i))
            playlistOri.Add(playlistPath & "\" & fileName & ".mp3")
            lstShuffle.Add(playlistPath & "\" & fileName & ".mp3")

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

    'Private Sub shuffleSong()
    '    Dim rnd As New Random
    '    For i As Integer = 0 To lstShuffle.Count - 1
    '        Dim shuffleIndex = rnd.Next(0, lstShuffle.Count - 1)
    '        queueShuffle.Add(lstShuffle(shuffleIndex))
    '        lstShuffle.Remove(lstShuffle(shuffleIndex))
    '    Next
    'End Sub

    Private Sub AddPlaylistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPlaylistToolStripMenuItem.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            playlistPath = FolderBrowserDialog1.SelectedPath
            playlistOri.Clear()
            queueShuffle.Clear()
            lstShuffle.Clear()
            getFiles()

            btnStop.Enabled = True
            btnNext.Enabled = True
            btnPrev.Enabled = True
            btnRepeatPlaylist.Enabled = True
            btnRepeatSong.Enabled = True
            btnShuffle.Enabled = True
            btnLirik.Enabled = True
            TrackBar1.Enabled = True
            tbVolume.Enabled = True
        End If
    End Sub

    'Private Sub AxWindowsMediaPlayer1_CurrentItemChange(sender As Object, e As AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent) Handles AxWindowsMediaPlayer1.CurrentItemChange
    '    MessageBox.Show("CurrentItemChange: " & Me.AxWindowsMediaPlayer1.currentMedia.name)
    'End Sub

    'Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
    '    Select Case e.newState
    '        Case 1 ' Stopped
    '            MessageBox.Show("Stopped")

    '        Case 2    ' Paused
    '            MessageBox.Show("Paused")

    '        Case 3 ' Playing
    '            MessageBox.Show("Playing")

    '        Case 4 ' ScanForward
    '            MessageBox.Show("ScanForward")

    '        Case 5 ' ScanReverse
    '            MessageBox.Show("ScanReverse")

    '        Case 6 ' Buffering
    '            MessageBox.Show("Buffering")

    '        Case 7 ' Waiting
    '            MessageBox.Show("Waiting")

    '        Case 8 ' MediaEnded
    '            MessageBox.Show("MediaEnded")

    '        Case 9 ' Transitioning
    '            MessageBox.Show("Transitioning")

    '        Case 10 ' Ready
    '            MessageBox.Show("Ready")

    '        Case 11 ' Reconnecting
    '            MessageBox.Show("Reconnecting")

    '        Case 12 ' Last
    '            MessageBox.Show("Last")

    '        Case Else
    '            MessageBox.Show("Undefined/Unknown: " & e.newState)
    '    End Select
    'End Sub

    'Private Sub btnRepeatPlaylist_Click(sender As Object, e As EventArgs) Handles btnRepeatPlaylist.Click
    '    If playlistOri.Count = 0 Then
    '        MsgBox("Silahkan pilih folder playlist terlebih dahulu",, "Repeat Playlist")
    '    ElseIf repeatOne = True Or shuffle = True Then
    '        MsgBox("Repeat playlist tidak bisa dilakukan bersamaan dengan shuffle atau repeat one song",, "Repeat Playlist")
    '    ElseIf btnRepeatPlaylist.FlatStyle = FlatStyle.Standard Then
    '        repeatPlaylist = False
    '        btnRepeatPlaylist.FlatStyle = FlatStyle.Flat
    '        btnRepeatPlaylist.FlatAppearance.BorderSize = 0
    '    Else
    '        repeatPlaylist = True
    '        btnRepeatPlaylist.FlatStyle = FlatStyle.Standard
    '        btnRepeatPlaylist.FlatAppearance.BorderSize = 1
    '    End If
    'End Sub

    'Private Sub btnRepeatSong_Click(sender As Object, e As EventArgs) Handles btnRepeatSong.Click
    '    If playlistOri.Count = 0 Then
    '        MsgBox("Silahkan pilih folder playlist terlebih dahulu",, "Repeat One Song")
    '    ElseIf repeatPlaylist = True Or shuffle = True Then
    '        MsgBox("Repeat one song tidak bisa dilakukan bersamaan dengan shuffle atau repeat playlist",, "Repeat One Song")
    '    ElseIf lvPlaylist.SelectedItems.Count <> 1 Then
    '        MsgBox("Silahkan pilih lagu yang akan direpeat",, "Repeat One SOng")
    '    ElseIf btnRepeatSong.FlatStyle = FlatStyle.Standard Then
    '        repeatOne = False
    '        btnRepeatSong.FlatStyle = FlatStyle.Flat
    '        btnRepeatSong.FlatAppearance.BorderSize = 0
    '    Else
    '        repeatOne = True
    '        btnRepeatSong.FlatStyle = FlatStyle.Standard
    '        btnRepeatSong.FlatAppearance.BorderSize = 1
    '    End If
    'End Sub

    'Private Sub btnShuffle_Click(sender As Object, e As EventArgs) Handles btnShuffle.Click
    '    If playlistOri.Count = 0 Then
    '        MsgBox("Silahkan pilih folder playlist terlebih dahulu",, "Shuffle")
    '    ElseIf repeatOne = True Or repeatPlaylist = True Then
    '        MsgBox("Shuffle tidak bisa dilakukan bersamaan dengan repeat",, "Shuffle")
    '    ElseIf btnShuffle.FlatStyle = FlatStyle.Standard Then
    '        shuffle = False
    '        btnShuffle.FlatStyle = FlatStyle.Flat
    '        btnShuffle.FlatAppearance.BorderSize = 0
    '    Else
    '        shuffle = True
    '        btnShuffle.FlatStyle = FlatStyle.Standard
    '        btnShuffle.FlatAppearance.BorderSize = 1
    '        shuffleSong()
    '    End If
    'End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        lblStartDuration.Text = "00:00"
        btnPlay.Image = Image.FromFile("Images/play.png")
        btnPlay.Text = "play"
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        tbSong.Value = 0
        TrackBar1.Value = 0
        Timer1.Enabled = False
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        'Menandakan play
        If btnPlay.Text = "play" And Not AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then
            If playlistOri.Count <> 0 Then
                ''shuffle
                'If shuffle = True And repeatOne = False And repeatPlaylist = False Then
                '    AxWindowsMediaPlayer1.URL = queueShuffle(0)
                '    AxWindowsMediaPlayer1.Ctlcontrols.play()
                '    lstShuffle.Add(queueShuffle(0))
                '    queueShuffle.Remove(queueShuffle(0))

                '    'repeat one song
                'ElseIf shuffle = False And repeatOne = True And repeatPlaylist = False Then
                '    AxWindowsMediaPlayer1.Ctlcontrols.play()

                '    'repeat one playlist
                'ElseIf shuffle = False And repeatOne = False And repeatPlaylist = True Then
                '    AxWindowsMediaPlayer1.URL = playlistOri(0)
                '    AxWindowsMediaPlayer1.Ctlcontrols.play()

                '    'play sesuai pilihan
                'ElseIf lvPlaylist.SelectedItems.Count = 1 Then
                '    AxWindowsMediaPlayer1.URL = playlistPath & "\" & lvPlaylist.SelectedItems(0).Text & ".mp3"
                '    AxWindowsMediaPlayer1.Ctlcontrols.play()

                '    'play normal
                'Else
                '    AxWindowsMediaPlayer1.URL = playlistOri(0)
                '    If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Then
                '        AxWindowsMediaPlayer1.Ctlcontrols.play()
                '    End If
                'End If

                'If AxWindowsMediaPlayer1.currentMedia Is Nothing Then
                '    AxWindowsMediaPlayer1.URL = playlistOri(0)
                '    AxWindowsMediaPlayer1.Ctlcontrols.play()
                'End If

                'If AxWindowsMediaPlayer1.currentMedia Is Nothing Then
                '    AxWindowsMediaPlayer1.URL = playlistOri(0)
                '    AxWindowsMediaPlayer1.Ctlcontrols.play()
                'End If
                Timer1.Enabled = True
                btnPlay.Image = Image.FromFile("Images/pause.png")
                btnPlay.Text = "pause"

                'tampilin judul
                If AxWindowsMediaPlayer1.currentMedia Is Nothing Then
                    AxWindowsMediaPlayer1.URL = playlistOri(0)
                End If

                tampilJudul()

            Else
                    MsgBox("Silahkan pilih folder playlist terlebih dahulu",, "Play")
            End If

            'runningtext
            TimerJudul.Enabled = True


            'Menandakan Pause
        ElseIf btnPlay.Text = "play" And AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            'Timer1.Enabled = True
        Else
            btnPlay.Image = Image.FromFile("Images/play.png")
            btnPlay.Text = "play"
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
            'Timer1.Enabled = False
        End If
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
            lblJudul.Text = AxWindowsMediaPlayer1.URL.Split("\")(AxWindowsMediaPlayer1.URL.Split("\").Count - 1)
            lblArtis.Text = "Unknown Artist"
        End If
        lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
        lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim indexLaguSkrg As Integer = playlistOri.IndexOf(AxWindowsMediaPlayer1.URL)
        Index -= 1
        If playlistOri.Count <> 0 Then
            'Shuffle
            If shuffle = True And repeatOne = False And repeatPlaylist = False Then
                Dim indexShuffle As Integer = queueShuffle.IndexOf(AxWindowsMediaPlayer1.URL)
                Try
                    AxWindowsMediaPlayer1.URL = queueShuffle(indexShuffle - 1)
                    lstShuffle.Add(queueShuffle(indexShuffle - 1))
                    queueShuffle.Remove(queueShuffle(indexShuffle - 1))
                Catch
                    AxWindowsMediaPlayer1.URL = queueShuffle(queueShuffle.Count - 1)
                    lstShuffle.Add(queueShuffle(queueShuffle.Count - 1))
                    queueShuffle.Remove(queueShuffle(queueShuffle.Count - 1))
                End Try
                AxWindowsMediaPlayer1.Ctlcontrols.play()

                'Repeat one song
            ElseIf shuffle = False And repeatOne = True And repeatPlaylist = False Then
                AxWindowsMediaPlayer1.Ctlcontrols.play()

                'Repeat one playlist
            ElseIf shuffle = False And repeatOne = False And repeatPlaylist = True Then
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg - 1)
                Catch
                    AxWindowsMediaPlayer1.URL = playlistOri(playlistOri.Count - 1)
                End Try
                AxWindowsMediaPlayer1.Ctlcontrols.play()

                'Play sesuai pilihan
            ElseIf lvPlaylist.SelectedItems.Count = 1 Then
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg - 1)
                Catch
                    AxWindowsMediaPlayer1.URL = playlistOri(playlistOri.Count - 1)
                End Try

                'Play normal
            Else
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg - 1)
                Catch
                    AxWindowsMediaPlayer1.URL = playlistOri(playlistOri.Count - 1)
                End Try
            End If
            Timer1.Enabled = True
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"

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
                lblJudul.Text = AxWindowsMediaPlayer1.URL.Split("\")(AxWindowsMediaPlayer1.URL.Split("\").Count - 1)
                lblArtis.Text = "Artist"
            End If

            lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
            lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)
        Else
            MsgBox("Silahkan pilih folder playlist terlebih dahulu",, "Play")
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim indexLaguSkrg As Integer = playlistOri.IndexOf(AxWindowsMediaPlayer1.URL)
        Index += 1
        If playlistOri.Count <> 0 Then
            'Shuffle
            If shuffle = True And repeatOne = False And repeatPlaylist = False Then
                Dim indexShuffle As Integer = queueShuffle.IndexOf(AxWindowsMediaPlayer1.URL)
                Try
                    AxWindowsMediaPlayer1.URL = queueShuffle(indexShuffle + 1)
                    lstShuffle.Add(queueShuffle(indexShuffle + 1))
                    queueShuffle.Remove(queueShuffle(indexShuffle + 1))
                Catch
                    AxWindowsMediaPlayer1.URL = queueShuffle(0)
                    lstShuffle.Add(queueShuffle(0))
                    queueShuffle.Remove(queueShuffle(0))
                End Try
                AxWindowsMediaPlayer1.Ctlcontrols.play()

                'Repeat one song
            ElseIf shuffle = False And repeatOne = True And repeatPlaylist = False Then
                AxWindowsMediaPlayer1.Ctlcontrols.play()

                'Repeat one playlist
            ElseIf shuffle = False And repeatOne = False And repeatPlaylist = True Then
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
                Catch
                    AxWindowsMediaPlayer1.URL = playlistOri(0)
                End Try
                AxWindowsMediaPlayer1.Ctlcontrols.play()

                'Play sesuai pilihan
            ElseIf lvPlaylist.SelectedItems.Count = 1 Then
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
                Catch
                    AxWindowsMediaPlayer1.URL = playlistOri(0)
                End Try

                'Play normal
            Else
                Try
                    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
                Catch
                    AxWindowsMediaPlayer1.URL = playlistOri(0)
                End Try
            End If
            Timer1.Enabled = True
            btnPlay.Image = Image.FromFile("Images/pause.png")
            btnPlay.Text = "pause"

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
                lblJudul.Text = AxWindowsMediaPlayer1.URL.Split("\")(AxWindowsMediaPlayer1.URL.Split("\").Count - 1)
                lblArtis.Text = "Artist"
            End If

            lblJudul.Left = (Me.Width / 2.2) - (lblJudul.Width / 2)
            lblArtis.Left = (Me.Width / 2.2) - (lblArtis.Width / 2)
        Else
            MsgBox("Silahkan pilih folder playlist terlebih dahulu",, "Play")
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AxWindowsMediaPlayer1.CreateControl()

        If AxWindowsMediaPlayer1.currentMedia IsNot Nothing Then
            'Progress bar untuk lagu
            'tbSong.Maximum = AxWindowsMediaPlayer1.currentMedia.duration
            'tbSong.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
            'tbSong.Increment(1)

            TrackBar1.Maximum = AxWindowsMediaPlayer1.currentMedia.duration
            TrackBar1.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition

            lblEndDuration.Text = AxWindowsMediaPlayer1.currentMedia.durationString
            lblStartDuration.Text = AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString
        End If


        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsUndefined Or
        AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            If playlistOri.Count > 0 Then
                Try
                    'AxWindowsMediaPlayer1.currentMedia = AxWindowsMediaPlayer1.newMedia(playlistOri(Index))
                    AxWindowsMediaPlayer1.URL = (playlistOri(Index))
                    Index += 1
                    tampilJudul()
                Catch outRange As System.ArgumentOutOfRangeException
                    TimerJudul.Enabled = False
                    Timer1.Enabled = False
                    MessageBox.Show("END")
                    'Index = -1
                End Try

                'If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsMediaEnded Then
                '    TimerJudul.Enabled = False
                'End If
            End If
        End If

        'Dim indexLaguSkrg As Integer = playlistOri.IndexOf(AxWindowsMediaPlayer1.URL)

        'If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsTransitioning And AxWindowsMediaPlayer1.currentMedia IsNot Nothing Then
        '    AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
        '    AxWindowsMediaPlayer1.Ctlcontrols.play()
        '    Timer1.Enabled = False
        '    tampilJudul()
        'End If

        ''Shuffle
        'If shuffle = True And repeatOne = False And repeatPlaylist = False Then
        '    If queueShuffle.Count < 1 Then
        '        shuffleSong()
        '    End If
        '    If tbSong.Value = tbSong.Maximum Then
        '        AxWindowsMediaPlayer1.URL = queueShuffle(0)
        '        AxWindowsMediaPlayer1.Ctlcontrols.play()
        '        lstShuffle.Add(queueShuffle(0))
        '        queueShuffle.Remove(queueShuffle(0))
        '    End If

        '    'Repeat one song
        'ElseIf shuffle = False And repeatOne = True And repeatPlaylist = False Then
        '    If tbSong.Value = tbSong.Maximum Then
        '        AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg)
        '        AxWindowsMediaPlayer1.Ctlcontrols.play()
        '    End If

        '    'Repeat one playlist
        'ElseIf shuffle = False And repeatOne = False And repeatPlaylist = True Then
        '    If tbSong.Value = tbSong.Maximum Then
        '        Try
        '            AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg + 1)
        '            AxWindowsMediaPlayer1.Ctlcontrols.play()
        '        Catch
        '            AxWindowsMediaPlayer1.URL = playlistOri(0)
        '            AxWindowsMediaPlayer1.Ctlcontrols.play()
        '        End Try
        '    End If

        '    'Play Normal
        'Else
        '    If tbSong.Value >= tbSong.Maximum Then
        '        Try
        '            AxWindowsMediaPlayer1.URL = playlistOri(indexLaguSkrg)
        '            AxWindowsMediaPlayer1.Ctlcontrols.play()
        '        Catch
        '        End Try
        '    End If
        'End If
    End Sub


    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbVolume.Value = 30
        lblEndDuration.Text = "00:00"
        lblStartDuration.Text = "00:00"
        btnStop.Enabled = False
        btnNext.Enabled = False
        btnPrev.Enabled = False
        btnRepeatPlaylist.Enabled = False
        btnRepeatSong.Enabled = False
        btnShuffle.Enabled = False
        btnLirik.Enabled = False
        TrackBar1.Enabled = False
        tbVolume.Enabled = False
    End Sub

    Private Sub btnLirik_Click(sender As Object, e As EventArgs) Handles btnLirik.Click
        If AxWindowsMediaPlayer1.currentMedia IsNot Nothing Then
            frmLirik.ShowDialog()
        Else
            MessageBox.Show("Please play a song first before opening lyric", "Error Message")
        End If
    End Sub

    Private Sub tbVolume_Scroll(sender As Object, e As EventArgs) Handles tbVolume.Scroll
        AxWindowsMediaPlayer1.settings.volume = tbVolume.Value
    End Sub

    Private Sub TrackBar1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseUp
        AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = TrackBar1.Value
        Timer1.Enabled = True
    End Sub

    Private Sub TrackBar1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseDown
        Timer1.Enabled = False
    End Sub

    Private Sub TrackBar1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.MouseLeave
        'Timer1.Enabled = True
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

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim hms = TimeSpan.FromSeconds(TrackBar1.Value)
        If TrackBar1.Maximum > 3600 Then
            lblStartDuration.Text = $"{hms.Hours.ToString}:{hms.Minutes.ToString}:{hms.Seconds.ToString}"
        Else
            lblStartDuration.Text = $"{hms.Minutes.ToString}:{hms.Seconds.ToString}"
        End If
    End Sub


End Class