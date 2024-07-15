using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class threepUISleep : MonoBehaviour
{
    public RectTransform threesleep;
    public RectTransform three2;

    int threepsleep;
    int threepsleeppoint;

    // Start is called before the first frame update
    void Start()
    {
        threepsleep = 0;
        threepsleeppoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (threepUIActive.threepturn == 3)
            {
                ++threepsleep;
                if (threepsleep == 1)
                {
                    threesleep.position += new Vector3(0, 200f, 0);
                }
                else if(threepsleep == 2)
                {
                    three2.position += new Vector3(0, 200f, 0);
                }
                else if(threepsleep >= 3)
                {
                    threepsleep = 2;
                }
            }
        }
        if(threepsleep >= 1)
        {
            if(threepUIActive.threepturn == 0)
            {
                if(threepsleeppoint == 1)
                {
                    threepsleeppoint = 0;
                    --threepsleep;
                    if(threepsleep == 0)
                    {
                        threesleep.position += new Vector3(0, -200f, 0);
                    }
                    else if(threepsleep == 1)
                    {
                        three2.position += new Vector3(0, -200f, 0);
                    }
                }
            }
            if(threepUIActive.threepturn == 1)
            {
                threepsleeppoint = 1;
            }
        }
    }
}
