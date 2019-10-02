using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobUpdater : MonoBehaviour
{
    public ObjectState payload;

    private Collider2D coll2d;

    private void Start()
    {
        coll2d = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        processCollidingObject(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        processCollidingObject(collision.gameObject);
    }

    public void processCollidingObject(GameObject other)
    {
        payload.inject(other);
        Destroy(gameObject);
    }
}
