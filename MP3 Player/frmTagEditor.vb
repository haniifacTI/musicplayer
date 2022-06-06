Imports Id3
Public Class frmTagEditor
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or
        mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Or
        mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Or
        mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            mainForm.AxWindowsMediaPlayer1.Ctlcontrols.stop()
            mainForm.AxWindowsMediaPlayer1.close()
            mainForm.AxWindowsMediaPlayer1.URL = ""
        End If

        Dim songPath As String
        For Each song In mainForm.playlistOri
            If song.Contains(mainForm.lvPlaylist.SelectedItems(0).Text) Then
                songPath = song
                Exit For
            End If
        Next

        Dim file As Mp3 = New Mp3(songPath, Mp3Permissions.ReadWrite)
        Try
            Dim tag As Id3Tag = New Id3Tag()
            If file.HasTagOfVersion(Id3Version.V1X) Then
                tag = file.GetTag(Id3TagFamily.Version1X)
            ElseIf file.HasTagOfVersion(Id3Version.V23) Then
                tag = file.GetTag(Id3TagFamily.Version2X)
            End If
            If txtTrack.Text.Length > 0 Then
                If tag.Track.IsAssigned Then
                    tag.Track.Value = Val(txtTrack.Text)
                Else
                    Dim x As Frames.TrackFrame = New Frames.TrackFrame()
                    x.Value = Val(txtTrack.Text)
                    tag.Append(x)
                End If
            End If
            If txtTitle.Text.Length > 0 Then
                If tag.Title.IsAssigned Then
                    tag.Title.Value = txtTitle.Text
                Else
                    Dim x As Frames.TitleFrame = New Frames.TitleFrame()
                    x.Value = txtTitle.Text
                    tag.Append(x)
                End If
            End If
            If txtArtist.Text.Length > 0 Then
                If tag.Artists.IsAssigned Then
                    tag.Artists.Value.Add(txtArtist.Text)
                Else
                    Dim x As Frames.ArtistsFrame = New Frames.ArtistsFrame
                    x.Value.Add(txtArtist.Text)
                    tag.Append(x)
                End If
            End If
            If txtAlbum.Text.Length > 0 Then
                If tag.Album.IsAssigned Then
                    tag.Album.Value = txtAlbum.Text
                Else
                    Dim x As Frames.AlbumFrame = New Frames.AlbumFrame
                    x.Value = txtAlbum.Text
                    tag.Append(x)
                End If
            End If
            If txtYear.Text.Length > 0 Then
                If tag.Year.IsAssigned Then
                    tag.Year.Value = Val(txtYear.Text)
                Else
                    Dim x As Frames.YearFrame = New Frames.YearFrame
                    x.Value = Val(txtYear.Text)
                    tag.Append(x)
                End If
            End If
            file.WriteTag(tag, WriteConflictAction.Replace)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            txtTrack.ReadOnly = True
            txtTitle.ReadOnly = True
            txtArtist.ReadOnly = True
            txtAlbum.ReadOnly = True
            txtYear.ReadOnly = True
            file.Dispose()
        End Try
    End Sub

    Private Sub frmTagEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim file As Mp3 = New Mp3(mainForm.playlistPath & "\" & mainForm.lvPlaylist.SelectedItems(0).Text & ".mp3",
        '    Mp3Permissions.ReadWrite)
        txtTrack.ReadOnly = False
        txtTitle.ReadOnly = False
        txtArtist.ReadOnly = False
        txtAlbum.ReadOnly = False
        txtYear.ReadOnly = False

        Dim pathSong As String
        Dim file As Mp3
        Try
            For Each song In mainForm.playlistOri
                If song.Contains(mainForm.lvPlaylist.SelectedItems(0).Text) Then
                    pathSong = song
                    Exit For
                End If
            Next

            If mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or
            mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Or
            mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Or
            mainForm.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
                mainForm.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                mainForm.Timer1.Enabled = False
            End If
            file = New Mp3(pathSong, Mp3Permissions.ReadWrite)
            mainForm.AxWindowsMediaPlayer1.settings.autoStart = False
            If mainForm.lvPlaylist.SelectedItems.Count = 1 Then
                Dim tag As Id3Tag = New Id3Tag()
                If file.HasTags Then
                    If file.HasTagOfVersion(Id3Version.V1X) Then
                        tag = file.GetTag(Id3TagFamily.Version1X)
                    ElseIf file.HasTagOfVersion(Id3Version.V23) Then
                        tag = file.GetTag(Id3TagFamily.Version2X)
                    End If
                    txtTrack.Text = tag.Track
                    txtTitle.Text = tag.Title
                    If tag.Artists.Value.Count > 0 Then
                        txtArtist.Text = tag.Artists.Value(0)
                    End If
                    txtAlbum.Text = tag.Album
                    txtYear.Text = tag.Year
                Else
                    MsgBox("ID3 Track Not Found",, "ID3 Tag Editor")
                    txtTrack.Clear()
                    txtTitle.Clear()
                    txtArtist.Clear()
                    txtAlbum.Clear()
                    txtYear.Clear()
                End If
                file.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Silahkan pilih terlebih dahulu lagu yang ingin dilihat ID3-nya",, "Music Tag Editor")
            Me.Hide()
        End Try

    End Sub
End Class