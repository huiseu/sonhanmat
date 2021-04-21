using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasController : MonoBehaviour
{
    public GameObject[] canvas;
    //ĵ������ ����
    public int canvas_order;
    //ĵ������ ������ ����
    public int canvas_num;
    //ĵ������ �� ����
    public int div = 8;
    public GameObject RoulletManager;
    // Start is called before the first frame update
    void Start()
    {
       div = GameManager.numeber;
       canvas_order = 0; //�ʱⰪ ����
       canvas_num = 2;
       Canvas_changed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Canvas_changed() //����ĵ������ �Ѿ�� �Լ�
    {
        if (canvas_order <= canvas_num) canvas_order++; //���� ĵ������
        for (int i = 1; i <= canvas_num; i++)
        {
            if (canvas_order == i)
            {
                for (int n = 0; n < canvas_num; n++)
                { canvas[n].SetActive(false); } //ĵ���� �����
                canvas[i - 1].SetActive(true);  //ĵ���� �����
            }
            RoulletManager.GetComponent<InstantiateScript>().div = div;
        } 
        
    }
    public void Canvas_back() //������
    {

    }

    public void Canvas_Reset()
    {
        SceneManager.LoadScene("SecondScene");
    }
}
