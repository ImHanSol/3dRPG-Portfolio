using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
	private PlayerAnimation playerAnimation;

	private void Start()
	{
		playerAnimation = GetComponent<PlayerAnimation>();
	}

	private void InputController()
	{
		// UI 클릭했을 때 다른 이벤트가 전달되지 않게 함
		if (EventSystem.current.IsPointerOverGameObject()) return;

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				var temp = hit.collider.gameObject;

                if(hit.collider.gameObject)
                {
                    playerAnimation.ToMove(hit.point);
                }

				if (temp.name == "Floor")
				{					
					playerAnimation.ToMove(hit.point);
				}
				else if(temp.tag == "NPC")
				{
					playerAnimation.ToMove(hit.point);
					temp.GetComponent<NPC>().LoadQuestWindow();
				}
			}
		}
	}

	private void Update()
	{
		InputController();
	}
}
