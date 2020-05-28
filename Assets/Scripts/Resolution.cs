using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{    void Awake()
     {
        Screen.SetResolution(540, 960, false);
     }
}
