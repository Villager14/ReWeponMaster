using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    const int MaxItem = 100;

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


    // Start is called before the first frame update
    void Start()
    {
        //      アイテムボックスの初期化
        for (int i = 0; i < 100; i++) itemBox[i] = -1;

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    itemEnhancmentJadgement = true;
        //}

        ItemEnhancement();

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

            i *= 1.5f;

            atk[itemEnhancment] = i;
        }
        //      サブステータス（防御力のレベルアップ）
        else if (rand < 70)
        {
            float i = def[itemEnhancment];

            i *= 1.5f;

            def[itemEnhancment] = i;
        }
        //      サブステータス（クリティカルのレベルアップ）
        else
        {
            float i = critical[itemEnhancment];

            i *= 1.5f;

            critical[itemEnhancment] = i;
        }
        itemEnhancmentJadgement = false;
    }

    //      アイテムナンバーを送る
    public int GetItemNumber()
    {
        return itemNumber;
    }

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

                itemNumber = -1;
                return;
            }
        }
    }


    //      攻撃力を送る
    public float NowItemATK(int i)
    {
        return atk[i] + basic[i];
    }

    public float NowItemWeponBasicAtk(int i)
    {
        return basic[i];
    }

    public float NowItemWeponSabAtk(int i)
    {
        return atk[i];
    }

    //      武器の名前を送る
    public string NowItemName(int i)
    {
        return WeponName[i];
    }

    //      武器のクリティカル率を送る
    public float NowItemCritical(int i)
    {
        return critical[i];
    }

    //      武器の防御力を送る
    public float NowItemDefense(int i)
    {
        return def[i];
    }

    //      ほしい武器の情報を受け取る
    public void SetWeponNumber(int i)
    {
        itemNumber = i;
    }

    public int GetWeponNumber(int i)
    {
        return itemBox[i];
    }

    public int GetSkill(int i)
    {
        return skill[i];
    }
}