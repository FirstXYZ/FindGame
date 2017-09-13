using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeClock : MonoBehaviour
{
    private Text clock;
    private int i;
    public event EventHandler TimeOver;
    GameObject[] bornPlace;
    public GameObject lifePlace;
    Vector3 bornpos;

    void Start()
    {

        clock = GetComponent<Text>();
        i = 20;
        StartCoroutine("ClockOver");
        bornPlace = GameObject.FindGameObjectsWithTag("Place");
        bornpos = bornPlace[UnityEngine.Random.Range(0, bornPlace.Length)].transform.position;
    }


    IEnumerator ClockOver()
    {
        while (i > 0)
        {
            yield return new WaitForSeconds(1f);
            i = i - 1;
            clock.text = i.ToString();
            if (i == 10)
            {
                lifePlace.transform.position = bornpos;
            }
        }
        yield return new WaitForSeconds(0.1f);

        TimeOver(this, EventArgs.Empty);
        clock.text = "";
        StopCoroutine("ClockOver");

    }
}

