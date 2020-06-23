using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    public int currentLevel = 1;
    public bool levelStarted = false;
    public int charactersLeft;

    #region static instance
    private static LevelState _instance;
    public static LevelState instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        charactersLeft = FindObjectsOfType<Character>().Length;
    }

    private void OnEnable()
    {
        EventManager.SubscribeToEventCharacterDestroyed(OnCharacterDestroyed);
    }

    private void OnDisable()
    {
        EventManager.UnsubscribeFromEventCharacterDestroyed(OnCharacterDestroyed);
    }

    //Invoked in main canvas OnClick 
    public void StartLevel()
    {
        levelStarted = true;
    }

    //Invoked in game over menu OnClick
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCharacterDestroyed()
    {
        charactersLeft--;
        if(charactersLeft <= 0)
        {
            Debug.LogError("Game over");
            EventManager.RaiseEventGameOver();
        }
    }
}
