Public Class Route
    Inherits BaseThingie
    Implements IRoute
    Private ReadOnly FromLocationId As Integer
    Public ReadOnly Property Direction As Directions Implements IRoute.Direction

    Public ReadOnly Property ToLocation As ILocation Implements IRoute.ToLocation
        Get
            Return New Location(WorldData, World, WorldData.Locations(FromLocationId).Routes(Direction).ToLocationId)
        End Get
    End Property

    Public ReadOnly Property RouteType As RouteTypes Implements IRoute.RouteType
        Get
            Return CType(WorldData.Locations(FromLocationId).Routes(Direction).RouteType, RouteTypes)
        End Get
    End Property

    Public Sub New(worldData As WorldData, world As IWorld, fromLocationId As Integer, direction As Directions)
        MyBase.New(worldData, world)
        Me.Direction = direction
        Me.FromLocationId = fromLocationId
    End Sub

    Friend Shared Function Create(worldData As WorldData, world As World, location As ILocation, direction As Directions, nextLocation As ILocation, routeType As RouteTypes) As IRoute
        worldData.Locations(location.Id).Routes(direction) = New RouteData With
            {
                .ToLocationId = nextLocation.Id,
                .RouteType = routeType
            }
        Return New Route(worldData, world, location.Id, direction)
    End Function
End Class
