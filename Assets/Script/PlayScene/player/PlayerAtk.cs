using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {

        wepon1 = 0;
        wepon2 = 1;

        itemManager.GetComponent<ItemManager>();
        WeponMotion.GetComponent<WeponMotion>();
        statasUIScript.GetComponent<StatasUIScript>();

        nowWepon = wepon1;

        itemManager.SetWeponNumber(0);

        weponAtk = itemManager.NowItemATK(nowWepon);
        nowWeponName = itemManager.NowItemName(nowWepon);
        weponCritical = itemManager.NowItemCritical(nowWepon);
        weponDefense = itemManager.NowItemDefense(nowWepon);
    }

    // Update is called once per frame
    void Update()
    {
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

    private void Atack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int number = Random.Range(0, 100);

            if (number < totalCritical) totalAtk *= 2f;
        }
    }

    private void SkillDamage()
    {
        if (skillMagnification != 0)
        {
            totalAtk *= skillMagnification;

            int number = Random.Range(0, 100);

            if (number < totalCritical) totalAtk *= 2f;
        }
    }


    public float GetAtack()
    {
        return totalAtk;
    }

    public float GetDefence()
    {
        return totalDefence;
    }
    public float GetCritical()
    {
        return totalCritical;
    }


    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    private void WeponChange()
    {
        //      武器の交換処理
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (weponChange)
            {
                //      武器１
                nowWepon = wepon1;
                weponChange = false;
            }
            else if (!weponChange)
            {
                //      武器２
                nowWepon = wepon2;
                weponChange = true;
            }

            //      アイテムの情報を受け取る
            if (itemManager != null)
            {
                weponAtk = itemManager.NowItemATK(nowWepon);
                nowWeponName = itemManager.NowItemName(nowWepon);
                weponCritical = itemManager.NowItemCritical(nowWepon);
                weponDefense = itemManager.NowItemDefense(nowWepon);
            }
        }
    }

    //      アイテムを獲得する
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                itemManager.SetWeponNumber(7);

                Destroy(collision.gameObject);
            }
        }
    }

    //      アイテムの情報を受け取る
    public void SetStatas(int playerLevel, float playerAtk, float playerCritical, float playerDefence)
    {
        this.playerLevel = playerLevel;
        this.playerAtk = playerAtk;
        this.playerCritical = playerCritical;
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