using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
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
    public GameObject leftPointer;
    public GameObject rightPointer;
    private bool returnToHomeBase;

    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        infected = 0;
        UpdateScore ();

        returnToHomeBase = false;
        toggleNewObjective ();
    }

    void Update () {
        if (restart) {
            if (Input.GetKeyDown (KeyCode.R)) {
                Scene loadedLevel = SceneManager.GetActiveScene ();
                SceneManager.LoadScene (loadedLevel.buildIndex);
            }
        }

        checkForRestart ();
        UpdateInfected ();
    }

    public void toggleNewObjective () {
        if (returnToHomeBase) {
            currentGoal = homeBase;
        } else {
            getNewGoal ();
        }
        returnToHomeBase = !returnToHomeBase;
    }

    void getNewGoal () {
        rightPointer.GetComponent<Renderer>().enabled  = false;
        leftPointer.GetComponent<Renderer>().enabled  = false;
        int randomGoal = Random.Range (0, goals.Length);
        
        Debug.Log("randomGoal Index is " + randomGoal);

        currentGoal = goals[randomGoal];

        Debug.Log("currentGoal name is " + currentGoal.name);
        Debug.Log("currentGoal x is" + currentGoal.transform.position.x);

        if (currentGoal.transform.position.x < 0) {
            leftPointer.GetComponent<Renderer>().enabled  = true;
        } else {
            rightPointer.GetComponent<Renderer>().enabled  = true;
        }
    }

    void checkForRestart () {
        if (gameOver) {
            restartText.text = "Press Space To Restart";
            restart = true;
        }
    }

    void UpdateInfected () {
        infected = GameObject.FindGameObjectsWithTag ("Infected").Length;
        infectedText.text = "Infected: " + infected;
    }

    public void AddScore (int newScoreValue) {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore () {
        scoreText.text = "Score: " + score;
    }

    public void GameOver () {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}