using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
    //�ؽ�Ʈ �ڽ��� �������ִ� ��ũ��Ʈ
{
    bool act = true; // �ڽ��� �������ִ� �Լ��� ���������� ����
    int div; // �귿�� div�����
    int rnd_round;
    float rotationSpeed, angle;
    //rotationSpeed : ȸ�����ۼӵ� , angle : ���°  div�� �ɸ��� + ����
    public GameObject RoulletManager;//�귿�� �ϼ������ִ� ������Ʈ 
    //�귿 ������ ���༭ div�� angle�� �޾ƿ�
    // Start is called before the first frame update
    void Start()
    {
        div = RoulletManager.GetComponent<InstantiateScript>().div;
        //RoulletManager���� div���� �޾ƿ�
    }

    // Update is called once per frame
    void Update()
    {
        rnd_round = RoulletManager.GetComponent<InstantiateScript>().rnd_round;
        angle = RoulletManager.GetComponent<InstantiateScript>().angle;
        //RoulletManager���� angle���� �޾ƿ�
        transform.RotateAround(new Vector3(360, 730, 0), Vector3.forward, rotationSpeed);
        //(360, 730, 0)�� �߽����� forward���⿡ rotationSpeed�� �ӵ��� ����;
        rotationSpeed *= 1 - 0.01f * div / (div * rnd_round + angle);
        //������ order*div��ŭ �߰��� �̵�(order : div�� ����)

        if (Input.GetMouseButtonDown(0) && act)
            //���콺 ���ʹ�ư�� ������ act�� true�϶�
        {
            rotationSpeed = 3.6f;
            act = false; // ��ư�� ������ �� �Լ��� �۵� ���ϰ� ����
        }
    }
}
