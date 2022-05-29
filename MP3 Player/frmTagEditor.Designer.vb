<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTagEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTagEditor))
        Me.lblMp3Editor = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.txtAlbum = New System.Windows.Forms.TextBox()
        Me.txtArtist = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtTrack = New System.Windows.Forms.TextBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblAlbum = New System.Windows.Forms.Label()
        Me.lblArtist = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTrack = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblMp3Editor
        '
        Me.lblMp3Editor.AutoSize = True
        Me.lblMp3Editor.Font = New System.Drawing.Font("Bahnschrift", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMp3Editor.Location = New System.Drawing.Point(25, 26)
        Me.lblMp3Editor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMp3Editor.Name = "lblMp3Editor"
        Me.lblMp3Editor.Size = New System.Drawing.Size(242, 41)
        Me.lblMp3Editor.TabIndex = 8
        Me.lblMp3Editor.Text = "MP3 ID3 Editor"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(293, 263)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 28)
        Me.btnEdit.TabIndex = 29
        Me.btnEdit.Text = "Save"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(149, 223)
        Me.txtYear.Margin = New System.Windows.Forms.Padding(4)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(68, 22)
        Me.txtYear.TabIndex = 28
        '
        'txtAlbum
        '
        Me.txtAlbum.Location = New System.Drawing.Point(149, 191)
        Me.txtAlbum.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAlbum.Name = "txtAlbum"
        Me.txtAlbum.Size = New System.Drawing.Size(243, 22)
        Me.txtAlbum.TabIndex = 27
        '
        'txtArtist
        '
        Me.txtArtist.Location = New System.Drawing.Point(149, 159)
        Me.txtArtist.Margin = New System.Windows.Forms.Padding(4)
        Me.txtArtist.Name = "txtArtist"
        Me.txtArtist.Size = New System.Drawing.Size(243, 22)
        Me.txtArtist.TabIndex = 26
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(149, 127)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(243, 22)
        Me.txtTitle.TabIndex = 25
        '
        'txtTrack
        '
        Me.txtTrack.Location = New System.Drawing.Point(149, 95)
        Me.txtTrack.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTrack.Name = "txtTrack"
        Me.txtTrack.Size = New System.Drawing.Size(243, 22)
        Me.txtTrack.TabIndex = 24
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.Location = New System.Drawing.Point(27, 217)
        Me.lblYear.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(77, 32)
        Me.lblYear.TabIndex = 23
        Me.lblYear.Text = "Year : "
        '
        'lblAlbum
        '
        Me.lblAlbum.AutoSize = True
        Me.lblAlbum.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbum.Location = New System.Drawing.Point(27, 185)
        Me.lblAlbum.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlbum.Name = "lblAlbum"
        Me.lblAlbum.Size = New System.Drawing.Size(103, 32)
        Me.lblAlbum.TabIndex = 22
        Me.lblAlbum.Text = "Album : "
        '
        'lblArtist
        '
        Me.lblArtist.AutoSize = True
        Me.lblArtist.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtist.Location = New System.Drawing.Point(27, 153)
        Me.lblArtist.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArtist.Name = "lblArtist"
        Me.lblArtist.Size = New System.Drawing.Size(88, 32)
        Me.lblArtist.TabIndex = 21
        Me.lblArtist.Text = "Artist : "
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(27, 121)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(79, 32)
        Me.lblTitle.TabIndex = 20
        Me.lblTitle.Text = "Title : "
        '
        'lblTrack
        '
        Me.lblTrack.AutoSize = True
        Me.lblTrack.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrack.Location = New System.Drawing.Point(25, 90)
        Me.lblTrack.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTrack.Name = "lblTrack"
        Me.lblTrack.Size = New System.Drawing.Size(87, 32)
        Me.lblTrack.TabIndex = 19
        Me.lblTrack.Text = "Track : "
        '
        'frmTagEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 330)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.txtAlbum)
        Me.Controls.Add(Me.txtArtist)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtTrack)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblAlbum)
        Me.Controls.Add(Me.lblArtist)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTrack)
        Me.Controls.Add(Me.lblMp3Editor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmTagEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tag Editor"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMp3Editor As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents txtYear As TextBox
    Friend WithEvents txtAlbum As TextBox
    Friend WithEvents txtArtist As TextBox
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtTrack As TextBox
    Friend WithEvents lblYear As Label
    Friend WithEvents lblAlbum As Label
    Friend WithEvents lblArtist As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTrack As Label
End Class
