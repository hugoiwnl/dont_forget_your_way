using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene(4);
    }

    public void gameInfo()
    {
        SceneManager.LoadScene(2);
    }

    public void gameCredits()
    {
        SceneManager.LoadScene(3);
    }
}
