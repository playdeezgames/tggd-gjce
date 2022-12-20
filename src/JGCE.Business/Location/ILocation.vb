Public Interface ILocation
    Inherits IThingie
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    ReadOnly Property Route(direction As Directions) As IRoute
    ReadOnly Property LocationType As LocationTypes
End Interface
