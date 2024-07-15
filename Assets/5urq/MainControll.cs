using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControll : MonoBehaviour
{

    public int currentTurn = 0; //プレイヤーごとに遷移
    public int allowMoveTurn = 0;
    public int currentPhase = 0; //プレイヤー内のイベントごとに遷移
    public int allowMovePhase = 0;
    public int wonPlayer = -1;
    public int currentPlayer = 0; //現在プレイしているプレイヤー:0-3
    public int requestDice = 0; // 1ならダイスをdiceRoll.csにリクエストする
    public int overcome = 0; // プレイヤーは0番マスを通過したか？
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
        Debug.Log("[MainControll] ゲームを開始します。");
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
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " " + wonPlayer + "番プレイヤーが勝利しました。");
        }
        if (currentPhase == 0) {
            tempSavePlayerProgress = 999;
            tempSavePlayerScore = 999;
            // 現在プレイしているプレイヤーをここで投げる
            currentPlayer = currentTurn % 4;
            Debug.Log("" + currentTurn + "===============================================================");
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " プレイヤー" + currentPlayer + "番プレイヤーのターンです。");
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " player0: " + playerProgress[0] + " マス目, player1:" + playerProgress[1] + " マス目, player2:" + playerProgress[2] + " マス目, player3:" + playerProgress[3] + " マス目です。");

            if (playerStatus[currentPlayer] == 3) {
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(11) : 今回休みなので進めません。");
                    tempSavePlayerProgress = playerProgress[currentPlayer];
                    playerStatus[currentPlayer] = 0;
                    currentPhase = 4;
            }else{
                // <<<< Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "サイコロを振ります。(requestDice = 1)");
                requestDice = 1;
                currentPhase = 1;
            }
            //PlayerPrefs.SetInt("diceRquester", requestDice);
        }

        //ダイスの数が-1から1-6に変わったとき、フェイズ進行
        receivedDice = diceRoll.diceResult;//PlayerPrefs.GetInt("dice");
        //receivedDice = PlayerPrefs.GetInt("dice");

        if (currentPhase == 1 && receivedDice != -1) {
            overcome = 0;
            currentPhase = 2;
            // <<<< Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "進むためのサイコロが確定されました。: " + receivedDice + "");
            if (playerStatus[currentPlayer] == 2) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(7) : サイコロの値を2倍します。");
                tempSavePlayerProgress = playerProgress[currentPlayer] + receivedDice + receivedDice;
                playerStatus[currentPlayer] = 0;
            }else if (playerStatus[currentPlayer] == 1) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(2) : 逆回転します。");
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
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "プレイヤー" + currentPlayer + " は、" + playerProgress[currentPlayer] + "マス目から" + tempSavePlayerProgress + "マス目まで進みました。");
            if (overcome == 1) {
                //overcome == 0;
                Debug.Log("[MainControl] " + currentTurn + "/" + currentPhase + "プレイヤー" + currentPlayer + "は、0マス目に到達または通過しました。");
                if (playerScore[currentPlayer] >= 3) {
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " プレイヤー" + currentPlayer + "のスコアが" + playerScore[currentPlayer] + "/3 を超えたので勝利しました。" );
                    wonPlayer = currentPlayer;
                }else{
                    tempSavePlayerScore = playerScore[currentPlayer] + 1;
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " プレイヤー" + currentPlayer + "のスコアは" + playerScore[currentPlayer] + "でクリアではないので、代わりに" + tempSavePlayerScore + "点になりました。" );
                }
            }

            switch (tempSavePlayerProgress)
            {
                case 0:
                    currentPhase = 4;
                    break;
                case 1:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(1) : +1 pt");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    tempSavePlayerScore = tempSavePlayerScore + 1;
                    currentPhase = 4;
                    break;
                case 2:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(2) : 次のターン逆回転");
                    playerStatus[currentPlayer] = 1; // 1: reverse
                    currentPhase = 4;
                    break;
                case 3:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(3) : + dice mod 3 pt");
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(3) : サイコロを振ってください。");
                    currentPhase = 11;
                    receivedDice = -1;
                    requestDice = 1;
                    /*rndPoint = randomSeed.Next(0, 3);
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(3) : +" + rndPoint + "pt が加算されました。");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    tempSavePlayerScore = tempSavePlayerScore + rndPoint;*/
                    break;
                case 4:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(4) : 2マス戻る");
                    tempSavePlayerProgress = tempSavePlayerProgress - 2;
                    currentPhase = 4;
                    break;
                case 5:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : 任意プレイヤーと位置交換");
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : 位置交換をする対象プレイヤーを数字キー1~4から選択してください。");
                    currentPhase = 21;
                    break;
                case 6:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(6) :  >=1pt : 1/2 else +1");
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
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(7) : x2 dice next");
                    playerStatus[currentPlayer] = 2; // 2: 2x dice
                    currentPhase = 4;
                    break;
                case 8:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(8) : Toggle +3 / -3");
                    if ( toggleMasu == 0 ) {
                        toggleMasu = 1;
                        tempSavePlayerProgress = tempSavePlayerProgress + 3;
                        Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(8) : 3マス進みました。次通る人は3マス戻ります。");
                    }else {
                        toggleMasu = 0;
                        tempSavePlayerProgress = tempSavePlayerProgress - 3;
                        Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(8) : 3マス戻りました。次通る人は3マス進みます。");
                    }
                    currentPhase = 4;
                    break;
                case 9:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(9) : コマが一番近い人と位置交換");
                    
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
                    
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(9) : -> " + playerProgressGap[0] + ", " + playerProgressGap[1] + ", " + playerProgressGap[2] + ", " + playerProgressGap[3] + "");
                    tempSavePlayerProgressGap = tempSavePlayerProgressGap % 10;

                    swapLocate = playerProgress[tempSavePlayerProgressGap];
                    playerProgress[tempSavePlayerProgressGap] = tempSavePlayerProgress;
                    tempSavePlayerProgress = swapLocate;

                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(9) : " + tempSavePlayerProgressGap + "番プレイヤーと位置を交換しました。");

                    currentPhase = 4;
                    break;
                case 10:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(10) : -2 pt");
                    if (overcome == 0) {
                        tempSavePlayerScore = playerScore[currentPlayer];
                    }
                    tempSavePlayerScore = tempSavePlayerScore - 2;
                    currentPhase = 4;
                    break;
                case 11:
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(11) : 5マス戻る+1休み");
                    tempSavePlayerProgress = tempSavePlayerProgress - 5;
                    playerStatus[currentPlayer] = 3;
                    currentPhase = 4;
                    break;       
            }
        }
        if (currentPhase == 11 && receivedDice != -1) {
            modPoint = receivedDice % 3;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(3) : サイコロが " + receivedDice + " だったので " + modPoint + "pt が加算されました。");
            if (overcome == 0) {
                tempSavePlayerScore = playerScore[currentPlayer];
            }
            tempSavePlayerScore = tempSavePlayerScore + modPoint;
            diceAccept = 1;
            currentPhase = 4;
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha1)) {
            if (currentPlayer == 0) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : 自分自身は選択できません。");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : プレイヤー" + currentPlayer + "番と0番の位置を入れ替えました。");
                swapLocate = playerProgress[0];
                playerProgress[0] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha2)) {
            if (currentPlayer == 1) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : 自分自身は選択できません。");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : プレイヤー" + currentPlayer + "番と1番の位置を入れ替えました。");
                swapLocate = playerProgress[1];
                playerProgress[1] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha3)) {
            if (currentPlayer == 2) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : 自分自身は選択できません。");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : プレイヤー" + currentPlayer + "番と2番の位置を入れ替えました。");
                swapLocate = playerProgress[2];
                playerProgress[2] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }

        if (currentPhase == 21 && Input.GetKeyDown(KeyCode.Alpha4)) {
            if (currentPlayer == 3) {
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : 自分自身は選択できません。");
            }else{
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " マス効果(5) : プレイヤー" + currentPlayer + "番と3番の位置を入れ替えました。");
                swapLocate = playerProgress[3];
                playerProgress[3] = tempSavePlayerProgress;
                tempSavePlayerProgress = swapLocate;
                currentPhase = 4;
            }
        }
            
        if (currentPhase == 4) {
            //マス効果を実行する。スコアを変更するときはovercome:0ならtemp = player + addScore、1ならtemp = temp + addScore

            // <<<< Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "マス効果が終了しました。スコアに変更があった場合は保存します...");
            if (tempSavePlayerProgress != 999) {
                playerProgress[currentPlayer] = tempSavePlayerProgress;
                //Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "マス効果が終了しました。位置、スコアに変更があった場合は保存します...");
            }
            if (tempSavePlayerScore != 999) {
                playerScore[currentPlayer] = tempSavePlayerScore;
                Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "スコアが変更されました。to" + playerScore[currentPlayer]);
            }
            currentPhase = 0;
            currentTurn++;
        }   
    }
}
