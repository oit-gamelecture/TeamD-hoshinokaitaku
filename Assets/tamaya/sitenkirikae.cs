using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitenkirikae : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MapCamera;

    void Start()
    {
        MainCamera.SetActive(false);
        MapCamera.SetActive(true);
        //Debug.Log("sitenkirikae.cs has loaded");
    }

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
