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
        if (Input.GetKeyDown(KeyCode.A)) // D�L�[����A�L�[�ɕύX
        {
            Debug.Log("A key pressed");
            MainCamera.SetActive(true);
            MapCamera.SetActive(false);
        }
    }
}
