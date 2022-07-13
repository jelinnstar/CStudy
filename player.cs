using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* To-do List */
/* ���� �κ� */
// ȭ�鿡 "START!" ������ ������ ������ �����Ѵ�.
// ���� �����ϰ� ����� ������ ȭ�� ���� ��ܿ��� ����� ���´�.
// �÷��̾ ��� ������ �����ϸ� �� ������ �Դ��� Map Bar���� �����ش�.

/* �÷��̾� ���� */
// ������ ���� ��(���� ó��, Ʈ���޸� ���� ��)���� �����ϸ� �ν��Ͱ� �����ȴ�. (�ν��� �����Ǹ� ���� ���� ������ �޸��� ����)
// �÷��̾� ü���� �� ������ ��� �÷��̾�� ����Ÿ��� 3������ �����.
// �߰��� �� �Ǵ� ��ֹ��� �ε����� �ڷ� ƨ���� ������.
// �÷��̾��� �г�������� Full�� �� ���, �ν��Ͱ� �����ȴ�.
// ���� ���� ������ ������ ���, �������� ���� ��ġ�� �÷��̾ �̵��ȴ�.
// Ʈ���޸��� ������ �ڵ����� ���� ���� �����Ѵ�. (�̶� ������ȯ�� ����)
// �Ĺݺ� ��ź�� ���������� ��ź�ڸ� Ÿ�� ���ϸ� ���ؾ��Ѵ�. (�̶� ������ȯ�� ����)

/* ���� �κ� */
// ���� ���� �Ŀ� ���� Ÿ�� �󸶳� �ɷȴ��� �����ش�.


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
        // ������� �Է¿� ���� ���� ��ȯ�� �Ѵ�.
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
        // ���� ����
        yVelocity += gravity * Time.deltaTime;

        // ���� ���� �� �����Ѵ�.
        if (cc.isGrounded)
        {
            jumpCount = 0;
            yVelocity = 0;
        }

        // ���� Freeze���¶��
        if (isFreeze)
        {
            // �ð��� �帣�ٰ�
            currentTime += Time.deltaTime;
            // ���� ����ð��� Freeze�ð��� �ʰ��ϸ�
            if (currentTime > freezeTime)
            {
                // ü���� ����ä���ʹ�.
                php.HP = php.maxHP;
                // Freeze���¸� ������ʹ�. 
                isFreeze = false;
            }
            // �Լ��� �ٷ� �����ϰ�ʹ�.
        }

        // ���� ������ �ִ������������� ���� ����Ű�� �����ٸ�
        if (false == isFreeze && jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            // �ѹ� �� �����Ѵ�.
            yVelocity = jumpPower;
            jumpCount++;
       
            // ������ 1���� ������ ü���� 1 �����ϰ� �ʹ�.
            php.HP--;
            // ���� �÷��̾��� ü���� 0���϶��
            if (php.HP <= 0)
            {
                // Freeze ���°� �ǰ��Ѵ�.
                isFreeze = true;
                currentTime = 0;
            }
        }

       
        //������� �Է¿� ���� �����¿�� �����δ�.
        float h = 0;
        float v = 0;
        if (false == isFreeze)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        // �� ���� �ְ� WŰ(Ȥ�� ArrowUpŰ)�� ������ �ִٸ�
        if (cc.isGrounded && Input.anyKey && (v != 0 || h != 0)) // WŰ Ȥ�� ArrowUpŰ�� �������ִٸ�
        {
            // ����Ÿ��� �����δ�.
            bodyTongTong.Jump();
        }
        else
        {
            bodyTongTong.CancelJump();
        }

        // �����¿�� ������ �����
        Vector3 dir = new Vector3(h, 0, v);
        dir = transform.TransformDirection(dir);
        // dir�� ũ�⸦ 1�� ������ �Ѵ�
        dir.Normalize();
        dir.y = yVelocity;
        // �� �������� �̵��ϰ� �ʹ�.
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

/* �����̵� �ϴ� �ڵ�(ĳ���� ��Ʈ�ѷ� ���� �ڵ尡 �۵��Ǿ�� ��)
        cc.enabled = false;   // componenet�� üũ�ڽ� ���� ����� enabled
        transform.position = Vector3.zero;
        cc.enabled = true;   */
