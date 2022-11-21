using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectily : MonoBehaviour
{
    public float speed = 20f;
    public Vector3 direction = Vector3.up;
    public System.Action destroyed;
    public new BoxCollider2D collider { get; private set; }

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnDestroy()
    {
        if (destroyed != null)
        {
            destroyed.Invoke() ;
        }
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void CheckCollision(Collider2D other)
    {
        Bunker bunker = other.gameObject.GetComponent<Bunker>();

        if (bunker == null || bunker.CheckCollision(collider, transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }



}



