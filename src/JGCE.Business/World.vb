Public Class World
    Implements IWorld
    Public Shared Function Create() As IWorld
        Return New World
    End Function
End Class
