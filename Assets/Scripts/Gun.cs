using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnPos;
    public float bulletSpeed = 100;
    public LineRenderer lineRenderer;
    public LayerMask mask;
    public int aimAssistReflectionCount = 1;

    private bool hasFired = false;

    // Update is called once per frame
    void Update()
    {
        if (hasFired)
            return;

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 dirNorm = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot;
        bulletSpawnPos.transform.rotation = rot;

        if (Input.GetMouseButtonDown(0) && !hasFired)
        {
            GameObject go = GameObject.Instantiate(bullet, bulletSpawnPos.transform.position, transform.rotation);
            Rigidbody2D rb =  go.GetComponent<Rigidbody2D>();
            rb.AddForce(dirNorm * bulletSpeed);

            EventManager.instance.PlayerFired();
            hasFired = true;
            lineRenderer.enabled = false;
        }

        DrawAimAssist(dirNorm);
    }

    void DrawAimAssist(Vector2 startDir)
    {
        List<Vector3> linePositions = new List<Vector3>();
        linePositions.Add(bulletSpawnPos.transform.position);

        Vector2 rayDir = startDir;

        //{ transform.position, hit.point, hit.point + Vector2.Reflect(dirNorm, hit.normal) * 3};
        
        for (int i = 0; i < aimAssistReflectionCount; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(linePositions[linePositions.Count - 1], rayDir, 100, mask);

            if (hit)
            {
                linePositions.Add(hit.point);
                rayDir = Vector2.Reflect(rayDir, hit.normal);
            }
        }

        lineRenderer.positionCount = linePositions.Count;
        lineRenderer.SetPositions(linePositions.ToArray());
    }
}
