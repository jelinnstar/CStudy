using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* ���� �κ� */
// ȭ�鿡 "START!" ������ ������ ������ �����Ѵ�.
// ���� �����ϰ� ����� ������ ȭ�� ���� ��ܿ��� ���, Running Time Bar, �÷��̾� ü��&�г�������� ������, ȭ�� �ϴܿ��� Map �����Ȳ bar�� ���´�.

/* �÷��̾� ���� */
// ������ ���� ��(���� ó��, Ʈ���޸� ���� ��)���� �����ϸ� �ν��Ͱ� �����ȴ�. (�ν��� �����Ǹ� ���� ���� ������ �޸��� ����)
// (�Ϸ�) ������ �����ϸ� �޸���. (���� �ִ� ����: 2��, ���� ���� �����ؾ� ��)
// �÷��̾� ü���� ������ ������ 1ĭ�� �پ���, ü���� �� ������ ��� �÷��̾�� ����Ÿ��� 2������ �����.
// �߰��� �� �Ǵ� ��ֹ��� �ε����� �ڷ� ƨ���� ������, �г�������� 1ĭ�� ��µȴ�.
// �÷��̾� ü�� �� �г�������� Full�� �� ���, �ν��Ͱ� �����ȴ�.
// ���� ���� ������ ������ ���, �������� ���� ��ġ�� �÷��̾ �̵��ȴ�.
// Ʈ���޸��� ������ �ڵ����� ���� ���� �����Ѵ�. (�̶� ������ȯ�� ����)
// �Ĺݺ� ��ź�� ���������� ��ź�ڸ� Ÿ�� ���ϸ� ���ؾ��Ѵ�. (�̶� ������ȯ�� ����)

/* ���� �κ� */
// ȭ�鿡 "GOAL / Running Time / �ٽ� �����غ��ðڽ��ϱ�?" ������ ǥ�õȴ�.



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


        //������� �Է¿� ����    
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (cc.isGrounded && Input.anyKey && (v != 0 || h != 0)) // WŰ Ȥ�� ArrowUpŰ�� �������ִٸ�
        {
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
    }
}
    /* �����̵� �ϴ� �ڵ�(ĳ���� ��Ʈ�ѷ� ���� �ڵ尡 �۵��Ǿ�� ��)
            cc.enabled = false;   // componenet�� üũ�ڽ� ���� ����� enabled
            transform.position = Vector3.zero;
            cc.enabled = true;   */
