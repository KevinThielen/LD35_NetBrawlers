using UnityEngine;


public class DrawCardAction : IAction {
    
    bool drawn = false;
    public DrawCardAction() {
        actionName = "DrawCard";
    }
    
    public override bool Execute(Game game) {
        if(!drawn) {
            if(game.CurrentPlayer.CardsInHand < Game.MAX_HANDCARDS) {
                game.CurrentPlayer.DrawCard();
                drawn = true;
            }
        }
        //TODO: Animation
        return true;
    }
}
