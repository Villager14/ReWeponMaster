using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public ItemManager itemManager;

    private int wepon1;                     //      ����P�̔ԍ�
    private int wepon2;                     //      ����Q�̔ԍ�

    private int nowWepon;                   //      ���ݑ������Ă��镐��

    private float weponAtk = 0f;            //      ����̍U����
    private float playerAtk = 0f;           //      �v���C���[�̊�b�U����

    private float totalAtk = 0f;            //      ����Ɗ�b�U���͂̍��v
    private bool weponChange = false;       //      ����̐؂�ւ��p

    private string nowWeponName = "";       //      ���ݑ������̕���̖��O

    private float weponCritical = 0f;       //      ����̃N���e�B�J����
    private float playerCritical = 0f;      //      �v���C���[�̊�b�N���e�B�J����

    private float totalCritical = 0f;       //      ����Ɗ�b�N���e�B�J�����̍��v

    private int playerLevel = 0;            //      �v���C���[�̌��݃��x��

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
        //      ���v�U���͂����߂�
        totalAtk = weponAtk + playerAtk;

        //      ���v�N���e�B�J���������߂�
        totalCritical = weponCritical + playerCritical;

        Atack();

        WeponChange(); 
    }

    //      �U�����̃_���[�W
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
        //      �}�E�X���N���b�N�������ƕ����؂�ւ���
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (weponChange)
            {
                //      ����P
                nowWepon = wepon1;
                weponChange = false;
            }
            else if (!weponChange)
            {
                //      ����Q
                nowWepon = wepon2;
                weponChange = true;
            }

            //      ����̏����󂯎��
            if (itemManager != null)
            {
                weponAtk = itemManager.NowItemATK(nowWepon);
                nowWeponName = itemManager.NowItemName(nowWepon);
                weponCritical = itemManager.NowItemCritical(nowWepon);
            }
        }
    }

    //      �A�C�e�����E������
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

    //      �X�e�[�^�X���󂯎��
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
            //      ��

            SordMotion();
        }
        else if (itemNumber < 10)
        {
            //      �|
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
