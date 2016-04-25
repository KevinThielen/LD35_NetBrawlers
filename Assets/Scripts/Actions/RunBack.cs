using UnityEngine;

public class RunBack : IAction {
    float range;
    float speed;
    
    public RunBack(float range, float speed) {
        actionName = "Run";      
        this.range = range;
        this.speed = speed;
    }
    public override bool Execute(Game game) {

       Vector2 target = game.CurrentPlayer.SpawnPosition;
        
        
       if(Vector2.Distance(target, game.CurrentPlayer.Position) > range) {
           Vector2 dir = (target - game.CurrentPlayer.Position).normalized;
           game.CurrentPlayer.Move(dir.x*speed, dir.y );
           return false;
       }
       else {
           game.CurrentPlayer.Position = target;
           return true;
       }
    }
}
