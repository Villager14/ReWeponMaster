using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillName : MonoBehaviour
{
    private string weponName;

    public string WeponSkillName(int nameNumber)
    {
        switch(nameNumber)
        {
            case 0:
                weponName = "回転切り";
                break;
            case 1:
                weponName = "回転切り";
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                weponName = "チャージショット";
                break;
        }

        return weponName;
    }
}
