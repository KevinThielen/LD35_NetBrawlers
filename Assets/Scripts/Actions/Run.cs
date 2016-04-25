using UnityEngine;

public class Run : IAction {
    float range;
    float speed;
    
    public Run(float range, float speed) {
        actionName = "Run";      
        this.range = range;
        this.speed = speed;
    }
    public override bool Execute(Game game) {

       Vector2 target = game.getOtherPlayer(game.CurrentPlayer).Position;
      if(Vector2.Distance(target, game.CurrentPlayer.Position) > range) {
           
           
           if(target.x > game.CurrentPlayer.Position.x)
            game.CurrentPlayer.Move(1*speed, 0 );
           else 
             game.CurrentPlayer.Move(-1*speed, 0 );
           return false;
       }
       else {
           return true;
       }
    }
}
