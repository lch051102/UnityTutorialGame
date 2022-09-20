using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� �߻��
public class Gun : MonoBehaviour
{
    public Transform muuzle;
    public Projectile projectile;//����ü
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;

    public float nextShotTime; //�߻� ����
    
    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000f;
            Projectile _projectile = Instantiate(projectile, muuzle.position, muuzle.rotation);
            _projectile.SetSpeed(muzzleVelocity);
        }
    }
}
