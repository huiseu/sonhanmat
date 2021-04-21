using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletController : MonoBehaviour
{
    private GameObject target; //Raycast�� ã�� ������Ʈ�� ����
    public GameObject RoulletManager; //�귿�� �ϼ������ִ� ������Ʈ
    //�귿 ������ ���༭ div�� angle�� �޾ƿ�
    float rotationSpeed; //ȸ���ӵ�
    bool act = true; //�Լ��� ���۽�ų ��
    public int div = 0;//���ҵ� ���� ��
    public int sector, order= 0; //���ҵ� ���� div��° ��
    //sector�� ���ۿ� ���� �����ϰ� order�� ��������
    public float angle = 0; //angle : ���°  div�� �ɸ��� + ����
    float rnd_round = 0;
    void Start()
    {
        act = true;
        div = RoulletManager.GetComponent<InstantiateScript>().div;
        //RoulletManager���� div���� �޾ƿ�
    }

    // Update is called once per frame
    void Update()
    {
        rnd_round = RoulletManager.GetComponent<InstantiateScript>().rnd_round;
        angle = RoulletManager.GetComponent<InstantiateScript>().angle;
        //RoulletManager���� angle���� �޾ƿ�
        transform.Rotate(0, 0, rotationSpeed);
        //rotationSpeed�� �ӵ��� ȸ��
        rotationSpeed *= 1-0.01f*div/(div* rnd_round + angle);
        //������ order*div��ŭ �߰��� �̵�(order : div�� ����)

        if (Input.GetMouseButtonDown(0)&&act)
        {
            target = null;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                target = hit.collider.gameObject;  //��Ʈ �� ���� ������Ʈ�� Ÿ������ ����
            }
            if (target == this.gameObject)
            {
                RoulletManager.GetComponent<InstantiateScript>().sector = order;
                //RoulletManager�� sector�� order������ ����
            }
                rotationSpeed = 3.6f; //ȸ���ӵ� 3.6��
                act = false; //���콺 Ŭ���� �Լ��� ���� �۵����ϰ� ����
        }
    }
}
