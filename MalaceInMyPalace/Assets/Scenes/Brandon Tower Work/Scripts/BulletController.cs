using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BulletController : MonoBehaviour {
    // Projectile Target
    private Transform target;

    // Projectile Movement Speed
    public float speed = 50f;

    // Projectile AOE Radius (Don't Change Here)
    private float aoe = 0;
    // Arrow Prefab = 0
    // Cannon Prefab = 2
    
    private float damage = 10;
    // Arrow Prefab = 20
    // Cannon prefab = 15

    // Hit Effect Prefab Linker
    public GameObject hitEffect;


    // Set Bullet Current Target
    public void setTarget(Transform _target){
        target = _target;
    }

    public void setAoe(float _aoe){
        aoe = _aoe;
    }

    public void setDamage(float _damage){
        damage = _damage;
    }

    void Update() {
        // If bullet loses target, destroy bullet
        if (target == null) { Destroy(gameObject); return; }
    
        // Calculate Bullet Movement Distance This Frame
        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        // If Bullet would pass through target next frame, Hit Target
        if (dir.magnitude <= distThisFrame){
            hitTarget();
            return;
        }

        // Move Projectile
        transform.Translate(dir.normalized * distThisFrame, Space.World);
        // Orient Projectile
        transform.LookAt(target);

    }



    private void hitTarget(){
        // Particle Effects
        GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);


        if (aoe > 0f) {
            Explode();
        } else {
            // Damage
            Damage(target);
        }

        // Destroy Projectile
        Destroy(gameObject);

    }

    void Explode(){
        // Get Colliders in Radius
        Collider[] hitTargets = Physics.OverlapSphere(transform.position, aoe);
        foreach (Collider hitTarget in hitTargets){
            if (hitTarget.tag == "Enemy"){
                Damage(hitTarget.transform);
            }
        }
    }


    void Damage(Transform enemyGO){
        Enemy enemy = enemyGO.GetComponent<Enemy>();

        if (enemy != null){
            enemy.TakeDamage(damage);
        }

    }


}
