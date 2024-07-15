using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class therrpUIReverse : MonoBehaviour
{
    public RectTransform threereverse;

    int threepreverse;
    int threepreversepoint;

    // Start is called before the first frame update
    void Start()
    {
        threepreverse = 0;
        threepreversepoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (threepUIActive.threepturn == 3)
            {
                if (threepreverse == 0)
                {
                    threepreverse = 1;
                    threereverse.position += new Vector3(0, 200f, 0);
                }
            }
        }
            if(threepreverse == 1)
            {
                if(threepUIActive.threepturn == 0)
                {
                    if(threepreversepoint == 1)
                    {
                        threepreverse = 0;
                        threepreversepoint = 0;
                        threereverse.position += new Vector3(0, -200f, 0);
                    }
                }
                if(threepUIActive.threepturn == 1)
                {
                    threepreversepoint = 1;
                }
            }
        }
        
    }

