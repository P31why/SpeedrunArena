using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isVisible;
    private void Awake()
    {
        isVisible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isVisible = !isVisible;
            Time.timeScale = isVisible ? 0:1;
        }
    }
}
