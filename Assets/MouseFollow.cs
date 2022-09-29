using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float smooth= 5f;
    public float tiltAngle = 30f;


    private float halfW = Screen.width / 2f;
    private float halfH = Screen.height / 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((Input.mousePosition.x - halfW) / halfW,
            0, (Input.mousePosition.y - halfH)/halfH);


        //Debug.Log(Input.mousePosition.x);

        //기울임 효과 추가 코드
        // 마우스의 위치를 
        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle * 2f;
        float tiltAroundX = Input.GetAxis("Mouse Y") * tiltAngle * -2f;
        
        
        //Slerp 함수 : 두 개의 쿼터니언 각도의 중간 각도를 계산해주는 함수
        //Time.deltaTime 바로 직전 프레임고 ㅏ현자 프레임 사이의 경과 시간
        // Quaternion.Euler : 오일러각에 해당하는 값을 쿼터니언 각도로 변환

        var target = Quaternion.Euler(new Vector3(tiltAroundX, 0, tiltAroundZ));
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
