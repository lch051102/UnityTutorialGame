using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("ATTACK"))
        {
            Debug.Log("�ǰ�");
            Destroy(collision.gameObject);
            
        }
    }
}
