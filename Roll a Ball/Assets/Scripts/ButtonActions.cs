using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonActions : MonoBehaviour
{
    
    public void StartGameOnClick()
    {
        SceneManager.LoadScene("Start");
    }

    public void RestartGameOnClick()
    {
        SceneManager.LoadScene("Start");
    }
}
