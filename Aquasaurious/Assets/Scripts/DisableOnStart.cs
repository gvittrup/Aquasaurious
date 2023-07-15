using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

}
