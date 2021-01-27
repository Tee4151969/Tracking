
Namespace DiagramFirstLook
    Partial Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.RadRibbonBar1 = New Telerik.WinControls.UI.RadRibbonBar()
            CType(Me.RadRibbonBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RadRibbonBar1
            '
            Me.RadRibbonBar1.Location = New System.Drawing.Point(0, 0)
            Me.RadRibbonBar1.Name = "RadRibbonBar1"
            Me.RadRibbonBar1.Size = New System.Drawing.Size(292, 148)
            Me.RadRibbonBar1.TabIndex = 0
            '
            'Form1
            '
            Me.ClientSize = New System.Drawing.Size(292, 295)
            Me.Controls.Add(Me.RadRibbonBar1)
            Me.Name = "Form1"
            '
            '
            '
            Me.RootElement.ApplyShapeToControl = True
            CType(Me.RadRibbonBar1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private diagramRibbonBar1 As Telerik.WinControls.UI.DiagramRibbonBar
        Private radDiagramToolbox1 As Telerik.WinControls.UI.RadDiagramToolbox
        Private radPropertyGrid1 As Telerik.WinControls.UI.RadPropertyGrid
        Private radDiagram1 As Telerik.WinControls.UI.RadDiagram
        Private radGroupBox1 As Telerik.WinControls.UI.RadGroupBox
        Private radGroupBox2 As Telerik.WinControls.UI.RadGroupBox
        Private dropDownExample As Telerik.WinControls.UI.RadDropDownListElement
        Private radDropDownList1 As Telerik.WinControls.UI.RadDropDownList
        Friend WithEvents RadRibbonBar1 As Telerik.WinControls.UI.RadRibbonBar
    End Class
End Namespace


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
