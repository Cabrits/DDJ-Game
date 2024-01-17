using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            GameObject.FindWithTag("Player").GetComponent<PlayerStats>().SaveSceneKeepValue();
            GameObject.FindWithTag("Player").GetComponent<PlayerGunStats>().SaveSceneKeepValue();
            GameObject.FindWithTag("Player").GetComponent<PlayerInventory>().SaveSceneKeepValue();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
