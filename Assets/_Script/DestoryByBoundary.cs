﻿using UnityEngine;
using System.Collections;

public class DestoryByBoundary : MonoBehaviour
{

    // Use this for initialization
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
	
	
