using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MojiControll : MonoBehaviour
{
    [SerializeField] private TMP_Text oneptext;
    [SerializeField] private TMP_Text twoptext;
    [SerializeField] private TMP_Text threeptext;
    [SerializeField] private TMP_Text fourptext;
    [SerializeField] private TMP_Text Undertext;

    public GameObject MojiCon;
    private MainControll MC;

    int OneMoji;
    int TwoMoji;
    int ThreeMoji;
    int FourMoji;
    string UnderMoji;

    // Start is called before the first frame update
    void Start()
    {
        MojiCon = GameObject.Find("MainControll");
        MC = MojiCon.GetComponent<MainControll>();
    }

    // Update is called once per frame
    void Update()
    {
        OneMoji = MC.playerScore[0];
        TwoMoji = MC.playerScore[1];
        ThreeMoji = MC.playerScore[2];
        FourMoji = MC.playerScore[3];
        UnderMoji = MC.showMessage;

        if (MC.wonPlayer == -1)
        {
            oneptext.text = "プレイヤー１\n         " + OneMoji + "pt";
            twoptext.text = "プレイヤー２\n         " + TwoMoji + "pt";
            threeptext.text = "プレイヤー３\n         " + ThreeMoji + "pt";
            fourptext.text = "プレイヤー４\n         " + FourMoji + "pt";
        }
        Undertext.text = UnderMoji;
    }
}
