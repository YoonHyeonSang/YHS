using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigController : MonoBehaviour
{
    private float speed = 5f;
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

}
