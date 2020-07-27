using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHpBar : MonoBehaviour
{
    private Camera uiCamera;
    private Canvas canvas;
    private RectTransform rectParent;
    private RectTransform rectHp;

    [HideInInspector] public Vector3 offset = Vector3.zero;
    [HideInInspector] public Transform target;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();   
    }

    private void LateUpdate()
    {
        // 월드 좌표를 스크린 좌표로 변환
        var screenPos = Camera.main.WorldToScreenPoint(target.position + offset);

        // 카메라가 180도 회전 되어있을 경우 좌표값 보정
        if(screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }

        var localPos = Vector2.zero;
        // 스크린 좌표를 RectTransform이 기준인 좌표로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectParent, screenPos, uiCamera, out localPos);

        // Hp바 위치 변경
        rectHp.localPosition = localPos;
    }

}
