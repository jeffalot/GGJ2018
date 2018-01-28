using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

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
    private GameObject leftPointer;
    private GameObject rightPointer;
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

        // Find our pointers attached to the Camera
        leftPointer = GameObject.Find ("HandPointerL");
        rightPointer = GameObject.Find ("HandPointerR");
    }

    void Update () {
        if (restart) {
            if (Input.GetKeyDown (KeyCode.R)) {
                Application.LoadLevel (Application.loadedLevel);
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
        currentGoal = goals[Random.Range (0, goals.Length)];

        if (currentGoal.transform.position.x < 0) {
            leftPointer.SetActive (true);
            rightPointer.SetActive (false);
        } else {
            leftPointer.SetActive (false);
            rightPointer.SetActive (true);
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
        //scoreText.text = "Score: " + score;
    }

    public void GameOver () {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}