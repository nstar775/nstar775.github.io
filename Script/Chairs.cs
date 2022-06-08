using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairs : MonoBehaviour
{
    [Range(1,8)]
    public int Chair_number = 1;

    public StageManager stg_Manager;

    public Animator Chair;

    private void Update()
    {
        if (stg_Manager.Mission2_Clear_Counter < 0)
        {
            stg_Manager.Mission2_Clear_Counter = 0;
        }

        if(stg_Manager.Mission2_Clear_Counter >= 4)
        {
            Chair.SetBool("Active", false);
        }
    }


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Active_Chair();

                if (Chair_number == 1 || Chair_number == 5 || Chair_number == 6 || Chair_number == 3) //활성화시
                {
                    if (Chair.GetBool("Active") == true) // 활성화
                    {
                        stg_Manager.Mission2_Clear_Counter++;
                    }
                    else if (Chair.GetBool("Active") == false) //비활성화
                    {
                        stg_Manager.Mission2_Clear_Counter--;
                    }
                }
            }
        }
    }

    private void Active_Chair()
    {
        if(Chair.GetBool("Active") == false)
        {
            Chair.SetBool("Active", true);
        }
        else if(Chair.GetBool("Active") == true)
        {
            Chair.SetBool("Active", false);
        }
    }

}
