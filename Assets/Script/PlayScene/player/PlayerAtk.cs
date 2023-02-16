using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;

    private int wepon1;                     //      武器１の番号
    private int wepon2;                     //      武器２の番号

    private int nowWepon;                   //      現在装備している武器

    private float weponAtk = 0f;            //      武器の攻撃力
    private float playerAtk = 0f;           //      プレイヤーの基礎攻撃力

    private float totalAtk = 0f;            //      武器と基礎攻撃力の合計
    private bool weponChange = false;       //      武器の切り替え用

    private string nowWeponName = "";       //      現在装備中の武器の名前

    private float weponCritical = 0f;       //      武器のクリティカル率
    private float playerCritical = 0f;      //      プレイヤーの基礎クリティカル率

    private float totalCritical = 0f;       //      武器と基礎クリティカル率の合計

    private int playerLevel = 0;            //      プレイヤーの現在レベル

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        wepon1 = 0;
        wepon2 = 1;

        itemManager.GetComponent<ItemManager>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //      合計攻撃力を求める
        totalAtk = weponAtk + playerAtk;

        //      合計クリティカル率を求める
        totalCritical = weponCritical + playerCritical;

        Atack();

        WeponChange(); 
    }

    //      攻撃時のダメージ
    private void Atack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int number = Random.Range(0, 100);

            if (number < totalCritical) totalAtk *= 2f;
        }
    }

    public float GetAtack()
    {
        return totalAtk;
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    private void WeponChange()
    {
        //      マウス左クリックを押すと武器を切り替える
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

            //      武器の情報を受け取る
            if (itemManager != null)
            {
                weponAtk = itemManager.NowItemATK(nowWepon);
                nowWeponName = itemManager.NowItemName(nowWepon);
                weponCritical = itemManager.NowItemCritical(nowWepon);
            }
        }
    }

    //      アイテムを拾う処理
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (Input.GetKey(KeyCode.C))
            {
                itemManager.SetWeponNumber(2);

                Destroy(collision.gameObject);
            }
        }
    }

    //      ステータスを受け取る
    public void SetStatas(int playerLevel, float playerAtk, float playerCritical)
    {
        this.playerLevel = playerLevel;
        this.playerAtk = playerAtk;
        this.playerCritical = playerCritical;
    }


    private void WeponAtk()
    {
        int itemNumber = itemManager.GetWeponNumber(1);

        if (itemNumber < 5)
        {
            //      剣

            SordMotion();
        }
        else if (itemNumber < 10)
        {
            //      弓
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

    private void SordMotion()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
