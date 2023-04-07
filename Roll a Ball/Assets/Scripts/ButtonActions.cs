using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonActions : MonoBehaviour
{
    public string Start = "Start";
    public LevelLoader levelLoader;

    public void StartGameOnClick()

    {
        levelLoader.Transition(Start);
    }

    public void QuitGameOnClick()
    {
        Application.Quit();
    }
}
