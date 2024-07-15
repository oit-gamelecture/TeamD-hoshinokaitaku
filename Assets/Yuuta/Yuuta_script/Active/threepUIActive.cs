using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class threepUIActive : MonoBehaviour
{
    public RectTransform threeposition;

    public static int threepturn;

    // Start is called before the first frame update
    void Start()
    {
        threepturn = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (threepturn == 2)
            {
                threeposition.position += new Vector3(0, 100f, 0);
            }else if(threepturn == 3)
            {
                threeposition.position += new Vector3(0, -100f, 0);
            }
            ++threepturn;
                if(threepturn >= 4)
            {
                threepturn = 0;
            }
        }
    }
}
