using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(new Vector3(0, 0.025f, 0));
        if(this.transform.position.y >= 5.2f)
        {
            Destroy(this.gameObject);
        }
    }

    //�Ѿ˷� ���⸦ �������� �� �Ѿ� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
