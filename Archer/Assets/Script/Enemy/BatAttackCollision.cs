using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<PlayerAbility>().TakeDamage();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
