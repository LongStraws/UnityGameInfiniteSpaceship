using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettingForTestOfPrefs : MonoBehaviour
{
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
