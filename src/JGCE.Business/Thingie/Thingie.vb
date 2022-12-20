Public Class Thingie
    Inherits BaseThingie
    Implements IThingie
    Public Sub New(worldData As WorldData, world As World, id As Integer)
        MyBase.New(worldData, world)
        Me.Id = id
    End Sub
    Public ReadOnly Property Id As Integer Implements IThingie.Id
End Class
