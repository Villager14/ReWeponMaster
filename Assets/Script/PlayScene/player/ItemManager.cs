<<<<<<< HEAD
using System.Collections;
=======
ï»¿using System.Collections;
>>>>>>> player
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    const int MaxItem = 100;

<<<<<<< HEAD
    private string[] WeponName    =   new string[100];      //      íÌ¼O
    private float[] basic         =   new float[100];       //      îbUÍ
    private float[] atk           =   new float[100];       //      TuUÍ
    private float[] def           =   new float[100];       //      TuhäÍ
    private float[] critical      =   new float[100];       //      ïS¦

    private int itemNumber;                                 //      ACeÌÔ

    private int[] itemBox = new int[100];                   //      ACeÌÛ¶Ô

    private bool itemEnhancmentJadgement = false;           //      ACeÌ­»ð·é©Ç¤©

    private int itemEnhancment = 0;                         //      ­»·éACeÌÔ
=======
    private string[] WeponName = new string[100];           //       æ­¦å¨ã®åå
    private float[] basic = new float[100];                 //      æ­¦å¨ã®ç´ ã®æ»æå
    private float[] atk = new float[100];                   //      ãµãã¹ãã¼ã¿ã¹ï¼æ»æåï¼
    private float[] def = new float[100];                   //      ãµãã¹ãã¼ã¿ã¹ï¼é²å¾¡åï¼
    private float[] critical = new float[100];              //      ãµãã¹ãã¼ã¿ã¹ï¼ä¼å¿ç)
    private int[] skill = new int[100];                     //      ã¹ã­ã«

    private int itemNumberã= 0;                            //      æã«å¥ããæ­¦å¨ã®çªå·

    private int[] itemBox = new int[100];                   //      æ­¦å¨ãç®¡çããããã¯ã¹

    private bool itemEnhancmentJadgement = false;           //      æ­¦å¨ãã¬ãã«ã¢ãããããå¤æ­ãã

    private int itemEnhancment = 0;                         //      å¼·åããæ­¦å¨ã®çªå·

>>>>>>> player

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        //      {bNXÌú»
        for (int i = 0; i < 100; i++) itemBox[i] = 0;
=======
        //      ã¢ã¤ãã ããã¯ã¹ã®åæå
        for (int i = 0; i < 100; i++) itemBox[i] = -1;

>>>>>>> player
    }

    private void Update()
    {
<<<<<<< HEAD
        //      xAbv
=======
>>>>>>> player
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    itemEnhancmentJadgement = true;
        //}

        ItemEnhancement();
<<<<<<< HEAD
    }

    //      íÌ­»
    private void ItemEnhancement()
    {   
        if (!itemEnhancmentJadgement) return;
        
        //      ð­¶³¹é
        int rand = Random.Range(0, 100);
        
        //      UÍAbv
        if (rand < 30)
        {
            float i =  atk[itemEnhancment];
=======

        //Debug.Log(atk[itemEnhancment]);
    }

    //      æ­¦å¨ã®ã¬ãã«ã¢ãã
    private void ItemEnhancement()
    {
        if (!itemEnhancmentJadgement) return;

        //      ä¹±æ°ãçºçããã
        int rand = Random.Range(0, 100);

        //      ãµãã¹ãã¼ã¿ã¹ï¼æ»æåã®ã¬ãã«ã¢ããï¼
        if (rand < 30)
        {
            float i = atk[itemEnhancment];
>>>>>>> player

            i *= 1.5f;

            atk[itemEnhancment] = i;
        }
<<<<<<< HEAD
        //      häÍAbv
=======
        //      ãµãã¹ãã¼ã¿ã¹ï¼é²å¾¡åã®ã¬ãã«ã¢ããï¼
>>>>>>> player
        else if (rand < 70)
        {
            float i = def[itemEnhancment];

            i *= 1.5f;

            def[itemEnhancment] = i;
        }
<<<<<<< HEAD
        //      NeBJAbv
=======
        //      ãµãã¹ãã¼ã¿ã¹ï¼ã¯ãªãã£ã«ã«ã®ã¬ãã«ã¢ããï¼
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

    //      üèµ½íÌÔðé
=======
        itemEnhancmentJadgement = false;
    }

    //      ã¢ã¤ãã ãã³ãã¼ãéã
>>>>>>> player
    public int GetItemNumber()
    {
        return itemNumber;
    }

<<<<<<< HEAD
    //      ACeÌîñðó¯æé
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

                //      ACeIðÌú»
=======
    //      ã¢ã¤ãã ãæ¢ãæå ±ãå¾ã
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
    //      UÍðé
=======

    //      æ»æåãéã
>>>>>>> player
    public float NowItemATK(int i)
    {
        return atk[i] + basic[i];
    }

<<<<<<< HEAD
    //      ¼Oðé
=======
    public float NowItemWeponBasicAtk(int i)
    {
        return basic[i];
    }

    public float NowItemWeponSabAtk(int i)
    {
        return atk[i];
    }

    //      æ­¦å¨ã®ååãéã
>>>>>>> player
    public string NowItemName(int i)
    {
        return WeponName[i];
    }

<<<<<<< HEAD
    //      NeBJ¦ðé
=======
    //      æ­¦å¨ã®ã¯ãªãã£ã«ã«çãéã
>>>>>>> player
    public float NowItemCritical(int i)
    {
        return critical[i];
    }

<<<<<<< HEAD
    //      ACeðEÁ½Æ«ÌÔ
=======
    //      æ­¦å¨ã®é²å¾¡åãéã
    public float NowItemDefense(int i)
    {
        return def[i];
    }

    //      ã»ããæ­¦å¨ã®æå ±ãåãåã
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