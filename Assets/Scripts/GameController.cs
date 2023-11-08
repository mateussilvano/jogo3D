using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int vidas = 3;
    private static int orange = 0;
    private int score;
    private int currentLevelIndex = 0;
    
    [SerializeField]
    public TextMeshProUGUI TextVidas;
    public TextMeshProUGUI TextOrange;
    public TextMeshProUGUI TextScore;
    public GameObject gameOver;
    public LevelController[] levels;
    
    public static GameController instance;

    void Start()
    {
         instance = this;
        SetCurrentLevelController();
    }

    private void CheckLevelUpdate()
    {
        if (currentLevelIndex >= levels.Length - 1) return;
        if (score < levels[currentLevelIndex + 1].minScore) return;
        currentLevelIndex++;

        SetCurrentLevelController();

    }

    private void SetCurrentLevelController()
    {

        LevelController level = levels[currentLevelIndex];
        CarController.speed = level.speed;
       
    }

    private void FixedUpdate()
    {
        TextOrange.text = orange.ToString("000");
        TextVidas.text = vidas.ToString("000");
        TextScore.text = score.ToString("000.##");

        if (CarController.verticalInput > 0)
        {
            score++;
            CheckLevelUpdate();
        }
    }
    
     public static void somaOrange() {
        orange++;
    }
    
    public static void diminuiVida()
    {
        vidas--;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        vidas = 3;
        orange = 0;
        score = 0;
    }

     public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
