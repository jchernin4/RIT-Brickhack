using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
    public int answer;
    public bool isCorrect;
    void Awake() {
        answer = Random.Range(3, 10);
    }
}
