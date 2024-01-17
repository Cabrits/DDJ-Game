using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrowth : MonoBehaviour{


    public void Grow(GameObject target){
        target.transform.localScale += new Vector3(0.3f, 0.3f);
    }

    public void Shrink(GameObject target){
       target.transform.localScale -= new Vector3(0.3f, 0.3f);
    }

}
