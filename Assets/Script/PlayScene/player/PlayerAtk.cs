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
        //      ���v�U���͂����߂�
        totalAtk = weponAtk + playerAtk;

        //      ���v�N���e�B�J���������߂�
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
        //      �}�E�X���N���b�N�������ƕ����؂�ւ���
        if (Input.GetMouseButtonDown(1))
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
}
