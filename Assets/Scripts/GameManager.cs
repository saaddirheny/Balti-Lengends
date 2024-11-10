using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Rock;
    public float maxX;
    public Transform spwanPoint;
    public float spwanRate;

 bool gameStarted = false;

 public GameObject tapText;
 public TextMeshProUGUI scoreText;
 public TextMeshProUGUI highScore;
 int score=0;

 private void start()
 {
 UpdateHighScore();
 }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
          StartSpawning();
          gameStarted = true;
          tapText.SetActive(false);
         
        }
       
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
        CheckHighScore();
        }
        UpdateHighScore();
        
    }


 private void StartSpawning()
 {
InvokeRepeating("SpwanRock", 0.5f , spwanRate);
 }
    private void SpwanRock()
    {
        Vector3 spawnPos = spwanPoint.position;
        spawnPos.x = Random.Range(-maxX , maxX);
        Instantiate(Rock , spawnPos , Quaternion.identity);

        score++;
        scoreText.text = score.ToString();
        
    }
    void CheckHighScore()
    {
        PlayerPrefs.SetInt("HighScore",score);
        PlayerPrefs.GetInt("HighScore");
    }
    void UpdateHighScore()
    {
        highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

   
}
