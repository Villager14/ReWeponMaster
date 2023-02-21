<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;

    private int wepon1;                     //      ����P�̔ԍ�
    private int wepon2;                     //      ����Q�̔ԍ�

    private int nowWepon;                   //      ���ݑ������Ă��镐��

    private float weponAtk = 0f;            //      ����̍U����
    private float playerAtk = 0f;           //      �v���C���[�̊�b�U����

    private float totalAtk = 0f;            //      ����Ɗ�b�U���͂̍��v
    private bool weponChange = false;       //      ����̐؂�ւ��p

    private string nowWeponName = "";       //      ���ݑ������̕���̖��O

    private float weponCritical = 0f;       //      ����̃N���e�B�J����
    private float playerCritical = 0f;      //      �v���C���[�̊�b�N���e�B�J����

    private float totalCritical = 0f;       //      ����Ɗ�b�N���e�B�J�����̍��v

    private int playerLevel = 0;            //      �v���C���[�̌��݃��x��

    private Animator animator;
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;
    public WeponMotion WeponMotion;

    [SerializeField] StatasUIScript statasUIScript;

    private int wepon1;                     //      武器１
    private int wepon2;                     //      武器２

    private int nowWepon;                   //      現在装備している武器

    private float weponAtk = 0f;            //      武器の攻撃力
    private float playerAtk = 0f;           //      プレイヤーの現在の攻撃力

    private float totalAtk = 0f;            //      総合攻撃力
    private bool weponChange = false;       //      武器の交換

    private string nowWeponName = "";       //      現在の武器の名前

    private float weponCritical = 0f;       //      武器の会心率
    private float playerCritical = 0f;      //      プレイヤーの会心率

    private float totalCritical = 0f;       //      合計の会心率

    private float weponDefense = 0f;        //      武器の防御力
    private float playerDefence = 0f;       //      プレイヤーの防御力

    private float totalDefence = 0f;        //      総合防御力

    private int playerLevel = 0;

    private float skillMagnification = 0;

    private bool a = false;
>>>>>>> player

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
=======

>>>>>>> player
        wepon1 = 0;
        wepon2 = 1;

        itemManager.GetComponent<ItemManager>();
<<<<<<< HEAD

        animator = GetComponent<Animator>();
=======
        WeponMotion.GetComponent<WeponMotion>();
        statasUIScript.GetComponent<StatasUIScript>();

        nowWepon = wepon1;

        itemManager.SetWeponNumber(0);

        weponAtk = itemManager.NowItemATK(nowWepon);
        nowWeponName = itemManager.NowItemName(nowWepon);
        weponCritical = itemManager.NowItemCritical(nowWepon);
        weponDefense = itemManager.NowItemDefense(nowWepon);
>>>>>>> player
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //      ���v�U���͂����߂�
        totalAtk = weponAtk + playerAtk;

        //      ���v�N���e�B�J���������߂�
        totalCritical = weponCritical + playerCritical;

        Atack();

        WeponChange(); 
    }

    //      �U�����̃_���[�W
=======
        //      合計の攻撃力
        totalAtk = weponAtk + playerAtk;

        //      合計のクリティカル率
        totalCritical = weponCritical + playerCritical;

        totalDefence = weponDefense + playerDefence;

        Atack();

        SkillDamage();

        WeponChange();

        WeponAtk();

        if (a == false)
        {
            itemManager.SetWeponNumber(7);
            a = true;
        }

        //      武器の配列番号
        statasUIScript.SetWepon(wepon1, wepon2);

        //Debug.Log(nowWeponName);
    }

>>>>>>> player
    private void Atack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int number = Random.Range(0, 100);

            if (number < totalCritical) totalAtk *= 2f;
        }
    }

<<<<<<< HEAD
=======
    private void SkillDamage()
    {
        if (skillMagnification != 0)
        {
            totalAtk *= skillMagnification;

            int number = Random.Range(0, 100);

            if (number < totalCritical) totalAtk *= 2f;
        }
    }


>>>>>>> player
    public float GetAtack()
    {
        return totalAtk;
    }

<<<<<<< HEAD
=======
    public float GetDefence()
    {
        return totalDefence;
    }
    public float GetCritical()
    {
        return totalCritical;
    }


>>>>>>> player
    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    private void WeponChange()
    {
<<<<<<< HEAD
        //      �}�E�X���N���b�N�������ƕ����؂�ւ���
=======
        //      武器の交換処理
>>>>>>> player
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (weponChange)
            {
<<<<<<< HEAD
                //      ����P
=======
                //      武器１
>>>>>>> player
                nowWepon = wepon1;
                weponChange = false;
            }
            else if (!weponChange)
            {
<<<<<<< HEAD
                //      ����Q
=======
                //      武器２
>>>>>>> player
                nowWepon = wepon2;
                weponChange = true;
            }

<<<<<<< HEAD
            //      ����̏����󂯎��
=======
            //      アイテムの情報を受け取る
>>>>>>> player
            if (itemManager != null)
            {
                weponAtk = itemManager.NowItemATK(nowWepon);
                nowWeponName = itemManager.NowItemName(nowWepon);
                weponCritical = itemManager.NowItemCritical(nowWepon);
<<<<<<< HEAD
=======
                weponDefense = itemManager.NowItemDefense(nowWepon);
>>>>>>> player
            }
        }
    }

<<<<<<< HEAD
    //      �A�C�e�����E������
=======
    //      アイテムを獲得する
>>>>>>> player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
<<<<<<< HEAD
            if (Input.GetKey(KeyCode.C))
            {
                itemManager.SetWeponNumber(2);
=======
            if (Input.GetKey(KeyCode.Space))
            {
                itemManager.SetWeponNumber(7);
>>>>>>> player

                Destroy(collision.gameObject);
            }
        }
    }

<<<<<<< HEAD
    //      �X�e�[�^�X���󂯎��
    public void SetStatas(int playerLevel, float playerAtk, float playerCritical)
=======
    //      アイテムの情報を受け取る
    public void SetStatas(int playerLevel, float playerAtk, float playerCritical, float playerDefence)
>>>>>>> player
    {
        this.playerLevel = playerLevel;
        this.playerAtk = playerAtk;
        this.playerCritical = playerCritical;
<<<<<<< HEAD
    }


    private void WeponAtk()
    {
        int itemNumber = itemManager.GetWeponNumber(1);

        if (itemNumber < 5)
        {
            //      ��

            SordMotion();
        }
        else if (itemNumber < 10)
        {
            //      �|
=======
        this.playerDefence = playerDefence;
    }

    private void WeponAtk()
    {
        int itemNumber = itemManager.GetWeponNumber(nowWepon);

        if (itemNumber < 5)
        {
            //      剣
            WeponMotion.Sord();
           
        }
        else if (itemNumber < 10)
        {
            //      弓
            WeponMotion.Bow();
            
>>>>>>> player
        }
        else if (itemNumber < 15)
        {

        }
        else if (itemNumber < 20)
        {

        }
        else if (itemNumber < 25)
        {

        }
        else if (itemNumber < 30)
        {

        }
    }

<<<<<<< HEAD
    private void SordMotion()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
=======
    public float GetDamage()
    {
        return totalAtk;
    }

    public void GetSkill(float i)
    {
        skillMagnification = i;
    }

    public int GetSkill(int i)
    {
        return itemManager.GetSkill(i);
    }
}
>>>>>>> player
