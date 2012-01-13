<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Me.btnSend = New System.Windows.Forms.Button
        Me.tboxSend = New System.Windows.Forms.TextBox
        Me.tboxReceive = New System.Windows.Forms.TextBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.lblInput = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(209, 74)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(109, 24)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "&Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'tboxSend
        '
        Me.tboxSend.Location = New System.Drawing.Point(58, 48)
        Me.tboxSend.Name = "tboxSend"
        Me.tboxSend.Size = New System.Drawing.Size(442, 20)
        Me.tboxSend.TabIndex = 1
        '
        'tboxReceive
        '
        Me.tboxReceive.Location = New System.Drawing.Point(80, 104)
        Me.tboxReceive.Name = "tboxReceive"
        Me.tboxReceive.Size = New System.Drawing.Size(420, 20)
        Me.tboxReceive.TabIndex = 2
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(188, 12)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(161, 30)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.Text = "&Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Location = New System.Drawing.Point(11, 51)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(38, 13)
        Me.lblInput.TabIndex = 5
        Me.lblInput.Text = "Send :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Received : "
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 148)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.tboxReceive)
        Me.Controls.Add(Me.tboxSend)
        Me.Controls.Add(Me.btnSend)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "mainForm"
        Me.Text = "Firefox Interface"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents tboxSend As System.Windows.Forms.TextBox
    Friend WithEvents tboxReceive As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents lblInput As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
