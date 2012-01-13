Imports System.Net
Imports System.Net.Sockets

Public Class mainForm

    Dim tcpClient As TcpClient
    Dim networkStream As NetworkStream
    Dim cF As Boolean

    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cF = 1
        tcpClient = New TcpClient()
    End Sub


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If tcpClient.Connected Then
            If networkStream.CanWrite And networkStream.CanRead Then
                ' Do a simple write.
                Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes(tboxSend.Text)
                networkStream.Write(sendBytes, 0, sendBytes.Length)
                ' Read the NetworkStream into a byte buffer.
                Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
                ' Output the data received from the host to the console.
                Dim returndata As String = System.Text.Encoding.ASCII.GetString(bytes)
                tboxReceive.Text = returndata
            Else
                If Not networkStream.CanRead Then
                    Console.WriteLine("cannot not write data to this stream")
                    tcpClient.Close()
                Else
                    If Not networkStream.CanWrite Then
                        Console.WriteLine("cannot read data from this stream")
                        tcpClient.Close()
                    End If
                End If
            End If
            ' Pause so user can view the console output
            Console.ReadLine()
        Else
            MsgBox("Connect to Firefox first", MsgBoxStyle.Information, "Err")
        End If
    End Sub

    Private Sub ConnectFF(ByVal port As Integer)
        Try
            tcpClient.Connect("127.0.0.1", port)
            networkStream = tcpClient.GetStream()
        Catch ex As Exception
            MsgBox(ex.Message + vbCrLf + "Check if Firefox is running and FF Interface Extension is Started", MsgBoxStyle.Information, "Err")
        End Try

    End Sub

    Private Sub DisconnectFF()
        If tcpClient.Connected Then
            networkStream.Close()
            tcpClient.Close()
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If cF Then
            ConnectFF(5432)
            btnConnect.Text = "&Disconnect"
            cF = False
        Else
            DisconnectFF()
            cF = True
            btnConnect.Text = "&Connect"
        End If
    End Sub

    Private Sub mainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisconnectFF()
    End Sub

End Class
