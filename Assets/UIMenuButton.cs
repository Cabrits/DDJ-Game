using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuButton : MonoBehaviour
{
    public void StartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void ReturnMainMenuButton(){
        SceneManager.LoadScene(0);
    }

    public void restartButton(){
        if(StaticData.level == 1){
            SceneManager.LoadScene(2);
        } else if(StaticData.level == 2){
            SceneManager.LoadScene(2);
        }
    }
}
