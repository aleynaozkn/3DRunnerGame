using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject[] Waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;

    private void Update()
    {
        if (Vector3.Distance(Waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= Waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, 
            Waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
