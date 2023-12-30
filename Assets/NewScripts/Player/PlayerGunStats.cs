using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunStats : MonoBehaviour
{   
    public int gunDamage;
    public int maxAmmo;
    public float fireRate;
    public float reloadSpeed; 
    public float bulletForce = 20f;

    void Start(){
        if(gameObject.scene.name != "Level 1"){
            LoadSceneKeepValue();
        }
    }

    public void SaveSceneKeepValue(){
        StaticData.gunDamage = gunDamage;
        StaticData.maxAmmo = maxAmmo;
        StaticData.fireRate = fireRate;
        StaticData.reloadSpeed = reloadSpeed;
        StaticData.bulletForce = bulletForce;
    }

    public void LoadSceneKeepValue(){
        gunDamage = StaticData.gunDamage ;
        maxAmmo = StaticData.maxAmmo;
        fireRate = StaticData.fireRate;
        reloadSpeed = StaticData.reloadSpeed;
        bulletForce = StaticData.bulletForce;
    }
}
