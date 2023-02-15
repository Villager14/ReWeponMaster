using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    const int MaxItem = 100;

    private string[] WeponName    =   new string[100];      //      武器の名前
    private float[] basic         =   new float[100];       //      基礎攻撃力
    private float[] atk           =   new float[100];       //      サブ攻撃力
    private float[] def           =   new float[100];       //      サブ防御力
    private float[] critical      =   new float[100];       //      会心率

    private int itemNumber;                                 //      アイテムの番号

    private int[] itemBox = new int[100];                   //      アイテムの保存番号

    private bool itemEnhancmentJadgement = false;           //      アイテムの強化をするかどうか

    private int itemEnhancment = 0;                         //      強化するアイテムの番号

    // Start is called before the first frame update
    void Start()
    {
        //      ボックスの初期化
        for (int i = 0; i < 100; i++) itemBox[i] = 0;
    }

    private void Update()
    {
        //      レベルアップ
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    itemEnhancmentJadgement = true;
        //}

        ItemEnhancement();
    }

    //      武器の強化
    private void ItemEnhancement()
    {   
        if (!itemEnhancmentJadgement) return;
        
        //      乱数を発生させる
        int rand = Random.Range(0, 100);
        
        //      攻撃力アップ
        if (rand < 30)
        {
            float i =  atk[itemEnhancment];

            i *= 1.5f;

            atk[itemEnhancment] = i;
        }
        //      防御力アップ
        else if (rand < 70)
        {
            float i = def[itemEnhancment];

            i *= 1.5f;

            def[itemEnhancment] = i;
        }
        //      クリティカルアップ
        else
        {
            float i = critical[itemEnhancment];

            i *= 1.5f;

            critical[itemEnhancment] = i;
        }

        itemEnhancmentJadgement = false;
    }

    //      入手した武器の番号を送る
    public int GetItemNumber()
    {
        return itemNumber;
    }

    //      アイテムの情報を受け取る
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

                itemBox[i] = 1;

                //      アイテム選択の初期化
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

    //      名前を送る
    public string NowItemName(int i)
    {
        return WeponName[i];
    }

    //      クリティカル率を送る
    public float NowItemCritical(int i)
    {
        return critical[i];
    }

    //      アイテムを拾ったときの番号
    public void GetWeponNumber(int i)
    {
        itemNumber = i;
    }
}