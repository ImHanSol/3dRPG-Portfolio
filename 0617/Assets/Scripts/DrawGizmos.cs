using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public Color m_color = Color.red;
    public float m_radius = 1.0f;

    // 매 프레임마다 호출되는 함수
    public void OnDrawGizmos()
    {
        Gizmos.color = m_color;
        Gizmos.DrawSphere(transform.position, m_radius);
    }
}
