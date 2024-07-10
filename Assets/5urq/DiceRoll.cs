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

    public GameObject dice1; //= Instantiate(objDice1, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
    public GameObject dice2;
    public GameObject dice3;
    public GameObject dice4;
    public GameObject dice5;
    public GameObject dice6;

    public GameObject MainCon;
    private MainControll mainCon;

    //diceReset - �_�C�X��6�ʂ��ׂĂ̕\���ʒu������1,����2,����3�Ƀ��Z�b�g���܂��B�ʏ�g�p�����AdiceLooks�ɂ���ČĂяo������܂��B
    public void diceReset(float diceBaseX,float diceBaseY,float diceBaseZ)
    {
        dice1 = Instantiate(objDice1, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        dice2 = Instantiate(objDice2, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        dice3 = Instantiate(objDice3, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        dice4 = Instantiate(objDice4, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        dice5 = Instantiate(objDice5, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
        dice6 = Instantiate(objDice6, new Vector3(diceBaseX,diceBaseY,diceBaseZ), Quaternion.identity);
    } 

    //diceLooks - ����1 �̌��ʂ̃T�C�R���̉摜��\�����܂��B(<���܂���>:�_�C�X6�ʂ̕\���ʒu������2,����3,����4�̍��W�ɐݒ肵������)�A����1�̖ʂ���������5������̍��W�Ɉړ����܂��B
    public void diceLooks(int diceNum, float diceBaseX,float diceBaseY,float diceBaseZ, float diceFrontY)
    {

        dice1.SetActive(false);
        dice2.SetActive(false);
        dice3.SetActive(false);
        dice4.SetActive(false);
        dice5.SetActive(false);
        dice6.SetActive(false);
        //diceReset(diceBaseX,diceBaseY,diceBaseZ);
        switch (diceNum)
        {
            case 1:
                //Instantiate (objDice1, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                dice1.transform.position = new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ);
                dice1.SetActive(true);
                break;
            case 2:
                //Instantiate (objDice2, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                dice2.transform.position = new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ);
                dice2.SetActive(true);
                break;
            case 3:
                //Instantiate (objDice3, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                dice3.transform.position = new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ);
                dice3.SetActive(true);
                break;
            case 4:
                //Instantiate (objDice4, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                dice4.transform.position = new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ);
                dice4.SetActive(true);
                break;
            case 5:
                //Instantiate (objDice5, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                dice5.transform.position = new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ);
                dice5.SetActive(true);
                break;
            case 6:
                //Instantiate (objDice6, new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ), Quaternion.identity);
                dice6.transform.position = new Vector3(diceBaseX,diceBaseY+diceFrontY,diceBaseZ);
                dice6.SetActive(true);
                break;

            default:
                Debug.Log("diceLooks failed : num over expected range : 1 to 6");
                break;
        }
    }

    public int diceResult = -1;
    private System.Random randomSeed;
    private bool isRolling = false;

    
    void Start()
    {
         randomSeed = new System.Random();
         //StartCoroutine(JustDiceCoroutine());

         diceReset(0f,0f,0f);

         MainCon = GameObject.Find("MainControll");
         mainCon = MainCon.GetComponent<MainControll>();
    }

    void Move(GameObject obj, float moveToX,float moveToY,float moveToZ)
    {
        // �I�u�W�F�N�g��V�����ʒu�Ɉړ�������
        obj.transform.position = new Vector3(moveToX, moveToY, moveToZ);
    }

    IEnumerator JustDiceCoroutine()
    {
        isRolling = true;
        
        diceResult = -1;
        PlayerPrefs.SetInt("dice", diceResult);

        //diceReset(0.0f,0.0f,0.0f);

        var diceObjectAddY = 0.01f;
        string debugLogger = "";

        for (int i = 0; i < 5; i++)
        {
            int tempResult = randomSeed.Next(1, 7);
            //Debug.Log("���̃T�C�R����: " + tempResult);
            debugLogger = debugLogger + tempResult + ",";
            diceLooks(tempResult,5.0f,7.0f,-3.0f,diceObjectAddY);

            diceObjectAddY = diceObjectAddY + 0.01f;
            yield return new WaitForSeconds(0.2f);
        }
        
        diceResult = randomSeed.Next(1, 7);
        PlayerPrefs.SetInt("dice", diceResult);
        Debug.Log(debugLogger + "- Final :" + diceResult);
        diceLooks(diceResult,5.0f,7.0f,-3.0f,0.06f);

        isRolling = false;
    }

    // Update is called once per frame
    void Update()
    {
        //int diceRequestedStatus = MainControll.diceRequest;//PlayerPrefs.GetInt("diceRquester");
        if (mainCon.requestDice == 1 && Input.GetKeyDown(KeyCode.R))
        {
            mainCon.requestDice = 0;
            //PlayerPrefs.SetInt("diceRequester", diceRequestedStatus);

            if (!isRolling)
            {
                StartCoroutine(JustDiceCoroutine());
            }
            else
            {
                Debug.Log("�����ł��܂���");
            }
        }else{
            
        diceResult = -1;
        }

    }
    
}
