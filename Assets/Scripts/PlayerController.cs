using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Coroutine routine;
    public BoltController boltPrefab;
    private float reload = 0.3f;
    private bool isReload;

    private GameObject enemyPrefab;
    private float delta;

    void Start()
    {

    }

    void Update()
    {
        //Input.GetAxis -1, -0.9, ... 0, 0.1, ... , 1
        var dirx = Input.GetAxisRaw("Horizontal");  //반환타입 float
        var diry = Input.GetAxisRaw("Vertical");  //반환타입 float
        var dir = new Vector3(dirx, diry, 0);

        //이동 : 방향*속도*시간
        this.transform.Translate(dir.normalized * 4f * Time.deltaTime);

        //스페이스바를 누르면 총알을 생성해서 발사해야한다
        if(Input.GetKey(KeyCode.Space))
        {
            if(!isReload)
            {
                var boltGo = Instantiate(boltPrefab);
                boltGo.transform.position = this.transform.position;
                this.isReload = true;
                this.routine = this.StartCoroutine(this.Reload());
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                this.StopCoroutine(this.routine);
            }
        }
    }
    //적기와 부딪혔을 때
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
    private void Blast()
    {

    }
    //총알 재장전 코루틴
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(this.reload);
        this.isReload = false;
    }
}
