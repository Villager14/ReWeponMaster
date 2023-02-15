using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    const int MaxItem = 100;

    private string[] WeponName    =   new string[100];      //      ����̖��O
    private float[] basic         =   new float[100];       //      ��b�U����
    private float[] atk           =   new float[100];       //      �T�u�U����
    private float[] def           =   new float[100];       //      �T�u�h���
    private float[] critical      =   new float[100];       //      ��S��

    private int itemNumber;                                 //      �A�C�e���̔ԍ�

    private int[] itemBox = new int[100];                   //      �A�C�e���̕ۑ��ԍ�

    private bool itemEnhancmentJadgement = false;           //      �A�C�e���̋��������邩�ǂ���

    private int itemEnhancment = 0;                         //      ��������A�C�e���̔ԍ�

    // Start is called before the first frame update
    void Start()
    {
        //      �{�b�N�X�̏�����
        for (int i = 0; i < 100; i++) itemBox[i] = 0;
    }

    private void Update()
    {
        //      ���x���A�b�v
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    itemEnhancmentJadgement = true;
        //}

        ItemEnhancement();
    }

    //      ����̋���
    private void ItemEnhancement()
    {   
        if (!itemEnhancmentJadgement) return;
        
        //      �����𔭐�������
        int rand = Random.Range(0, 100);
        
        //      �U���̓A�b�v
        if (rand < 30)
        {
            float i =  atk[itemEnhancment];

            i *= 1.5f;

            atk[itemEnhancment] = i;
        }
        //      �h��̓A�b�v
        else if (rand < 70)
        {
            float i = def[itemEnhancment];

            i *= 1.5f;

            def[itemEnhancment] = i;
        }
        //      �N���e�B�J���A�b�v
        else
        {
            float i = critical[itemEnhancment];

            i *= 1.5f;

            critical[itemEnhancment] = i;
        }

        itemEnhancmentJadgement = false;
    }

    //      ���肵������̔ԍ��𑗂�
    public int GetItemNumber()
    {
        return itemNumber;
    }

    //      �A�C�e���̏����󂯎��
    public void GetItem(string getname, float getbasic,float getatk, float getdef, float getcritical)
    {
        for (int i = 0; i < MaxItem; i++)
        {
            if (itemBox[i] == 0)
            {
                WeponName[i]    = getname;
                basic[i]        = getbasic;
                atk[i]          = getatk;
                def[i]          = getdef;
                critical[i]     = getcritical;

                itemBox[i] = 1;

                //      �A�C�e���I���̏�����
                itemNumber = -1;
                return;
            }
        }
    }

    //      �U���͂𑗂�
    public float NowItemATK(int i)
    {
        return atk[i] + basic[i];
    }

    //      ���O�𑗂�
    public string NowItemName(int i)
    {
        return WeponName[i];
    }

    //      �N���e�B�J�����𑗂�
    public float NowItemCritical(int i)
    {
        return critical[i];
    }

    //      �A�C�e�����E�����Ƃ��̔ԍ�
    public void GetWeponNumber(int i)
    {
        itemNumber = i;
    }
}