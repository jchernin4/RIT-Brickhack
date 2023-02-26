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

    public int correctAnswer;

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
}