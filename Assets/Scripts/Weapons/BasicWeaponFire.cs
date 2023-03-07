using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float forceMagnitude = 5;

    private GameObject myProjectile;
    private Rigidbody2D rb;
    
    void Start()
    {
        myProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        rb = myProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.forward * forceMagnitude, ForceMode2D.Impulse);       
    }
}
