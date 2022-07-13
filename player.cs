using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* To-do List */
/* 시작 부분 */
// 화면에 "START!" 문구가 나오며 게임을 시작한다.
// 게임 시작하고 종료될 때까지 화면 좌측 상단에는 등수가 나온다.
// 플레이어가 어느 지점에 도달하면 맵 어디까지 왔는지 Map Bar에서 보여준다.

/* 플레이어 동작 */
// 무조건 높은 곳(게임 처음, 트램펄린 점프 등)에서 착지하면 부스터가 생성된다. (부스터 생성되면 몇초 동안 빠르게 달리기 가능)
// 플레이어 체력이 다 없어질 경우 플레이어는 헥헥거리며 3초정도 멈춘다.
// 중간에 적 또는 장애물과 부딪히면 뒤로 튕겨져 나간다.
// 플레이어의 분노게이지가 Full로 찰 경우, 부스터가 생성된다.
// 만약 높은 곳에서 떨어질 경우, 떨어지기 직전 위치에 플레이어가 이동된다.
// 트램펄린을 만나면 자동으로 아주 높게 점프한다. (이때 방향전환만 가능)
// 후반부 양탄자 구간에서는 양탄자를 타며 지니를 피해야한다. (이때 방향전환만 가능)

/* 종료 부분 */
// 게임 종료 후에 러닝 타임 얼마나 걸렸는지 보여준다.


public class player : MonoBehaviour
{
    public float jumpPower = 3.5f;
    public float gravity = -8f;
    public float speed = 20;
    float yVelocity;
    int jumpCount;
    public int maxJumpCount = 2;

    CharacterController cc;
    public TongTong bodyTongTong;

    public Transform goalZone;

    bool isFreeze = false;
    float currentTime;
    public float freezeTime = 3;
    PlayerHP php;
    AngerHP pahp;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        php = this.gameObject.GetComponent<PlayerHP>();
        pahp = this.gameObject.GetComponent<AngerHP>();
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
        // 사용자의 입력에 따라 방향 전환을 한다.
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
        // 점프 구현
        yVelocity += gravity * Time.deltaTime;

        // 땅에 있을 때 점프한다.
        if (cc.isGrounded)
        {
            jumpCount = 0;
            yVelocity = 0;
        }

        // 만약 Freeze상태라면
        if (isFreeze)
        {
            // 시간이 흐르다가
            currentTime += Time.deltaTime;
            // 만약 현재시간이 Freeze시간을 초과하면
            if (currentTime > freezeTime)
            {
                // 체력을 만땅채우고싶다.
                php.HP = php.maxHP;
                // Freeze상태를 끝내고싶다. 
                isFreeze = false;
            }
            // 함수를 바로 종료하고싶다.
        }

        // 점프 개수가 최대점프개수보다 적고 점프키를 눌렀다면
        if (false == isFreeze && jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            // 한번 더 점프한다.
            yVelocity = jumpPower;
            jumpCount++;
       
            // 점프를 1번할 때마다 체력이 1 감소하고 싶다.
            php.HP--;
            // 만약 플레이어의 체력이 0이하라면
            if (php.HP <= 0)
            {
                // Freeze 상태가 되게한다.
                isFreeze = true;
                currentTime = 0;
            }
        }

       
        //사용자의 입력에 따라 상하좌우로 움직인다.
        float h = 0;
        float v = 0;
        if (false == isFreeze)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        // 땅 위에 있고 W키(혹은 ArrowUp키)를 누르고 있다면
        if (cc.isGrounded && Input.anyKey && (v != 0 || h != 0)) // W키 혹은 ArrowUp키를 누르고있다면
        {
            // 통통거리며 움직인다.
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


        TestGoGoalZone();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("geine"))
        {
            pahp.ANGERHP++;
        }
    }

    
    private void TestGoGoalZone()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cc.enabled = false;
            transform.position = goalZone.position + Vector3.up * 3;
            cc.enabled = true;
        }
    }
}

/* 순간이동 하는 코드(캐릭터 컨트롤러 끄고 코드가 작동되어야 함)
        cc.enabled = false;   // componenet의 체크박스 끄는 방법이 enabled
        transform.position = Vector3.zero;
        cc.enabled = true;   */
