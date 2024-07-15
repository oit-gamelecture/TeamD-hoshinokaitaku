using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onepUIReverse : MonoBehaviour
{
    public RectTransform onereverse;

    int onepreverse;
    int onepreversepoint;

    // Start is called before the first frame update
    void Start()
    {
        onepreverse = 0;
        onepreversepoint = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (onepUIActive.onepturn == 1)
            {
                if (onepreverse == 0)
                {
                    onepreverse = 1;
                    onereverse.position += new Vector3(0, 200f, 0);
                }
            }
        }
        if (onepreverse == 1)
        {
            if (onepUIActive.onepturn == 2)
            {
                if (onepreversepoint == 1)
                {
                    onepreverse = 0;
                    onepreversepoint = 0;
                    onereverse.position += new Vector3(0, -200f, 0);
                }
            }

            if (onepUIActive.onepturn == 3)
            {
                onepreversepoint = 1;
            }
        }
    }
}
