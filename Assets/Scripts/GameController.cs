using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
	public Text infectedText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
	private int infected;

	public GameObject[] goals;
	public GameObject homeBase;

	private GameObject currentGoal;

    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
		infected = 0;
        UpdateScore ();
		getNewGoal();
    }
 
    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }

		checkForRestart();

		updateInfected();
    }

	public void getNewGoal(){
		currentGoal = goals[Random.Range(0,goals.Length)];
	}

	void checkForRestart(){
		if (gameOver)
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
		}
	}

	void UpdateInfected(){
		infected = GameObject.FindGameObjectsWithTag("Infected").Length;
		infectedText = "Infected: " + infected;
	}

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}