Public Class clsKeyMaker
    Dim bValidity As Boolean
    Dim bTemp As Boolean
    Dim dValidityDate As Date
    Public Sub New(ByVal Key As String)
        If Key <> "ebsl.lk#1234" Then
            bValidity = False
        Else
            bValidity = True
        End If

    End Sub
    Private Function HDDId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" & _
            "{impersonationLevel=impersonate}!\\" & _
            computer & "\root\cimv2")
        Dim HDDs As Object = wmi.ExecQuery("Select * from " & _
            "Win32_PhysicalMedia")

        Dim HDD_SN As String = ""
        'cpu_ids = CObj(processors(0)).SerialNumber

        For Each HDD As Object In HDDs
            HDD_SN = HDD_SN & ", " & HDD.SerialNumber
            Exit For
        Next HDD
        If HDD_SN.Length > 0 Then HDD_SN = _
            HDD_SN.Substring(2)

        Return HDD_SN
    End Function
    Public Property Trial As Boolean
        Get
            Return bTemp
        End Get
        Set(ByVal value As Boolean)
            bTemp = value
        End Set
    End Property
    Public Property Validity_Period As Date
        Get
            Return dValidityDate
        End Get
        Set(ByVal value As Date)
            dValidityDate = value
        End Set
    End Property
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

    Public Function GetKey(ByVal ProductID As String) As String
        Dim K As String = ""
        Try
            K = Trim(CpuId)
            K = K & Trim(ProductID)
            K = K & Trim(HDDId)
        Catch ex As Exception

        End Try
        If bValidity = True Then
            Return K
        Else
            Return ""
        End If

    End Function
End Class
