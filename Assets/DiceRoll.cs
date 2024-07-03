using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiceRoll : MonoBehaviour
{
    // Start is called once after start button pressed

    public GameObject objDice1;
    public GameObject objDice2;
    public GameObject objDice3;
    public GameObject objDice4;
    public GameObject objDice5;
    public GameObject objDice6;

    public AudioClip whileRoll;
    public AudioClip endRoll;

    AudioSource audioSource;

    //diceReset - ダイスの6面すべての表示位置を引数1,引数2,引数3にリセットします。通常使用せず、diceLooksによって呼び出しされます。
    public void diceReset(float diceBaseX,float diceBaseY,float diceBaseZ)
    {
        Instantiate (objDice1, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        Instantiate (objDice2, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        Instantiate (objDice3, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        Instantiate (objDice4, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        Instantiate (objDice5, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        Instantiate (objDice6, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
    } 

    //diceLooks - 引数1 の結果のサイコロの画像を表示します。ダイス6面の表示位置を引数2,引数3,引数4の座標に設定したあと、引数1の面だけを引数5だけ上の座標に移動します。
    public void diceLooks(int diceNum, float diceBaseX,float diceBaseY,float diceBaseZ, float diceFrontY)
    {
        diceReset(diceBaseX,diceBaseY,diceBaseZ);
        switch (diceNum)
        {
            case 1:
                Instantiate (objDice1, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                break;
            case 2:
                Instantiate (objDice2, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                break;
            case 3:
                Instantiate (objDice3, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                break;
            case 4:
                Instantiate (objDice4, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                break;
            case 5:
                Instantiate (objDice5, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                break;
            case 6:
                Instantiate (objDice6, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                break;

            default:
                Debug.Log("diceLooks failed : num over expected range : 1 to 6");
                break;
        }
    }


    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        var diceResult = 0;
        var diceWhilerollLooks = 0;
        
        System.Random randomSeed = new System.Random();

        diceResult = randomSeed.Next(1,6);

        /*var diceRollLoopCount = 0;
        while (diceRollLoopCount < 11) {
            diceWhilerollLooks = randomSeed.Next(1,6);
            //diceLooks(diceWhilerollLooks,15.0f,7.0f,-3.0f,0.1f);
            //audioSource.PlayOneShot(whileRoll);
            diceRollLoopCount++;
        }*/

        diceLooks(diceResult,5.0f,7.0f,-3.0f,0.1f);
        Debug.Log("Dice Rolled :" + diceResult + "");

        //audioSource.PlayOneShot(endRoll);
    }

    // Update is called once per frame
    void Update()
    {


    }
    
}
