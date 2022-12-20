Public Class Location
    Inherits Thingie
    Implements ILocation

    Public Sub New(worldData As WorldData, world As World, id As Integer)
        MyBase.New(worldData, world, id)
    End Sub

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return WorldData.Locations(Id).Routes.Select(Function(x) New Route(WorldData, World, Id, CType(x.Key, Directions)))
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, world As World) As ILocation
        Dim locationId = If(worldData.Locations.Any, worldData.Locations.Keys.Max + 1, 0)
        worldData.Locations(locationId) = New LocationData
        Return New Location(worldData, world, locationId)
    End Function
End Class
