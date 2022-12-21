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

    Friend Shared Function Create(worldData As WorldData, world As World, itemType As ItemTypes) As IItem
        Dim itemId = If(worldData.Items.Any, worldData.Items.Keys.Max + 1, 0)
        worldData.Items(itemId) = New ItemData With {.ItemType = itemType}
        Return New Item(worldData, world, itemId)
    End Function
End Class
