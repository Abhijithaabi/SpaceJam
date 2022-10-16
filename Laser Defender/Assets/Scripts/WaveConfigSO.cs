using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "WaveConfig", menuName = "New Wave Config" )]
public class WaveConfigSO : ScriptableObject 
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] float timeBtwEnemySpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public Transform getFirstWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> getWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
            
        }
        return waypoints;
    }

    public float getmoveSpeed(){
        return moveSpeed;
    }
    public int getenemyCount()
    {
        return enemyPrefab.Count;
    }
    public GameObject getEnemyPrefab(int index)
    {
        return enemyPrefab[index];
    }
    public float getRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBtwEnemySpawn-spawnTimeVariance,timeBtwEnemySpawn+spawnTimeVariance);
        return Mathf.Clamp(spawnTime,minimumSpawnTime,float.MaxValue);

    }
    
}

