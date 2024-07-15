using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartmasuInvisible : MonoBehaviour
{
    [SerializeField] private Renderer startmasuhyouji;

    // Start is called before the first frame update
    void Start()
    {
        startmasuhyouji.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
