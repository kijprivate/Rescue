using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUi : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.SubscribeToEventGameOver(OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.UnsubscribeFromEventGameOver(OnGameOver);
    }

    private void OnGameOver()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
