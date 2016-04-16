using UnityEngine;


public class EndTurnAction : IAction {
    
    public EndTurnAction() {
        actionName = "EndTurn";
    }
    
    public override bool Execute(Game game) 
    {
        game.ChangeCurrentPlayer();
        return true;
    }
}
