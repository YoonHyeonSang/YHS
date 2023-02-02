using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallController : MonoBehaviour
{
    private float speed = 1f;
    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(-this.transform.up * this.speed * Time.deltaTime);
        if (this.transform.position.y <= -5.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bolt")
        {
            Destroy(this.gameObject);
        }
    }
}
