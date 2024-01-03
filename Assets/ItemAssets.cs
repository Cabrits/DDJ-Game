using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance{get; private set;}

    private void Awake(){
        Instance = this;
    }

    public Sprite ammoBuffSprite;
    public Sprite bulletSpeedBuffSprite;
    public Sprite damagePowerupSprite;
    public Sprite fireRateBuffSprite;
    public Sprite healthPotionSprite;
    public Sprite reloadSpeedBuffSprite;
    public Sprite speedPowerupSprite;


}
