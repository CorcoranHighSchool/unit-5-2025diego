using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public static GameManager instance;
    private float spawnRate = 1.0f;

    public GameObject[] prefabs;

    private int score;

    public TextMeshProUGUI scoreText;
    public bool isGameActive { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

    }
    public void GameOver() { 
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score" + score;
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, prefabs.Length);
            //spawnTarget
            Instantiate(prefabs[index]);
            UpdateScore(5);
        }
    }

}
   
   
