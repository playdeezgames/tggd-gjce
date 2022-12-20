Public Class Route
    Inherits BaseThingie
    Implements IRoute
    Private ReadOnly FromLocationId As Integer
    Public ReadOnly Property Direction As Directions

    Public Sub New(worldData As WorldData, world As World, fromLocationId As Integer, direction As Directions)
        MyBase.New(worldData, world)
        Me.Direction = direction
        fromLocationId = fromLocationId
    End Sub

    Friend Shared Function Create(worldData As WorldData, world As World, location As ILocation, direction As Directions, nextLocation As ILocation) As IRoute
        worldData.Locations(location.Id).Routes(direction) = New RouteData With {.ToLocationId = nextLocation.Id}
        Return New Route(worldData, world, location.Id, direction)
    End Function
End Class
