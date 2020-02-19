using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrier_ctrl : MonoBehaviour
{
    public GameObject Reward;
    public GameObject Trap;
    public GameObject gameManager;

    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager");
        int childIndex = Random.Range(1, 4);
        //Debug.Log(childIndex);
        if(childIndex == 1)
        {
            GameObject trapObj = Instantiate(Trap, transform.position, Quaternion.Euler(0,0,0));
            trapObj.transform.parent = gameObject.transform;
        }
        else if(childIndex != 1)
        {
            GameObject rewardObj = Instantiate(Reward, transform.position, Quaternion.Euler(0, 180, 0));
            rewardObj.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = gameManager.GetComponent<scene_ctrl>().Speed;
        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));

        //Destroy after certain position (To prevent piling up unused objects)
        if (gameObject.transform.position.z < -1)
        {
            Destroy(gameObject, 0);
        }

    }
}
