<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.cmdGen = New System.Windows.Forms.Button()
        Me.txtProdID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProdKey = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdGen
        '
        Me.cmdGen.Location = New System.Drawing.Point(270, 80)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(75, 23)
        Me.cmdGen.TabIndex = 0
        Me.cmdGen.Text = "Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'txtProdID
        '
        Me.txtProdID.Location = New System.Drawing.Point(87, 26)
        Me.txtProdID.Name = "txtProdID"
        Me.txtProdID.Size = New System.Drawing.Size(258, 20)
        Me.txtProdID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Product ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Product Key"
        '
        'txtProdKey
        '
        Me.txtProdKey.Location = New System.Drawing.Point(87, 54)
        Me.txtProdKey.Name = "txtProdKey"
        Me.txtProdKey.ReadOnly = True
        Me.txtProdKey.Size = New System.Drawing.Size(258, 20)
        Me.txtProdKey.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 111)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProdKey)
        Me.Controls.Add(Me.txtProdID)
        Me.Controls.Add(Me.cmdGen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "KeyMaker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents txtProdID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProdKey As System.Windows.Forms.TextBox

End Class
