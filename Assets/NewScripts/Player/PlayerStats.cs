using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{   

    public float playerSpeed;

    public int powerUpCount;


    void Start(){
        if(gameObject.scene.name != "Level 1"){
            LoadSceneKeepValue();
        }
    }

    public void SaveSceneKeepValue(){
        StaticData.playerSpeed = playerSpeed;
    }

    public void LoadSceneKeepValue(){
        playerSpeed = StaticData.playerSpeed;
    }

    public void IncreasePowerUpCount(){
        powerUpCount++;
    }

    public void DecreasePowerUpCount(){
        powerUpCount--;
    }

}
