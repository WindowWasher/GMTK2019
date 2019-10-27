using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiLevelCount : MonoBehaviour
{
    private Text levelCount;

    // Start is called before the first frame update
    void Start()
    {
        levelCount = gameObject.GetComponent<Text>();
        levelCount.text = "Level " + SceneManager.GetActiveScene().buildIndex + " of " + (SceneManager.sceneCountInBuildSettings - 1);
    }
}
