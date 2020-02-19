using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene_ctrl : MonoBehaviour
{
    //this indicates wether it's gameover or not (basically stops the factories, zeros the speed and pulls the endgame screen)
    public bool gameON;
    // to integers for setting the limitation on jamping lanes (the character wont jump passed this limits)
    public int leftLane;
    public int rightLane;
    // indicates the speed of food/trap tokens (the higher the number the harder the game would be)
    public float Speed;
    // Score integer (must be converted to String to be displayed on screen)
    public int Score;
    // A timer interval to make speed go faster as time goes by
    public float difficultyTimer;
    private float timer;
    // access to display text (to write the score)
    public Text Scoring;

    private GameObject resetBut;

    // Start is called before the first frame update
    void Start()
    {
        resetBut = GameObject.Find("Restart_but");
        if (resetBut == null)
        {
            Debug.Log("Reset Button is Null!");
        }

        gameON = true;
        Score = 00;
    }

    // Update is called once per frame
    void Update()
    {

        //Write the Score integer into the text component on the screen
        //Debug.Log(Score);
        Scoring.text = ("Score: " + Score);

        //Uses DificultyTimer to make game faster as time goes by (if the game is running)
        timer += Time.deltaTime;
        if (gameON)
        {
            if(difficultyTimer < timer)
            {
                Speed += 0.1f;
                timer = 0;
            }
        }
        else
        {
            //Brings back the Restart Button when game is over
            resetBut.GetComponent<Animator>().Play("reveal");
            //Stops background music
            gameObject.GetComponent<AudioSource>().Stop();
        }

    }

    // Restart function, called by clicking on Restart Button
    public void restart()
    {
        SceneManager.LoadScene("Bunny_jump");
    }

    //Exit function
    public void exit()
    {
        Application.Quit();
    }
}
