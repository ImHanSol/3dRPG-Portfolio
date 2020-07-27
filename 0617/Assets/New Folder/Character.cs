using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    enum eAni
    {
        Idle = 0,
        Walk = 1,
    }

    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetInteger("iAniIdex", 1);
        ani.SetInteger("iAniIdex", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
