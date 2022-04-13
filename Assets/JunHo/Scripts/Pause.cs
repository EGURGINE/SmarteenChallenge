using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject bg;
    private bool isPause = false;
    
    public void BtnPause()
    {
        if (isPause)
        {
            Time.timeScale = 1f;
            bg.SetActive(false);
            isPause = false;
        }
        else
        {
            isPause = true;
            bg.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
