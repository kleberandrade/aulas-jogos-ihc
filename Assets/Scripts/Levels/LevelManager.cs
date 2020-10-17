using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LevelManager : MonoBehaviour
{
    public Transform m_Parent;
    public GameObject m_LevelCard;
    public bool m_Fill = true;
    public bool m_Create = true;
    public int m_MaxLevel = 21;
    public List<Level> m_Levels = new List<Level>();

    private void Start()
    {
        CreateLevelCards();
    }

    private void AutoFill()
    {
        for (int i = 1; i <= m_MaxLevel; i++)
        {
            m_Levels.Add(new Level() { id = i, prefix = "Level", score = 0, isUnlock = i == 1 });
        }
    }

    [ContextMenu("Create Level Cards")]
    private void CreateLevelCards()
    {
        if (m_Fill) AutoFill();

        if (!m_Create) return;
        
        foreach (var level in m_Levels)
        {
            var go = Instantiate(m_LevelCard);
            var card = go.GetComponent<LevelCard>();
            card.m_Id = level.id;
            card.m_Prefix = level.prefix;
            card.m_Score = level.score;
            card.m_IsUnlock = level.isUnlock;

            card.transform.SetParent(m_Parent);
            card.transform.localScale = Vector3.one;

            card.UpdateUI();
        }
    }
}

[System.Serializable]
public class Level
{
    public int id;
    public string prefix;
    public int score;
    public bool isUnlock;
}