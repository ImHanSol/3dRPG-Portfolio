using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    public int money { get; set; }

    public void AddMoney(int _money)
    {
        this.money += _money;
    }
}
