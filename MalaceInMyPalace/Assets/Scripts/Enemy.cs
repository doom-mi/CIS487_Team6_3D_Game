using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float health = 100;    // Enemy Health
    public float speed = 10f;   // Enemy Movement Speed
    public int enemyValue = 20; // Coin when killed

    private Transform target;
    private int waypointIndex = 0;

    [Header("Audio")]
    public AudioClip enemyTakesDamage;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    public void TakeDamage(float amount){
        health -= amount;
        audioManager.PlaySFX(enemyTakesDamage);
        if (health <= 0){
            Die();
        }
    }

    void Die(){
        // Increase Player Money
        PlayerStats.Money += enemyValue;

        // Destroy Enemy Game Object
        Destroy(gameObject);
    }


    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
        transform.LookAt(target);
    }


    void EndPath(){
        PlayerStats.Lives--;
        audioManager.PlaySFX(audioManager.playerLoseLife);
        Destroy(gameObject);
    }


    /*
    I don't Know where this came from? - Brandon
    public static implicit operator Enemy(GameObject v)
    {
        throw new NotImplementedException();
    }
    */
}
