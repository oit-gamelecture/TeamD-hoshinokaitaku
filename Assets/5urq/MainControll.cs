using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControll : MonoBehaviour
{

    public int currentTurn = 0; //�v���C���[���ƂɑJ��
    public int allowMoveTurn = 0;
    public int currentPhase = 0; //�v���C���[���̃C�x���g���ƂɑJ��
    public int allowMovePhase = 0;
    public int wonPlayer = -1;
    public int currentPlayer = 0; //���݃v���C���Ă���v���C���[:0-3
    public int requestDice = 0; // 1�Ȃ�_�C�X��diceRoll.cs�Ƀ��N�G�X�g����
    public int overcome = 0; // �v���C���[��0�ԃ}�X��ʉ߂������H
    public int toggleMasu = 0; // +3/-3 toggleer

    public GameObject Dicetest;
    private DiceRoll diceRoll;


    int modPoint = 0;
    int swapLocate = 0;

    public int diceAccept = 0;

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
    
    public int[] playerStatus = {0,0,0,0};
    // 1: reverse, 2: 2x, 3: absent

    public int[] playerProgressGap = {0,0,0,0};

    public int tempSavePlayerProgressGap;

    public int tempSavePlayerProgress;
    public int tempSavePlayerScore;

    int receivedDice = -1;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("[MainControll] �Q�[�����J�n���܂��B");
        //a = PlayerPrefs.GetInt("dice");
        //Debug.Log(a);

        Dicetest = GameObject.Find("DiceTest");
        diceRoll = Dicetest.GetComponent<DiceRoll>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (wonPlayer != -1) {
            currentPhase = 99;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " " + wonPlayer + "�ԃv���C���[���������܂����B");
        }
        if (currentPhase == 0) {
            tempSavePlayerProgress = 999;
            tempSavePlayerScore = 999;
            // ���݃v���C���Ă���v���C���[�������œ�����
            currentPlayer = currentTurn % 4;
            Debug.Log("" + currentTurn + "===============================================================");
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �v���C���[" + currentPlayer + "�ԃv���C���[�̃^�[���ł��B");
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " player0: " + playerProgress[0] + " �}�X��, player1:" + playerProgress[1] + " �}�X��, player2:" + playerProgress[2] + " �}�X��, player3:" + playerProgress[3] + " �}�X�ڂł��B");

            if (playerStatus[currentPlayer] == 3) {
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(11) : ����x�݂Ȃ̂Ői�߂܂���B");
                    tempSavePlayerProgress = playerProgress[currentPlayer];
                    playerStatus[currentPlayer] = 0;
                    currentPhase = 4;
            }else{
                // <<<< Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�T�C�R����U��܂��B(requestDice = 1)");
                requestDice = 1;
                currentPhase = 1;
            }
            //PlayerPrefs.SetInt("diceRquester", requestDice);
        }

        //�_�C�X�̐���-1����1-6�ɕς�����Ƃ��A�t�F�C�Y�i�s
        receivedDice = diceRoll.diceResult;//PlayerPrefs.GetInt("dice");
        //receivedDice = PlayerPrefs.GetInt("dice");

        if (currentPhase == 1 && receivedDice != -1) {
            overcome = 0;
            currentPhase = 2;
            // <<<< Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�i�ނ��߂̃T�C�R�����m�肳��܂����B: " + receivedDice + "");
            if (playerStatus[currentPlayer] == 2) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(7) : �T�C�R���̒l��2�{���܂��B");
                tempSavePlayerProgress = playerProgress[currentPlayer] + receivedDice + receivedDice;
                playerStatus[currentPlayer] = 0;
            }else if (playerStatus[currentPlayer] == 1) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(2) : �t��]���܂��B");
                tempSavePlayerProgress = playerProgress[currentPlayer] - receivedDice;
                playerStatus[currentPlayer] = 0;
                if (tempSavePlayerProgress < 0) {
                    tempSavePlayerProgress = tempSavePlayerProgress + 12;
                }
            }else{
                tempSavePlayerProgress = playerProgress[currentPlayer] + receivedDice;
            }
            //receivedDice = -1;
            diceAccept = 1;
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
                    wonPlayer = currentPlayer;
                }else{
                    tempSavePlayerScore = playerScore[currentPlayer] + 1;
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �v���C���[" + currentPlayer + "�̃X�R�A��" + playerScore[currentPlayer] + "�ŃN���A�ł͂Ȃ��̂ŁA�����" + tempSavePlayerScore + "�_�ɂȂ�܂����B" );
                }
            }

            switch (tempSavePlayerProgress)
            {
                case 0:
                    currentPhase = 4;
                    break;
                case 1:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(1) : +1 pt");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    tempSavePlayerScore = tempSavePlayerScore + 1;
                    currentPhase = 4;
                    break;
                case 2:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(2) : ���̃^�[���t��]");
                    playerStatus[currentPlayer] = 1; // 1: reverse
                    currentPhase = 4;
                    break;
                case 3:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(3) : + dice mod 3 pt");
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(3) : �T�C�R����U���Ă��������B");
                    currentPhase = 11;
                    receivedDice = -1;
                    requestDice = 1;
                    /*rndPoint = randomSeed.Next(0, 3);
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(3) : +" + rndPoint + "pt �����Z����܂����B");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    tempSavePlayerScore = tempSavePlayerScore + rndPoint;*/
                    break;
                case 4:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(4) : 2�}�X�߂�");
                    tempSavePlayerProgress = tempSavePlayerProgress - 2;
                    currentPhase = 4;
                    break;
                case 5:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �C�Ӄv���C���[�ƈʒu����");
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �ʒu����������Ώۃv���C���[�𐔎��L�[1~4����I�����Ă��������B");
                    currentPhase = 21;
                    break;
                case 6:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(6) :  >=1pt : 1/2 else +1");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    if (tempSavePlayerScore >= 1) {
                        if (tempSavePlayerScore % 2 == 1) {
                            tempSavePlayerScore = tempSavePlayerScore - 1;
                        }
                        tempSavePlayerScore = tempSavePlayerScore / 2;
                    }else{
                        tempSavePlayerScore = tempSavePlayerScore + 1;
                    }
                    currentPhase = 4;
                    break;
                case 7:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(7) : x2 dice next");
                    playerStatus[currentPlayer] = 2; // 2: 2x dice
                    currentPhase = 4;
                    break;
                case 8:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(8) : Toggle +3 / -3");
                    if ( toggleMasu == 0 ) {
                        toggleMasu = 1;
                        tempSavePlayerProgress = tempSavePlayerProgress + 3;
                        Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(8) : 3�}�X�i�݂܂����B���ʂ�l��3�}�X�߂�܂��B");
                    }else {
                        toggleMasu = 0;
                        tempSavePlayerProgress = tempSavePlayerProgress - 3;
                        Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(8) : 3�}�X�߂�܂����B���ʂ�l��3�}�X�i�݂܂��B");
                    }
                    currentPhase = 4;
                    break;
                case 9:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(9) : �R�}����ԋ߂��l�ƈʒu����");
                    
                    playerProgressGap[0] = Mathf.Abs(playerProgress[0] - playerProgress[currentPlayer]) * 10;
                    playerProgressGap[1] = Mathf.Abs(playerProgress[1] - playerProgress[currentPlayer]) * 10 + 1;
                    playerProgressGap[2] = Mathf.Abs(playerProgress[2] - playerProgress[currentPlayer]) * 10 + 2;
                    playerProgressGap[3] = Mathf.Abs(playerProgress[3] - playerProgress[currentPlayer]) * 10 + 3;

                    for (int p=0; p < 4; p++)
                    {
                        if (p == 0) {
                            tempSavePlayerProgressGap = playerProgressGap[0];
                        }else{
                            if (tempSavePlayerProgressGap > playerProgressGap[p]) {
                                if (playerProgressGap[p] >= 10) {
                                    tempSavePlayerProgressGap = playerProgressGap[p];
                                }
                            }
                        }
                    }
                    
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(9) : -> " + playerProgressGap[0] + ", " + playerProgressGap[1] + ", " + playerProgressGap[2] + ", " + playerProgressGap[3] + "");
                    tempSavePlayerProgressGap = tempSavePlayerProgressGap % 10;

                    swapLocate = playerProgress[tempSavePlayerProgressGap];
                    playerProgress[tempSavePlayerProgressGap] = tempSavePlayerProgress;
                    tempSavePlayerProgress = swapLocate;

                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(9) : " + tempSavePlayerProgressGap + "�ԃv���C���[�ƈʒu���������܂����B");

                    currentPhase = 4;
                    break;
                case 10:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(10) : -2 pt");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    tempSavePlayerScore = tempSavePlayerScore - 2;
                    currentPhase = 4;
                    break;
                case 11:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(11) : 5�}�X�߂�+1�x��");
                    tempSavePlayerProgress = tempSavePlayerProgress - 5;
                    playerStatus[currentPlayer] = 3;
                    currentPhase = 4;
                    break;       
            }
        }
        if (currentPhase == 11 && receivedDice != -1) {
            modPoint = receivedDice % 3;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(3) : �T�C�R���� " + receivedDice + " �������̂� " + modPoint + "pt �����Z����܂����B");
            if (overcome == 0) {
                tempSavePlayerScore = playerScore[currentPlayer];
            }
            tempSavePlayerScore = tempSavePlayerScore + modPoint;
            diceAccept = 1;
            currentPhase = 4;
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha1)) {
            if (currentPlayer == 0) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �������g�͑I���ł��܂���B");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �v���C���[" + currentPlayer + "�Ԃ�0�Ԃ̈ʒu�����ւ��܂����B");
                swapLocate = playerProgress[0];
                playerProgress[0] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha2)) {
            if (currentPlayer == 1) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �������g�͑I���ł��܂���B");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �v���C���[" + currentPlayer + "�Ԃ�1�Ԃ̈ʒu�����ւ��܂����B");
                swapLocate = playerProgress[1];
                playerProgress[1] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha3)) {
            if (currentPlayer == 2) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �������g�͑I���ł��܂���B");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �v���C���[" + currentPlayer + "�Ԃ�2�Ԃ̈ʒu�����ւ��܂����B");
                swapLocate = playerProgress[2];
                playerProgress[2] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha4)) {
            if (currentPlayer == 3) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �������g�͑I���ł��܂���B");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " �}�X����(5) : �v���C���[" + currentPlayer + "�Ԃ�3�Ԃ̈ʒu�����ւ��܂����B");
                swapLocate = playerProgress[3];
                playerProgress[3] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }
            
        if (currentPhase == 4) {
            //�}�X���ʂ����s����B�X�R�A��ύX����Ƃ���overcome:0�Ȃ�temp = player + addScore�A1�Ȃ�temp = temp + addScore

            // <<<< Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "�}�X���ʂ��I�����܂����B�X�R�A�ɕύX���������ꍇ�͕ۑ����܂�...");
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
