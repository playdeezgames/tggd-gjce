Public Interface ILocation
    Inherits IThingie
    ReadOnly Property Routes As IEnumerable(Of IRoute)
End Interface
