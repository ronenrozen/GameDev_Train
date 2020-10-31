using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    void doExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        doExitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
