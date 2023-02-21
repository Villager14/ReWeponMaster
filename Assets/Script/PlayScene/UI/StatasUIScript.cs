using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StatasUIScript : MonoBehaviour
{
    public GameObject level;
    public GameObject totalAtk;
    public GameObject totalDef;
    public GameObject totalCritical;

    public GameObject wepon1Name;
    public GameObject wepon1Skill;
    public GameObject wepon1BasicAtk;
    public GameObject wepon1SubAtk;
    public GameObject wepon1Def;
    public GameObject wepon1Critical;

    public GameObject wepon2Name;
    public GameObject wepon2Skill;
    public GameObject wepon2BasicAtk;
    public GameObject wepon2SubAtk;
    public GameObject wepon2Def;
    public GameObject wepon2Critical;

    public GameObject inventor;

    [SerializeField] PlayerAtk playerAtk;

    [SerializeField] ItemManager itemManager;

    [SerializeField] SkillName skillName;

    private int wepon1;
    private int wepon2;

    private bool change = false;

    public Image Statas;
    public Image Wepoon;
    public Image Item;
    public Image Logout;

    public GameObject Inventori;

    private int select = 0;

    private int decision = 0;

    private string wepon1skillName;

    // Start is called before the first frame update
    void Start()
    {
        playerAtk.GetComponent<PlayerAtk>();
        itemManager.GetComponent<ItemManager>();
        skillName.GetComponent<SkillName>();
        inventor.gameObject.SetActive(false);
        Inventori.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (change) change = false;
            else if (!change) change = true;
        }

        Inventori.gameObject.SetActive(change);

        if (!change)
        {
            inventor.gameObject.SetActive(false);
            return;
        }

        //TotalStatas();
        //Wepon();

        Select();
    }

    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (select != 0)select -= 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (select != 3) select += 1;
        }

        Statas.color =  Color.white;
        Wepoon.color =  Color.white;
        Item.color =    Color.white;
        Logout.color =  Color.white;

        switch (select)
        {
            case 0:
                Statas.color = Color.green;
                break;
            case 1:
                Wepoon.color = Color.green;
                break;
            case 2:
                Item.color = Color.green;
                break;
            case 3:
                Logout.color = Color.green;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            decision = select + 1;
        }

        switch(decision)
        {
            case 1:
                inventor.gameObject.SetActive(true);
                TotalStatas();
                Wepon();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                Application.Quit();
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            decision = 0;

            inventor.gameObject.SetActive(false);
        }
    }

    //      ステータス
    private void TotalStatas()
    {
        Text levell = level.GetComponent<Text>();

        levell.text = "現在のレベル" + playerAtk.GetPlayerLevel();

        //      総合攻撃力
        Text atk = totalAtk.GetComponent<Text>();

        atk.text =      "総合攻撃力" + playerAtk.GetAtack();

        //      総合防御力
        Text def = totalDef.GetComponent<Text>();

        def.text =      "総合防御力" + playerAtk.GetDefence();

        //      総合クリティカル率
        Text critcal = totalCritical.GetComponent<Text>();

        critcal.text =  "総合会心率" + playerAtk.GetCritical() + "%";
    }

    //      武器ステータス
    private void Wepon()
    {
        //      武器名１
        Text name1 = wepon1Name.GetComponent<Text>();

        name1.text = "武器名1 " + itemManager.NowItemName(wepon1);

        //      スキル１
        Text skill1 = wepon1Skill.GetComponent<Text>();

        skill1.text = "スキル" +  skillName.WeponSkillName(itemManager.GetSkill(wepon1));

        //      基礎攻撃力　武器１
        Text basicAtk1 = wepon1BasicAtk.GetComponent<Text>();

        basicAtk1.text = "基礎攻撃力" + itemManager.NowItemWeponBasicAtk(wepon1);

        //      サブ攻撃力　武器１
        Text subAtk1 = wepon1SubAtk.GetComponent<Text>();

        subAtk1.text = "サブ攻撃力" + itemManager.NowItemWeponSabAtk(wepon1);

        //      サブ防御力　武器１
        Text def1 = wepon1Def.GetComponent<Text>();

        def1.text = "防御力" + itemManager.NowItemDefense(wepon1);

        //      サブクリティカル率　武器１
        Text critical1 = wepon1Critical.GetComponent<Text>();

        critical1.text = "会心率" + itemManager.NowItemCritical(wepon1);

        //      武器名２
        Text name2 = wepon2Name.GetComponent<Text>();

        name2.text = "武器名2 " + itemManager.NowItemName(wepon2);

        //      スキル１
        Text skill2 = wepon2Skill.GetComponent<Text>();

        skill2.text = "スキル" + skillName.WeponSkillName(itemManager.GetSkill(wepon2));

        //      基礎攻撃力　武器2
        Text basicAtk2 = wepon2BasicAtk.GetComponent<Text>();

        basicAtk2.text = "基礎攻撃力" + itemManager.NowItemWeponBasicAtk(wepon2);

        //      サブ攻撃力　武器２
        Text subAtk2 = wepon2SubAtk.GetComponent<Text>();

        subAtk2.text = "サブ攻撃力" + itemManager.NowItemWeponSabAtk(wepon2);

        //      サブ防御力　武器２
        Text def2 = wepon2Def.GetComponent<Text>();

        def2.text = "防御力" + itemManager.NowItemDefense(wepon2);

        //      サブクリティカル率　武器２
        Text critical2 = wepon2Critical.GetComponent<Text>();

        critical2.text = "会心率" + itemManager.NowItemCritical(wepon2);
    }

    public void SetWepon(int wepon1, int wepon2)
    {
        this.wepon1 = wepon1;
        this.wepon2 = wepon2;
    }
}
