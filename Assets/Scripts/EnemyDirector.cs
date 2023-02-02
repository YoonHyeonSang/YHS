using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour
{
    public GameObject bigPrefab;
    public GameObject mediumPrefab;
    public GameObject smallPrefab;
    private float delta;
    void Start()
    {

    }

    void Update()
    {
        this.delta += Time.deltaTime;
        float ranT = Random.Range(0.5f, 2f);
        if(this.delta >= ranT)
        {
            float x = Random.Range(-2.3f, 2.3f);
            int e = Random.Range(0, 100);
            if(e<20)
            {
                var smallGo = Instantiate(this.smallPrefab);
                smallGo.transform.position = new Vector3(x, 6f, 0);
            }
            else if(e<60)
            {
                var mediumGo = Instantiate(this.mediumPrefab);
                mediumGo.transform.position = new Vector3(x, 6f, 0);
            }
            else if(e<100)
            {
                var bigGo = Instantiate(this.bigPrefab);
                bigGo.transform.position = new Vector3(x, 6f, 0);
            }
            this.delta = 0;
        }

    }
}
