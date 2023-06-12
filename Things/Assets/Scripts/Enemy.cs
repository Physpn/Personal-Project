using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    public GameObject Player;
    public float damage = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Player = GameObject.Find("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerHP>().TakeDamage(damage);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(Player.transform.position); 
    }
}