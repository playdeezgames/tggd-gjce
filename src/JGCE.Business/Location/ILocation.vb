Public Interface ILocation
    Inherits IThingie
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    ReadOnly Property Route(direction As Directions) As IRoute
    ReadOnly Property LocationType As LocationTypes
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
End Interface
