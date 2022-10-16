using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    scoreKeeper scoreKeeper;
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<scoreKeeper>();   
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.getHealth();
        
    }

    
    void Update()
    {
        healthSlider.value = playerHealth.getHealth();
        scoreText.text = scoreKeeper.getCurrentScore().ToString("000000000");
        
    }
}
