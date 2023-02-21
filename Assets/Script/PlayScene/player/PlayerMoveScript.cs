using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveScript : MonoBehaviour
{
    public float playerSpeed = 7f;                                  //      プレイヤーの移動速度

    public float playerRanSpeed = 13f;                              //      プレイヤーの走る移動速度

    private Vector2 playerPos = new Vector2(0f, 0f);                 //      プレイヤーの現在位置

    private Vector2 playerVelocity = new Vector2(0f, 0f);           //      プレイヤーの移動量

    private float ranTime = 0f;                                     //      プレイヤーが走り始める時間の管理

    private Vector2 weponDirection = new Vector2(0f,0f);            //      向いている方向

    private Vector2 weponMove = new Vector2(0f,0f);                 //      武器使用時の移動

    private bool atkChack = false;                                  //      攻撃をしているかどうか

    private bool stopPlayer = false;                                //      プレイヤーのストップ

    private bool dash = false;                                      //      ダッシュをしているかどうか

    private float dashLength = 0f;                                  //      ダッシュの距離

    private float dashCoolTime = 0f;                                //      ダッシュのクールタイム

    //      システム系
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

    //      移動関係
    private void Move()
    {
        //      Velocityの初期化
        playerVelocity = new Vector2(0f, 0f);

        if (!stopPlayer)
        if (!atkChack)
        {
            //      入力を受け取る
            playerVelocity.x = Input.GetAxisRaw("Horizontal");
            playerVelocity.y = Input.GetAxisRaw("Vertical");
        }

        //      移動量の正規化
        var length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x +
                            playerVelocity.y * playerVelocity.y);


        //      移動量が０以上の時処理する
        if (length > 0)
        {
            playerVelocity.x /= length;
            playerVelocity.y /= length;

            //      プレイヤーの向いている方向を手に入れる
            weponDirection = playerVelocity;
        }

        PlayerMoveAnimation();

        MoveSpeed(length);

        playerPos = playerVelocity;

        //      武器で攻撃しているときの移動処理
        if (atkChack)
        {
            SordNomalAtkMove();
        }
        else
        {
            //      プレイヤーの現在位置を変更する
            rd.velocity = playerPos;

            Avoidance();
        }

        Avoidance();
    }

    //      歩きか走りかの判定
    private void MoveSpeed(float length)
    {
        //      正規化したときの大きさが０の時止まっていると判断する
        if (length == 0)
        {
            ranTime = 0f;
            return;
        }

        if (ranTime > 5f)
        {
            //      移動量にスピードを掛ける(ダッシュ)
            playerVelocity.x *= playerRanSpeed;
            playerVelocity.y *= playerRanSpeed;
        }
        else
        {
            //      移動量にスピードを掛ける(歩き)
            playerVelocity.x *= playerSpeed;
            playerVelocity.y *= playerSpeed;

            //      何秒歩いているか計測する
            ranTime += Time.deltaTime;
        }
    }

    //      プレイヤー移動のアニメーション
    private void PlayerMoveAnimation()
    {
        PlayerMoveAnimationInitialization();

        //      横に移動しているかどうか
        bool diagonal = false;

        //      左右移動をしているか
        if (playerVelocity.x != 0f)
        {
            //      右移動しているときのアニメーション
            if (playerVelocity.x > 0)
            {
                animator.SetBool("Right", true);
                diagonal = true;
            }

            //      左移動しているときのアニメーション
            if (playerVelocity.x < 0)
            {
                animator.SetBool("Left", true);
                diagonal = true;
            }
        }

        //      横に移動しているときは返す
        if (diagonal) return;

        //      上下に移動しているかどうか
        if (playerVelocity.y != 0f)
        {
            //      上移動しているときのアニメーション
            if (playerVelocity.y < 0)
            {
                animator.SetBool("Behind", true);
            }

            //      下移動しているときのアニメーション
            if (playerVelocity.y > 0)
            {
                animator.SetBool("Before", true);
            }
        }
    }

    //      移動のアニメーションの初期化
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

    //      剣で攻撃したときのプレイヤーの移動処理
    private void SordNomalAtkMove()
    {
        weponMove = weponDirection;
        float length = Mathf.Sqrt(weponDirection.x * weponDirection.x +
                                    weponDirection.y * weponDirection.y);

        if (length > 0)weponMove /= length;

        weponMove *= 2.0f;

        rd.velocity = weponMove;
    }

    //      スキルで攻撃したかどうか
    public void SetNomalAtkJadgement(bool i)
    {
        atkChack = i;
    }

    //      移動を止める
    public void SetStopPlayer(bool i)
    {
        stopPlayer = i;
    }

    //      ダッシュ中の処理
    private void Avoidance()
    {
        //      クールタイム
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