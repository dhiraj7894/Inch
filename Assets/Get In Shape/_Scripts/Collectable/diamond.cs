﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))        {
            Debug.Log(this.transform.name + "  :  Diamond");
            Destroy(this.gameObject);
        }
    }
}
