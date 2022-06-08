using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Collide_Mission : MonoBehaviour
{
    [Range(1,3)]
    public int My_Number = 1;

    public StageManager stg_Manager;




    private void OnCollisionEnter(Collision collision)
    {
        if(My_Number == 1)
        {
            if (collision.gameObject.name == "Cylinder")
            {
                if(stg_Manager.Mission1_Clear_Counter == 0)
                {
                    stg_Manager.Mission1_Clear_Counter++;
                    stg_Manager.Figure_Objects[0].transform.position = new Vector3(-100, -100, -100);
                }
                else
                {
                    stg_Manager.Mission1_Clear_Counter = -1;
                }
            }
        }

        if(My_Number == 2)
        {
            if(collision.gameObject.name == "Cube")
            {
                if (stg_Manager.Mission1_Clear_Counter == 2)
                {
                    stg_Manager.Mission1_Clear_Counter++;
                    stg_Manager.Figure_Objects[1].transform.position = new Vector3(-100, -100, -100);
                }
                else
                {
                    stg_Manager.Mission1_Clear_Counter = -1;
                }

            }
        }

        if(My_Number == 3)
        {
            if (collision.gameObject.name == "TriBox")
            {
                if (stg_Manager.Mission1_Clear_Counter == 1)
                {
                    stg_Manager.Mission1_Clear_Counter++;
                    stg_Manager.Figure_Objects[2].transform.position = new Vector3(-100, -100, -100);
                }
                else
                {
                    stg_Manager.Mission1_Clear_Counter = -1;
                }
            }
        }
    }
}
