using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    [FormerlySerializedAs("answerSphere")] 
    public GameObject answerSpherePrefab;
    public GameObject points;
    public String mathProblem;

    public int correctAnswer;
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        int answerPos = Random.Range(0, points.transform.childCount-1);
        GameObject curSphere = Instantiate(answerSphere, points.transform.GetChild(answerPos));
        curSphere.transform.localPosition = new Vector3(0, 0, 0);
        curSphere.GetComponent<Sphere>().answer = correctAnswer;
        Destroy(points.transform.GetChild(answerPos).gameObject);
        for (int i = 0; i < points.transform.childCount; i++)
        { 
            Instantiate(answerSphere, points.transform.GetChild(i).transform);
=======
>>>>>>> a74cc5690124a3ef7e433f2ad44c649138299de4

    void Start() {
        int answerPos = Random.Range(0, points.transform.childCount - 1);
        
        GameObject curSphere = Instantiate(answerSpherePrefab, points.transform.GetChild(answerPos).position, Quaternion.identity);
        curSphere.transform.localPosition = Vector3.zero;
        curSphere.GetComponent<Sphere>().answer = correctAnswer;
        
        Destroy(points.transform.GetChild(answerPos));
        
        for (int i = 0; i < points.transform.childCount; i++) {
            GameObject sphereTwo = Instantiate(answerSpherePrefab, points.transform.GetChild(i));
            sphereTwo.transform.localPosition = Vector3.zero;
        }
    }
<<<<<<< HEAD

    // Update is called once per frame
    private void equation(){
        answer = 0;
        int choice = (int)Random.Range(1.0f,4.0f);
        if(choice == 1){
            int addx = (int)Random.Range(1.0f,50.0f);
            int addy = (int)Random.Range(1.0f,49.0f);
            answer = addx + addy;
            mathProblem = addx + " + " + addy + " = " + answer;

        }
        else if(choice == 2){
            int subx = (int)Random.Range(1.0f,100.0f);
            int suby = (int)Random.Range(1.0f,100.0f);
            if(suby > subx){
                answer = suby - subx;
                mathProblem = suby + " - " + subx + " = " + answer;
            }
            answer = subx - suby;
            mathProblem = subx + " - " + suby + " = " + answer;
        }
        else if(choice == 3){
            int mulx = (int)Random.Range(0.0f,10.0f);
            int muly = (int)Random.Range(1.0f,9.0f);
            answer = mulx * muly;
            mathProblem = mulx + " + " + muly + " = " + answer;
        }
        else{
            int divx = (int)Random.Range(0.0f, 10.0f);
            int divy = (int)Random.Range(1.0f,9.0f);
            int bignum = divx * divy;
            mathProblem = bignum + " / " + divx + " = " + divy;
        }
    }
}
=======
}
>>>>>>> a74cc5690124a3ef7e433f2ad44c649138299de4
