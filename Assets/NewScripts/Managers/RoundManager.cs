using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{
    List<GameObject> listOfEnemies = new List<GameObject>();
    public int numberOfEnemies;

    private float timeLeft = 5;
    private bool timerOn = false;

    private void Start()
    {
        listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        numberOfEnemies = listOfEnemies.Count;
    }

    void Update(){
        if(timerOn){
            if(timeLeft > 0){
                timeLeft -= Time.deltaTime;
            } else{
                timerOn = false;
                GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<ShowExit>().enabled = false;
            }
        }
    }

    public void KilledEnemy(GameObject enemy)
    {
        if (listOfEnemies.Contains(enemy))
        {
            listOfEnemies.Remove(enemy);
            numberOfEnemies = listOfEnemies.Count;
        }

        if(listOfEnemies.Count <= 0)
        {
            timerOn = true;
            GameObject.Find("Portal").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<ShowExit>().enabled = true;
        }
    }
}
