Public Class frmTagEditor
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            txtTrack.ReadOnly = False
            txtTitle.ReadOnly = False
            txtArtist.ReadOnly = False
            txtAlbum.ReadOnly = False
            txtYear.ReadOnly = False
            btnEdit.Text = "Save"
        Else
            If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or
            AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Or
            AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Or
            AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
                Timer1.Enabled = False
                btnPlay.Text = "Play"
                lblPlaying.Text = "00:00"
                AxWindowsMediaPlayer1.close()
                AxWindowsMediaPlayer1.URL = ""
            End If
            Dim file As Mp3 = New Mp3(lvMp3.SelectedItems(0).Tag.ToString,
            Mp3Permissions.ReadWrite)
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
            btnEdit.Text = "Edit"
        End If
    End Sub
End Class