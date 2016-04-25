using UnityEngine;
using System.Collections.Generic;

class SpriteDatabase : MonoBehaviour { 
    
    public Sprite yellow_idle;
    public Sprite yellow_run;
    public Sprite yellow_punch;
    public Sprite yellow_dash;
    public Sprite yellow_serious_punch;
    public Sprite yellow_blast;
    public Sprite yellow_ura_0;    
    public Sprite yellow_ura_1;
    public Sprite yellow_ura_2;
    public Sprite yellow_guard;
    
    public Sprite red_idle;
    public Sprite red_guard;
    public Sprite red_run;
    public Sprite red_slash;
    public Sprite red_spear_dash;
    
    public Sprite green_idle;
    public Sprite green_fireblast;
    public Sprite green_pierce_shot;
    public Sprite green_yellowblast;
    public Sprite green_guard;
    
    public Sprite gray_idle;
    public Sprite gray_guard;
    public Sprite gray_blast;
    public Sprite gray_run;
    public Sprite gray_boom_0;
    public Sprite gray_boom_1;
    public Sprite gray_boom_2;
    
    static SpriteDatabase instance;
    void Start() {
        instance = this;
   
    }
    
    public static SpriteDatabase Instance {
        get {

            return instance;
        }
    }

    // REALLY ugly hack due deadline
    public Sprite getAnimation(string name, EForm form) {
        switch (form) {
            case EForm.GRAY: {
                 switch (name) {
                    case "idle":  { return gray_idle; break; }
                    case "run": { return gray_run; break; }
                    case "blast":{ return gray_blast; break; }
                    case "guard": { return gray_guard; break; }
                    case "boom_0": { return gray_boom_0; break; }
                    case "boom_1": { return gray_boom_1; break; }
                    case "boom_2": { return gray_boom_2; break; }
                }
                break;
            }
            case EForm.GREEN: {
                 switch (name) {
                    case "idle":  { return green_idle; break; }
                    case "fireblast": { return green_fireblast; break; }
                    case "pierce_shot":{ return green_pierce_shot; break; }
                    case "yellowblast": { return green_yellowblast; break; }
                    case "guard": { return green_guard; break; }
                }
                break;
            }
            case EForm.YELLOW: {
                switch (name) {
                    case "idle":  { return yellow_idle; break; }
                    case "run":   { return yellow_run; break; }
                    case "punch": { return yellow_punch; break; }
                    case "dash":{ return yellow_dash; break; }
                    case "serious_punch": { return yellow_serious_punch; break; }
                    case "blast": { return yellow_blast; break; }
                    case "ura_0": { return yellow_ura_0; break; }
                    case "ura_1": { return yellow_ura_1; break; }
                    case "ura_2": { return yellow_ura_2; break; }
                    case "guard": { return yellow_guard; break; }
                }
                break;
            }
             case EForm.RED: {
                switch (name) {
                    case "idle":  { return red_idle; break; }
                    case "run":   { return red_run; break; }
                    case "slash": { return red_slash; break; }
                    case "spear_dash":{ return red_spear_dash; break; }
                    case "guard": { return red_guard; break; }
                }
                 break;
            }
           
        }       
        return null;
    }
}