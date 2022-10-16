using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour
{
    int currentScore = 0;
    static scoreKeeper instance;

    void Awake()
    {
        ManageSingleTon();   
    }
    void ManageSingleTon()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }   
    
    public int getCurrentScore()
    {
        return currentScore;
    }
    public void modifyScore(int value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore,0,int.MaxValue);
        Debug.Log(currentScore);
    }
    public void resetScore()
    {
        currentScore = 0;
    }
}
