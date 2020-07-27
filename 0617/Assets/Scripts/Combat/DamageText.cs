using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public TextScrolling prefab;
    public Color color = Color.red;
    public float offset = 0.5f;

    public void AttackDamageText(int damage)
    {
        var position = transform.position + Vector3.up * offset;
        var scroll = Instantiate(prefab, position, Quaternion.identity);

        scroll.SetColor(color);
        scroll.SetText(damage.ToString());
    }
}
