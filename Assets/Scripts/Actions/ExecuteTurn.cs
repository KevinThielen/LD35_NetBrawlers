public class ExecuteTurn : IAction {
    

    public ExecuteTurn() {
        actionName = "ExecuteTurn";
    }
    
    public override bool Execute(Game game) 
    {
        game.WaitForAction = false;
        return true;
    }
}
