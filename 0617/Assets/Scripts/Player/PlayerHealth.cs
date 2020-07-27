using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;	
    public Slider hpBar;
    private Text hpText;

	public Image damageImage; // Hp가 30이하일 때 화면 깜빡이기 위한 이미지
    public float flashSpeed = 0.3f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

	private float flashTime = 3f;
	private float elapsedTime = 0f;

	public bool isDie
	{
		get 
		{ 
			if (currentHp <= 0) 
				return true;
			return false;
		}
	}

	PlayerAnimation playerAnimation;

    void Start()
    {
		playerAnimation = GetComponent<PlayerAnimation>();
        hpText = hpBar.GetComponentInChildren<Text>();

        currentHp = maxHp;
	}

    public void TakeDamage(int damageAmount)
    {
        currentHp = Mathf.Clamp(currentHp - damageAmount, 0, maxHp);

        hpBar.value = currentHp;

		playerAnimation.ChangeState(State.DAMAGE);

		if (isDie) playerAnimation.ChangeState(State.DIE);
    }

	private void Flash()
	{
		if (currentHp <= 30 && currentHp > 0)
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime > flashTime)
			{
				damageImage.color = flashColor;
				elapsedTime = 0f;
			}

			damageImage.color = Color.Lerp(damageImage.color, Color.clear, Time.deltaTime * flashSpeed);
		}
	}

    void Update()
    {
        hpText.text = currentHp + " / " + maxHp;
        Flash();
	}
}
