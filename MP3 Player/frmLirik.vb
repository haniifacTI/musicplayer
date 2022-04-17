Imports System.IO

Public Class frmLirik
    Dim ini As New IniFile
    Dim startpath As String = Application.StartupPath

    Private Sub frmLirik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lyrics As String = Nothing
        Try
            If Not File.Exists(startpath & "\Lyrics.txt") Then
                File.Create(startpath & "\Lyrics.txt")
            End If
        Catch ex As Exception
        End Try

        Dim fileRead = IO.File.ReadAllText(startpath & "\Lyrics.txt")
        Dim reader = File.OpenText(startpath & "\Lyrics.txt")
        Dim line As String
        Dim endLyric As Boolean = False

        If fileRead.Contains(Path.GetFileNameWithoutExtension(mainForm.AxWindowsMediaPlayer1.URL)) Then
            While reader.Peek <> -1
                line = reader.ReadLine
                If line.Contains("[") And endLyric = True Then
                    Exit While
                ElseIf line.Contains("[") Then
                    endLyric = True
                    Continue While
                Else
                    lyrics = lyrics & line & vbCrLf
                End If
            End While
        Else
            MsgBox("Lirik belum ditambahkan" & vbCrLf & "Tambahkan lirik terlebih dahulu",, "Lyrics")
        End If

        reader.Close()
        rtbLirik.Text = lyrics
    End Sub

    Private Sub AddLyricsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddLyricsToolStripMenuItem.Click
        rtbLirik.ReadOnly = False
        Try
            If Not file.Exists(startpath & "\Lyrics.txt") Then
                file.Create(startpath & "\Lyrics.txt")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim fileWrite As System.IO.StreamWriter
        fileWrite = My.Computer.FileSystem.OpenTextFileWriter(startpath & "\Lyrics.txt", True)
        fileWrite.WriteLine("[" & Path.GetFileNameWithoutExtension(mainForm.AxWindowsMediaPlayer1.URL) & "]")
        fileWrite.WriteLine(rtbLirik.Text)
        fileWrite.Close()
    End Sub
End Class