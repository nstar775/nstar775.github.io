using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static bool Stage1_Clear = false;
    public static bool Stage2_Clear = false;
    public static bool Stage1_Hidden = false;
    public static bool Stage2_Hidden = false;
    bool ClearYet = true;

    [Header("Object")]
    public GameObject Player;
    public GameObject[] StageDoorTrigger; //Ʃ�丮����� ������ ������������ �������� ���� Ʈ����.
    public GameObject Hint_trigger;
    public GameObject Talk_Pannel;
    public Text player_Text;
    public Animator FinStageDoor;
    public Animator AnotherFinDoor;

    [Header("Stage01_Clear_Requirements")]
    public int WinterClearCount;
    public int SummerClearCount;
    public int FallClearCount;

    [Header("Stage01_Player_Answer")]
    public int WinterCounter = 0;
    public int SummerCounter = 0;
    public int FallCounter = 0;

    [Header("Stage01_Hidden")]
    public bool Hidden_Open1 = false;

    [Header("Stage01_Door_Sound")]
    public GameObject Stg01_Clear_SoundEvent;

    [Header("Stage2")]
    public int HiddenClear_Counter = 0;
    public int Clear_Counter = 0;

    [Header("Stage2-1")]
    public int Mission1_Clear_Counter = 0;
    public Vector3[] Figure_Objects_Position;
    public GameObject[] Figure_Objects;             //  0:�����   1:����ü   2:����ü

    [Header("Stage2-2")]
    public int Mission2_Clear_Counter = 0; // ���� ������Ʈ(�ٴ��� ��Ʈ�ѷ�)

    [Header("Stage2_3")]
    public int SpringClearCount;
    public int SpringCounter = 12;

    [Header("Stage2_Hidden")]
    public bool Hidden_Open2 = false;

    private void Start()
    {
        for (int i = 0; i < Figure_Objects.Length; i++)
        {
            Figure_Objects_Position[i] = Figure_Objects[i].transform.position;
        }
    }


    private void Update()
    {
        Stage1();
        Stage2();
        SoundEvent();

        Stage1_Hidden = Hidden_Open1;
        Hidden_Open2 = Stage2_Hidden;

        if (Stage1_Clear == true)
            Hint_trigger.SetActive(true);

        if (HiddenClear_Counter == 3)
        {
            Stage2_Hidden = true;
        }

        if (Clear_Counter == 3 && HiddenClear_Counter < 3)
        {
            FinStageDoor.SetBool("Open", true);
        }

        if (Stage1_Hidden == true && Stage2_Hidden == true && ClearYet == true)
        {
            AnotherFinDoor.SetBool("DoorOpen", true);
            Talk_Pannel.SetActive(true);
            ClearYet = false;
            player_Text.text = "���� ���� ���� ����� ���ȴ�." + "\n" + "[ESC�� ���� ��ȭâ �ݱ�]";

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Talk_Pannel.SetActive(false);
            }
        }
    }

    void Stage1()
    {
        //���ī���Ͱ� ī��Ʈ�� 13�Ͻ� 1�� �ʱ�ȭ
        if (WinterCounter >= 13)
            WinterCounter = 1;

        if (SummerCounter >= 13)
            SummerCounter = 1;

        if (FallCounter >= 13)
            FallCounter = 1;

        if (WinterCounter == WinterClearCount && SummerCounter == SummerClearCount && FallCounter == FallClearCount)
        {
            StageDoorTrigger[0].GetComponent<Animator>().SetBool("MoveOn", true);
            Stage1_Clear = true;
        }

        //���� Ŭ���� ����
        if (WinterCounter == 5 && SummerCounter == 3 && FallCounter == 6 && SpringCounter == 12)
        {
            StageDoorTrigger[0].GetComponent<Animator>().SetBool("MoveOn", true);
            Stage1_Clear = true;
            Hidden_Open1 = true;
        }


    }


    void Stage2()
    {
        //1����
        if(Mission1_Clear_Counter < 0)
        {
            for(int i = 0; i < Figure_Objects.Length; i++)
            {
                Figure_Objects[i].transform.position = Figure_Objects_Position[i];
            }

            Mission1_Clear_Counter = 0;
        }



        if (Mission1_Clear_Counter == 3) 
        {
            Clear_Counter++;
            Mission1_Clear_Counter++; //3�϶� ��� �ö󰡱� ������ �ѹ��� �ö�� �ϱ� ���� ���ڸ� �÷�, �극��ũ�� ��.

            if (HiddenClear_Counter == 2)
            {
                HiddenClear_Counter++;
            }
            else
            {
                HiddenClear_Counter = 0;
            }
        }

        //2����
        if(Mission2_Clear_Counter == 4)
        {
            Clear_Counter++;
            Mission2_Clear_Counter++;


            if (HiddenClear_Counter == 0)
            {
                HiddenClear_Counter++;
            }
            else
            {
                HiddenClear_Counter = 0;
            }
        }

        //3����

        if (SpringCounter >= 13)
            SpringCounter = 1;

        if (SpringCounter == SpringClearCount && WinterCounter == 4  && SummerCounter == 8 && FallCounter == 6)
        {
            Clear_Counter++;
            
            SpringCounter = 0;
            WinterCounter = 0;
            SummerCounter = 0;
            FallCounter = 0;

            if(HiddenClear_Counter == 1)
            {
                HiddenClear_Counter++;
            }
            else
            {
                HiddenClear_Counter = 0;
            }
        }
       
    }

    private void SoundEvent()
    {
        //���� �������� ���� ������ �Ҹ� ���
        if(Stage1_Clear == true)
        {
            if (!Stg01_Clear_SoundEvent.activeSelf)
            {
                Stg01_Clear_SoundEvent.SetActive(true);
            }
        }
    }


    public void Initialized()
    {
        SpringCounter = 0;
        WinterCounter = 0;
        SummerCounter = 0;
        FallCounter = 0;

        Mission1_Clear_Counter = 0;
        Mission2_Clear_Counter = 0;
        Clear_Counter = 0;
        HiddenClear_Counter = 0;

        for (int i = 0; i < Figure_Objects.Length; i++)
        {
            Figure_Objects[i].transform.position = Figure_Objects_Position[i];
        }

        Stage1_Clear = false;
        Stage1_Hidden = false;

        Stage2_Clear = false;
        Stage2_Hidden = false;
    }

}
