using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassWord_Box : MonoBehaviour
{
    GameObject player;

    //�켱���� ����
    public int red = 1;
    public int blue = 2;
    public int yellow = 3;
    public int green = 4;

    //�佺����üũ
    public int PassWord_Check = 1;
    public int Pass_Check = 4;

    //���
    public static bool Pass = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        isError();

        if(PassWord_Check >= Pass_Check)
        {
            if (!Pass)
            {
                Pass = true;
                PassWord_Check = 1;
                Game_Manager.instance.Cursor_LockOn = true;
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Red()
    {
        if(red == PassWord_Check)
        {
            PassWord_Check++;
        }
        else
        {
            PassWord_Check = 1;
        }
    }

    public void Blue()
    {
        if(blue == PassWord_Check)
        {
            PassWord_Check++;
        }
        else
        {
            PassWord_Check = 1;
        }
    }

    public void Yellow()
    {
        if (yellow == PassWord_Check)
        {
            PassWord_Check++;
        }
        else
        {
            PassWord_Check = 1;
        }
    }

    public void Green()
    {
        if (green == PassWord_Check)
        {
            PassWord_Check++;
        }
        else
        {
            PassWord_Check = 1;
        }

    }

    private void isError()
    {
        if (red == blue || red == yellow || red == green)
        {
            Debug.LogError("������ �����ϴ�.");

        }
        else if (blue == yellow || blue == green)
        {
            Debug.LogError("������ �����ϴ�.");
        }
        else if (yellow == green)
        {
            Debug.LogError("������ �����ϴ�.");
        }


        if(red < 0 || red >= 5)
        {
            Debug.LogError("�ߺ������ʴ� 0�̻� 4������ ���� �־��ּ���!");
        }
        else if (blue < 0 || blue >= 5)
        {
            Debug.LogError("�ߺ������ʴ� 1�̻� 4������ ���� �־��ּ���!");
        }
        else if (yellow < 0 || yellow >= 5)
        {
            Debug.LogError("�ߺ������ʴ� 1�̻� 4������ ���� �־��ּ���!");
        }
        else if (green < 0 || green >= 5)
        {
            Debug.LogError("�ߺ������ʴ� 1�̻� 4������ ���� �־��ּ���!");
        }

    }
}
