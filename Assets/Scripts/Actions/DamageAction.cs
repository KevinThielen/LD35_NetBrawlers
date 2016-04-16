public class DamageAction : IAction {
    
    int amount;
    public DamageAction(int amount) {
        actionName = "Damage";
        this.amount = amount;

    }
    
    public override bool Execute(Game game) {
        Player opponent = game.getOtherPlayer(game.CurrentPlayer);
        opponent.Damage(amount);
        return true;
    }
}
