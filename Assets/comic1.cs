using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class comic1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextComic()
    {
        SceneManager.LoadScene(5);
    }
}
