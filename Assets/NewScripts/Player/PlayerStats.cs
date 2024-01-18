using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{   

    public float playerSpeed;


    public int powerUpCount;


    void Start(){
        if(gameObject.scene.name != "Level 1" && gameObject.scene.name != "Tutorial"){
            LoadSceneKeepValue();
        }
    }

    public void SaveSceneKeepValue(){
        StaticData.playerSpeed = playerSpeed;
        StaticData.playersize = GameObject.FindWithTag("Player").transform.localScale;
    }

    public void LoadSceneKeepValue(){
        playerSpeed = StaticData.playerSpeed;
        GameObject.FindWithTag("Player").transform.localScale = StaticData.playersize;
    }

    public void IncreasePowerUpCount(){
        powerUpCount++;
    }

    public void DecreasePowerUpCount(){
        powerUpCount--;
    }

}
