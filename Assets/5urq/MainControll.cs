using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControll : MonoBehaviour
{

    public int currentTurn = 0; //�v���C���[���ƂɑJ��
    public int allowMoveTurn = 0;
    public int currentPhase = 0; //�v���C���[���̃C�x���g���ƂɑJ��
    public int allowMovePhase = 0;
    public bool winnedConfirmed = false;
    public int currentPlayer = 0; //���݃v���C���Ă���v���C���[:0-3
    public static int requestDice = 0; // 1�Ȃ�_�C�X��diceRoll.cs�Ƀ��N�G�X�g����
    public int overcome = 0; // �v���C���[��0�ԃ}�X��ʉ߂������H

    public int[] playerProgress = {0,0,0,0};
    /*playerProgress[0] = 0;
    playerProgress[1] = 0;
    playerProgress[2] = 0;
    playerProgress[3] = 0;*/

    public int[] playerScore = {0,0,0,0};
    /*playerScore[0] = 0;
    playerScore[1] = 0;
    playerScore[2] = 0;
    playerScore[3] = 0;*/

    public int tempSavePlayerProgress;
    public int tempSavePlayerScore;

    int receivedDice = -1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[MainControll] �Q�[�����J�n���܂��B");
        //a = PlayerPrefs.GetInt("dice");
        //Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {   
        if (currentPhase == 0) {
            tempSavePlayerProgress = 999;
            tempSavePlayerScore = 999;
            // ���݃v���C���Ă���v���C���[�������œ�����
            currentPlayer = currentTurn % 4;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �v���C���[" + currentPlayer + "�ԃv���C���[�̃^�[���ł��B");
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�T�C�R����U��܂��B(requestDice = 1)");
            requestDice = 1;
            //PlayerPrefs.SetInt("diceRquester", requestDice);
            currentPhase = 1;
        }

        //�_�C�X�̐���-1����1-6�ɕς�����Ƃ��A�t�F�C�Y�i�s
        receivedDice = DiceRoll.diceResult;//PlayerPrefs.GetInt("dice");

        if (currentPhase == 1 && receivedDice != -1) {
            currentPhase = 2;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�i�ނ��߂̃T�C�R�����m�肳��܂����B: " + receivedDice + "");
            tempSavePlayerProgress = playerProgress[currentPlayer] + receivedDice;
            if (tempSavePlayerProgress >= 12) {
                overcome = 1;
                tempSavePlayerProgress = tempSavePlayerProgress - 12;
            }
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�v���C���[" + currentPlayer + " �́A" + playerProgress[currentPlayer] + "�}�X�ڂ���" + tempSavePlayerProgress + "�}�X�ڂ܂Ői�݂܂����B");
            if (overcome == 1) {
                //overcome == 0;
                Debug.Log("[MainControl] " + currentTurn + "/" + currentPhase + "�v���C���[" + currentPlayer + "�́A0�}�X�ڂɓ��B�܂��͒ʉ߂��܂����B");
                if (playerScore[currentPlayer] >= 3) {
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �v���C���[" + currentPlayer + "�̃X�R�A��" + playerScore[currentPlayer] + "/3 �𒴂����̂ŏ������܂����B" );
                    //winFlag
                }else{
                    tempSavePlayerScore = playerScore[currentPlayer] + 1;
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �v���C���[" + currentPlayer + "�̃X�R�A��" + playerScore[currentPlayer] + "�ŃN���A�ł͂Ȃ��̂ŁA�����" + tempSavePlayerScore + "�_�ɂȂ�܂����B" );
                }
            }
            //�}�X���ʂ����s����B�X�R�A��ύX����Ƃ���overcome:0�Ȃ�temp = player + addScore�A1�Ȃ�temp = temp + addScore

            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�}�X���ʂ��I�����܂����B�X�R�A�ɕύX���������ꍇ�͕ۑ����܂�...");
            if (tempSavePlayerProgress != 999) {
                playerProgress[currentPlayer] = tempSavePlayerProgress;
                //Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�}�X���ʂ��I�����܂����B�ʒu�A�X�R�A�ɕύX���������ꍇ�͕ۑ����܂�...");
            }
            if (tempSavePlayerScore != 999) {
                playerScore[currentPlayer] = tempSavePlayerScore;
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�X�R�A���ύX����܂����Bto" + playerScore[currentPlayer]);
            }
            currentPhase = 0;
            currentTurn++;
        }

        
    }
}
