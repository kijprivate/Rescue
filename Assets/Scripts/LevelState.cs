﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    public int currentLevel = 1;

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
    }
}