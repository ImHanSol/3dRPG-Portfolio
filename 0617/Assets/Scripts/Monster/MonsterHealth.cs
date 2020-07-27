using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public int maxHp = 100;
    public int monsterCurrentHp;

    private MonsterStat monsterStat;
    private MonsterAnimation monsterAnimation;
    private MonsterHpBar monsterHpBar;
    private Slider hpBarSlider;
    private DamageText damageText;

    public Vector3 hpBarOffset = new Vector3(0, 2f, 0);

    public bool isMonsterDie
    {
        get
        {
            if (monsterCurrentHp <= 0)
            {
                monsterAnimation.ChangeState(MonsterState.Die);
                return true;
            }
            return false;
        }
    }

    private void Awake()
    {
        monsterAnimation = GetComponent<MonsterAnimation>();
        monsterStat = GetComponent<MonsterStat>();
        monsterHpBar = GetComponent<MonsterHpBar>();
        hpBarSlider = monsterHpBar.GetComponent<Slider>();
        damageText = GetComponent<DamageText>();
        
        monsterCurrentHp = maxHp;
        HpBar();
    }

    public void TakeDamage(int damageAmount)
    {
        monsterCurrentHp = Mathf.Clamp(monsterCurrentHp - damageAmount, 0, maxHp);
        damageText.AttackDamageText(damageAmount); // 데미지 출력

        hpBarSlider.value = monsterCurrentHp;

        if (isMonsterDie)
            CoinManager.instance.DropCoin(transform.position, monsterStat.rewardMoney);
    }

    private void HpBar()
    {
        monsterHpBar.target = this.gameObject.transform;
        monsterHpBar.offset = hpBarOffset;
    }

    private void Update()
    {

    }
}
