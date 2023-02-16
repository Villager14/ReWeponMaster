using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeponMotion : MonoBehaviour
{
    public GameObject direction;                        //      プレイヤーの向いている方向

    public PlayerMoveScript playerMoveScript;

    private float sordNomalAtk = 0f;                    //      剣通常攻撃時の角度

    private bool sordNomalAtkFlag = false;              //      剣を振っているかどうか判断する

    private bool atk = false;                           //      攻撃しているかどうか判断する

    private bool changeSord = false;                    //      剣通常往復切り替え

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

    //      剣の処理
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

    //      剣の基本攻撃１
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

    //      剣の基本攻撃２
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
