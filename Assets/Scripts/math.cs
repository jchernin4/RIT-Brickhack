using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class math {
    private string equation(){
        int choice = (int)Random.Range(1.0f,4.0f);
        if(choice == 1){
            int addx = (int)Random.Range(1.0f,50.0f);
            int addy = (int)Random.Range(1.0f,49.0f);
            int answer = addx + addy;
            return addx + " + " + addy + " = " + answer;

        }
        else if(choice == 2){
            int subx = (int)Random.Range(1.0f,100.0f);
            int suby = (int)Random.Range(1.0f,100.0f);
            if(suby > subx){
                int answer = suby - subx;
                return suby + " - " + subx + " = " + answer;
            }
            int answer = subx - suby;
            return subx + " - " + suby + " = " + answer;
        }
        else if(choice == 3){
            int mulx = (int)Random.Range(0.0f,10.0f);
            int muly = (int)Random.Range(1.0f,9.0f);
            int answer = mulx * muly;
            return mulx + " + " + muly + " = " + answer;
        }
        else{
            int divx = (int)Random.Range(0.0f, 10.0f);
            int divy = (int)Random.Range(1.0f,9.0f);
            int bignum = divx * divy;
            return bignum + " / " + divx + " = " + divy;
        }
    }
}
