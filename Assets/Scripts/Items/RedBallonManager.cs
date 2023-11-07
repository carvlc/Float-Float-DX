using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedBallonManager : MonoBehaviour
{
    public void AllBallonsCollected()
    {
        if (transform.childCount == 8)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                // SceneManager.LoadScene("Level2");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

}
