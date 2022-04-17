Imports YoutubeExplode
Imports YoutubeExplode.Videos.Streams
Imports cs_ffmpeg_mp3_converter
Public Class frmDownload
    ReadOnly youtube As New YoutubeClient
    Dim video As Videos.Video
    Dim path As String
    Dim file As String

    Async Sub YT_Find(ByVal linkvid As String)
        If Not txtLink.Text = String.Empty Then
            Try
                video = Await youtube.Videos.GetAsync(linkvid)
                lblTitle.Text = video.Title
                lblArtist.Text = video.Author.Title
                lblDuration.Text = video.Duration.ToString
            Catch ex As System.ArgumentException
                MessageBox.Show("Please put an appropriate youtube link")
            End Try
        Else
            MessageBox.Show("Please input your youtube music link")
        End If

    End Sub

    Async Function YT_Download() As Task(Of Boolean)
        Dim streammanifest = Await youtube.Videos.Streams.GetManifestAsync(video.Id)
        Dim streaminfo = streammanifest.GetAudioOnlyStreams().GetWithHighestBitrate()
        Dim filename As String = $"{path}{lblTitle.Text}.tmp"
        file = filename

        'downloadnya
        Await youtube.Videos.Streams.DownloadAsync(streaminfo, filename)

        Return True
    End Function

    Private Sub frmDownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnClear_Click(sender, e)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        YT_Find(txtLink.Text)
        ssStatus.Text = "Ready"
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtTarget.Text = FolderBrowserDialog1.SelectedPath
            path = FolderBrowserDialog1.SelectedPath & "\"
            btnDownload.Enabled = True
        End If
    End Sub

    Private Async Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If txtLink.Text IsNot String.Empty Then
            ssStatus.Text = "Downloading..."

            For idx As Integer = 1 To 3 Step 1
                ToolStripProgressBar1.Value += 20
            Next

            Try
                If Await YT_Download() = True Then
                    ToolStripProgressBar1.Value += 20
                End If
                ssStatus.Text = "Converting..."
                cs_ffmpeg_mp3_converter.FFMpeg.Convert2Mp3(file, $"{path}{lblTitle.Text}.mp3")
                My.Computer.FileSystem.DeleteFile(file)
                ToolStripProgressBar1.Value += 20
                ssStatus.Text = "Done."
                MessageBox.Show("Download and Convert Completed")

            Catch ex As System.Net.Http.HttpRequestException
                MessageBox.Show("Make sure you are connected to Internet.")
            End Try

        Else
            MessageBox.Show("Please input your youtube music link.")
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblTitle.Text = ""
        lblArtist.Text = ""
        lblDuration.Text = ""
        ssStatus.Text = "Waiting for link"
        txtLink.Text = String.Empty
        ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        txtTarget.Text = String.Empty
        btnClear_Click(sender, e)
    End Sub
End Class
