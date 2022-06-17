using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Instantiate(other.transform.gameObject);
            Instantiate(other.transform.gameObject);
        }
    }
}
