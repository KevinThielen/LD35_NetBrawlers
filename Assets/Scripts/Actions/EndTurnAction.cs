using UnityEngine;


public class EndTurnAction : IAction {
    
    public EndTurnAction() {
        actionName = "EndTurn";
    }
    
    public override bool Execute(Game game) 
    {
        if(game.WaitForAction)
            return false;
        game.ChangeCurrentPlayer();
            return true;
    }
}
