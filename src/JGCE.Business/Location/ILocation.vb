Public Interface ILocation
    Inherits IThingie
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    ReadOnly Property Route(direction As Directions) As IRoute
    ReadOnly Property LocationType As LocationTypes
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    Sub AddItem(item As IItem)
    Function HasItem(item As IItem) As Boolean
    Sub RemoveItem(item As IItem)
    Sub OnEnter(character As Character)
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItem)
    ReadOnly Property DungeonType As DungeonTypes
End Interface
