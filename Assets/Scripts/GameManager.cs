using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    public int answer;
    [FormerlySerializedAs("answerSphere")] public GameObject answerSpherePrefab;
    public GameObject points;
    public String mathProblem;

    public int correctAnswer;

    void Start() {
        int answerPos = Random.Range(0, points.transform.childCount - 1);

        GameObject curSphere = Instantiate(answerSpherePrefab, points.transform.GetChild(answerPos).position,
            Quaternion.identity);
        Sphere correct = curSphere.GetComponent<Sphere>();
        correct.answer = correctAnswer;
        correct.isCorrect = true;

        for (int i = 0; i < points.transform.childCount; i++) {
            if (i == answerPos) {
                continue;
            }
            GameObject sphereTwo = Instantiate(answerSpherePrefab, points.transform.GetChild(i));
            sphereTwo.transform.localPosition = Vector3.zero;
        }
    }

    private void equation() {
        answer = 0;
        int choice = (int)Random.Range(1.0f, 4.0f);
        switch (choice) {
            case 1: {
                int addx = (int)Random.Range(1.0f, 50.0f);
                int addy = (int)Random.Range(1.0f, 49.0f);
                answer = addx + addy;
                mathProblem = addx + " + " + addy + " = " + answer;
                break;
            }

            case 2: {
                int subx = (int)Random.Range(1.0f, 100.0f);
                int suby = (int)Random.Range(1.0f, 100.0f);
                if (suby > subx) {
                    answer = suby - subx;
                    mathProblem = suby + " - " + subx + " = " + answer;
                }

                answer = subx - suby;
                mathProblem = subx + " - " + suby + " = " + answer;
                break;
            }

            case 3: {
                int mulx = (int)Random.Range(0.0f, 10.0f);
                int muly = (int)Random.Range(1.0f, 9.0f);
                answer = mulx * muly;
                mathProblem = mulx + " + " + muly + " = " + answer;
                break;
            }

            default: {
                int divx = (int)Random.Range(0.0f, 10.0f);
                int divy = (int)Random.Range(1.0f, 9.0f);
                int bignum = divx * divy;
                mathProblem = bignum + " / " + divx + " = " + divy;
                break;
            }
        }
    }
}