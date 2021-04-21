using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    public GameObject[] prefab_24; //�������� ����
    public GameObject[] prefab_35; //�������� ����
    int order = 0;  //������ ���ҵ� ���� ���ۼ���
    int bt = 0;  //�귿�� �����ϴ� ��ä���� ��
    public int div, sector = 0; //div : �� ������ ���� ��
    //sector : ���° �鿡 �ɸ���
    public float rnd, angle = 0; //rnd 0�� 1������ float�� ����
    //angle : ���° �鿡 �ɸ��� + ����(sector + rnd - 1)
    public int rnd_round;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] prefab_24 = new GameObject[8];
        //�������� ������ ������Ʈ ����
        GameObject[] prefab_35 = new GameObject[7];
        //�������� ������ ������Ʈ ����
        rnd = Random.Range(1.000f, 0.000f);
        //rnd 0�� 1������ float�� ��������
        rnd_round = Random.Range(0, 4);

    }

    // Update is called once per frame
    void Update()
    {
        angle = sector + rnd - 1;
 
        if (div == 5 || div == 7)
            {
                for (int i = 0; i < prefab_24.Length; i++)
                    prefab_24[i].SetActive(false);
                for (order = 1; order <= div; order++)
                { 
                    for (; bt < 35 / div * order; bt++)
                    {
                        GameObject.Find("Roullet" + order.ToString() + "_35").GetComponent<RouletController>().order = order;
                        //Roullet1���� Roulletdiv(div�� ���)���� order������ ����
                        Instantiate(prefab_35[order - 1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -10.28571f * bt));
                        //-10.28571f 35�п� 360��
                        //35�п��� �����Ͽ� �귿�� ����
                    }
                }
            }
        else{
                for (int i = 0; i < prefab_35.Length; i++)
                    prefab_35[i].SetActive(false);
                for (order = 1; order <= div; order++)
                {
                    for (; bt < 24 / div * order; bt++)
                    {
                        GameObject.Find("Roullet" + order.ToString() + "_24").GetComponent<RouletController>().order = order;
                        //Roullet1_24���� Roulletdiv_24(div�� ���)���� order������ ����
                        Instantiate(prefab_24[order - 1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -15.0f * bt));
                        //24�п��� �����Ͽ� �귿�� ����
                    }
                }
            }
        
    }
}
