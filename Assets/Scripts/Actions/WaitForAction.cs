public class WaitForAction : IAction {
   
   bool initialized = false;
    public WaitForAction() {
        actionName = "WaitForAction";
    }
    
    public override bool Execute(Game game) 
    {
        if(!initialized) {
         game.WaitForAction = true;
         initialized = true;
        }
        
        return !game.WaitForAction;
    }
}
