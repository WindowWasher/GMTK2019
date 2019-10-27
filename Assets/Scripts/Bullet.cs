using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int maxHitCount = 4;
    public int hitCountReductionForHittingEnemy = 1;

    private int hitCount = 0;
    private bool bulletDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnAllEnemiesKilled += AllEnemiesKilled;
        EventManager.instance.OnEnemyKilled += EnemyKilled;
    }

    private void OnDisable()
    {
        EventManager.instance.OnAllEnemiesKilled -= AllEnemiesKilled; 
        EventManager.instance.OnEnemyKilled -= EnemyKilled;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hitCount >= maxHitCount && !bulletDestroyed)
        {
            bulletDestroyed = true;
            EventManager.instance.PlayerBulletExpired();
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount += 1;
    }

    void AllEnemiesKilled()
    {
        hitCount = maxHitCount;
    }

    void EnemyKilled()
    {
        hitCount -= hitCountReductionForHittingEnemy;
    }
}
