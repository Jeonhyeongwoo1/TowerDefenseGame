using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 0.5f;

    private Transform target;
    private int wavePointIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= distance)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }
}

