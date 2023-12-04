using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private Transform target;

    public float speed = 50f;
    public GameObject hitEffect;

    public void setTarget(Transform _target){
        target = _target;
    }

    private void hitTarget(){
        GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // If bullet loses target, destroy bullet
        if (target == null) { Destroy(gameObject); return; }
    
        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame){
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);
    
    }
}
