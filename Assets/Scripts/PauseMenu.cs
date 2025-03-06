using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    private void Awake()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0:1;
        }
    }
}
