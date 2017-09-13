using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBorn : MonoBehaviour
{
    public GameObject star;
    GameObject newStar;
    GameObject[] starBorn;
    Transform bornPlace;
    int i = 0;
    Vector3 starPos;
 

    // Use this for initialization
    void Start()
    {
        starBorn = GameObject.FindGameObjectsWithTag("StarBorn");
        Born();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Born()
    {
        for (; i < 10;)
        {
     
            bornPlace = starBorn[Random.Range(0, starBorn.Length)].transform;
            starPos = new Vector3(bornPlace.position.x, bornPlace.position.y + 1, bornPlace.position.z);
            newStar = (GameObject)Instantiate(star, starPos, Quaternion.Euler(0, 90, 0));
            i++;
        }
    }
}
