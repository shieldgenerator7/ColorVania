using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobShooter : MonoBehaviour
{
    public GameObject blobPrefab;
    public float blobMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireBlob();
        }
    }

    private void fireBlob()
    {
        GameObject blob = Instantiate(blobPrefab);
        blob.transform.position = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        blob.transform.up = mousePos - (Vector2)transform.position;
        blob.GetComponent<Rigidbody2D>().velocity = blob.transform.up * blobMoveSpeed;
    }
}
