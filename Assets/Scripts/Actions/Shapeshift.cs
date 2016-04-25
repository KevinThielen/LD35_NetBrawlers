using UnityEngine;


public class Shapeshift : IAction {
    
    EForm targetForm;
    public Shapeshift(EForm targetForm) {
        actionName = "ShapeShift";
        this.targetForm = targetForm;
    }
    
    public override bool Execute(Game game) {
        game.CurrentPlayer.Form = targetForm;
        //TODO: Animation
        return true;
    }
}
