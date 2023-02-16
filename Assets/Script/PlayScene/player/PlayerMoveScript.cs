using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveScript : MonoBehaviour
{
    public float playerSpeed = 7f;                                  //      プレイヤーの移動速度

    public float playerRanSpeed = 13f;                              //      プレイヤーの走る移動速度

    private Vector2 playerPos = new Vector2(0f,0f);                 //      プレイヤーの現在位置

    private Vector2 playerVelocity = new Vector2(0f, 0f);           //      プレイヤーの移動量

    private float ranTime = 0f;                                     //      プレイヤーが走り始める時間の管理

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

        //      入力を受け取る
        playerVelocity.x = Input.GetAxisRaw("Horizontal");
        playerVelocity.y = Input.GetAxisRaw("Vertical");

        //      移動量の正規化
        var length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x +
                            playerVelocity.y * playerVelocity.y);

        //      移動量が０以上の時処理する
        if (length > 0)
        {
            playerVelocity.x /= length;
            playerVelocity.y /= length;
        }

        PlayerMoveAnimation();

        MoveSpeed(length);

        playerPos = playerVelocity;

        //      プレイヤーの現在位置を変更する
        rd.velocity = playerPos;
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
        animator.SetBool("Right",  false);
        animator.SetBool("Left",   false);
    }

    private void AtkAnimaTest()
    {
    }
}
