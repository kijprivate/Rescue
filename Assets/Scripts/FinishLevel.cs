using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private Coroutine finishLevelCoroutine = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Character"))
        {
            if(finishLevelCoroutine == null)
                finishLevelCoroutine = StartCoroutine(FinishLevelRoutine());
        }
    }

    private IEnumerator FinishLevelRoutine()
    {
        yield return new WaitForSeconds(2f);
        //summary
        SceneManager.LoadScene("Level" + (LevelState.instance.currentLevel + 1));
    }
}
