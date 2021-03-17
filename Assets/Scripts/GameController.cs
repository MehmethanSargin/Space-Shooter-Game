using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject hazard;

    [SerializeField]
    private int spawnCount;

    [SerializeField]
    private float spawnWait;

    [SerializeField]
    private float startWait;

    [SerializeField]
    private float waveWait;

    [SerializeField]
    Text scoreText;

    private int score;

    private bool gameOver = false;

    [SerializeField]
    GameObject gameOverPanel;

    void Start()
    {
        StartCoroutine(SpawnValues());
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for(int i = 0; i<spawnCount; i++) 
            { 
                Vector3 spawnPosition = new Vector3(Random.Range(-2.9f,2.9f),0,9);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver == true)
            {
                GameOver();
                break;
            }
        } 
    }

    public void UpdateScore() 
    {
        score += 10;
        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
