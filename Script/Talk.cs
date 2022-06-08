using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    public GameObject Talk_Panel;

    public Text CharSaying;

    public int page = 0;

    private void Update()
    {
        if (Talk_Panel.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Talk_Panel.SetActive(false);
                page = 0;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                page++;
                Talk_Panel.SetActive(true);
                TalkText();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Talk_Panel.activeSelf == true)
            {
                    Talk_Panel.SetActive(false);
                    page = 0;
            }
        }
    }


    private void TalkText()
    {
        if (this.gameObject.CompareTag("SpringBook"))
        {
            CharSaying.text = "�ƹ������� �׸� �׸��̴�." + "\n" + "�׸������� �������� �Ǳ� �ѽð����� �����̾��� �� ����." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
        }
        if (this.gameObject.CompareTag("SummerBook"))
        {
            CharSaying.text = "������ �Ƹ��ٿ� ������ �ٴ��̴�." + "\n" + "�ذ� ���� �ð��� �����ε��ϴ�." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
        }
        if (this.gameObject.CompareTag("AutumnBook"))
        {
            CharSaying.text = "��� ���⿣ ������ ��ó�� ��������" + "\n" + "�ذ��ߴ� ��ħ�� ������ ���̶�� �����Ͱ���." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
        }
        if (this.gameObject.CompareTag("WinterBook"))
        {
            CharSaying.text = "ƼŸ�������� �ܿ����� ��ȸ �̶�� �׸��ε��ϴ�." + "\n" + "�ƹ��� ���� ƼŸ�Ӱ� ���� ���������... �׷��ٰ��Ѵ�." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
        }
        if (this.gameObject.CompareTag("Memo"))
        {
            CharSaying.text = "��������" + "\n" + "ƼŸ���� �ð��� 4�ú���..." + "\n" + "��� �����ִ�." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
        }

        if (this.gameObject.CompareTag("Item"))
        {
            if (page == 1 || page == 0)
                CharSaying.text = "���� �� �޸� �ΰ� ����." + "\n" + "�ƹ��������� �׻� ���� �� ���ִ� " + "\n" + "���� �Ա��� �ڸ��� �ɾƽĻ��ϽŴ�." + "\n" + "[FŰ�� ���� ��������]" + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
            if (page == 2)
                CharSaying.text = "��Ӵϲ����� �׻� �ƹ��� �������� �Ļ��ϽŴ�." + "\n" + "�׸��� �׿����� �׻� � ������ �ɴ´�. ��� �����ִ�." + "\n" + "[FŰ�� ���� ��������]" + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
            if (page == 3)
                CharSaying.text = "�����غ��� ���� �׻� ������ �밢�� �ڸ��� ���� ���ϴ�. " + "\n" + "[FŰ�� ���� ó������]" + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
            if (page >= 4)
                page = 0;
        }

        if (this.gameObject.CompareTag("Puzzle_Box"))
        {
            if (page == 1 || page == 0)
                CharSaying.text = "��������" + "\n" + "�̹濡 ���� ��Ʈ�� �����ִ�." +"\n" + "| [FŰ�� ���� ��������]" + " ||  " + "[ESC�� ���� ��ȭâ �ݱ�] |";
            if(page == 2)
                CharSaying.text = "������ �ձ׷��� �����ߴ�." + "\n" + "�ð��� ���� ���� ���� �����," + "\n" + "���������� ó���� ���µ� ������ �ȳ� ������ �׸𳪰� ���ع��ȴ�." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";
        }
    }

}
