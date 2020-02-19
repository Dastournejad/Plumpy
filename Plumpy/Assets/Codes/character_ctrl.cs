using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_ctrl : MonoBehaviour
{
    private GameObject gameManager;

    private int LeftLaneLimit;
    private int RightLaneLimit;
    public int LaneIndex;

    public int scoreCounter;

    public AudioClip failSound;
    public AudioClip biteSound1;
    public AudioClip biteSound2;
    public AudioClip biteSound3;
    private AudioSource effectSounds;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager");
        effectSounds = gameObject.GetComponent<AudioSource>();
        LaneIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the variable for the number of lanes into useful integers so the character wont jump outside of lines.
        LeftLaneLimit = gameManager.GetComponent<scene_ctrl>().leftLane;
        RightLaneLimit = gameManager.GetComponent<scene_ctrl>().rightLane;

        //A keyboard controll madule using arrow keys to move the character (useful for testing on laptops)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            JumpRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            JumpLeft();
        }
    }

    //Moves the character to upper lanes if there is any (Needs to be accessed from click event controls)
    public void JumpLeft()
    {
        if (LaneIndex > LeftLaneLimit)
        {
            Vector3 currentPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(currentPosition.x + 0.1f, 0, currentPosition.z);
            LaneIndex = LaneIndex - 1;
        }
    }

    //Moves the character to lower lanes if there is any (Needs to be accessed from click event controls)
    public void JumpRight()
    {
        if (LaneIndex < RightLaneLimit)
        {
            Vector3 currentPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(currentPosition.x - 0.1f, 0, currentPosition.z);
            LaneIndex = LaneIndex + 1;
        }
    }

    //This method checks if in each frame any game object that contains a collider (food/trap) would collide with the character 
    //(necessary to get the food and hit the traps)
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Reward")
        {
            effectSounds.clip = biteSound2;
            effectSounds.Play();
            gameManager.GetComponent<scene_ctrl>().Score += 10;
            other.GetComponent<Animator>().Play("grab");
            Destroy(other.gameObject, 0.3f);
        }

        if (other.tag == "Trap")
        {
            effectSounds.clip = failSound;
            effectSounds.PlayOneShot(failSound);
            gameManager.GetComponent<scene_ctrl>().Speed = 0;
            gameManager.GetComponent<scene_ctrl>().gameON = false;
            other.GetComponent<Animator>().Play("drop");
            other.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}