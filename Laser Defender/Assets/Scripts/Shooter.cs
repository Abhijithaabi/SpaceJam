using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float basefireRate = 0.6f;
    [Header("AI")]
    [SerializeField] float fireRateVariance =0f;
    [SerializeField] float minFireRate =0.2f;
    [SerializeField] bool useAI;
    [HideInInspector]public bool isFiring;
    audioPlayer audioPlayer;
    Coroutine Firing;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<audioPlayer>();    
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    
    void Update()
    {
       Fire(); 
    }
    void Fire()
    {
        if(isFiring && Firing == null)
        {
           Firing = StartCoroutine(FireCont());
        }
        else if(!isFiring && Firing != null)
        {
            StopCoroutine(Firing);
            Firing = null;
        }
    }
    IEnumerator FireCont()
    {
        while(true)
        {
            GameObject Instance = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            Rigidbody2D rb = Instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(Instance,projectileLifetime);
            
            float timefornextProjectile = Random.Range(basefireRate-fireRateVariance,basefireRate+fireRateVariance);
            timefornextProjectile = Mathf.Clamp(timefornextProjectile,minFireRate,float.MaxValue);
            audioPlayer.playShootingAudio();
            yield return new WaitForSeconds(timefornextProjectile);

        }
    }
}
