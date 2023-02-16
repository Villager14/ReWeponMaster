using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeponMotion : MonoBehaviour
{
    public GameObject direction;                        //      �v���C���[�̌����Ă������

    public PlayerMoveScript playerMoveScript;

    private float sordNomalAtk = 0f;                    //      ���ʏ�U�����̊p�x

    private bool sordNomalAtkFlag = false;              //      ����U���Ă��邩�ǂ������f����

    private bool atk = false;                           //      �U�����Ă��邩�ǂ������f����

    private bool changeSord = false;                    //      ���ʏ퉝���؂�ւ�

    public GameObject SordNomalAtkObj;

    private void Start()
    {
        playerMoveScript.GetComponent<PlayerMoveScript>();

        SordNomalAtkObj.gameObject.SetActive(false);
    }

    private void Update()
    {
        Sord();
    }

    //      ���̏���
    private void Sord()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            atk = true;
        }

        playerMoveScript.SetNomalAtkJadgement(atk);

        if (atk == true)
        {
            if (changeSord)
            {
                if (SordNomalAtk1() == true)
                {
                    atk = false;
                }
            }
            else
            {
                if (SordNomalAtk2() == true)
                {
                    atk = false;
                }
            }
        }
    }

    //      ���̊�{�U���P
    private bool SordNomalAtk1()
    {
        if (!sordNomalAtkFlag)
        {
            sordNomalAtkFlag = true;
            sordNomalAtk = -40f;
            SordNomalAtkObj.gameObject.SetActive(true);
        }

        sordNomalAtk += 1.0f;

        Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

        float angele = Mathf.Atan2(playerVelocity.y, playerVelocity.x) * Mathf.Rad2Deg;

        direction.transform.rotation = Quaternion.Euler(0, 0, angele + sordNomalAtk);

        if (sordNomalAtk > 40)
        {
            sordNomalAtkFlag = false;
            SordNomalAtkObj.gameObject.SetActive(false);
            changeSord = false;
            return true;
        }

        return false;
    }

    //      ���̊�{�U���Q
    private bool SordNomalAtk2()
    {
        if (!sordNomalAtkFlag)
        {
            sordNomalAtkFlag = true;
            sordNomalAtk = 40f;
            SordNomalAtkObj.gameObject.SetActive(true);
        }

        sordNomalAtk -= 1.0f;

        Vector2 playerVelocity = playerMoveScript.GetWeponDirection();

        float angele = Mathf.Atan2(playerVelocity.y, playerVelocity.x) * Mathf.Rad2Deg;

        direction.transform.rotation = Quaternion.Euler(0, 0, angele + sordNomalAtk);

        if (sordNomalAtk < -40)
        {
            sordNomalAtkFlag = false;
            SordNomalAtkObj.gameObject.SetActive(false);
            changeSord = true;
            return true;
        }

        return false;
    }

}
