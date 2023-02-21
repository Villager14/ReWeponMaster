<<<<<<< HEAD
using System.Collections;
=======
﻿using System.Collections;
>>>>>>> player
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    const int MaxItem = 100;

<<<<<<< HEAD
    private string[] WeponName    =   new string[100];      //      ����̖��O
    private float[] basic         =   new float[100];       //      ��b�U����
    private float[] atk           =   new float[100];       //      �T�u�U����
    private float[] def           =   new float[100];       //      �T�u�h���
    private float[] critical      =   new float[100];       //      ��S��

    private int itemNumber;                                 //      �A�C�e���̔ԍ�

    private int[] itemBox = new int[100];                   //      �A�C�e���̕ۑ��ԍ�

    private bool itemEnhancmentJadgement = false;           //      �A�C�e���̋��������邩�ǂ���

    private int itemEnhancment = 0;                         //      ��������A�C�e���̔ԍ�
=======
    private string[] WeponName = new string[100];           //       武器の名前
    private float[] basic = new float[100];                 //      武器の素の攻撃力
    private float[] atk = new float[100];                   //      サブステータス（攻撃力）
    private float[] def = new float[100];                   //      サブステータス（防御力）
    private float[] critical = new float[100];              //      サブステータス（会心率)
    private int[] skill = new int[100];                     //      スキル

    private int itemNumber　= 0;                            //      手に入れた武器の番号

    private int[] itemBox = new int[100];                   //      武器を管理するボックス

    private bool itemEnhancmentJadgement = false;           //      武器をレベルアップするか判断する

    private int itemEnhancment = 0;                         //      強化する武器の番号

>>>>>>> player

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        //      �{�b�N�X�̏�����
        for (int i = 0; i < 100; i++) itemBox[i] = 0;
=======
        //      アイテムボックスの初期化
        for (int i = 0; i < 100; i++) itemBox[i] = -1;

>>>>>>> player
    }

    private void Update()
    {
<<<<<<< HEAD
        //      ���x���A�b�v
=======
>>>>>>> player
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    itemEnhancmentJadgement = true;
        //}

        ItemEnhancement();
<<<<<<< HEAD
    }

    //      ����̋���
    private void ItemEnhancement()
    {   
        if (!itemEnhancmentJadgement) return;
        
        //      �����𔭐�������
        int rand = Random.Range(0, 100);
        
        //      �U���̓A�b�v
        if (rand < 30)
        {
            float i =  atk[itemEnhancment];
=======

        //Debug.Log(atk[itemEnhancment]);
    }

    //      武器のレベルアップ
    private void ItemEnhancement()
    {
        if (!itemEnhancmentJadgement) return;

        //      乱数を発生させる
        int rand = Random.Range(0, 100);

        //      サブステータス（攻撃力のレベルアップ）
        if (rand < 30)
        {
            float i = atk[itemEnhancment];
>>>>>>> player

            i *= 1.5f;

            atk[itemEnhancment] = i;
        }
<<<<<<< HEAD
        //      �h��̓A�b�v
=======
        //      サブステータス（防御力のレベルアップ）
>>>>>>> player
        else if (rand < 70)
        {
            float i = def[itemEnhancment];

            i *= 1.5f;

            def[itemEnhancment] = i;
        }
<<<<<<< HEAD
        //      �N���e�B�J���A�b�v
=======
        //      サブステータス（クリティカルのレベルアップ）
>>>>>>> player
        else
        {
            float i = critical[itemEnhancment];

            i *= 1.5f;

            critical[itemEnhancment] = i;
        }
<<<<<<< HEAD

        itemEnhancmentJadgement = false;
    }

    //      ���肵������̔ԍ��𑗂�
=======
        itemEnhancmentJadgement = false;
    }

    //      アイテムナンバーを送る
>>>>>>> player
    public int GetItemNumber()
    {
        return itemNumber;
    }

<<<<<<< HEAD
    //      �A�C�e���̏����󂯎��
    public void GetItem(string getname, float getbasic,float getatk, float getdef, float getcritical)
    {
        for (int i = 0; i < MaxItem; i++)
        {
            if (itemBox[i] == 0)
            {
                WeponName[i]    = getname;
                basic[i]        = getbasic;
                atk[i]          = getatk;
                def[i]          = getdef;
                critical[i]     = getcritical;

                itemBox[i] = itemNumber;

                //      �A�C�e���I���̏�����
=======
    //      アイテムを探し情報を得る
    public void GetItem(string getname, float getbasic, float getatk, float getdef, float getcritical, int skill)
    {
        for (int i = 0; i < MaxItem; i++)
        {
            if (itemBox[i] == -1)
            {
                WeponName[i] = getname;
                basic[i] = getbasic;
                atk[i] = getatk;
                def[i] = getdef;
                critical[i] = getcritical;
                this.skill[i] = skill;

                itemBox[i] = itemNumber;

>>>>>>> player
                itemNumber = -1;
                return;
            }
        }
    }

<<<<<<< HEAD
    //      �U���͂𑗂�
=======

    //      攻撃力を送る
>>>>>>> player
    public float NowItemATK(int i)
    {
        return atk[i] + basic[i];
    }

<<<<<<< HEAD
    //      ���O�𑗂�
=======
    public float NowItemWeponBasicAtk(int i)
    {
        return basic[i];
    }

    public float NowItemWeponSabAtk(int i)
    {
        return atk[i];
    }

    //      武器の名前を送る
>>>>>>> player
    public string NowItemName(int i)
    {
        return WeponName[i];
    }

<<<<<<< HEAD
    //      �N���e�B�J�����𑗂�
=======
    //      武器のクリティカル率を送る
>>>>>>> player
    public float NowItemCritical(int i)
    {
        return critical[i];
    }

<<<<<<< HEAD
    //      �A�C�e�����E�����Ƃ��̔ԍ�
=======
    //      武器の防御力を送る
    public float NowItemDefense(int i)
    {
        return def[i];
    }

    //      ほしい武器の情報を受け取る
>>>>>>> player
    public void SetWeponNumber(int i)
    {
        itemNumber = i;
    }

    public int GetWeponNumber(int i)
    {
        return itemBox[i];
    }

<<<<<<< HEAD
=======
    public int GetSkill(int i)
    {
        return skill[i];
    }
>>>>>>> player
}