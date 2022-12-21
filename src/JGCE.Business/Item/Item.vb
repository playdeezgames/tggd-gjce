Public Class Item
    Inherits Thingie
    Implements IItem

    Public Sub New(worldData As WorldData, world As World, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub

    Public ReadOnly Property ItemType As ItemTypes Implements IItem.ItemType
        Get
            Return CType(WorldData.Items(Id).ItemType, ItemTypes)
        End Get
    End Property
End Class
