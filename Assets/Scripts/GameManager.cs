using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public Text score;
    public Text highScore_;

    [Header("atributes")]
    [SerializeField]bool isGameOver = false;
    public float currentScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int score_)
    {
        currentScore += score_;
        score.text = currentScore.ToString();

    }

    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

}
