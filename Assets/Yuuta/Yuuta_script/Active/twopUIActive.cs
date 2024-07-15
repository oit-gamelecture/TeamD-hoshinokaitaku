using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class twopUIActive : MonoBehaviour
{
    public RectTransform twoposition;

    public static int twopturn;

    // Start is called before the first frame update
    void Start()
    {
        twopturn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (twopturn == 1)
            {
                twoposition.position += new Vector3(0, 100f, 0);
            }
            else if (twopturn == 2)
            {
                twoposition.position += new Vector3(0, -100f, 0);
            }
            ++twopturn;
            if(twopturn >= 4)
            {
                twopturn = 0;
            }
        }
    }
}
