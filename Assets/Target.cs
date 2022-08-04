using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public UIContoller uiContoller;
    public int CurrnetHealth = 20;

    //���̽� �������� ������ ����
    public void Damage(int damageAmount)
    {
        CurrnetHealth -= damageAmount;
        if(CurrnetHealth<=0)
        {
            uiContoller.UpdateScore(10);
            Destroy(this.gameObject);
        }
    }
}
