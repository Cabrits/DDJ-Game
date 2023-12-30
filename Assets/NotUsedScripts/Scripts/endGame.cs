using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    List<GameObject> listOfEnemies = new List<GameObject>();
    public int numberOfEnemies;

    private void Start()
    {
        listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        numberOfEnemies = listOfEnemies.Count;
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
            Debug.Log("GG!");
        }
    }
}
