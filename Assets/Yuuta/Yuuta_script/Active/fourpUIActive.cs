using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourpUIActive : MonoBehaviour
{
    public RectTransform fourposition;

    public static int fourpturn;

    // Start is called before the first frame update
    void Start()
    {
        fourpturn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (fourpturn == 3)
            {
                fourposition.position += new Vector3(0, 100f, 0);
            }
            else if (fourpturn == 4)
            {
                fourpturn = 0;
                fourposition.position += new Vector3(0, -100f, 0);
            }
            ++fourpturn;
        }
    }
}
