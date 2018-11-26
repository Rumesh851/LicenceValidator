Imports System.Management

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        If txtProdID.Text <> "" Then
            Dim obj As New Keymaker.clsKeyMaker("ebsl.lk#1234")
            txtProdKey.Text = obj.GetKey(txtProdID.Text)
        End If
       
    End Sub
    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
            "{impersonationLevel=impersonate}!\\" & _
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " & _
            "Win32_Processor")

        Dim cpu_ids As String = ""

        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorID
            Exit For
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = _
            cpu_ids.Substring(2)

        Return cpu_ids
    End Function
    Private Function HDDId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
            "{impersonationLevel=impersonate}!\\" & _
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " & _
            "Win32_DiskDrive")

        Dim cpu_ids As String = ""
        'cpu_ids = CObj(processors(0)).SerialNumber

        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.SerialNumber
            Exit For
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = _
            cpu_ids.Substring(2)

        Return cpu_ids
    End Function
End Class
