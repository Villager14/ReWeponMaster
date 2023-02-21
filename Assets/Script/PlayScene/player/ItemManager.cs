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
    private string[] WeponName    =   new string[100];      //      •Ší‚Ì–¼‘O
    private float[] basic         =   new float[100];       //      Šî‘bUŒ‚—Í
    private float[] atk           =   new float[100];       //      ƒTƒuUŒ‚—Í
    private float[] def           =   new float[100];       //      ƒTƒu–hŒä—Í
    private float[] critical      =   new float[100];       //      ‰ïS—¦

    private int itemNumber;                                 //      ƒAƒCƒeƒ€‚Ì”Ô†

    private int[] itemBox = new int[100];                   //      ƒAƒCƒeƒ€‚Ì•Û‘¶”Ô†

    private bool itemEnhancmentJadgement = false;           //      ƒAƒCƒeƒ€‚Ì‹­‰»‚ð‚·‚é‚©‚Ç‚¤‚©

    private int itemEnhancment = 0;                         //      ‹­‰»‚·‚éƒAƒCƒeƒ€‚Ì”Ô†
=======
    private string[] WeponName = new string[100];           //       æ­¦å™¨ã®åå‰
    private float[] basic = new float[100];                 //      æ­¦å™¨ã®ç´ ã®æ”»æ’ƒåŠ›
    private float[] atk = new float[100];                   //      ã‚µãƒ–ã‚¹ãƒ†ãƒ¼ã‚¿ã‚¹ï¼ˆæ”»æ’ƒåŠ›ï¼‰
    private float[] def = new float[100];                   //      ã‚µãƒ–ã‚¹ãƒ†ãƒ¼ã‚¿ã‚¹ï¼ˆé˜²å¾¡åŠ›ï¼‰
    private float[] critical = new float[100];              //      ã‚µãƒ–ã‚¹ãƒ†ãƒ¼ã‚¿ã‚¹ï¼ˆä¼šå¿ƒçŽ‡)
    private int[] skill = new int[100];                     //      ã‚¹ã‚­ãƒ«

    private int itemNumberã€€= 0;                            //      æ‰‹ã«å…¥ã‚ŒãŸæ­¦å™¨ã®ç•ªå·

    private int[] itemBox = new int[100];                   //      æ­¦å™¨ã‚’ç®¡ç†ã™ã‚‹ãƒœãƒƒã‚¯ã‚¹

    private bool itemEnhancmentJadgement = false;           //      æ­¦å™¨ã‚’ãƒ¬ãƒ™ãƒ«ã‚¢ãƒƒãƒ—ã™ã‚‹ã‹åˆ¤æ–­ã™ã‚‹

    private int itemEnhancment = 0;                         //      å¼·åŒ–ã™ã‚‹æ­¦å™¨ã®ç•ªå·

>>>>>>> player

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        //      ƒ{ƒbƒNƒX‚Ì‰Šú‰»
        for (int i = 0; i < 100; i++) itemBox[i] = 0;
=======
        //      ã‚¢ã‚¤ãƒ†ãƒ ãƒœãƒƒã‚¯ã‚¹ã®åˆæœŸåŒ–
        for (int i = 0; i < 100; i++) itemBox[i] = -1;

>>>>>>> player
    }

    private void Update()
    {
<<<<<<< HEAD
        //      ƒŒƒxƒ‹ƒAƒbƒv
=======
>>>>>>> player
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    itemEnhancmentJadgement = true;
        //}

        ItemEnhancement();
<<<<<<< HEAD
    }

    //      •Ší‚Ì‹­‰»
    private void ItemEnhancement()
    {   
        if (!itemEnhancmentJadgement) return;
        
        //      —”‚ð”­¶‚³‚¹‚é
        int rand = Random.Range(0, 100);
        
        //      UŒ‚—ÍƒAƒbƒv
        if (rand < 30)
        {
            float i =  atk[itemEnhancment];
=======

        //Debug.Log(atk[itemEnhancment]);
    }

    //      æ­¦å™¨ã®ãƒ¬ãƒ™ãƒ«ã‚¢ãƒƒãƒ—
    private void ItemEnhancement()
    {
        if (!itemEnhancmentJadgement) return;

        //      ä¹±æ•°ã‚’ç™ºç”Ÿã•ã›ã‚‹
        int rand = Random.Range(0, 100);

        //      ã‚µãƒ–ã‚¹ãƒ†ãƒ¼ã‚¿ã‚¹ï¼ˆæ”»æ’ƒåŠ›ã®ãƒ¬ãƒ™ãƒ«ã‚¢ãƒƒãƒ—ï¼‰
        if (rand < 30)
        {
            float i = atk[itemEnhancment];
>>>>>>> player

            i *= 1.5f;

            atk[itemEnhancment] = i;
        }
<<<<<<< HEAD
        //      –hŒä—ÍƒAƒbƒv
=======
        //      ã‚µãƒ–ã‚¹ãƒ†ãƒ¼ã‚¿ã‚¹ï¼ˆé˜²å¾¡åŠ›ã®ãƒ¬ãƒ™ãƒ«ã‚¢ãƒƒãƒ—ï¼‰
>>>>>>> player
        else if (rand < 70)
        {
            float i = def[itemEnhancment];

            i *= 1.5f;

            def[itemEnhancment] = i;
        }
<<<<<<< HEAD
        //      ƒNƒŠƒeƒBƒJƒ‹ƒAƒbƒv
=======
        //      ã‚µãƒ–ã‚¹ãƒ†ãƒ¼ã‚¿ã‚¹ï¼ˆã‚¯ãƒªãƒ†ã‚£ã‚«ãƒ«ã®ãƒ¬ãƒ™ãƒ«ã‚¢ãƒƒãƒ—ï¼‰
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

    //      “üŽè‚µ‚½•Ší‚Ì”Ô†‚ð‘—‚é
=======
        itemEnhancmentJadgement = false;
    }

    //      ã‚¢ã‚¤ãƒ†ãƒ ãƒŠãƒ³ãƒãƒ¼ã‚’é€ã‚‹
>>>>>>> player
    public int GetItemNumber()
    {
        return itemNumber;
    }

<<<<<<< HEAD
    //      ƒAƒCƒeƒ€‚Ìî•ñ‚ðŽó‚¯Žæ‚é
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

                //      ƒAƒCƒeƒ€‘I‘ð‚Ì‰Šú‰»
=======
    //      ã‚¢ã‚¤ãƒ†ãƒ ã‚’æŽ¢ã—æƒ…å ±ã‚’å¾—ã‚‹
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
    //      UŒ‚—Í‚ð‘—‚é
=======

    //      æ”»æ’ƒåŠ›ã‚’é€ã‚‹
>>>>>>> player
    public float NowItemATK(int i)
    {
        return atk[i] + basic[i];
    }

<<<<<<< HEAD
    //      –¼‘O‚ð‘—‚é
=======
    public float NowItemWeponBasicAtk(int i)
    {
        return basic[i];
    }

    public float NowItemWeponSabAtk(int i)
    {
        return atk[i];
    }

    //      æ­¦å™¨ã®åå‰ã‚’é€ã‚‹
>>>>>>> player
    public string NowItemName(int i)
    {
        return WeponName[i];
    }

<<<<<<< HEAD
    //      ƒNƒŠƒeƒBƒJƒ‹—¦‚ð‘—‚é
=======
    //      æ­¦å™¨ã®ã‚¯ãƒªãƒ†ã‚£ã‚«ãƒ«çŽ‡ã‚’é€ã‚‹
>>>>>>> player
    public float NowItemCritical(int i)
    {
        return critical[i];
    }

<<<<<<< HEAD
    //      ƒAƒCƒeƒ€‚ðE‚Á‚½‚Æ‚«‚Ì”Ô†
=======
    //      æ­¦å™¨ã®é˜²å¾¡åŠ›ã‚’é€ã‚‹
    public float NowItemDefense(int i)
    {
        return def[i];
    }

    //      ã»ã—ã„æ­¦å™¨ã®æƒ…å ±ã‚’å—ã‘å–ã‚‹
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