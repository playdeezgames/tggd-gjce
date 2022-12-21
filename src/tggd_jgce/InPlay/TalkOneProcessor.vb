Friend Module TalkOneProcessor
    Friend Sub Run(world As IWorld, targetCharacter As ICharacter)
        world.PlayerCharacter.Talk(targetCharacter)
    End Sub
End Module
