using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMove : MonoBehaviour
{
    // public WeponMotion WeponMotion;
    //[SerializeField] PlayerMoveScript playerMoveScript;

    Rigidbody2D rd;

    private float bow;

    private GameObject ob;

    Vector2 velocity;

    private float time;

    private float damage;

    PlayerMoveScript playerMoveScript;

    PlayerAtk playerAtk;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();

        ob = GameObject.Find("Player");

        playerMoveScript = ob.GetComponent<PlayerMoveScript>();

        velocity = playerMoveScript.GetWeponDirection();

        playerAtk = ob.GetComponent<PlayerAtk>();

        damage = playerAtk.GetAtack();
    }

    // Update is called once per frame
    void Update()
    {

        rd.velocity = velocity * 100f;

        time += Time.deltaTime;

        if (time > 3f)
        {
            Destroy(gameObject);
        }
    }

    public float BowDamage()
    {
        return damage;
    }
}
