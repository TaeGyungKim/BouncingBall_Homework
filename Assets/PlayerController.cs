using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; //�¿�� ������ ���� �ӵ�
                                 // private Rigidbody rigidbody;


    private void Start()
    {

    }

    private void Update() //�� ������ ���� ����
    {


        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //moveSpeed��
        if (xInput != 0 || zInput != 0)
            transform.position = new Vector3(transform.position.x + xInput * moveSpeed * Time.deltaTime,
                transform.position.y, transform.position.z + zInput * moveSpeed * Time.deltaTime);
    }




    private void OnCollisionStay2D(Collision2D collision)
    { //�ٸ� ��ü�� �����ϴ� ���� (�ٴڿ� ������� ����)
        if (collision.contacts[0].normal.y > 0.7f && collision.collider.CompareTag("DeathZone"))
        { //��ü�� ���ʿ� ���, �� ��ü�� Ground�� ��� 
            gameObject.SetActive(false);
        }
    }
}