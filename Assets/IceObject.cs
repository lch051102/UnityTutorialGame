using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceObject : MonoBehaviour
{
   
    void Update()
    {
        IceMove();
    }
    private void IceMove()
    {
        this.transform.Translate(new Vector3(0f, 0f, 0.5f));
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹");
        if (other.gameObject.name == "Penguin")
            Destroy(other.gameObject);
    }

}
