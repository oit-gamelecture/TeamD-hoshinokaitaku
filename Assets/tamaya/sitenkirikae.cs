using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitenkirikae : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MapCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S key pressed");
            MainCamera.SetActive(false);
            MapCamera.SetActive(true);
        }
    }
}
