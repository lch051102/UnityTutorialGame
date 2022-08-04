using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunState
    {
        //�Ѿ��� ���ִ°��, ����ִ� �ܿ�, �������� �ʿ��� ���,
        Ready, 
        Emtpy, 
        Reloading
    }

    //get�� �ٸ� ����ڰ� ���� �������� ����.
    //set ������ ���� �Ҵ��Ҽ� ����.
    public GunState gunState { get; private set; }

    public AudioSource audioSource; //�Ҹ��� �����ϴ� ���
    public AudioClip gunFireSound; //�Ҹ��� ���� Ĩ

    public LineRenderer bulletLine; //ȭ�鿡 ���� �׸��� ���
    public Transform gunFirePosition; //��ġ�� �����ϴ� ���
    
    public float timenow;
    
    //�ѿ��� ���� ����
    public float lastFireTime;// ���� ���������� �߻��� ����
    public float fireDelayTime =0.12f; //���� �߻��� �����ð� (�����)

    //�� ���� ����
    public float damage = 10f;
    public float distance;
    public int ammoToFill; //���� �Ѿ� ���

    public int ammoReMain; //���� ��ü �Ѿ� 270
    public int magazineSize; //źâũ�� 30
    public int magazineAmmo; //źâ�� ���� �Ѿ� 30
    public float reloadTime; //�������� �ɸ��� �ð�

    private void Start()
    {
        //�Ҹ��� �����ϴ� ����� ������
        audioSource = GetComponent<AudioSource>();
        bulletLine = GetComponent<LineRenderer>();
        //�� ���¸� �غ���·� ����
        gunState = GunState.Ready;
    }
    private void Update()
    {
        timenow = Time.time;
        //���콺 Ŭ��
        if (Input.GetButton("Fire1"))
        {
            if (gunState == GunState.Ready && Time.time >= lastFireTime + fireDelayTime)
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
                magazineAmmo --;
                if(magazineAmmo<=0)
                {
                    gunState = GunState.Emtpy;
                }
            }
        }
        //������ �ڵ�
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("������ ��ư ����");
            if(gunState ==GunState.Reloading || ammoReMain <= 0
                || magazineAmmo >= magazineSize)
            {
                return;
            }
            StartCoroutine(ReloadingSystem());
        }
    }

    public IEnumerator ReloadingSystem()
    {
        //������
        gunState = GunState.Reloading;
        yield return new WaitForSeconds(reloadTime);
        //var = �ڿ� ���� ���� ���� ���¸� ��ȯ��;
         ammoToFill = Mathf.Clamp(magazineSize - magazineAmmo,
            0, ammoReMain);
        magazineAmmo += ammoToFill;
        ammoReMain -= ammoToFill;

        gunState = GunState.Ready;


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
