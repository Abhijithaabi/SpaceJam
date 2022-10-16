using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingAudio;
    [SerializeField] [Range(0f,1f)] float shootingVolume =1f;

    [Header("Damage Audio")]
    [SerializeField] AudioClip damageAudio;
    [SerializeField] [Range(0f,1f)] float damageVolume =1f;
    static audioPlayer instance;

    void Awake()
    {
        // manageSingleTon();    
    }
    // void manageSingleTon()
    // {
        
    //     int instanceID =instance.GetInstanceID();
    //     if(instance != null)
    //     {
    //         if(instanceID != 2)
    //         {
    //             gameObject.SetActive(false);
    //             Destroy(gameObject);
    //         }
    //         else
    //         {
    //             instance=this;
    //         }
    //     }
    //     else
    //     {
    //         instance=this;
    //         DontDestroyOnLoad(gameObject);  
    //     }
    //     Debug.Log("Instanceid" + instanceID);
    // }

    public void playShootingAudio()
    {
        playClip(shootingAudio,shootingVolume);
    }
    public void playDamageAudio()
    {
        playClip(damageAudio,damageVolume);
    }
    void playClip(AudioClip clip,float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
        }
    }
}
