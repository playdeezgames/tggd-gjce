﻿Public Interface ICharacter
    Inherits IThingie
    ReadOnly Property IsAlive As Boolean
    Property Location As ILocation
    Sub AttemptMove(direction As Directions)
    Sub AddMessage(message As String)
End Interface