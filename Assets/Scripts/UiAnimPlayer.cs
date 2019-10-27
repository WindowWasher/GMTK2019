using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiAnimPlayer : MonoBehaviour
{
    public Animator winAnimation;
    public Animator looseAnimation;
    public Animator beatTheGameAnimation;
    
    void LevelOver(int enemyStartCount, int enemiesKilled)
    {
        if(enemyStartCount != enemiesKilled)
        {
            looseAnimation.SetTrigger("LevelLoss");
            Debug.Log("Level loss");
        }
        else if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
        {
            winAnimation.SetTrigger("LevelWon");
            Debug.Log("Level won");
        }
        else
        {
            beatTheGameAnimation.SetTrigger("GameWon");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnLevelOver += LevelOver;
    }

    private void OnDisable()
    {
        EventManager.instance.OnLevelOver -= LevelOver;
    }

}
