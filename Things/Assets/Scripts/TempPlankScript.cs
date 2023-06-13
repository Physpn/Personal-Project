using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlankScript : MonoBehaviour
{
    float speed = 500;
    public float damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}
