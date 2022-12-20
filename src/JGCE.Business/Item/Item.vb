Public Class Item
    Inherits Thingie
    Implements IItem

    Public Sub New(worldData As WorldData, world As World, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub
End Class
