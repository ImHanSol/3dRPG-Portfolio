using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarManager : MonoBehaviour
{
    [SerializeField] private GameObject hpBarPrefab;
    private GameObject hpBarObj;
    private int hpBarCount;

    private Canvas uiCanvas;

    // Start is called before the first frame update
    void Start()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        hpBarCount = GameObject.Find("Monster").transform.childCount;

        CreateHpBar();
    }

    private void CreateHpBar()
    {
        for (int i = 0; i < hpBarCount; i++)
        {
            hpBarObj = Instantiate(hpBarPrefab, uiCanvas.transform) as GameObject;
            //hpBarObj.SetActive(false);
        }
    }
}
