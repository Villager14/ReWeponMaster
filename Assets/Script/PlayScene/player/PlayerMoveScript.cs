using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveScript : MonoBehaviour
{
    public float playerSpeed = 7f;                                  //      �v���C���[�̈ړ����x

    public float playerRanSpeed = 13f;                              //      �v���C���[�̑���ړ����x

    private Vector2 playerPos = new Vector2(0f, 0f);                 //      �v���C���[�̌��݈ʒu

    private Vector2 playerVelocity = new Vector2(0f, 0f);           //      �v���C���[�̈ړ���

    private float ranTime = 0f;                                     //      �v���C���[������n�߂鎞�Ԃ̊Ǘ�

    private Vector2 weponDirection = new Vector2(0f,0f);            //      �����Ă������

    private Vector2 weponMove = new Vector2(0f,0f);                 //      ����g�p���̈ړ�

    private bool atkChack = false;                                  //      �U�������Ă��邩�ǂ���

    private bool stopPlayer = false;                                //      �v���C���[�̃X�g�b�v

    private bool dash = false;                                      //      �_�b�V�������Ă��邩�ǂ���

    private float dashLength = 0f;                                  //      �_�b�V���̋���

    private float dashCoolTime = 0f;                                //      �_�b�V���̃N�[���^�C��

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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash = true;
        }
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

        if (!stopPlayer)
        if (!atkChack)
        {
            //      ���͂��󂯎��
            playerVelocity.x = Input.GetAxisRaw("Horizontal");
            playerVelocity.y = Input.GetAxisRaw("Vertical");
        }

        //      �ړ��ʂ̐��K��
        var length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x +
                            playerVelocity.y * playerVelocity.y);


        //      �ړ��ʂ��O�ȏ�̎���������
        if (length > 0)
        {
            playerVelocity.x /= length;
            playerVelocity.y /= length;

            //      �v���C���[�̌����Ă����������ɓ����
            weponDirection = playerVelocity;
        }

        PlayerMoveAnimation();

        MoveSpeed(length);

        playerPos = playerVelocity;

        //      ����ōU�����Ă���Ƃ��̈ړ�����
        if (atkChack)
        {
            SordNomalAtkMove();
        }
        else
        {
            //      �v���C���[�̌��݈ʒu��ύX����
            rd.velocity = playerPos;

            Avoidance();
        }

        Avoidance();
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
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
    }


    public Vector2 GetWeponDirection()
    {
        return weponDirection;
    }

    //      ���ōU�������Ƃ��̃v���C���[�̈ړ�����
    private void SordNomalAtkMove()
    {
        weponMove = weponDirection;
        float length = Mathf.Sqrt(weponDirection.x * weponDirection.x +
                                    weponDirection.y * weponDirection.y);

        if (length > 0)weponMove /= length;

        weponMove *= 2.0f;

        rd.velocity = weponMove;
    }

    //      �X�L���ōU���������ǂ���
    public void SetNomalAtkJadgement(bool i)
    {
        atkChack = i;
    }

    //      �ړ����~�߂�
    public void SetStopPlayer(bool i)
    {
        stopPlayer = i;
    }

    //      �_�b�V�����̏���
    private void Avoidance()
    {
        //      �N�[���^�C��
        if (dashCoolTime > 0)
        {
            dashCoolTime -= Time.deltaTime;
            return;
        }

        if (!dash) return;

        Vector2 avoidance = weponDirection;

        if (dashLength > 400.0f)
        {
            dash = false;
            avoidance = new Vector2(0f, 0f);
            dashLength = 0f;
            dashCoolTime = 0.5f;
            return;
        }

        float speed = 30.0f;

        avoidance *= speed;

        rd.velocity = avoidance;

        dashLength += Mathf.Sqrt(avoidance.x * avoidance.x + avoidance.y * avoidance.y);

    }

    public bool AvoidanceJadgement()
    {
        return dash;
    }
}