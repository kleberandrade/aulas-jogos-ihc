using UnityEngine;
using UnityEngine.UI;

public class StageCard : MonoBehaviour
{
    public Text m_ContentUI;
    public Text m_ScoreUI;
    public Stage Stage { get; set; }

    public void Play()
    {
        if (Stage.isUnlock)
        {
            var sceneName = $"{Stage.prefix}{Stage.id:000}";
            ScreenManager.Instance.LoadLevelLoading(sceneName);
        }
    }

    public void UpdateUI()
    {
        m_ContentUI.text = Stage.id.ToString();
        m_ScoreUI.text = Stage.isUnlock ? Stage.score.ToString() : "Locked";
    }
}
