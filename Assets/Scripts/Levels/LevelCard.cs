using UnityEngine;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
    [Header("UI")]
    public Text m_ContentUI;
    public Text m_ScoreUI;

    [Header("Info")]
    public int m_Id;
    public string m_Prefix = "Level";
    public int m_Score;
    public bool m_IsUnlock;

    public void Play()
    {
        if (m_IsUnlock)
        {
            var sceneName = $"{m_Prefix}{m_Id:000}";
            ScreenManager.Instance.LoadLevelLoading(sceneName);
        }
    }

    public void UpdateUI()
    {
        m_ContentUI.text = m_Id.ToString();
        m_ScoreUI.text = m_IsUnlock ? m_Score.ToString() : "Locked";
    }
}
