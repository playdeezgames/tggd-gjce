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

    Public ReadOnly Property Route(direction As Directions) As IRoute Implements ILocation.Route
        Get
            If WorldData.Locations(Id).Routes.ContainsKey(direction) Then
                Return New Route(WorldData, World, Id, direction)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property LocationType As LocationTypes Implements ILocation.LocationType
        Get
            Return CType(WorldData.Locations(Id).LocationType, LocationTypes)
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, world As World, locationType As LocationTypes) As ILocation
        Dim locationId = If(worldData.Locations.Any, worldData.Locations.Keys.Max + 1, 0)
        worldData.Locations(locationId) = New LocationData With
            {
                .LocationType = locationType
            }
        Return New Location(worldData, world, locationId)
    End Function
End Class
