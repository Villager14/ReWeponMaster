using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeponMotion : MonoBehaviour
{
    [SerializeField] 
    PlayerAudio playerAudio;


    public GameObject direction;                        //      プレイヤーの向いている方向

    public PlayerMoveScript playerMoveScript;

    public PlayerAtk playerAtk;

    private float sordNomalAtk = 0f;                    //      剣通常攻撃時の角度

    private bool sordNomalAtkFlag = false;              //      剣を振っているかどうか判断する

    private bool atk = false;                           //      攻撃しているかどうか判断する

    private bool changeSord = false;                    //      剣通常往復切り替え

    public float sordNomalAtkSpeed = 600.0f;            //      剣の攻撃スピード

    private bool sordskill = false;                     //      スキルを発動しているかどうか

    private int skillNumber = 1;                        //      スキルの番号

    private float sordSkilltime = 0f;                   //      長押し計測用

    private float sordPastTime = 0f;                    //      過去の時間剣

    private bool sordnotSkill = false;                  //      スキルを使用しているか

    private float InitialPosition = 0f;                 //      スキル撃ちはじめ角度を覚える

    private float skillCoolTime = 0f;                   //      スキルのクールタイム

    private float bowNomalAtkCoolTime = 1f;             //      弓の通常攻撃クールタイム

    private float bowSkilltime = 0f;                    //      弓の長押し計測用     

    private bool bownotSkill = false;                   //      弓のボタンを押していないとき

    private float bowPastTime = 0f;                     //      過去の時間弓

    private bool bowskill = false;                      //      スキルを発動しているかどうか

    private bool bowSkillAtkFlag;                       //      弓のスキル攻撃フラグ

    private float bowSkillCootTime = 0f;                //      弓のスキルクールタイム

    private float bowSkillInterval = 0f;                //      弓のスキルの間隔

    private bool bowSkill1Stop = false;                 //      弓スキル１の制限

    private bool[] becauseJadgement = new bool [4];     //      スキルチャージをしたかどうか

    public GameObject SordNomalAtkObj;
    public GameObject SordNomalAtkObj2;
    public GameObject SordNomalAtkObj3;

    public GameObject bow;
    public GameObject FiringBow;
    public GameObject FiringBow1;
    public GameObject FiringBow2;

    public GameObject SkillBow1;
    public GameObject SkillBow2;

    public GameObject SkillBow3;
    public GameObject SkillBow4;
    public GameObject SkillBow5;
    public GameObject SkillBow6;
    public GameObject SkillBow7;


    private void Start()
    {
        playerMoveScript.GetComponent<PlayerMoveScript>();
        playerAtk.GetComponent<PlayerAtk>();


        for (int i = 0; i < 4; i++)
        {
            becauseJadgement[i] = false;
        }

        SordNomalAtkObj.gameObject.SetActive(false);
        SordNomalAtkObj2.gameObject.SetActive(false);
        SordNomalAtkObj3.gameObject.SetActive(false);
    }

    private void Update()
    {
        playerAudio.GetComponent<PlayerAudio>();
    }

    //      剣の処理
    public void Sord()
    {
        //      通常攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            atk = true;
        }

        playerMoveScript.SetNomalAtkJadgement(atk);

        if (atk == true)
        {
            if (changeSord)
            {
                if (SordNomalAtk1() == true)
                {
                    atk = false;
                }
            }
            else
            {
                if (SordNomalAtk2() == true)
                {
                    atk = false;
                }
            }
        }

        switch (skillNumber)
        {
            case 1:
                SordSkill1();
                break;
            case 2:
                break;
        }
    }

    //      弓の処理
    public void Bow()
    {
        BowNomalAtk();
        BowSkillAtk1();
    }

    //      剣の基本攻撃１
    private bool SordNomalAtk1()
    {
        //      処理の初期化
        if (!sordNomalAtkFlag)
        {
            sordNomalAtkFlag = true;
            sordNomalAtk = -40f;
            SordNomalAtkObj.gameObject.SetActive(true);

            playerAudio.SourdSwing();
        }

        //      武器をフルスピード
        sordNomalAtk += sordNomalAtkSpeed * Time.deltaTime;

        //      回転の管理
        direction.transform.rotation = Quaternion.Euler(0, 0, PlayerLook() + sordNomalAtk);

        //      攻撃終了
        if (sordNomalAtk > 40)
        {
            sordNomalAtkFlag = false;
            SordNomalAtkObj.gameObject.SetActive(false);
            changeSord = false;
            return true;
        }

        return false;
    }

    //      剣の基本攻撃２
    private bool SordNomalAtk2()
    {
        if (!sordNomalAtkFlag)
        {
            sordNomalAtkFlag = true;
            sordNomalAtk = 40f;
            SordNomalAtkObj.gameObject.SetActive(true);
            playerAudio.SourdSwing();
        }

        sordNomalAtk -= sordNomalAtkSpeed * Time.deltaTime;

        direction.transform.rotation = Quaternion.Euler(0, 0, PlayerLook() + sordNomalAtk);

        if (sordNomalAtk < -40)
        {
            sordNomalAtkFlag = false;
            SordNomalAtkObj.gameObject.SetActive(false);
            changeSord = true;
            return true;
        }

        return false;
    }

    //      剣のスキル１
    private void SordSkill1()
    {
        skillCoolTime -= Time.deltaTime;

        if (skillCoolTime < 0)
        {
            //      スキルボタン長押し
            if (Input.GetKey(KeyCode.E))
            {
                sordSkilltime += Time.deltaTime;
                sordnotSkill = true;
            }

            BecauseOfAttack(sordSkilltime, 0.0f, 1.0f, 2.0f, 1000.0f, sordnotSkill);

            if (!sordnotSkill) return;


            //      ボタンを離したときの処理
            if (sordSkilltime == sordPastTime)
            {
                sordskill = true;
            }
            else
            {
                sordPastTime = sordSkilltime;
            }

            //      長押し時間が３秒以上になった時強制的に発動する
            if (sordSkilltime > 3.0)
            {
                sordskill = true;
            }

            if (!sordskill) return;

            //      押した時間が１秒以下の時一回転する
            if (sordSkilltime < 1f)
            {
                if (!sordNomalAtkFlag)
                {
                    sordNomalAtkFlag = true;
                    sordNomalAtk = 0f;
                    SordNomalAtkObj.gameObject.SetActive(true);
                    InitialPosition = PlayerLook();
                    playerAtk.GetSkill(1.2f);
                }

                sordNomalAtk += 500f * Time.deltaTime;

                direction.transform.rotation = Quaternion.Euler(0, 0, InitialPosition + sordNomalAtk);


                if (sordNomalAtk > 360f)
                {
                    sordNomalAtkFlag = false;
                    SordNomalAtkObj.gameObject.SetActive(false);
                    sordskill = false;
                    sordnotSkill = false;
                    sordSkilltime = 0f;
                    playerAtk.GetSkill(0.0f);
                    skillCoolTime = 6.0f;
                }
            }
            //      押した時間が１秒以上２秒以下の時２回転する
            else if (sordSkilltime < 2f)
            {
                if (!sordNomalAtkFlag)
                {
                    sordNomalAtkFlag = true;
                    sordNomalAtk = 0f;
                    SordNomalAtkObj2.gameObject.SetActive(true);
                    InitialPosition = PlayerLook();
                    playerAtk.GetSkill(1.2f);
                }

                if (sordNomalAtk > 360)
                {
                    playerAtk.GetSkill(1.3f);
                }


                sordNomalAtk += 500f * Time.deltaTime;

                direction.transform.rotation = Quaternion.Euler(0, 0, InitialPosition + sordNomalAtk);

                if (sordNomalAtk > 720f)
                {
                    sordNomalAtkFlag = false;
                    SordNomalAtkObj2.gameObject.SetActive(false);
                    sordskill = false;
                    sordnotSkill = false;
                    sordSkilltime = 0f;
                    playerAtk.GetSkill(0.0f);
                    skillCoolTime = 6.0f;
                }
            }
            //      押した時間が２秒以上の時３回転する
            else
            {
                if (!sordNomalAtkFlag)
                {
                    sordNomalAtkFlag = true;
                    sordNomalAtk = 0f;
                    SordNomalAtkObj3.gameObject.SetActive(true);
                    InitialPosition = PlayerLook();
                    playerAtk.GetSkill(1.2f);
                }

                if (sordNomalAtk > 360)
                {
                    playerAtk.GetSkill(1.3f);
                }

                if (sordNomalAtk > 720)
                {
                    playerAtk.GetSkill(1.5f);
                }


                sordNomalAtk += 500f * Time.deltaTime;

                direction.transform.rotation = Quaternion.Euler(0, 0, InitialPosition + sordNomalAtk);

                if (sordNomalAtk > 1080f)
                {
                    sordNomalAtkFlag = false;
                    SordNomalAtkObj3.gameObject.SetActive(false);
                    sordskill = false;
                    sordnotSkill = false;
                    sordSkilltime = 0f;
                    playerAtk.GetSkill(0.0f);
                    skillCoolTime = 6.0f;
                }
            }
        }

        playerMoveScript.SetStopPlayer(sordNomalAtkFlag);
    }

    //      弓の通常攻撃
    private void BowNomalAtk()
    {
        //      弓のクールタイム
        if (bowNomalAtkCoolTime < 0.5f)
        {
            bowNomalAtkCoolTime += Time.deltaTime;
            return;
        }

        //      スペースを押すと発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

            float length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x + playerVelocity.y * playerVelocity.y);

            FiringBow.transform.rotation = Quaternion.Euler(0, 0, PlayerLook());

            for (int i = 0; i < 3; i++)
            {
                GameObject box = FiringBow;

                switch (i)
                {
                    case 1:
                        box = FiringBow1;
                        break;
                    case 2:
                        box = FiringBow2;
                        break;
                }

                Instantiate(bow, new Vector3(box.transform.position.x,
                            box.transform.position.y, 0.0f),
                            Quaternion.Euler(0, 0, PlayerLook()));
            }

            bowNomalAtkCoolTime = 0f;
        }
    }

    //      弓のスキル１
    private void BowSkillAtk1()
    {

        //      スキルのクールタイム
        if (bowSkillCootTime > 0)
        {
            bowSkillCootTime -= Time.deltaTime;
            playerAtk.GetSkill(1.0f);
            return;
        }

        //      スキル発動させる
        if (Input.GetKey(KeyCode.E))
        {
            bowSkilltime += Time.deltaTime;
            bownotSkill = true;
        }

        BecauseOfAttack(bowSkilltime, 0.0f, 1.0f, 5.0f, 1000.0f, bownotSkill);

        if (!bownotSkill) return;

        //      過去の時間とスキルタイム時間が同じだった場合実行する
        if (bowSkilltime == bowPastTime)
        {
            bowskill = true;
        }
        else
        {
            bowPastTime = bowSkilltime;
        }

        if (!bowskill) return;

        //      スキルを押した時間が１秒以下の時
        if (bowSkilltime < 1f)
        {
            if (!bowSkillAtkFlag)
            {
                playerAtk.GetSkill(1.2f);
            }

            Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

            float length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x + playerVelocity.y * playerVelocity.y);

            FiringBow.transform.rotation = Quaternion.Euler(0, 0, PlayerLook());

            Instantiate(bow, new Vector3(FiringBow.transform.position.x,
            FiringBow.transform.position.y, 0.0f),
            Quaternion.Euler(0, 0, PlayerLook()));

            bowSkillAtkFlag = false;
            bowSkilltime = 0f;
            bowPastTime = 0f;
            bowSkillCootTime = 3f;
            bownotSkill = false;
            bowskill = false;
        }
        //      三秒長押しいた時の処理
        else if (bowSkilltime < 5f)
        {
            if (!bowSkillAtkFlag)
            {
                playerAtk.GetSkill(1.4f);
                bowSkillInterval = 0f;
                bowSkillAtkFlag = true;
            }

            if (bowSkillInterval == 0f || bowSkillInterval > 0.5f)
            {

                Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

                float length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x + playerVelocity.y * playerVelocity.y);

                FiringBow.transform.rotation = Quaternion.Euler(0, 0, PlayerLook());

                for (int i = 0; i < 2; i++)
                {
                    GameObject ob = SkillBow1;

                    if (i == 1) ob = SkillBow2;

                    Instantiate(bow, new Vector3(ob.transform.position.x,
                                    ob.transform.position.y, 0.0f),
                                    Quaternion.Euler(0, 0, PlayerLook()));
                }

                if (bowSkillInterval > 0.5f)
                {
                    bowSkillAtkFlag = false;
                    bowSkilltime = 0f;
                    bowPastTime = 0f;
                    bowSkillCootTime = 5f;
                    bownotSkill = false;
                    bowskill = false;
                }
            }

            bowSkillInterval += Time.deltaTime;
        }
        //      五秒長押しいた時の処理
        else if (bowSkilltime > 5f)
        {
            if (!bowSkillAtkFlag)
            {
                playerAtk.GetSkill(1.8f);
                bowSkillInterval = 0f;
                bowSkillAtkFlag = true;
            }

            if (!bowSkill1Stop)
            if (bowSkillInterval == 0f || bowSkillInterval > 0.5f)
            {

                Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

                float length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x + playerVelocity.y * playerVelocity.y);

                FiringBow.transform.rotation = Quaternion.Euler(0, 0, PlayerLook());

                for (int i = 0; i < 5; i++)
                {
                    GameObject ob = SkillBow3;

                    switch(i)
                    {
                        case 1:
                            ob = SkillBow4;
                            break;
                        case 2:
                            ob = SkillBow5;
                            break;
                        case 3:
                            ob = SkillBow6;
                            break;
                        case 4:
                            ob = SkillBow7;
                            break;
                    }

                    Instantiate(bow, new Vector3(ob.transform.position.x,
                                    ob.transform.position.y, 0.0f),
                                    Quaternion.Euler(0, 0, PlayerLook()));
                }

                if (bowSkillInterval > 0.5f)
                {
                    bowSkill1Stop = true;
                }
            }

            if (bowSkillInterval > 1.0f)
            {

                Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

                float length = Mathf.Sqrt(playerVelocity.x * playerVelocity.x + playerVelocity.y * playerVelocity.y);

                FiringBow.transform.rotation = Quaternion.Euler(0, 0, PlayerLook());

                for (int i = 0; i < 5; i++)
                {
                    GameObject ob = SkillBow3;

                    switch (i)
                    {
                        case 1:
                            ob = SkillBow4;
                            break;
                        case 2:
                            ob = SkillBow5;
                            break;
                        case 3:
                            ob = SkillBow6;
                            break;
                        case 4:
                            ob = SkillBow7;
                            break;
                    }

                    Instantiate(bow, new Vector3(ob.transform.position.x,
                                    ob.transform.position.y, 0.0f),
                                    Quaternion.Euler(0, 0, PlayerLook()));
                }
            }

            //      スキル１の初期化
            if (bowSkillInterval > 1.0f)
            {
                bowSkillAtkFlag = false;
                bowSkilltime = 0f;
                bowPastTime = 0f;
                bowSkillCootTime = 10f;
                bownotSkill = false;
                bowskill = false;
                bowSkill1Stop = false;
            }

            bowSkillInterval += Time.deltaTime;
        }

        //      移動を止める
        playerMoveScript.SetStopPlayer(bownotSkill);
    }

    //      プレイヤーの向いている方向
    private float PlayerLook()
    {
        Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

        float angele = Mathf.Atan2(playerVelocity.y, playerVelocity.x) * Mathf.Rad2Deg;

        return angele;
    }

    private void BecauseOfAttack(float time, float becaseu1, float becaseu2, float becaseu3, float becaseu4, bool chack)
    {
        if (!chack)
        {
            for (int i = 0; i < 3; i++)
                becauseJadgement[i] = false;

            return;
        }

        if (!becauseJadgement[0])
            if (time > becaseu1)
            {
                becauseJadgement[0] = true;
                playerAudio.Because(0);
            }

        if (!becauseJadgement[1])
            if (time > becaseu2)
            {
                becauseJadgement[1] = true;
                playerAudio.Because(1);
            }

        if (!becauseJadgement[2])
            if (time > becaseu3)
            {
                becauseJadgement[2] = true;
                playerAudio.Because(2);
            }

        if (!becauseJadgement[3])
            if (time > becaseu4)
            {
                becauseJadgement[3] = true;
                playerAudio.Because(3);
            }
    }
}
