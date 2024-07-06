using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControll : MonoBehaviour
{

    public int currentTurn = 0; //プレイヤーごとに遷移
    public int allowMoveTurn = 0;
    public int currentPhase = 0; //プレイヤー内のイベントごとに遷移
    public int allowMovePhase = 0;
    public bool winnedConfirmed = false;
    public int currentPlayer = 0; //現在プレイしているプレイヤー:0-3
    public static int requestDice = 0; // 1ならダイスをdiceRoll.csにリクエストする
    public int overcome = 0; // プレイヤーは0番マスを通過したか？

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
        Debug.Log("[MainControll] ゲームを開始します。");
        //a = PlayerPrefs.GetInt("dice");
        //Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {   
        if (currentPhase == 0) {
            tempSavePlayerProgress = 999;
            tempSavePlayerScore = 999;
            // 現在プレイしているプレイヤーをここで投げる
            currentPlayer = currentTurn % 4;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " プレイヤー" + currentPlayer + "番プレイヤーのターンです。");
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "サイコロを振ります。(requestDice = 1)");
            requestDice = 1;
            //PlayerPrefs.SetInt("diceRquester", requestDice);
            currentPhase = 1;
        }

        //ダイスの数が-1から1-6に変わったとき、フェイズ進行
        receivedDice = DiceRoll.diceResult;//PlayerPrefs.GetInt("dice");

        if (currentPhase == 1 && receivedDice != -1) {
            currentPhase = 2;
            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "進むためのサイコロが確定されました。: " + receivedDice + "");
            tempSavePlayerProgress = playerProgress[currentPlayer] + receivedDice;
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
                    //winFlag
                }else{
                    tempSavePlayerScore = playerScore[currentPlayer] + 1;
                    Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + " プレイヤー" + currentPlayer + "のスコアは" + playerScore[currentPlayer] + "でクリアではないので、代わりに" + tempSavePlayerScore + "点になりました。" );
                }
            }
            //マス効果を実行する。スコアを変更するときはovercome:0ならtemp = player + addScore、1ならtemp = temp + addScore

            Debug.Log("[MainControll] " + currentTurn + "/" + currentPhase + "マス効果が終了しました。スコアに変更があった場合は保存します...");
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
