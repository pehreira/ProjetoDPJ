using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    //public Transform spawner;

    private Transform target; //variavel onde vai armazenar os waypoints
    private int wavepointIndex = 0; //este e o indice do waypoint atual que estamos a seguir, ou seja, começa sempre com o 0 e depois vai aumentando
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(-80.511f, 379.182f, 2.274f);
        target = Waypoints.points[0]; //dizemos que a variavel target armazena os points da class waypoints
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
        Vector3 transformPosition = new Vector3(transform.position.x, 0, transform.position.z);

        Vector3 dir = targetPosition - transformPosition;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        
        
        if (Vector3.Distance(transformPosition, targetPosition) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
