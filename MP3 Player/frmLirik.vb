Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmLirik
    Dim startpath As String = Application.StartupPath
    Dim isLyricFound As Boolean = False

    Private Function removeIdentifierOnLyrics(ByVal txt As String) 'Regex buat ngilangin [] di lirik
        Dim txtLines() As String = txt.Split(Environment.NewLine)
        Dim cleanResult As String = ""
        For Each line In txtLines
            cleanResult = cleanResult & Regex.Replace(line, "[\[\]]", "==") & vbCrLf
        Next
        Return cleanResult
    End Function

    Private Sub frmLirik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnEdit.Enabled = False
        btnSave.Enabled = False

        Try
            If Not File.Exists(startpath & "\Lyrics.txt") Then
                File.Create(startpath & "\Lyrics.txt")
            End If
        Catch ex As Exception
            MsgBox("Lyrics.txt not found, creating one...")
        End Try

        LoadExistingLyrics()
    End Sub

    Private Sub AddLyricsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddLyricsToolStripMenuItem.Click
        If isLyricFound = False Then
            rtbLirik.ReadOnly = False
            btnSave.Enabled = True
            MsgBox("Please paste your music lyrics down below, and save it after you paste")
        ElseIf isLyricFound = True Then
            MsgBox("This music already have a lyrics, Click Edit Button if you want to edit the lyrics")
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If isLyricFound = True Then
            'btnSave.Enabled = True
            'rtbLirik.ReadOnly = False
            'MsgBox("Edit Mode")
            MsgBox("Under Development.")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If rtbLirik.Text IsNot Nothing Then
            Dim cleanLyrics As String = removeIdentifierOnLyrics(rtbLirik.Text) 'Regex buat ngilangin tanda [ dan ]
            If isLyricFound = False Then
                Dim fileWrite As System.IO.StreamWriter
                fileWrite = My.Computer.FileSystem.OpenTextFileWriter(startpath & "\Lyrics.txt", True)
                fileWrite.WriteLine("[" & Path.GetFileNameWithoutExtension(mainForm.AxWindowsMediaPlayer1.URL) & "]")
                fileWrite.WriteLine(cleanLyrics & vbCrLf)
                fileWrite.Close()
                rtbLirik.Text = cleanLyrics
                rtbLirik.ReadOnly = True
                btnEdit.Enabled = True
                btnSave.Enabled = False
                MsgBox("Successfully saved.")
            Else
                EditLyrics()
            End If
        Else
            MsgBox("Paste your lyrics first before saving it.")
        End If
    End Sub
    Private Sub EditLyrics()
        MsgBox("Under Development")
    End Sub

    Private Sub LoadExistingLyrics()
        Dim lyrics As String = Nothing
        Dim fileRead = IO.File.ReadAllText(startpath & "\Lyrics.txt")
        Dim reader = File.OpenText(startpath & "\Lyrics.txt")
        Dim line As String
        Dim endLyric As Boolean = False
        Dim founded As Boolean = False

        If fileRead.Contains(Path.GetFileNameWithoutExtension(mainForm.AxWindowsMediaPlayer1.URL)) Then
            While reader.Peek <> -1
                line = reader.ReadLine

                If founded = False And Not line.Contains("[") Then
                    Continue While
                ElseIf line.Contains($"[{Path.GetFileNameWithoutExtension(mainForm.AxWindowsMediaPlayer1.URL)}]") Or founded = True Then
                    founded = True
                    isLyricFound = True

                    If Not line.Contains("[") Then
                        lyrics = lyrics & line & vbCrLf
                    ElseIf line.Contains("[") And Not line.Contains($"[{Path.GetFileNameWithoutExtension(mainForm.AxWindowsMediaPlayer1.URL)}]") Then
                        endLyric = True
                        founded = False
                        Exit While
                    End If
                End If
            End While
            btnEdit.Enabled = True
            rtbLirik.Text = lyrics
        Else
            MsgBox("This Music lyrics is not yet added. Go to File > Add Lyrics.",, "Lyrics")
            isLyricFound = False
            rtbLirik.Text = Nothing
        End If

        reader.Close()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        rtbLirik.Text = Nothing
        LoadExistingLyrics()
    End Sub
End Class