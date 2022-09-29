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

        //����� ȿ�� �߰� �ڵ�
        // ���콺�� ��ġ�� 
        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle * 2f;
        float tiltAroundX = Input.GetAxis("Mouse Y") * tiltAngle * -2f;
        
        
        //Slerp �Լ� : �� ���� ���ʹϾ� ������ �߰� ������ ������ִ� �Լ�
        //Time.deltaTime �ٷ� ���� �����Ӱ� ������ ������ ������ ��� �ð�
        // Quaternion.Euler : ���Ϸ����� �ش��ϴ� ���� ���ʹϾ� ������ ��ȯ

        var target = Quaternion.Euler(new Vector3(tiltAroundX, 0, tiltAroundZ));
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
