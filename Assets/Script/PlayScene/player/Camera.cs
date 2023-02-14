using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //      カメラの距離
    private const float Cameradistance = -10f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = player.transform.position;

        //      z軸は-10にする
        cameraPos.z = Cameradistance;

        //      カメラの位置をプレイヤーと同じにする（Z軸はー１０とする）
        this.gameObject.transform.position = cameraPos;
    }
}
