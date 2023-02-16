using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveScript : MonoBehaviour
{
    public float playerSpeed = 7f;                                  //      �v���C���[�̈ړ����x

    public float playerRanSpeed = 13f;                              //      �v���C���[�̑���ړ����x

    private Vector2 playerPos = new Vector2(0f,0f);                 //      �v���C���[�̌��݈ʒu

    private Vector2 playerVelocity = new Vector2(0f, 0f);           //      �v���C���[�̈ړ���

    private float ranTime = 0f;                                     //      �v���C���[������n�߂鎞�Ԃ̊Ǘ�

    //      �V�X�e���n
    private Animator animator;
    private Rigidbody2D rd;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() 
    {
        Move();
    }

    //      �ړ��֌W
    private void Move()
    {
        //      Velocity�̏�����
        playerVelocity = new Vector2(0f, 0f);

        //      ���͂��󂯎��
        playerVelocity.x = Input.GetAxisRaw("Horizontal");
        playerVelocity.y = Input.GetAxisRaw("Vertical");

        //      �ړ��ʂ̐��K��
        var length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x +
                            playerVelocity.y * playerVelocity.y);

        //      �ړ��ʂ��O�ȏ�̎���������
        if (length > 0)
        {
            playerVelocity.x /= length;
            playerVelocity.y /= length;
        }

        PlayerMoveAnimation();

        MoveSpeed(length);

        playerPos = playerVelocity;

        //      �v���C���[�̌��݈ʒu��ύX����
        rd.velocity = playerPos;
    }

    //      ���������肩�̔���
    private void MoveSpeed(float length)
    {
        //      ���K�������Ƃ��̑傫�����O�̎��~�܂��Ă���Ɣ��f����
        if (length == 0)
        {
            ranTime = 0f;
            return;
        }

        if (ranTime > 5f)
        {
            //      �ړ��ʂɃX�s�[�h���|����(�_�b�V��)
            playerVelocity.x *= playerRanSpeed;
            playerVelocity.y *= playerRanSpeed;
        }
        else
        {
            //      �ړ��ʂɃX�s�[�h���|����(����)
            playerVelocity.x *= playerSpeed;
            playerVelocity.y *= playerSpeed;

            //      ���b�����Ă��邩�v������
            ranTime += Time.deltaTime;
        }
    }

    //      �v���C���[�ړ��̃A�j���[�V����
    private void PlayerMoveAnimation()
    {
        PlayerMoveAnimationInitialization();

        //      ���Ɉړ����Ă��邩�ǂ���
        bool diagonal = false;

        //      ���E�ړ������Ă��邩
        if (playerVelocity.x != 0f)
        {
            //      �E�ړ����Ă���Ƃ��̃A�j���[�V����
            if (playerVelocity.x > 0)
            {
                animator.SetBool("Right", true);
                diagonal = true;
            }

            //      ���ړ����Ă���Ƃ��̃A�j���[�V����
            if (playerVelocity.x < 0)
            {
                animator.SetBool("Left", true);
                diagonal = true;
            }
        }

        //      ���Ɉړ����Ă���Ƃ��͕Ԃ�
        if (diagonal) return;

        //      �㉺�Ɉړ����Ă��邩�ǂ���
        if (playerVelocity.y != 0f)
        {
            //      ��ړ����Ă���Ƃ��̃A�j���[�V����
            if (playerVelocity.y < 0)
            {
                animator.SetBool("Behind", true);
            }

            //      ���ړ����Ă���Ƃ��̃A�j���[�V����
            if (playerVelocity.y > 0)
            {
                animator.SetBool("Before", true);
            }
        }
    }

    //      �ړ��̃A�j���[�V�����̏�����
    private void PlayerMoveAnimationInitialization()
    {
        animator.SetBool("Behind", false);
        animator.SetBool("Before", false);
        animator.SetBool("Right",  false);
        animator.SetBool("Left",   false);
    }

    private void AtkAnimaTest()
    {
    }
}
