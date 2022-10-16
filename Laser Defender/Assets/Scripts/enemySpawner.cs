using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigSOs;
    [SerializeField] float timeBtwWave = 0f;
    [SerializeField] bool isLooping = true;
    void Start()
    {
        StartCoroutine(spawnEnemywaves());
    }
    public WaveConfigSO getCurrentWave()
    {
        return currentWave;
    }
    IEnumerator spawnEnemywaves()
    {
        do
        {
                foreach(WaveConfigSO wave in waveConfigSOs)
            {
                currentWave=wave;
                for(int i=0;i<currentWave.getenemyCount();i++)
            {
                Instantiate(currentWave.getEnemyPrefab(i),currentWave.getFirstWaypoint().position,Quaternion.Euler(0,0,180),transform);
                yield return new WaitForSeconds(currentWave.getRandomSpawnTime());
            }
            }
            yield return new WaitForSeconds(timeBtwWave);
        }while(isLooping);
        
        
        
    }

    
   
}
