using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


    public float xMinMax;
    public float zMin;

    public GameObject Rock;


    public int count;
    public float startWait;
    public float cloneWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

  

    private int score;
    private bool gameOver;
    private bool restart;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = restart = false;
        scoreText.text = "Score:0";
        restartText.text = "";
        gameOverText.text = "";
       StartCoroutine(Waves());
    }
    private void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator Waves()
    {

        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < count; i++)
            {
                Instantiate(Rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            if (gameOver)
            {
                restart = true;
                restartText.text = "designer Minh Duc said press 'R' to play again";
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void addScore(int sc)
    {
        score += sc;
        scoreText.text = "Score: " +score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! - This game is designed by engineer Minh Duc";
        gameOver = true;
    }
}
