using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{   
    public float playerSpeed;

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

}
