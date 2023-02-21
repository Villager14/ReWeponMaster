using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerAtk playerAtk;

    BowMove bowMove;

    private float HP = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        playerAtk.GetComponent<PlayerAtk>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bow")
        {
            bowMove = collision.GetComponent<BowMove>();

            HP -= bowMove.BowDamage();
            //Debug.Log(HP);
        }
        else
        {
            HP -= playerAtk.GetAtack();
            //Debug.Log(HP); 
        }
    }
}

