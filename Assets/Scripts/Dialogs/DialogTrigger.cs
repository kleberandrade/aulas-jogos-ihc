using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_Dialog;
    public bool m_PlayOnAproach;
    private bool m_IsAproach;

    private void Update()
    {
        if (m_IsAproach && Input.GetButtonDown("Fire1")) 
            DialogManager.Instance.BeginDialog(m_Dialog);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_PlayOnAproach)
                DialogManager.Instance.BeginDialog(m_Dialog);
            else
                m_IsAproach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            m_IsAproach = false;
    }
}
