using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeReference] private float rotateSpeed = 180f;
    [HideInInspector] public int coinValue = 1000;

    private float coinPickUpDistance = 3.5f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void SetCoinValue(int _coinValue)
    {
        this.coinValue = _coinValue;
    }

    private void CoinRotate()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0f, 0f);

        transform.position = new Vector3(transform.position.x, 
            Mathf.Lerp(transform.position.y, 0.9f, 0.5f * Time.deltaTime), transform.position.z);
        transform.position = new Vector3(transform.position.x, 
            Mathf.Lerp(transform.position.y, 0.22f, 0.5f * Time.deltaTime), transform.position.z);
    }

    IEnumerator YChange()
    {
        yield return null;
    }

    private void PickUpCoin()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= coinPickUpDistance)
        {
            player.GetComponent<PlayerStuff>().AddMoney(coinValue);

            RemoveCoin();
        }
    }

    private void RemoveCoin()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        CoinRotate();
    }
}
