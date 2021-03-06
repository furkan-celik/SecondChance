﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletObj bulletInfo;

    private void OnEnable()
    {
        GetComponent<MeshFilter>().mesh = bulletInfo.mesh;
        GetComponent<Rigidbody>().WakeUp();
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(transform.forward * 4000, ForceMode.Force);
    }
    private void OnDisable()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().Sleep();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<AgentController>().TakeDamage(bulletInfo.damage);
            Lean.Pool.LeanPool.Despawn(this);
        }
    }
}
