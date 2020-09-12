using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public Vector3 m_Axis = Vector3.forward;
    public float m_Speed = 180.0f;

    public void Update()
    {
        transform.Rotate(m_Axis * m_Speed * Time.deltaTime);
    }
}
