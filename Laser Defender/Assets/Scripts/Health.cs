using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    cameraShake cameraShake;
    audioPlayer audioPlayer;
    scoreKeeper scoreKeeper;
    levelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<cameraShake>();
        audioPlayer = FindObjectOfType<audioPlayer>();
        scoreKeeper = FindObjectOfType<scoreKeeper>();
        levelManager = FindObjectOfType<levelManager>();    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        damageDealer damageDealer = other.GetComponent<damageDealer>();
        if(damageDealer != null)
        {
            takeDamage(damageDealer.getDamage());
            playHitEffect();
            playcameraShake();
            audioPlayer.playDamageAudio();
            damageDealer.Hit();
        }   
    }
    void takeDamage(int damage)
    {
        Debug.Log("Damage" + damage);
        health -= damage;
        Debug.Log(health);
        if(health<=0)
        {
            
            Die();
        }
    }
    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.modifyScore(score);
        }
        else
        {
            levelManager.loadGameOver();
            
            
        }
        Destroy(gameObject);
    }
    void playHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        }
        
    }
    void playcameraShake()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.startCameraShake();
        }
    }

    public int getHealth()
    {
        return health;
    }
    
}
