<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;

    private int wepon1;                     //      •Ší‚P‚Ì”Ô†
    private int wepon2;                     //      •Ší‚Q‚Ì”Ô†

    private int nowWepon;                   //      Œ»Ý‘•”õ‚µ‚Ä‚¢‚é•Ší

    private float weponAtk = 0f;            //      •Ší‚ÌUŒ‚—Í
    private float playerAtk = 0f;           //      ƒvƒŒƒCƒ„[‚ÌŠî‘bUŒ‚—Í

    private float totalAtk = 0f;            //      •Ší‚ÆŠî‘bUŒ‚—Í‚Ì‡Œv
    private bool weponChange = false;       //      •Ší‚ÌØ‚è‘Ö‚¦—p

    private string nowWeponName = "";       //      Œ»Ý‘•”õ’†‚Ì•Ší‚Ì–¼‘O

    private float weponCritical = 0f;       //      •Ší‚ÌƒNƒŠƒeƒBƒJƒ‹—¦
    private float playerCritical = 0f;      //      ƒvƒŒƒCƒ„[‚ÌŠî‘bƒNƒŠƒeƒBƒJƒ‹—¦

    private float totalCritical = 0f;       //      •Ší‚ÆŠî‘bƒNƒŠƒeƒBƒJƒ‹—¦‚Ì‡Œv

    private int playerLevel = 0;            //      ƒvƒŒƒCƒ„[‚ÌŒ»ÝƒŒƒxƒ‹

    private Animator animator;
=======
ï»¿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;
    public WeponMotion WeponMotion;

    [SerializeField] StatasUIScript statasUIScript;

    private int wepon1;                     //      æ­¦å™¨ï¼‘
    private int wepon2;                     //      æ­¦å™¨ï¼’

    private int nowWepon;                   //      ç¾åœ¨è£…å‚™ã—ã¦ã„ã‚‹æ­¦å™¨

    private float weponAtk = 0f;            //      æ­¦å™¨ã®æ”»æ’ƒåŠ›
    private float playerAtk = 0f;           //      ãƒ—ãƒ¬ã‚¤ãƒ¤ãƒ¼ã®ç¾åœ¨ã®æ”»æ’ƒåŠ›

    private float totalAtk = 0f;            //      ç·åˆæ”»æ’ƒåŠ›
    private bool weponChange = false;       //      æ­¦å™¨ã®äº¤æ›

    private string nowWeponName = "";       //      ç¾åœ¨ã®æ­¦å™¨ã®åå‰

    private float weponCritical = 0f;       //      æ­¦å™¨ã®ä¼šå¿ƒçŽ‡
    private float playerCritical = 0f;      //      ãƒ—ãƒ¬ã‚¤ãƒ¤ãƒ¼ã®ä¼šå¿ƒçŽ‡

    private float totalCritical = 0f;       //      åˆè¨ˆã®ä¼šå¿ƒçŽ‡

    private float weponDefense = 0f;        //      æ­¦å™¨ã®é˜²å¾¡åŠ›
    private float playerDefence = 0f;       //      ãƒ—ãƒ¬ã‚¤ãƒ¤ãƒ¼ã®é˜²å¾¡åŠ›

    private float totalDefence = 0f;        //      ç·åˆé˜²å¾¡åŠ›

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
        //      ‡ŒvUŒ‚—Í‚ð‹‚ß‚é
        totalAtk = weponAtk + playerAtk;

        //      ‡ŒvƒNƒŠƒeƒBƒJƒ‹—¦‚ð‹‚ß‚é
        totalCritical = weponCritical + playerCritical;

        Atack();

        WeponChange(); 
    }

    //      UŒ‚Žž‚Ìƒ_ƒ[ƒW
=======
        //      åˆè¨ˆã®æ”»æ’ƒåŠ›
        totalAtk = weponAtk + playerAtk;

        //      åˆè¨ˆã®ã‚¯ãƒªãƒ†ã‚£ã‚«ãƒ«çŽ‡
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

        //      æ­¦å™¨ã®é…åˆ—ç•ªå·
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
        //      ƒ}ƒEƒX¶ƒNƒŠƒbƒN‚ð‰Ÿ‚·‚Æ•Ší‚ðØ‚è‘Ö‚¦‚é
=======
        //      æ­¦å™¨ã®äº¤æ›å‡¦ç†
>>>>>>> player
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (weponChange)
            {
<<<<<<< HEAD
                //      •Ší‚P
=======
                //      æ­¦å™¨ï¼‘
>>>>>>> player
                nowWepon = wepon1;
                weponChange = false;
            }
            else if (!weponChange)
            {
<<<<<<< HEAD
                //      •Ší‚Q
=======
                //      æ­¦å™¨ï¼’
>>>>>>> player
                nowWepon = wepon2;
                weponChange = true;
            }

<<<<<<< HEAD
            //      •Ší‚Ìî•ñ‚ðŽó‚¯Žæ‚é
=======
            //      ã‚¢ã‚¤ãƒ†ãƒ ã®æƒ…å ±ã‚’å—ã‘å–ã‚‹
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
    //      ƒAƒCƒeƒ€‚ðE‚¤ˆ—
=======
    //      ã‚¢ã‚¤ãƒ†ãƒ ã‚’ç²å¾—ã™ã‚‹
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
    //      ƒXƒe[ƒ^ƒX‚ðŽó‚¯Žæ‚é
    public void SetStatas(int playerLevel, float playerAtk, float playerCritical)
=======
    //      ã‚¢ã‚¤ãƒ†ãƒ ã®æƒ…å ±ã‚’å—ã‘å–ã‚‹
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
            //      Œ•

            SordMotion();
        }
        else if (itemNumber < 10)
        {
            //      ‹|
=======
        this.playerDefence = playerDefence;
    }

    private void WeponAtk()
    {
        int itemNumber = itemManager.GetWeponNumber(nowWepon);

        if (itemNumber < 5)
        {
            //      å‰£
            WeponMotion.Sord();
           
        }
        else if (itemNumber < 10)
        {
            //      å¼“
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
