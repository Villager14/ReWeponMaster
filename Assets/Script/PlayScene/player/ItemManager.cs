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
    private float[] critical = new float[100];              //      サブステータス（会心率）

    private int itemNumber;                                 //      手に入れた武器の番号

    private int[] itemBox = new int[100];                   //      武器を管理するボックス

    private bool itemEnhancmentJadgement = false;           //      武器をレベルアップするか判断する

    private int itemEnhancment = 0;                         //      強化する武器の番号


    // Start is called before the first frame update
    void Start()
    {
        //      アイテムボックスの初期化
        for (int i = 0; i < 100; i++) itemBox[i] = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            itemEnhancmentJadgement = true;
        }

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
    public void GetItem(string getname, float getbasic, float getatk, float getdef, float getcritical)
    {
        for (int i = 0; i < MaxItem; i++)
        {
            if (itemBox[i] == 0)
            {
                WeponName[i] = getname;
                basic[i] = getbasic;
                atk[i] = getatk;
                def[i] = getdef;
                critical[i] = getcritical;

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

    //      ほしい武器の情報を受け取る
    public void SetWeponNumber(int i)
    {
        itemNumber = i;
    }
    public int GetWeponNumber(int i)
    {
        return itemBox[i];
    }
}