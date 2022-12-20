Public Interface ICharacter
    Inherits IThingie
    ReadOnly Property IsAlive As Boolean
    Property Location As ILocation
End Interface
