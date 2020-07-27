using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public GameObject coinPrefab;
    private int coinCount;
    private GameObject coin;
    List<GameObject> coinList = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        coinCount = GameObject.Find("Monster").transform.childCount;
        CreateCoin();
    }

    // 게임 시작 시 미리 코인 생성 후 비활성화 
    private void CreateCoin()
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject tempCoin = Instantiate(coinPrefab) as GameObject;

            tempCoin.transform.parent = transform;
            tempCoin.SetActive(false);
            coinList.Add(tempCoin);
        }
    }

    // 미리 생성 한 코인이 남아 있는지 체크
    private void DropCoinCheck()
    {
        for (int i = 0; i < coinList.Count; i++)
        {
            // coinList에서 비활성화 상태인 코인이 있다면 그 coin사용
            if (coinList[i].activeSelf == false)
            {
                coin = coinList[i];
                break;
            }
        }

        // coinList의 모든 인덱스가 활성화 상태라면 새로운 코인 Instantiate
        if (coin == null)
        {
            GameObject newCoin = Instantiate(coinPrefab) as GameObject;
            coinList.Add(newCoin);
            coin = newCoin;
        }
    }

    // 몬스터 죽은 위치에 코인 활성화
    public void DropCoin(Vector3 monsterPosition, int coinValue)
    {
        DropCoinCheck();

        coin.SetActive(true);
        coin.GetComponent<Coin>().SetCoinValue(coinValue);
        coin.transform.position = new Vector3(monsterPosition.x, coin.transform.position.y, monsterPosition.z);
    }
}
