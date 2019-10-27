using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem OnDeathParticles;
    public bool verticalPatrol = false;
    public bool invertVertical = false;
    public bool horizontalPatrol = false;
    public bool invertHorizontal = false;

    public float patrolDistance = 2;
    public float speed = 0.5f;

    private Vector2 initialPos;
    private float counter = 0;

    private void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (verticalPatrol || horizontalPatrol)
            Patrol();
    }

    void Patrol()
    {
        float time = Mathf.PingPong(counter * speed, 1);
        counter += Time.deltaTime;

        Vector2 patrolVec = initialPos;

        if (horizontalPatrol)
        {
            float invert = invertHorizontal ? -1 : 1;
            patrolVec.x += patrolDistance * invert;
        }

        if (verticalPatrol)
        {
            float invert = invertVertical ? -1 : 1;
            patrolVec.y += patrolDistance * invert;
        }

        transform.position = Vector2.Lerp(initialPos, patrolVec, time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            ParticleSystem particles = GameObject.Instantiate(OnDeathParticles, transform.position, Quaternion.identity);
            Destroy(particles.gameObject, particles.main.duration);

            EventManager.instance.EnemyKilled();

            GameObject.Destroy(gameObject);
        }
    }
}
