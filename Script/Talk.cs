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
            CharSaying.text = "아버지께서 그린 그림이다." + "\n" + "그림제목은 『정오가 되기 한시간전의 봄』이었던 것 같다." + "\n" + "[ESC를 눌러 대화창 닫기]";
        }
        if (this.gameObject.CompareTag("SummerBook"))
        {
            CharSaying.text = "석양이 아름다운 여름의 바다이다." + "\n" + "해가 지는 시간의 여름인듯하다." + "\n" + "[ESC를 눌러 대화창 닫기]";
        }
        if (this.gameObject.CompareTag("AutumnBook"))
        {
            CharSaying.text = "언뜻 보기엔 여름의 숲처럼 보이지만" + "\n" + "해가뜨는 아침의 가을의 숲이라고 들은것같다." + "\n" + "[ESC를 눌러 대화창 닫기]";
        }
        if (this.gameObject.CompareTag("WinterBook"))
        {
            CharSaying.text = "티타임직전의 겨울언덕의 교회 이라는 그림인듯하다." + "\n" + "아무리 봐도 티타임과 관련 없어보이지만... 그렇다고한다." + "\n" + "[ESC를 눌러 대화창 닫기]";
        }
        if (this.gameObject.CompareTag("Memo"))
        {
            CharSaying.text = "쪽지에는" + "\n" + "티타임의 시간은 4시부터..." + "\n" + "라고 적혀있다." + "\n" + "[ESC를 눌러 대화창 닫기]";
        }

        if (this.gameObject.CompareTag("Item"))
        {
            if (page == 1 || page == 0)
                CharSaying.text = "내가 쓴 메모 인것 같다." + "\n" + "아버지께서는 항상 문을 볼 수있는 " + "\n" + "가장 입구쪽 자리에 앉아식사하신다." + "\n" + "[F키를 눌러 다음으로]" + "\n" + "[ESC를 눌러 대화창 닫기]";
            if (page == 2)
                CharSaying.text = "어머니께서는 항상 아버지 맞은편에서 식사하신다." + "\n" + "그리고 그옆에는 항상 어린 동생이 앉는다. 라고 적혀있다." + "\n" + "[F키를 눌러 다음으로]" + "\n" + "[ESC를 눌러 대화창 닫기]";
            if (page == 3)
                CharSaying.text = "생각해보니 나는 항상 동생의 대각선 자리에 앉은 듯하다. " + "\n" + "[F키를 눌러 처음으로]" + "\n" + "[ESC를 눌러 대화창 닫기]";
            if (page >= 4)
                page = 0;
        }

        if (this.gameObject.CompareTag("Puzzle_Box"))
        {
            if (page == 1 || page == 0)
                CharSaying.text = "쪽지에는" + "\n" + "이방에 대한 힌트가 쓰여있다." +"\n" + "| [F키를 눌러 다음으로]" + " ||  " + "[ESC를 눌러 대화창 닫기] |";
            if(page == 2)
                CharSaying.text = "시작은 둥그렇게 시작했다." + "\n" + "시간이 지나 여러 각이 생겼고," + "\n" + "마지막에는 처음의 형태도 생각이 안날 정도로 네모나게 변해버렸다." + "\n" + "[ESC를 눌러 대화창 닫기]";
        }
    }

}
