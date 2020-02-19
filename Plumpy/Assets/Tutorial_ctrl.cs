using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_ctrl : MonoBehaviour
{
    public Canvas TutorialCanvas;

    // Start is called before the first frame update
    void Start()
    {
        TutorialCanvas.enabled = true;
    }

    public void gameStarts()
    {
        TutorialCanvas.enabled = false;
    }
}
