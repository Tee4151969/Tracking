Public Class Cls_Random

    Public Shared Function Color_Random_Back() As Color
        Dim MyRed As Integer
        Dim MyGreen As Integer
        Dim MyBlue As Integer
        Dim BackColor As System.Drawing.Color = Nothing
        Randomize()
        MyRed = CInt(Int((254 * Rnd()) + 0))
        Randomize()
        MyGreen = CInt(Int((254 * Rnd()) + 0))
        Randomize()
        MyBlue = CInt(Int((254 * Rnd()) + 0))

        BackColor = Color.FromArgb(MyRed, MyGreen, MyBlue)
         
        Return BackColor
    End Function

    Public Shared Function Color_Random_Fore() As Color
        Dim MyRed As Integer
        Dim MyGreen As Integer
        Dim MyBlue As Integer
        Dim ForeColor As System.Drawing.Color = Nothing
        Randomize()
        MyRed = CInt(Int((125 * Rnd()) + 0))
        Randomize()
        MyGreen = CInt(Int((150 * Rnd()) + 0))
        Randomize()
        MyBlue = CInt(Int((100 * Rnd()) + 0))
        ForeColor = Color.FromArgb(MyRed, MyGreen, MyBlue)
         
        Return ForeColor
    End Function
    Public Shared Function Color_Random() As objReturnColor
        Dim MyAlpha As Integer
        Dim MyRed As Integer
        Dim MyGreen As Integer
        Dim MyBlue As Integer

        Dim ObjResult As objReturnColor = Nothing

        Dim ForeColor As System.Drawing.Color = Nothing
        Dim BackColor As System.Drawing.Color = Nothing
        Randomize()
        MyAlpha = CInt(Int((254 * Rnd()) + 0))
        Randomize()
        MyRed = CInt(Int((254 * Rnd()) + 0))
        Randomize()
        MyGreen = CInt(Int((254 * Rnd()) + 0))
        Randomize()
        MyBlue = CInt(Int((254 * Rnd()) + 0))


        BackColor = Color.FromArgb(MyAlpha, MyRed, MyGreen, MyBlue)

        Randomize()
        MyRed = CInt(Int((125 * Rnd()) + 0))
        Randomize()
        MyGreen = CInt(Int((150 * Rnd()) + 0))
        Randomize()
        MyBlue = CInt(Int((100 * Rnd()) + 0))
        ForeColor = Color.FromArgb(MyRed, MyGreen, MyBlue)

        ObjResult = New objReturnColor
        ObjResult.BackColor = BackColor
        ObjResult.ForeColor = ForeColor
        Return ObjResult
    End Function


End Class
Public Class objReturnColor
    Private _BackColor As System.Drawing.Color
    Private _ForeColor As System.Drawing.Color
    Property BackColor As System.Drawing.Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            _BackColor = value
        End Set
    End Property
    Property ForeColor As System.Drawing.Color
        Get
            Return _ForeColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            _ForeColor = value
        End Set
    End Property



End Class
