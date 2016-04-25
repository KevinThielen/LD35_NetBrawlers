using UnityEngine;

public class PlayAnimation : IAction {
    string animation;

    
    public PlayAnimation(string animation) {
        actionName = "PlayAnimation";
        this.animation = animation;      
    }
    public override bool Execute(Game game) {
           game.CurrentPlayer.Animation = animation;
           return true;
    }
}
