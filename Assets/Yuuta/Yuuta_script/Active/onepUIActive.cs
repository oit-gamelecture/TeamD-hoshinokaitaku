using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onepUIActive : MonoBehaviour
{
    public RectTransform oneposition;

    public static int onepturn;

    // Start is called before the first frame update
    void Start()
    {
        onepturn = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (onepturn == 0)
            {
                oneposition.position += new Vector3(0, 100f, 0);

            }
            else if (onepturn == 1)
            {
                oneposition.position += new Vector3(0, -100f, 0);
            }
            ++onepturn;
            if(onepturn >= 4)
            {
                onepturn = 0;
            } 
        }
    }
}
