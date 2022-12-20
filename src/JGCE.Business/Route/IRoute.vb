Public Interface IRoute
    ReadOnly Property Direction As Directions
    ReadOnly Property ToLocation As ILocation
    ReadOnly Property RouteType As RouteTypes
End Interface
