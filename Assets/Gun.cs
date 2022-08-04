using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource audioSource; //�Ҹ��� �����ϴ� ���
    public AudioClip gunFireSound; //�Ҹ��� ���� Ĩ

    public LineRenderer bulletLine; //ȭ�鿡 ���� �׸��� ���
    public Transform gunFirePosition; //��ġ�� �����ϴ� ���
    public float distance;

    public float timenow;
    public float lastFireTime;// ���� ���������� �߻��� ����
    public float fireDelayTime =0.12f; //���� �߻��� �����ð� (�����)

    private void Start()
    {
        //�Ҹ��� �����ϴ� ����� ������
        audioSource = GetComponent<AudioSource>();
        bulletLine = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        timenow = Time.time;
        //���콺 Ŭ��
        if (Input.GetButton("Fire1"))
        {

            if (Time.time >= lastFireTime + fireDelayTime)
            {
                RaycastHit hit;

                if (Physics.Raycast(gunFirePosition.position, gunFirePosition.forward * distance, out hit))
                {
                    Debug.Log(hit.collider.name);
                }
                Debug.DrawRay(gunFirePosition.position, gunFirePosition.forward * distance,
                    Color.red);

                StartCoroutine(ShotEffect(hit.point));
                lastFireTime = Time.time;
            }
        }
    }

 
    public IEnumerator ShotEffect(Vector3 hitPotion)
    {
        bulletLine.enabled = true;
        bulletLine.SetPosition(0, gunFirePosition.position);
        bulletLine.SetPosition(1, hitPotion);
        audioSource.PlayOneShot(gunFireSound);
        yield return new WaitForSeconds(0.03f);

        bulletLine.enabled = false;
    }
}
