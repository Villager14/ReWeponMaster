<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;

    private int wepon1;                     //      íPÌÔ
    private int wepon2;                     //      íQÌÔ

    private int nowWepon;                   //      »ÝõµÄ¢éí

    private float weponAtk = 0f;            //      íÌUÍ
    private float playerAtk = 0f;           //      vC[ÌîbUÍ

    private float totalAtk = 0f;            //      íÆîbUÍÌv
    private bool weponChange = false;       //      íÌØèÖ¦p

    private string nowWeponName = "";       //      »ÝõÌíÌ¼O

    private float weponCritical = 0f;       //      íÌNeBJ¦
    private float playerCritical = 0f;      //      vC[ÌîbNeBJ¦

    private float totalCritical = 0f;       //      íÆîbNeBJ¦Ìv

    private int playerLevel = 0;            //      vC[Ì»Ýx

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

    private int wepon1;                     //      æ­¦å¨ï¼
    private int wepon2;                     //      æ­¦å¨ï¼

    private int nowWepon;                   //      ç¾å¨è£åãã¦ããæ­¦å¨

    private float weponAtk = 0f;            //      æ­¦å¨ã®æ»æå
    private float playerAtk = 0f;           //      ãã¬ã¤ã¤ã¼ã®ç¾å¨ã®æ»æå

    private float totalAtk = 0f;            //      ç·åæ»æå
    private bool weponChange = false;       //      æ­¦å¨ã®äº¤æ

    private string nowWeponName = "";       //      ç¾å¨ã®æ­¦å¨ã®åå

    private float weponCritical = 0f;       //      æ­¦å¨ã®ä¼å¿ç
    private float playerCritical = 0f;      //      ãã¬ã¤ã¤ã¼ã®ä¼å¿ç

    private float totalCritical = 0f;       //      åè¨ã®ä¼å¿ç

    private float weponDefense = 0f;        //      æ­¦å¨ã®é²å¾¡å
    private float playerDefence = 0f;       //      ãã¬ã¤ã¤ã¼ã®é²å¾¡å

    private float totalDefence = 0f;        //      ç·åé²å¾¡å

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
        //      vUÍðßé
        totalAtk = weponAtk + playerAtk;

        //      vNeBJ¦ðßé
        totalCritical = weponCritical + playerCritical;

        Atack();

        WeponChange(); 
    }

    //      UÌ_[W
=======
        //      åè¨ã®æ»æå
        totalAtk = weponAtk + playerAtk;

        //      åè¨ã®ã¯ãªãã£ã«ã«ç
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

        //      æ­¦å¨ã®éåçªå·
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
        //      }EX¶NbNð·ÆíðØèÖ¦é
=======
        //      æ­¦å¨ã®äº¤æå¦ç
>>>>>>> player
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (weponChange)
            {
<<<<<<< HEAD
                //      íP
=======
                //      æ­¦å¨ï¼
>>>>>>> player
                nowWepon = wepon1;
                weponChange = false;
            }
            else if (!weponChange)
            {
<<<<<<< HEAD
                //      íQ
=======
                //      æ­¦å¨ï¼
>>>>>>> player
                nowWepon = wepon2;
                weponChange = true;
            }

<<<<<<< HEAD
            //      íÌîñðó¯æé
=======
            //      ã¢ã¤ãã ã®æå ±ãåãåã
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
    //      ACeðE¤
=======
    //      ã¢ã¤ãã ãç²å¾ãã
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
    //      Xe[^Xðó¯æé
    public void SetStatas(int playerLevel, float playerAtk, float playerCritical)
=======
    //      ã¢ã¤ãã ã®æå ±ãåãåã
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
            //      

            SordMotion();
        }
        else if (itemNumber < 10)
        {
            //      |
=======
        this.playerDefence = playerDefence;
    }

    private void WeponAtk()
    {
        int itemNumber = itemManager.GetWeponNumber(nowWepon);

        if (itemNumber < 5)
        {
            //      å£
            WeponMotion.Sord();
           
        }
        else if (itemNumber < 10)
        {
            //      å¼
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
