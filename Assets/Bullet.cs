using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float disThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= disThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * disThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
