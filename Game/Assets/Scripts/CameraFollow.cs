using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float speed = 5f;
    Vector3 offset;         


    void Awake()
    {
        offset = transform.position - player.position; //计算出offset
    }

    void FixedUpdate()
    {
        Vector3 camerapos = player.position + offset; //摄像机将要去的位置
        transform.position = Vector3.Lerp(transform.position, camerapos, speed * Time.deltaTime);//Lerp(现在的位置，目的地位置，持续时间)
        //Lerp函数是插值函数
    }
}
