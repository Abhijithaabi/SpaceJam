using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    [SerializeField] float shakeMag = 0.5f;
    [SerializeField] float shakeDuration = 1f;
    Vector3 InitPos;
    void Start()
    {
        InitPos = transform.position;
    }
    public void startCameraShake()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while(elapsedTime < shakeDuration)
        {
            transform.position = InitPos + (Vector3)Random.insideUnitCircle * shakeMag;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = InitPos;
        
    }

    
}
