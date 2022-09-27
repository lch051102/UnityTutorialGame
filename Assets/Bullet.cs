using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletPower { get; private set; } //�Ѿ˼ӵ�

    [SerializeField] private float bulletDamage = 20f; //�Ѿ� ������

    public void SetSpeed(float _BulletSpeed)
    {
        bulletPower = _BulletSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletPower);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
