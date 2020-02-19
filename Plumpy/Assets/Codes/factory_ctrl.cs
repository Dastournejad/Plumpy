using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factory_ctrl : MonoBehaviour
{
    public GameObject objCarrier;
    private GameObject gameManager;
    private float GeneratorTimer;
    private float timer;
    public bool workHour;
    // indicates the max delay time for each factory to create a food/trap (the lower the number the harder the game will be)
    public int maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        workHour = true;
        GeneratorTimer = maxDelay;
        gameManager = GameObject.Find("Game_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (gameManager.GetComponent<scene_ctrl>().gameON == false)
        {
            workHour = false;
        }

        if(workHour && timer > GeneratorTimer)
        {
            Instantiate(objCarrier, transform.position, Quaternion.Euler(0, 180, 0));
            timer = 0;
            GeneratorTimer = Random.Range(0.1f, maxDelay);
        }
    }

}

