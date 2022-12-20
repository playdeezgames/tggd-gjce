Public Interface IWorld
    Property PlayerCharacter As ICharacter
    ReadOnly Property Messages As IEnumerable(Of String)
    Sub ClearMessages()
    ReadOnly Property Locations As IEnumerable(Of ILocation)
End Interface
