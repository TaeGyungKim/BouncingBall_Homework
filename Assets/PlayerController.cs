using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; //좌우로 움직일 때의 속도
                                 // private Rigidbody rigidbody;


    private void Start()
    {

    }

    private void Update() //매 프레임 마다 실행
    {


        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //moveSpeed만
        if (xInput != 0 || zInput != 0)
            transform.position = new Vector3(transform.position.x + xInput * moveSpeed * Time.deltaTime,
                transform.position.y, transform.position.z + zInput * moveSpeed * Time.deltaTime);
    }




    private void OnCollisionStay2D(Collision2D collision)
    { //다른 물체와 접촉하는 동안 (바닥에 닿았음을 감지)
        if (collision.contacts[0].normal.y > 0.7f && collision.collider.CompareTag("DeathZone"))
        { //물체의 위쪽에 닿고, 이 물체가 Ground일 경우 
            gameObject.SetActive(false);
        }
    }
}