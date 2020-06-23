using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgressUI : MonoBehaviour
{
    [SerializeField] Image[] levelImages;
    [SerializeField] TextMeshProUGUI[] levelTexts;
    [SerializeField] Slider[] levelSliders;
    [SerializeField] Color lockedColor; 

    private void Start()
    {
        var currentLevel = LevelState.instance.currentLevel;
        SetLevelTexts(currentLevel);
        SetImages(currentLevel % 5);
        SetSliders(currentLevel % 5);
    }

    private void SetLevelTexts(int currentLevel)
    {
        levelTexts[0].text = ((currentLevel / 5) * 5 + 1).ToString();
        levelTexts[1].text = ((currentLevel / 5) * 5 + 2).ToString();
        levelTexts[2].text = ((currentLevel / 5) * 5 + 3).ToString();
        levelTexts[3].text = ((currentLevel / 5) * 5 + 4).ToString();
        levelTexts[4].text = ((currentLevel / 5) * 5 + 5).ToString();
    }

    private void SetImages(int remainder)
    {
        if(remainder == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                levelImages[i].color = Color.white;
                levelTexts[i].color = Color.white;
            }
        }
        else
        {
            for(int i=0; i < remainder; i++)
            {
                levelImages[i].color = Color.white;
                levelTexts[i].color = Color.white;
            }
            for (int i = remainder; i < 5; i++)
            {
                levelImages[i].color = lockedColor;
                levelTexts[i].color = lockedColor;
            }
        }
    }

    private void SetSliders(int remainder)
    {
        if (remainder == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i < 3)
                    levelSliders[i].value = 1f;
                else if (i == 3)
                    levelSliders[i].value = 0.35f;
            }
        }
        else
        {
            for (int i = 0; i < remainder; i++)
            {
                if (i < remainder - 1)
                    levelSliders[i].value = 1f;
                else if (i == remainder - 1)
                    levelSliders[i].value = 0.35f;
            }
            for (int i = remainder; i < 4; i++)
            {
                levelSliders[i].value = 0f;
            }
        }
    }
}
