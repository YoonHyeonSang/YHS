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
        var dirx = Input.GetAxisRaw("Horizontal");  //��ȯŸ�� float
        var diry = Input.GetAxisRaw("Vertical");  //��ȯŸ�� float
        var dir = new Vector3(dirx, diry, 0);

        //�̵� : ����*�ӵ�*�ð�
        this.transform.Translate(dir.normalized * 4f * Time.deltaTime);

        //�����̽��ٸ� ������ �Ѿ��� �����ؼ� �߻��ؾ��Ѵ�
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
    //����� �ε����� ��
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
    //�Ѿ� ������ �ڷ�ƾ
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(this.reload);
        this.isReload = false;
    }
}
