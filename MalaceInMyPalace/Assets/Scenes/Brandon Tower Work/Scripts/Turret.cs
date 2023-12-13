using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Health;
using Core.Utilities;
using TowerDefense.Affectors;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{

    public Renderer rend;

    [Header("Unity Setup Fields")]
    private Transform target;
    public Transform partToRotate;
    private float turnSpeed = 10f;
    private float cooldown = 0f;
    private bool toggleRadius = true;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Attributes")]
    public float fireRate = 1f;
    public float range = 2f;
    public float AOE = 0;
    public float damage = 10;
    public string enemyTag = "Enemy";
    
    [Header("Audio")]
    public AudioClip towerSound;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start(){
        rend = GetComponentInChildren<MeshRenderer>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject furthestEnemy = null; //(Enemy)enemies[0]
        float shortestDistance = Mathf.Infinity; //Vector3.Distance(transform.position, enemies[0].transform.position)

        foreach (GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                furthestEnemy = enemy;
            }
        }


        // Target Lock On
        if (furthestEnemy != null && shortestDistance <= range){
            target = furthestEnemy.transform;
        } else {
            target = null;
        }

    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            if (toggleRadius == true){
                toggleRadius = false;
                rend.enabled = false;
                Debug.Log("Toggle Off");
            } else if (toggleRadius == false){
                toggleRadius = true;
                rend.enabled = true;
                Debug.Log("Toggle On");
            }
        }

        if (target == null) { return; }


        //Directional Lock On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);


        if (cooldown <= 0f){
            Attack();
            cooldown = 1f / fireRate;
        }

        cooldown -= Time.deltaTime;

    }


    void Attack(){
        //Debug.DrawLine(transform.position, target.transform.position, Color.red, 1f);
        audioManager.PlaySFX(towerSound);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletController bullet = bulletGO.GetComponent<BulletController>();

        if (bullet != null){
            bullet.setTarget(target);
            bullet.setAoe(AOE);
            bullet.setDamage(damage);
        }
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
