Public Interface ICharacter
    Inherits IThingie
    ReadOnly Property IsAlive As Boolean
    Property Location As ILocation
    Sub AttemptMove(direction As Directions)
    Sub AddMessage(message As String)
    Function CanTalk(otherCharacter As ICharacter) As Boolean
    ReadOnly Property CharacterType As CharacterTypes
End Interface
