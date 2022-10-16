using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    [SerializeField] float loadsceneDelay =1f;
    scoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<scoreKeeper>();    
    }
    public void loadGame()
    {
        scoreKeeper.resetScore();
        SceneManager.LoadScene("Game");
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void loadGameOver()
    {
        StartCoroutine(waitandLoad("GameOver",loadsceneDelay));
        
    }
    public void quitGame()
    {
        Debug.Log("quitgame");
        Application.Quit();
    }
    IEnumerator waitandLoad(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
