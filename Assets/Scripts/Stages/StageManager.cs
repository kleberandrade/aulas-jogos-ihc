using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class StageManager : MonoBehaviour
{
    public Transform m_Parent;
    public GameObject m_StageCard;
    public bool m_Fill = true;
    public bool m_Create = true;
    public int m_MaxLevel = 21;
    public List<Stage> m_Stages = new List<Stage>();

    private void Start()
    {
        CreateStageCards();
    }

    private void AutoFill()
    {
        for (int i = 1; i <= m_MaxLevel; i++)
        {
            m_Stages.Add(new Stage() { id = i, prefix = "Stage", score = 0, isUnlock = i == 1 });
        }
    }

    [ContextMenu("Create Stage Cards")]
    private void CreateStageCards()
    {
        if (m_Fill) AutoFill();

        if (!m_Create) return;
        
        foreach (var stage in m_Stages)
        {
            var go = Instantiate(m_StageCard);
            var card = go.GetComponent<StageCard>();
            card.Stage = stage;

            card.transform.SetParent(m_Parent);
            card.transform.localScale = Vector3.one;

            card.UpdateUI();
        }
    }
}