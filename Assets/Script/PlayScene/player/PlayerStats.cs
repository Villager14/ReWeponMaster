using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatas : MonoBehaviour
{
    private int playerRank = 1;

    private float playerHp = 1000f;
    private float playerAtk = 2f;
    private float playerDef = 2f;
    private float playerCritical = 5f;

    public PlayerAtk playerATK;

    // Start is called before the first frame update
    void Start()
    {
        playerATK.GetComponent<PlayerAtk>();
    }

    // Update is called once per frame
    void Update()
    {
        //      レベルアップ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerRank += 1;
            playerHp *= 1.2f;
            playerAtk *= 1.5f;
            playerDef *= 1.5f;
            playerCritical *= 1.2f;
        }

        //      プレイヤーのステータスを送る
        playerATK.SetStatas(playerRank, playerAtk, playerCritical);
    }


}
