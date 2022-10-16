using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    scoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<scoreKeeper>();
         
    }
    
    void Start()
    {
        scoreText.text = "You Scored:\n " + scoreKeeper.getCurrentScore();
    }

    
}
