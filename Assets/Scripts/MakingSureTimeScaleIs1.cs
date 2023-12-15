using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingSureTimeScaleIs1 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(gameObject == enabled)
        {
            Time.timeScale = 1f;
        }
    }
}
