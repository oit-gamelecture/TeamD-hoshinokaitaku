using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitenkrikae2 : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MapCamera;

    void Start()
    {
        //Debug.Log("sitenkirikae.cs has loaded");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // DキーからAキーに変更
        {
            Debug.Log("A key pressed");
            MainCamera.SetActive(true);
            MapCamera.SetActive(false);
        }
    }
}
