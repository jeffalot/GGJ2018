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
    public bool returnToHomeBase;

    public GameObject bottle;

    //public AudioSource overallAudio;
    //public AudioClip[] overallAudios;


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
        rightPointer.GetComponent<Renderer> ().enabled = false;
        leftPointer.GetComponent<Renderer> ().enabled = false;
        toggleNewObjective ();


        //int n = Random.Range(1, overallAudios.Length);
        //overallAudio.clip = overallAudios[n];
        //overallAudio.PlayOneShot(overallAudio.clip);

    }

    void Update () {
        if (restart) {
            if (Input.GetKeyDown (KeyCode.R)) {
                Scene loadedLevel = SceneManager.GetActiveScene ();
                SceneManager.LoadScene (loadedLevel.buildIndex);
            }
        }

        //Handle Scene Restart
        if (Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }

        checkForRestart ();
        UpdateInfected ();
        UpdateActivePointer ();

        bottle.SetActive(returnToHomeBase);
    }

    public void triggerCheckpointDeliver () {
        Debug.Log("XXXXXXX");
        AddScore (1);
        toggleNewObjective ();
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

        clearGoals ();

        int randomGoal = Random.Range (0, goals.Length);
        currentGoal = goals[randomGoal];
        currentGoal.SetActive(true);
        currentGoal.tag = "currentGoal";
    }

    void clearGoals () {
        homeBase.SetActive(false);
        foreach (var goal in goals)
        {
            goal.SetActive(false);
        }
        GameObject lastGoal = GameObject.FindWithTag ("currentGoal");
        if (lastGoal) {
            lastGoal.tag = "Untagged";
        }
    }

    void UpdateActivePointer () {
        if (currentGoal.transform.position.x < Camera.main.transform.position.x) {
            leftPointer.GetComponent<Renderer> ().enabled = true;
        } else if (currentGoal.transform.position.x > Camera.main.transform.position.x) {
            rightPointer.GetComponent<Renderer> ().enabled = true;
        }

        if (currentGoal.GetComponent<SpriteRenderer>().isVisible){
            rightPointer.GetComponent<Renderer> ().enabled = false;
            leftPointer.GetComponent<Renderer> ().enabled = false;
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