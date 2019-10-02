using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class ObjectState : MonoBehaviour
{
    public Color color = Color.white;
    public bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //Remove other object states
        foreach (ObjectState os in GetComponents<ObjectState>())
        {
            if (os != this)
            {
                Destroy(os);
            }
        }
        //Set the color of the object
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr)
        {
            sr.color = this.color;
        }
        SpriteShapeRenderer ssr = GetComponent<SpriteShapeRenderer>();
        if (ssr)
        {
            ssr.color = this.color;
        }
        //Set trigger status
        GetComponent<Collider2D>().isTrigger = isTrigger;
    }

    /// <summary>
    /// Injects this object state into the given object
    /// </summary>
    /// <param name="target"></param>
    public void inject(GameObject target)
    {
        ObjectState os = (ObjectState)target.AddComponent(this.GetType());
        os.color = this.color;
        os.isTrigger = this.isTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTrigger)
        {
            BlobUpdater blob = collision.gameObject.GetComponent<BlobUpdater>();
            if (blob)
            {
                blob.processCollidingObject(gameObject);
            }
        }
    }
}
