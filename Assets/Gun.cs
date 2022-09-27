 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� �߻��
public class Gun : MonoBehaviour
{
    public Transform muuzle;
    public Bullet projectile;//����ü
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;

    public float nextShotTime; //�߻� ����
    
    public void Shoot()
    {
        Debug.Log("�Ѿ� ����");
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000f;
            Bullet _projectile = Instantiate(projectile, muuzle.position, muuzle.rotation);
            _projectile.SetSpeed(muzzleVelocity);
            
            Destroy(_projectile.gameObject, 5f);
        }
    }
}
