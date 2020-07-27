using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScrolling : MonoBehaviour
{
	[SerializeField] private float durationTime = 2f;
	[SerializeField] private float speed = 10f;
	[SerializeField] private float alphaSpeed = 2f;
	private float endTime;
	private TextMesh textmesh;
	private Color color;

	// Start is called before the first frame update
	private void Awake()
	{
		textmesh = GetComponent<TextMesh>();
		color = textmesh.color;
		Invoke("DestroyText", endTime);
	}

	// Update is called once per frame
	void Update()
	{
		transform.LookAt(Camera.main.transform); // 항상 카메라를 바라보게 함
		transform.Translate(Vector3.up * speed * Time.deltaTime); // 텍스트 위치
		color.a = Mathf.Lerp(color.a, 0, Time.deltaTime * alphaSpeed); // 텍스트의 알파값
	}

	private void DestroyText()
	{
		Destroy(gameObject);
	}

	public void SetText(string text)
	{
		textmesh.text = text;
	}

	public void SetColor(Color _color)
	{
		color = _color;
		textmesh.color = color;
	}
}
