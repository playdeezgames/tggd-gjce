Public Interface IWorld
    Property PlayerCharacter As ICharacter
    ReadOnly Property Messages As IEnumerable(Of String)
    Sub ClearMessages()
End Interface
