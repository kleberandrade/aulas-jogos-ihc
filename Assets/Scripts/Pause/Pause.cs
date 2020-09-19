using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Pause : MonoBehaviour
{
    public bool m_IsPaused { get; set; }

    public GameObject m_PausePanel;

    public void Show()
    {
        m_IsPaused = true;
        m_PausePanel.SetActive(m_IsPaused);
        Time.timeScale = 0.0f;
    }

    public void Hide()
    {
        m_PausePanel.SetActive(false);
        m_IsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void Toggle()
    {
        if (m_IsPaused)
            Hide();
        else 
            Show();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Toggle();
    }
}
