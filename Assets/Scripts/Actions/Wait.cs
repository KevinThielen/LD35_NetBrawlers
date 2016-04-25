using UnityEngine;

public class Wait : IAction {
    float duration;

    public Wait(float duration) {
        actionName = "Wait";
        this.duration = duration;
    }
    
    public override bool Execute(Game game) 
    {
        duration -= Time.deltaTime;
        if(duration <= 0.0f)
          return true;
        else 
          return false;
    }
}
