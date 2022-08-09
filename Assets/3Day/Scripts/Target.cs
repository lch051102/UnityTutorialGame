using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public UIContoller uiContoller;
    public int CurrnetHealth = 20;

    private void Start()
    {
        //���ӿ�����Ʈ.Find�� ����ȭ�鿡 �����ϴ� ������Ʈ�� �̸����� ã�� ����̴�.
        //ã�� ������Ʈ ���ο� ����� �����ɴϴ�. ���࿡ ���ϴ� ����� ������ ������ ���ϴ�.
        uiContoller = GameObject.Find("Canvas").GetComponent<UIContoller>();
    }
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
