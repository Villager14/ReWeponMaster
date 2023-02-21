using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVProcessing : MonoBehaviour
{
    //      ※アセットCSVSERIALIZERが必要デス

    //      モンスターのステータス
    public MonsterData[] monsterData;

    //      プレイヤーの武器のステータス
    public PlayerWeapon[] playerWeapons;

    public ItemManager itemManager;

    // Start is called before the first frame update
    void Start()
    {
        //      テキストファイルの読み込みを行って繰れるクラス
        TextAsset textasset = new TextAsset();

        //      モンスターのステータスをCSVから受けとる
        EnemyStatas(textasset);

        //      テキストファイルの読み込みを行って繰れるクラス
        TextAsset textasse = new TextAsset();

        //      武器のステータスをCSVから受け取る
        PlayerWeapon(textasset);

<<<<<<< HEAD
        itemManager.GetComponent<ItemManager>();
=======
            int i = itemManager.GetItemNumber();

            itemManager.GetItem(playerWeapons[i].name, playerWeapons[i].Basic,
                        playerWeapons[i].atk, playerWeapons[i].def, playerWeapons[i].critical, Skill(i));
>>>>>>> player
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD


        //      �A�C�e���̏����l���󂯎��
=======
        //      アイテムの情報を受け取る
>>>>>>> player
        if (itemManager.GetItemNumber() != -1)
        {
            int i = itemManager.GetItemNumber();

            itemManager.GetItem(playerWeapons[i].name, playerWeapons[i].Basic,
<<<<<<< HEAD
                        playerWeapons[i].atk, playerWeapons[i].def, playerWeapons[i].critical);
        }
=======
                        playerWeapons[i].atk, playerWeapons[i].def, playerWeapons[i].critical, Skill(i));
        }

    }

    private int Skill(int i)
    {
        int skill = 0;

        if (i < 5)
        {
            skill = 1;
            //      剣のスキル
            return skill;    
        }
        else if (i < 10)
        {
            skill = 6;
            //      弓のスキル
            return skill;
        }

        return 0;
>>>>>>> player
    }

    private void EnemyStatas(TextAsset textasset)
    {
        //      ファイルを探しその中のCSVを読み込む
        textasset = Resources.Load("jabu", typeof(TextAsset)) as TextAsset;

        //      CSVファイルを配列に入れる
        monsterData = CSVSerializer.Deserialize<MonsterData>(textasset.text);
    }

    private void PlayerWeapon(TextAsset textasset)
    {
        //      ファイルを探しその中のCSVを読み込む
        textasset = Resources.Load("weapon", typeof(TextAsset)) as TextAsset;

        //      CSVファイルを配列に入れる
        playerWeapons = CSVSerializer.Deserialize<PlayerWeapon>(textasset.text);
    }
}
