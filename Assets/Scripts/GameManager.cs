using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public int answer;
    public GameObject answerSphere;
    public GameObject points;

    public int correctAnswer;
    // Start is called before the first frame update
    void Start()
    {
        int answerPos = Random.Range(0, points.transform.childCount-1);
        GameObject curSphere = Instantiate(answerSphere, points.transform.GetChild(answerPos));
        curSphere.GetComponent<Sphere>().answer = correctAnswer;
        Destroy(points.transform.GetChild(answerPos));
        for (int i = 0; i < points.transform.childCount; i++)
        { 
            Instantiate(answerSphere, points.transform.GetChild(i));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
