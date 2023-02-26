using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
    public int answer;
    void Awake() {
        answer = Random.Range(3, 10);
    }
}
