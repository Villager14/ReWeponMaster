using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVProcessing : MonoBehaviour
{
    //      ���A�Z�b�gCSVSERIALIZER���K�v�f�X

    //      �����X�^�[�̃X�e�[�^�X
    public MonsterData[] monsterData;

    //      �v���C���[�̕���̃X�e�[�^�X
    public PlayerWeapon[] playerWeapons;

    public ItemManager itemManager;

    // Start is called before the first frame update
    void Start()
    {
        //      �e�L�X�g�t�@�C���̓ǂݍ��݂��s���ČJ���N���X
        TextAsset textasset = new TextAsset();

        //      �����X�^�[�̃X�e�[�^�X��CSV����󂯂Ƃ�
        EnemyStatas(textasset);

        //      �e�L�X�g�t�@�C���̓ǂݍ��݂��s���ČJ���N���X
        TextAsset textasse = new TextAsset();

        //      ����̃X�e�[�^�X��CSV����󂯎��
        PlayerWeapon(textasset);

        itemManager.GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {


        //      �A�C�e���̏����l���󂯎��
        if (itemManager.GetItemNumber() != -1)
        {
            int i = itemManager.GetItemNumber();

            itemManager.GetItem(playerWeapons[i].name, playerWeapons[i].Basic,
                        playerWeapons[i].atk, playerWeapons[i].def, playerWeapons[i].critical);
        }
    }

    private void EnemyStatas(TextAsset textasset)
    {
        //      �t�@�C����T�����̒���CSV��ǂݍ���
        textasset = Resources.Load("jabu", typeof(TextAsset)) as TextAsset;

        //      CSV�t�@�C����z��ɓ����
        monsterData = CSVSerializer.Deserialize<MonsterData>(textasset.text);
    }

    private void PlayerWeapon(TextAsset textasset)
    {
        //      �t�@�C����T�����̒���CSV��ǂݍ���
        textasset = Resources.Load("weapon", typeof(TextAsset)) as TextAsset;

        //      CSV�t�@�C����z��ɓ����
        playerWeapons = CSVSerializer.Deserialize<PlayerWeapon>(textasset.text);
    }
}
