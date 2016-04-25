using UnityEngine;

public class PlayAudio : IAction {
    string audio;

    
    public PlayAudio(string audio) {
        actionName = "PlayAudio";
        this.audio = audio;      
    }
    public override bool Execute(Game game) {
           game.PlayAudio(audio);
           return true;
    }
}
