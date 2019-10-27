using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEnemiesKilled : MonoBehaviour
{
    private Text enemiesKilledText;

    void SetUiEnemiesKilled(int enemyStartCount, int enemiesKilled)
    {
        enemiesKilledText.text = enemiesKilled + " of " + enemyStartCount + " Enemies Killed";
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnLevelOver += SetUiEnemiesKilled;
        enemiesKilledText = gameObject.GetComponent<Text>();
    }

    private void OnDisable()
    {
        EventManager.instance.OnLevelOver -= SetUiEnemiesKilled; 
    }
}
