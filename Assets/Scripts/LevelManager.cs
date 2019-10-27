using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int startingEnemyCount;
    private int enemiesKilled;

    private void OnDisable()
    {
        EventManager.instance.OnPlayerBulletExpired -= PlayerBulletExpired;
        EventManager.instance.OnEnemyKilled -= EnemyKilled;
    }

    void Start()
    {
        EventManager.instance.OnPlayerBulletExpired += PlayerBulletExpired;
        EventManager.instance.OnEnemyKilled += EnemyKilled;

        startingEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void EnemyKilled()
    {
        enemiesKilled += 1;

        if (enemiesKilled == startingEnemyCount)
            EventManager.instance.AllEnemiesKilled();
    }

    private void PlayerBulletExpired()
    {
        EventManager.instance.LevelOverEnemyCheck(startingEnemyCount, enemiesKilled);
    }
}
