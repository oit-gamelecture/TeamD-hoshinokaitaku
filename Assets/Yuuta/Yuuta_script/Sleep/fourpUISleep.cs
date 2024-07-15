using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourpUISleep : MonoBehaviour
{
    public RectTransform foursleep;
    public RectTransform four2;

    int fourpsleep;
    int fourpsleeppoint;

    // Start is called before the first frame update
    void Start()
    {
        fourpsleep = 0;
        fourpsleeppoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(fourpsleep < 0)
        {
            fourpsleep = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(fourpUIActive.fourpturn == 4)
            {
                ++fourpsleep;
                if(fourpsleep == 1)
                {
                    foursleep.position += new Vector3(0, 200f, 0);
                }
                else if(fourpsleep == 2)
                {
                    four2.position += new Vector3(0, 200f, 0);
                }
            }
        }
        if(fourpsleep >= 1)
        {
            if(fourpUIActive.fourpturn == 1)
            {
                if(fourpsleeppoint == 1)
                {
                    fourpsleeppoint = 0;
                    --fourpsleep;
                    if(fourpsleep == 0)
                    {
                        foursleep.position += new Vector3(0, -200f, 0);
                    }
                    else if(fourpsleep == 1)
                    {
                        four2.position += new Vector3(0, -200f, 0);
                    }
                }
            }
            if(fourpUIActive.fourpturn == 2)
            {
                fourpsleeppoint = 1;
            }
        }
    }
}
