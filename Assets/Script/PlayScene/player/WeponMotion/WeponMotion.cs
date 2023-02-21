using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeponMotion : MonoBehaviour
{
    [SerializeField] 
    PlayerAudio playerAudio;


    public GameObject direction;                        //      �v���C���[�̌����Ă������

    public PlayerMoveScript playerMoveScript;

    public PlayerAtk playerAtk;

    private float sordNomalAtk = 0f;                    //      ���ʏ�U�����̊p�x

    private bool sordNomalAtkFlag = false;              //      ����U���Ă��邩�ǂ������f����

    private bool atk = false;                           //      �U�����Ă��邩�ǂ������f����

    private bool changeSord = false;                    //      ���ʏ퉝���؂�ւ�

    public float sordNomalAtkSpeed = 600.0f;            //      ���̍U���X�s�[�h

    private bool sordskill = false;                     //      �X�L���𔭓����Ă��邩�ǂ���

    private int skillNumber = 1;                        //      �X�L���̔ԍ�

    private float sordSkilltime = 0f;                   //      �������v���p

    private float sordPastTime = 0f;                    //      �ߋ��̎��Ԍ�

    private bool sordnotSkill = false;                  //      �X�L�����g�p���Ă��邩

    private float InitialPosition = 0f;                 //      �X�L�������͂��ߊp�x���o����

    private float skillCoolTime = 0f;                   //      �X�L���̃N�[���^�C��

    private float bowNomalAtkCoolTime = 1f;             //      �|�̒ʏ�U���N�[���^�C��

    private float bowSkilltime = 0f;                    //      �|�̒������v���p     

    private bool bownotSkill = false;                   //      �|�̃{�^���������Ă��Ȃ��Ƃ�

    private float bowPastTime = 0f;                     //      �ߋ��̎��ԋ|

    private bool bowskill = false;                      //      �X�L���𔭓����Ă��邩�ǂ���

    private bool bowSkillAtkFlag;                       //      �|�̃X�L���U���t���O

    private float bowSkillCootTime = 0f;                //      �|�̃X�L���N�[���^�C��

    private float bowSkillInterval = 0f;                //      �|�̃X�L���̊Ԋu

    private bool bowSkill1Stop = false;                 //      �|�X�L���P�̐���

    private bool[] becauseJadgement = new bool [4];     //      �X�L���`���[�W���������ǂ���

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

    //      ���̏���
    public void Sord()
    {
        //      �ʏ�U��
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

    //      �|�̏���
    public void Bow()
    {
        BowNomalAtk();
        BowSkillAtk1();
    }

    //      ���̊�{�U���P
    private bool SordNomalAtk1()
    {
        //      �����̏�����
        if (!sordNomalAtkFlag)
        {
            sordNomalAtkFlag = true;
            sordNomalAtk = -40f;
            SordNomalAtkObj.gameObject.SetActive(true);

            playerAudio.SourdSwing();
        }

        //      ������t���X�s�[�h
        sordNomalAtk += sordNomalAtkSpeed * Time.deltaTime;

        //      ��]�̊Ǘ�
        direction.transform.rotation = Quaternion.Euler(0, 0, PlayerLook() + sordNomalAtk);

        //      �U���I��
        if (sordNomalAtk > 40)
        {
            sordNomalAtkFlag = false;
            SordNomalAtkObj.gameObject.SetActive(false);
            changeSord = false;
            return true;
        }

        return false;
    }

    //      ���̊�{�U���Q
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

    //      ���̃X�L���P
    private void SordSkill1()
    {
        skillCoolTime -= Time.deltaTime;

        if (skillCoolTime < 0)
        {
            //      �X�L���{�^��������
            if (Input.GetKey(KeyCode.E))
            {
                sordSkilltime += Time.deltaTime;
                sordnotSkill = true;
            }

            BecauseOfAttack(sordSkilltime, 0.0f, 1.0f, 2.0f, 1000.0f, sordnotSkill);

            if (!sordnotSkill) return;


            //      �{�^���𗣂����Ƃ��̏���
            if (sordSkilltime == sordPastTime)
            {
                sordskill = true;
            }
            else
            {
                sordPastTime = sordSkilltime;
            }

            //      ���������Ԃ��R�b�ȏ�ɂȂ����������I�ɔ�������
            if (sordSkilltime > 3.0)
            {
                sordskill = true;
            }

            if (!sordskill) return;

            //      ���������Ԃ��P�b�ȉ��̎����]����
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
            //      ���������Ԃ��P�b�ȏ�Q�b�ȉ��̎��Q��]����
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
            //      ���������Ԃ��Q�b�ȏ�̎��R��]����
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

    //      �|�̒ʏ�U��
    private void BowNomalAtk()
    {
        //      �|�̃N�[���^�C��
        if (bowNomalAtkCoolTime < 0.5f)
        {
            bowNomalAtkCoolTime += Time.deltaTime;
            return;
        }

        //      �X�y�[�X�������Ɣ���
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

    //      �|�̃X�L���P
    private void BowSkillAtk1()
    {

        //      �X�L���̃N�[���^�C��
        if (bowSkillCootTime > 0)
        {
            bowSkillCootTime -= Time.deltaTime;
            playerAtk.GetSkill(1.0f);
            return;
        }

        //      �X�L������������
        if (Input.GetKey(KeyCode.E))
        {
            bowSkilltime += Time.deltaTime;
            bownotSkill = true;
        }

        BecauseOfAttack(bowSkilltime, 0.0f, 1.0f, 5.0f, 1000.0f, bownotSkill);

        if (!bownotSkill) return;

        //      �ߋ��̎��ԂƃX�L���^�C�����Ԃ������������ꍇ���s����
        if (bowSkilltime == bowPastTime)
        {
            bowskill = true;
        }
        else
        {
            bowPastTime = bowSkilltime;
        }

        if (!bowskill) return;

        //      �X�L�������������Ԃ��P�b�ȉ��̎�
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
        //      �O�b�������������̏���
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
        //      �ܕb�������������̏���
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

            //      �X�L���P�̏�����
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

        //      �ړ����~�߂�
        playerMoveScript.SetStopPlayer(bownotSkill);
    }

    //      �v���C���[�̌����Ă������
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
