using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public NavMeshAgent pathFinder; //��ΰ�� AI ������Ʈ
    public Transform playerTr;
    public Transform MonsterTr;
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
