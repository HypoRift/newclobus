using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerEnter : MonoBehaviour
{
    void OnCollisionEnter()
    {
        Invoke("e", 10.0f);
    }
    void e()
    {
        Destroy(gameObject);
    }
}
