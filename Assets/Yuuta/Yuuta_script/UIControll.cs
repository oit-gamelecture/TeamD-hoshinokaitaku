using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    public RectTransform OA;
    public RectTransform OR;
    public RectTransform OD;
    public RectTransform OS;

    public RectTransform TwA;
    public RectTransform TwR;
    public RectTransform TwD;
    public RectTransform TwS;

    public RectTransform ThA;
    public RectTransform ThR;
    public RectTransform ThD;
    public RectTransform ThS;

    public RectTransform FA;
    public RectTransform FR;
    public RectTransform FD;
    public RectTransform FS;

    public GameObject qawsedrftgyhujikolp;
    private MainControll UIS;

    int Turn;
    int Turn2;

    int OpS;
    int OpS2;

    int TwpS;
    int TwpS2;

    int ThpS;
    int ThpS2;

    int FpS;
    int FpS2;

    // Start is called before the first frame update
    void Start()
    {
        Turn2 = -1;
        OpS2 = 0;
        TwpS2 = 0;
        ThpS2 = 0;
        FpS2 = 0;

        qawsedrftgyhujikolp = GameObject.Find("MainControll");
        UIS = qawsedrftgyhujikolp.GetComponent<MainControll>();
    }

    // Update is called once per frame
    void Update()
    {
        Turn = UIS.currentPlayer;
        OpS = UIS.playerStatus[0];
        TwpS = UIS.playerStatus[1];
        ThpS = UIS.playerStatus[2];
        FpS = UIS.playerStatus[3];

        if (Turn != Turn2)
        {
            if (Turn == 0)
            {
                OA.position += new Vector3(0, 100f, 0);
                FA.position += new Vector3(0, -100f, 0);
            }
            else if (Turn == 1)
            {
                TwA.position += new Vector3(0, 100f, 0);
                OA.position += new Vector3(0, -100f, 0);
            }
            else if (Turn == 2)
            {
                ThA.position += new Vector3(0, 100f, 0);
                TwA.position += new Vector3(0, -100f, 0);
            }
            else if (Turn == 3)
            {
                FA.position += new Vector3(0, 100f, 0);
                ThA.position += new Vector3(0, -100f, 0);
            }
            Turn2 = Turn;
        }

        if (OpS != OpS2)
        {
            if(OpS2 == 1)
            {
                OR.position += new Vector3(0, -200f, 0);
            }
            else if(OpS2 == 2)
            {
                OD.position += new Vector3(0, -200f, 0);
            }
            else if(OpS2 == 3)
            {
                OS.position += new Vector3(0, -200f, 0);
            }

            if (OpS == 1)
            {
                OR.position += new Vector3(0, 200f, 0);
            }
            else if (OpS == 2)
            {
                OD.position += new Vector3(0, 200f, 0);
            }
            else if (OpS == 3)
            {
                OS.position += new Vector3(0, 200f, 0);
            }
            OpS2 = OpS;
        }

        if(TwpS != TwpS2)
        {
            if (TwpS2 == 1)
            {
                TwR.position += new Vector3(0, -200f, 0);
            }
            else if (TwpS2 == 2)
            {
                TwD.position += new Vector3(0, -200f, 0);
            }
            else if (TwpS2 == 3)
            {
                TwS.position += new Vector3(0, -200f, 0);
            }

            if (TwpS == 1)
            {
                TwR.position += new Vector3(0, 200f, 0);
            }
            else if(TwpS == 2)
            {
                TwD.position += new Vector3(0, 200f, 0);
            }
            else if (TwpS == 3)
            {
                TwS.position += new Vector3(0, 200f, 0);
            }
            TwpS2 = TwpS;
        }

        if(ThpS != ThpS2)
        {
            if(ThpS2 == 1)
            {
                ThR.position += new Vector3(0, -200f, 0);
            }
            else if(ThpS == 2)
            {
                ThD.position += new Vector3(0, -200f, 0);
            }
            else if(ThpS == 3)
            {
                ThS.position += new Vector3(0, -200f, 0);
            }

            if(ThpS == 1)
            {
                ThR.position += new Vector3(0, 200f, 0);
            }
            else if(ThpS == 2)
            {
                ThD.position += new Vector3(0, 200f, 0);
            }
            else if(ThpS == 3)
            {
                ThS.position += new Vector3(0, 200f, 0);
            }
            ThpS2 = ThpS;
        }

        if(FpS != FpS2)
        {
            if (FpS2 == 1)
            {
                FR.position += new Vector3(0, -200f, 0);
            }
            else if (FpS2 == 2)
            {
                FD.position += new Vector3(0, -200f, 0);
            }
            else if (FpS2 == 3)
            {
                FS.position += new Vector3(0, -200f, 0);
            }

            if (FpS == 1)
            {
                FR.position += new Vector3(0, 200f, 0);
            }
            else if (FpS == 2)
            {
                FD.position += new Vector3(0, 200f, 0);
            }
            else if (FpS == 3)
            {
                FS.position += new Vector3(0, 200f, 0);
            }
            FpS2 = FpS;
        }
    }
}
