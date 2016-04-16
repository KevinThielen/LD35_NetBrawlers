public class WaitForAction : IAction {
   
    public WaitForAction() {
        actionName = "WaitForAction";
    }
    
    public override bool Execute(Game game) 
    {
        game.WaitForAction = true;
        return true;
    }
}
