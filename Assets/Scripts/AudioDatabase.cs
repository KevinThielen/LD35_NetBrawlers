using UnityEngine;
using System.Collections.Generic;

class AudioDatabase : MonoBehaviour { 
    
    public AudioClip punch;
    public AudioClip blast;
    public AudioClip heavy;
    
    static AudioDatabase instance;
    void Start() {
        instance = this;
   
    }
    
    public static AudioDatabase Instance {
        get {

            return instance;
        }
    }

    // REALLY ugly hack due deadline
    public AudioClip getAudio(string name) {
        switch (name) {
            case "punch":  { return punch; }
            case "blast":   { return blast;}
            case "heavy":  { return heavy;}
        }

        return null;
    }
}