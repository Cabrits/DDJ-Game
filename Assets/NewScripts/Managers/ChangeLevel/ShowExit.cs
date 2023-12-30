using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExit : MonoBehaviour
{
    Vector3 target;
    Vector3 portal;

    float timer=0;
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        target = new Vector3(target.x, target.y, -10);
        portal = GameObject.Find("Portal").transform.position;
        portal = new Vector3(portal.x, portal.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(target, portal, timer/3);
        timer+=Time.deltaTime;
    }
}
