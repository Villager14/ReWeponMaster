using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] PlayerMoveScript playerMoveScript;

    private int playerHP = 1000;

    public Slider playerSliderHP;

    // Start is called before the first frame update
    void Start()
    {
        playerSliderHP.maxValue = 1000;

        playerMoveScript.GetComponent<PlayerMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy") return;

        if (playerMoveScript.AvoidanceJadgement()) return;

        playerHP -= 1;
        playerSliderHP.value = playerHP;
    }
}
