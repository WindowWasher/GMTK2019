using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void PlayerFiredAction();
    public event PlayerFiredAction OnPlayerFired;

    public delegate void PlayerBulletExpiredAction();
    public event PlayerBulletExpiredAction OnPlayerBulletExpired;

    public delegate void LevelOverAction(int startingEnemyCount, int enemiesKilled);
    public event LevelOverAction OnLevelOver;

    public delegate void EnemyKilledAction();
    public event EnemyKilledAction OnEnemyKilled;

    public delegate void AllEnemiesKilledAction();
    public event AllEnemiesKilledAction OnAllEnemiesKilled;

    public static EventManager instance;
    

    public void PlayerFired()
    {
        if (OnPlayerFired != null)
            OnPlayerFired();
    }

    public void PlayerBulletExpired()
    {
        if (OnPlayerBulletExpired != null)
            OnPlayerBulletExpired();
    }

    public void LevelOverEnemyCheck(int startingEnemyCount, int enemiesKilled)
    {
        if (OnLevelOver != null)
            OnLevelOver(startingEnemyCount, enemiesKilled);
    }

    public void EnemyKilled()
    {
        if (OnEnemyKilled != null)
            OnEnemyKilled();
    }

    public void AllEnemiesKilled()
    {
        if (OnAllEnemiesKilled != null)
            OnAllEnemiesKilled();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }
}
