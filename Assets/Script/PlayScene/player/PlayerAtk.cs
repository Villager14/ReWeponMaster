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

    // Start is called before the first frame update
    void Start()
    {
        wepon1 = 0;
        wepon2 = 2;

        itemManager.GetComponent<ItemManager>();
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

    private void Atack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int number = Random.Range(0, 100);

            if (number < totalCritical) totalAtk *= 2f;
        }
    }

    private void WeponChange()
    {
        //      マウス左クリックを押すと武器を切り替える
        if (Input.GetMouseButtonDown(1))
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
}
