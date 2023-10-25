using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonController : MonoBehaviour
{
    public GameObject panel;
    public void Start()
    {
        panel.SetActive(false);
    }
    public void open()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);

    }
    public void close()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);

    }

    public void quit()
    {
        Application.Quit();
    }
}
