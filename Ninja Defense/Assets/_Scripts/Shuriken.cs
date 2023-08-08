using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private void Start()
    {
        Invoke("DestroyShuriken", 2.5f);
    }
    public void FixedUpdate()
    {
        transform.Translate(new Vector2(0f, speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IlifeSystem>() != null)
        {
            collision.gameObject.GetComponent<IlifeSystem>().TakeDamage(damage);
            DestroyShuriken();
        }
    }

    private void DestroyShuriken()
    {
        Destroy(this.gameObject);
    }
}
