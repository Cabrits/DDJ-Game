//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//[CreateAssetMenu(menuName = "Manager/LevelManager")]
//public class LevelManager : ScriptableObject
//{
//    public GameState GameState { get; private set; }

//    private void OnEnable()
//    {
//        LevelEvents.levelExit += OnLevelExit;
//    }

//    private void OnLevelExit(SceneAsset nextLevel, string playerSpawnTransformName)
//    {
//        GameState.playerSpawnLocation = playerSpawnTransformName;
//        SceneManager.LoadScene(nextLevel.name, LoadSceneMode.Single);
//    }

//    private void OnDisable()
//    {
//        LevelEvents.levelExit -= OnLevelExit;
//    }
//}
