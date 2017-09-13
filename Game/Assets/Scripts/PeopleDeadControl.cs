using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleDeadControl : MonoBehaviour
{

    public MusicControl musicControl;
    public TimeClock timeClock;
    private Vector3 v;
    //private Vector3 beforv;
    Animator animatar;
    Rigidbody rigiBody;
    private bool isStar;
    private GameObject EatStar;
    private Vector3 StarF;
    //private bool isRun;
    //private bool isStop;
    private bool idcard;
    //private float i;

    // 注册监听,初始化
    void Start()
    {
        musicControl.MusicDead += MusicControl_MusicDead;
        musicControl.MusicRun += MusicControl_MusicRun;
        timeClock.TimeOver += TimeClock_TimeOver;
        animatar = GetComponent<Animator>();
        //rigiBody = GetComponent<Rigidbody>();
        isStar = false;
        idcard = false;
        //isRun = false;
        //isStop = false;
        v = transform.position;
        //beforv=transform.position;
        //i = 0;

    }

    //时间结束事件
    private void TimeClock_TimeOver(object sender, EventArgs e)
    {
        if (idcard == false || isStar == false)
        {
            Dead();
        }
        else
        {
            timeClock.TimeOver -= TimeClock_TimeOver;
        }
    }

    //奔跑事件
    private void MusicControl_MusicRun(object sender, System.EventArgs e)
    {
        StopCoroutine("Peopledead");
        StopCoroutine("Peoplerun");
        StartCoroutine("Peoplerun");
        //isStop = false;
        //isRun = true;


    }
    //停止事件
    private void MusicControl_MusicDead(object sender, System.EventArgs e)
    {
        StopCoroutine("Peoplerun");
        StopCoroutine("Peopledead");
        StartCoroutine("Peopledead");
        //isRun = false;
        //isStop = true;





    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //if (i >= 1)
        //{
        //    if (isStop == true)
        //    {
        //        v = transform.position;
        //        Debug.Log(v - beforv + "-----------");
        //        if (v == beforv)
        //        {
        //            Debug.Log("活111111111");
        //        }
        //        else
        //        {
        //            Dead();

        //            Debug.Log("死11111111");
        //            StopAllCoroutines();
        //        }
        //    }

        //    if (isRun == true)
        //    {

        //        v = transform.position;
        //        if (v != beforv)
        //        {
        //            Debug.Log("活2222");

        //        }
        //        else
        //        {
        //            Debug.Log("死2222222222");
        //            Dead();
        //            StopAllCoroutines();
        //        }
        //    }
        //}
        //i +=Time.deltaTime;
        //beforv = transform.position;
    }


    //事件协同程序
    IEnumerator Peoplerun()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            v = transform.position;
            yield return new WaitForSeconds(0.02f);
            if (v != transform.position)
            {


            }
            else
            {
                Debug.Log("死2222222222");
                Dead();

            }


        }
    }

    IEnumerator Peopledead()
    {

        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            v = transform.position;

            yield return new WaitForSeconds(0.02f);
            if (v != transform.position)
            {
                Dead();

                Debug.Log("死11111111");

            }
            else
            {

            }



        }


    }


    //死亡方式
    void Dead()
    {
        animatar.SetBool("Dead", true);
        if (isStar == true)
        {
            EatStar.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            //EatStar.transform.position = Vector3.Lerp(EatStar.transform.position, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 10f);
            //EatStar.transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + 1, Time.deltaTime * 0.1f), transform.position.z);
        }
        StopAllCoroutines();

    }

    //进入触发器
    void OnTriggerEnter(Collider col)
    {
        //吃星星触发器
        if (col.tag.Equals("Star"))
        {

            if (isStar == false)
            {
                isStar = true;
                EatStar = col.gameObject;
                StartCoroutine(StarFollow());

            }
        }

        //存活点触发器
        if (col.tag.Equals("LifePlace"))
        {
            idcard = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag.Equals("LifePlace"))
        {
            idcard = false;
        }
    }

    //星星跟随协同器
    IEnumerator StarFollow()
    {

        while (isStar == true)
        {
            StarF = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
            EatStar.transform.position = StarF;
            yield return null;
        }

    }

    //时间协同器
    IEnumerator myTime()
    {
        yield return new WaitForSeconds(5f);
    }

}

