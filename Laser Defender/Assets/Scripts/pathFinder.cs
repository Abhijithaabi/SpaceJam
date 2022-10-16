using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinder : MonoBehaviour
{
    WaveConfigSO waveConfigSO;
    List<Transform> Waypoints;
    int waypointIndex = 0;
    enemySpawner enemySpawner;

    private void Awake() {
        enemySpawner = FindObjectOfType<enemySpawner>();
    }
   
    void Start()
    {
        waveConfigSO = enemySpawner.getCurrentWave();
        Waypoints = waveConfigSO.getWaypoints();
        transform.position = waveConfigSO.getFirstWaypoint().position;
    }

   
    void Update()
    {
        followPath();
    }
    void followPath()
    {
        if(waypointIndex < Waypoints.Count)
        {
            Vector3 targetPos = Waypoints[waypointIndex].position;
            float delta = waveConfigSO.getmoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPos,delta);
            if(transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
