using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public Text infectedText;
    public Text restartText;
    public Text gameOverText;
    public Text scoreText;

    private bool gameOver;
    private bool restart;
    public int score;
    public int infected;

    public GameObject[] goals;
    public GameObject homeBase;

    private GameObject currentGoal;
    public GameObject leftPointer;
    public GameObject rightPointer;
    private bool returnToHomeBase;

    void Start () {
        Instance = (GameController) GameObject.FindObjectOfType (typeof (GameController));

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

    public void triggerCheckpointDeliver () {
        AddScore (1);
        toggleNewObjective ();
    }

    public void toggleNewObjective () {
        returnToHomeBase = !returnToHomeBase;
        if (returnToHomeBase) {
            currentGoal = homeBase;
        } else {
            getNewGoal ();
        }
    }

    void getNewGoal () {

        clearGoals ();

        int randomGoal = Random.Range (0, goals.Length);
        currentGoal = goals[randomGoal];
        currentGoal.tag = "currentGoal";

        UpdateActivePointer ();
    }

    void clearGoals () {
        GameObject lastGoal = GameObject.FindWithTag ("currentGoal");
        if (lastGoal) {
            lastGoal.tag = "";
        }
    }

    void UpdateActivePointer () {
        rightPointer.GetComponent<Renderer> ().enabled = false;
        leftPointer.GetComponent<Renderer> ().enabled = false;

        if (currentGoal.transform.position.x < 0) {
            leftPointer.GetComponent<Renderer> ().enabled = true;
        } else {
            rightPointer.GetComponent<Renderer> ().enabled = true;
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

    void AddScore (int newScoreValue) {
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