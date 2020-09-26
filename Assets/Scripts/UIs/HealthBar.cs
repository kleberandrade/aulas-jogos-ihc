using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealthBar : MonoBehaviour
{
    public Image m_BarUI;
    public Text m_TextUI;
    public float m_MaxValue = 100.0f;
    public float m_CurrentValue = 100.0f;
    public Color m_MinColor = new Color(0.90f, 0.29f, 0.23f, 1.0f);
    public Color m_MaxColor = new Color(0.94f, 0.76f, 0.06f, 1.0f); 

    private void Start()
    {
        UpdateValue(m_CurrentValue);
    }

    private void UpdateValue(float value)
    {
        m_CurrentValue = Mathf.Clamp(value, 0.0f, m_MaxValue);
        float valueRatio = m_CurrentValue / m_MaxValue;
        if (m_BarUI)
        {
            m_BarUI.fillAmount = valueRatio;
            m_BarUI.color = Color.Lerp(m_MinColor, m_MaxColor, valueRatio);
        }

        if (m_TextUI)
        {
            m_TextUI.text = $"{(int)m_CurrentValue} / {(int)m_MaxValue}";
        }
    }

    public void TakeDamage(float value)
    {
        UpdateValue(m_CurrentValue - value);
    }

    public void Heal(float value)
    {
        UpdateValue(m_CurrentValue + value);
    }


    [ContextMenu("Take Damage (10)")]
    public void TakeFixedDamageTest()
    {
        TakeDamage(10.0f);
    }

    [ContextMenu("Heal (5)")]
    public void HealFixedTest()
    {
        Heal(5.0f);
    }
}
