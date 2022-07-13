using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* 시작 부분 */
// 화면에 "START!" 문구가 나오며 게임을 시작한다.
// 게임 시작하고 종료될 때까지 화면 좌측 상단에는 등수, Running Time Bar, 플레이어 체력&분노게이지가 나오고, 화면 하단에는 Map 진행상황 bar가 나온다.

/* 플레이어 동작 */
// 무조건 높은 곳(게임 처음, 트램펄린 점프 등)에서 착지하면 부스터가 생성된다. (부스터 생성되면 몇초 동안 빠르게 달리기 가능)
// (완료) 점프와 병행하며 달린다. (점프 최대 개수: 2개, 점프 높이 제한해야 함)
// 플레이어 체력은 점프할 때마다 1칸씩 줄어들며, 체력이 다 없어질 경우 플레이어는 헥헥거리며 2초정도 멈춘다.
// 중간에 적 또는 장애물과 부딪히면 뒤로 튕겨져 나가며, 분노게이지가 1칸씩 상승된다.
// 플레이어 체력 및 분노게이지가 Full로 찰 경우, 부스터가 생성된다.
// 만약 높은 곳에서 떨어질 경우, 떨어지기 직전 위치에 플레이어가 이동된다.
// 트램펄린을 만나면 자동으로 아주 높게 점프한다. (이때 방향전환만 가능)
// 후반부 양탄자 구간에서는 양탄자를 타며 지니를 피해야한다. (이때 방향전환만 가능)

/* 종료 부분 */
// 화면에 "GOAL / Running Time / 다시 도전해보시겠습니까?" 문구가 표시된다.



public class player : MonoBehaviour

{
    public float jumpPower = 5;
    public float gravity = -9.81f;
    public float speed = 5;
    float yVelocity;
    int jumpCount;
    public int maxJumpCount = 2;

    CharacterController cc;
    public TongTong bodyTongTong;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateRotate();
        UpdateMove();
    }

    public float rotSpeed = 1;
    private void UpdateRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, rotSpeed * -150 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotSpeed * 150 * Time.deltaTime);
        }
    }

    void UpdateMove()
    {
        yVelocity += gravity * Time.deltaTime;

        if (cc.isGrounded)
        {
            jumpCount = 0;
            yVelocity = 0;
        }

        if (jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }


        //사용자의 입력에 따라    
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (cc.isGrounded && Input.anyKey && (v != 0 || h != 0)) // W키 혹은 ArrowUp키를 누르고있다면
        {
            bodyTongTong.Jump();
        }
        else
        {
            bodyTongTong.CancelJump();
        }

        // 상하좌우로 방향을 만들고
        Vector3 dir = new Vector3(h, 0, v);
        dir = transform.TransformDirection(dir);
        // dir의 크기를 1로 만들어야 한다
        dir.Normalize();
        dir.y = yVelocity;
        // 그 방향으로 이동하고 싶다.
        cc.Move(dir * speed * Time.deltaTime);
    }
}
    /* 순간이동 하는 코드(캐릭터 컨트롤러 끄고 코드가 작동되어야 함)
            cc.enabled = false;   // componenet의 체크박스 끄는 방법이 enabled
            transform.position = Vector3.zero;
            cc.enabled = true;   */
