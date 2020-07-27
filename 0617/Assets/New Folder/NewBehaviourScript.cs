using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// fbx파일 은 3D 데이터의 원본 파일 (3d max파일)
// 원본 fbx파일로 부터 프리팹을 만들기 때문에 fbx파일 지우면 안됌

// 3D 데이터 : *.fbx
// 사운드 데이터 : *.ogg

// 충돌처리할 때 skinned mesh renderer 아니면 rect renderer 사용
// collider, trigger 사용 X


public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Vector3 world = transform.TransformPoint(new Vector3(0, 0, 0));
        Debug.Log(world);
    }

    // Update is called once per frame
    void Update()
    {
		Debug.DrawRay(transform.position, transform.forward * 10f, Color.red); 
		// Debug.DrawLine
    }
}
