using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터를 따라가는 메인카메라 클래스
public class CameraFallow : MonoBehaviour
{
	//	// The target we are following
	//	[SerializeField]
	//	private Transform target;
	//	[SerializeField]
	//	private float distance = 10.0f;
	//	[SerializeField]
	//	private float height = 5.0f;

	//	[SerializeField]
	//	private float rotationDamping;
	//	[SerializeField]
	//	private float heightDamping;

	//	void LateUpdate()
	//	{
	//		if (!target)
	//			return;

	//		var wantedRotationAngle = target.eulerAngles.y;
	//		var wantedHeight = target.position.y + height;

	//		var currentRotationAngle = transform.eulerAngles.y;
	//		var currentHeight = transform.position.y;

	//		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
	//		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

	//		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

	//		transform.position = target.position;
	//		transform.position -= currentRotation * Vector3.forward * distance;


	//		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

	//		transform.LookAt(target);
	//	}
	//}

	[SerializeField]
	private Transform target;
	private Vector3 offset; //카메라와 플레이어 사이의 거리
    [SerializeField] private float fallowSpeed = 5f;

	private float minZoom = 30.0f;
	private float maxZoom = 90.0f;
	private float currentZoom = 60.0f;
    

	// Start is called before the first frame update
	void Start()
	{
		offset = transform.position - target.transform.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * fallowSpeed);

		var wheel = Input.GetAxis("Mouse ScrollWheel");
		currentZoom += wheel;
		Camera.main.fieldOfView = Mathf.Clamp(currentZoom, minZoom, maxZoom);
	}
}

