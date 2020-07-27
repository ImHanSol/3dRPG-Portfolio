using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public int rewardMoney { get; set; }

    private void Start()
    {
        rewardMoney = Random.Range(50, 100);
    }
}
