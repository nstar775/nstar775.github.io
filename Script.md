# ProJect Name : 《Estate Escape》

## Script
## ▶목차
#### 1. [시스템 관련](#-시스템-관련-1)
#### 2. [튜토리얼 스테이지 관련](#-related-images--videos)
#### 3. [스테이지1 관련](#-representative-image)
#### 4. [스테이지2 관련](#-describe-the-concept--representative-image)
#### 5. [엔딩 ](#-escape-to-memorys-ingredients)


__________________________
## 1. 시스템 관련
### A. StageManager.cs
```cs
//StageManager.cs
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
    public GameObject[] StageDoorTrigger; //튜토리얼맵을 제외한 스테이지맵의 최종문에 대한 트리거.
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
    public GameObject[] Figure_Objects;             //  0:원기둥   1:육면체   2:오면체

    [Header("Stage2-2")]
    public int Mission2_Clear_Counter = 0; // 의자 오브젝트(바닥의 컨트롤러)

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
            player_Text.text = "윗층 방의 문의 잠금이 열렸다." + "\n" + "[ESC를 눌러 대화창 닫기]";

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Talk_Pannel.SetActive(false);
            }
        }
    }

    void Stage1()
    {
        //사계카운터가 카운트가 13일시 1로 초기화
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

        //히든 클리어 조건
        if (WinterCounter == 5 && SummerCounter == 3 && FallCounter == 6 && SpringCounter == 12)
        {
            StageDoorTrigger[0].GetComponent<Animator>().SetBool("MoveOn", true);
            Stage1_Clear = true;
            Hidden_Open1 = true;
        }


    }


    void Stage2()
    {
        //1번방
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
            Mission1_Clear_Counter++; //3일때 계속 올라가기 때문에 한번만 올라게 하기 위해 숫자를 올려, 브레이크를 줌.

            if (HiddenClear_Counter == 2)
            {
                HiddenClear_Counter++;
            }
            else
            {
                HiddenClear_Counter = 0;
            }
        }

        //2번방
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

        //3번방

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
        //다음 스테이지 문이 열리는 소리 재생
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

```  

### B. Game_Manager.cs
```cs
//Game_Manager.cs
//게임 매니저로 쓰려고 했지만, 스테이지 매니저가 그 역할을 다 하여, 마우스 커서의 락 온/오프 기능 만 수행.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    [SerializeField]
    public bool Cursor_LockOn;
    public static bool pauseTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        Cursor_LockOn = true;
    }

    private void Update()
    {
        CursorLockOn();

        if (Input.GetKeyDown(KeyCode.LeftControl)&& Input.GetKeyDown(KeyCode.Escape))
            Cursor_LockOn = false;
        if (Input.GetKeyUp(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor_LockOn == false)
            {
                Cursor_LockOn = true;
            }
            else{ } //None
        }
    }


    private void CursorLockOn()
    {
        if (Cursor_LockOn == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public static void pauseGame()
    {
        if (!pauseTime)
        {
            Time.timeScale = 0;
            pauseTime = true;
        }
        else if (pauseTime)
        {
            Time.timeScale = 1;
            pauseTime = false;
        }
    }

}
```  

### C. AudioManager.cs
```cs
// 클론을 만들어 BGM을 재생함.
//BGM 재생이 종료 되었을 시, 클론오브젝트를 파괴함.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Range(0, 2.0f)]
    public float SFX_Volume = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.time *= Time.unscaledDeltaTime;
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume *= SFX_Volume;

        Destroy(go, clip.length);
    }
}
```

### D. MainMenu.cs
```cs
//버튼 UI를 위한 함수입니다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("게임을 시작합니다.");
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
    }

    public void OnClickExit()
    {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }
}
```

### E. SceneLoader.cs
```cs
// 게임 씬을 로드 합니다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public static string loadScene;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Start");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                loadtext.text = "Press AnyKey";
            }

            if (Input.anyKeyDown && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
```

### F. PlayerController2.cs  
```cs
// 플레이어의 이동 및 카메라 조작이다.
// 2가 붙은건 본래 3인칭 조작및 1인칭 조작을 모두 사용하려 했기 떄문으로,
// 3인칭 쪽이 넘버링이 없었으며. 3인칭 쪽 스크립트를 제거 했기 때문에 해당 스크립트를 그대로 사용한다.
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private float walkSpeed = 5; //원래 걸음 속도
    [SerializeField]
    private float runSpeed = 8; //뜀걸음 속도
    [SerializeField]
    private float applySpeed = 5; // 현재 속도

    //상태 변수
    private bool isRun = false;
    private bool isGround = true;
    private float OrignWalkSpeed = 5;
    private float OrignRunSpeed = 8;

    [Range(0,1)]
    public float DontMove = 1;

    public float jumpForce = 10f;
    [SerializeField]
    private float lookSensitivity;

    //카메라
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;
    
    //컴포너
    [SerializeField]
    private Camera myCamera;
    private Rigidbody MyRigidbody;
    private CharacterController characterController;
    private CapsuleCollider capsuleCollider;

    Vector3 playerHittheWall;
    Vector3 playerStartPosition;

    private void Start()
    {
        myCamera = FindObjectOfType<Camera>();
        MyRigidbody = gameObject.GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        OrignRunSpeed = runSpeed;
        OrignWalkSpeed = walkSpeed;
        applySpeed = walkSpeed;

        playerStartPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        CameraRotation();
        CharacterRotation();
        TryRun();
        JumpTo();
        IsGround();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        float _moveY = MyRigidbody.velocity.y;

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized;

        MyRigidbody.velocity = _velocity * applySpeed;
        MyRigidbody.velocity = new Vector3(MyRigidbody.velocity.x, _moveY, MyRigidbody.velocity.z);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        MyRigidbody.rotation *= Quaternion.Euler(_characterRotationY);

    }
    private void CameraRotation()
    {
        float _xRotaion = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotaion * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        myCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancle();
        }
    }

    private void Running()
    {
        isRun = true;
        applySpeed = runSpeed;
    }


    private void RunningCancle()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    public void JumpTo()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        MyRigidbody.velocity = new Vector3(MyRigidbody.velocity.x, jumpForce, MyRigidbody.velocity.z) ;
    }

    private void IsGround()
    {
        //isGround = Physics.Raycast(transform.position, Vector3.down, characterController.bounds.extents.y + 0.1f);
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }


    public void Initialized()
    {
        gameObject.transform.position = playerStartPosition;
    }
}


```

________________________  

## 1. 튜토리얼 스테이지 관련

### A. DoorTrigger.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    [SerializeField]
    bool doorOpen = false;
    public AudioClip[] clip;
    public GameObject Open_Messege;
    public GameObject Close_Messege;

    public Animator animator;

    GameObject _player;


    //bool isOpened = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        door.GetComponent<Animator>().SetBool("DoorOpen", doorOpen);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player)
        {

            if (!doorOpen)
            {
                if (Open_Messege.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        doorOpen = true;
                        AudioManager.instance.SFXPlay("문 여는 소리", clip[0]);
                        Open_Messege.SetActive(false);
                    }
                }
                else if (!Open_Messege.activeSelf)
                {
                    Open_Messege.SetActive(true);
                    Close_Messege.SetActive(false);
                }
            }

            else if (doorOpen)
            {
                if (Close_Messege.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        doorOpen = false;
                        AudioManager.instance.SFXPlay("문 여는 소리", clip[1]);
                        Close_Messege.SetActive(false);
                    }
                }
                else if(!Close_Messege.activeSelf)
                {
                    Close_Messege.SetActive(true);
                    Open_Messege.SetActive(false);
                }
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            if (Open_Messege.activeSelf)
            {
                Open_Messege.SetActive(false);
            }

            if (Close_Messege.activeSelf)
            {
                Close_Messege.SetActive(false);
            }
        }
    }

    public void Initialized()
    {
        AudioManager.instance.SFXPlay("문 여는 소리 ", clip[0]);
        AudioManager.instance.SFXPlay("문 닫는 소리", clip[1]);
        door.SetActive(!doorOpen);
    }
}
```

### B. Tuto_Button.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Button : MonoBehaviour
{
    public GameObject DoorTrigger;
    GameObject player;

    static public bool onButtonTrigger = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        DoorTrigger.SetActive(onButtonTrigger);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            onButtonTrigger = !onButtonTrigger;
        }
    }
}
```
### C. Tuto_Piano.cs  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Piano : MonoBehaviour
{
    [SerializeField]
    GameObject PianoPanel;

    [SerializeField]
    GameObject piano_object;

    GameObject player;

    [SerializeField]
    GameObject askUI;

    public GameObject DoorTrigger;

    public AudioClip[] clip;

    bool isPlayPiano = false;

    public int openCount = 0;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (openCount >= 6)
        {
            isPlayPiano = false;
            piano_object.SetActive(false);
            DoorTrigger.SetActive(true);
            AudioManager.instance.SFXPlay("피아노가 사라졌다!", clip[8]);
            Game_Manager.pauseGame();
        }
        Piano();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            askUI.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                if (!PianoPanel.activeInHierarchy)
                {
                    PianoPanel.SetActive(true);
                    Game_Manager.pauseGame();
                    isPlayPiano = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            askUI.SetActive(false);
        }
    }

    private void Piano()
    {
        if (isPlayPiano == true)
        {
            askUI.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPlayPiano = false;
                askUI.SetActive(false);
                Game_Manager.pauseGame();
            }
            if (Input.GetKeyDown(KeyCode.A)) //C (도)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("도", clip[0]);
            }

            if (Input.GetKeyDown(KeyCode.S)) //D (레)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("레", clip[1]);
            }

            if (Input.GetKeyDown(KeyCode.D)) // E (미)
            {
                if (openCount == 1)
                    openCount += 1;
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("미", clip[2]);
            }

            if (Input.GetKeyDown(KeyCode.F)) // F (파)
            {
                if (openCount == 2)
                    openCount += 1;
                else if (openCount == 5)
                    openCount += 1;
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("파", clip[3]);
            }

            if (Input.GetKeyDown(KeyCode.J)) //G (솔)
            {
                if (openCount == 0)
                    openCount += 1;
                else if (openCount == 3)
                    openCount += 1;
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("솔", clip[4]);
            }

            if (Input.GetKeyDown(KeyCode.K)) //A (라)
            {
                if (openCount == 4)
                {
                    openCount += 1;
                }
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("라", clip[5]);
            }

            if (Input.GetKeyDown(KeyCode.L)) //B (시)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("시", clip[6]);
            }

            if (Input.GetKeyDown(KeyCode.Semicolon) || Input.GetKeyDown(KeyCode.Colon)) // C (높은 도)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("높은_도", clip[7]);
            }
        }
        if (isPlayPiano == false)
        {
            PianoPanel.SetActive(false);
            player.SetActive(true);
        }
    }

    public void Initialized()
    {
        openCount = 0;
    }
}
```  

### F. EventTutorial.cs  
```cs
//튜토리얼 이벤트로, 플레이어가 해당 관문에 도달, 힌트를 줌.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTutorial : MonoBehaviour
{
    public GameObject Tutorial_UI;


    private int PlayerCount = 0;
    private float Timer = 0f;

    private void FixedUpdate()
    {
        //UI가 켜져있으면 타이머를 카운트함
        if(Tutorial_UI.activeSelf)
            Timer += 1 * Time.deltaTime;

        // UI가 30초 동안 켜져있으면 30초 후에 종료 시킴. 
        if(Timer >= 30)
        {
            Timer = 0.1f;

            if (Tutorial_UI.activeSelf)
            {
                Tutorial_UI.SetActive(false);
                Game_Manager.pauseGame();
            }
        }

        //UI가 열려있을 때, Esc를 누르면 닫히고, Timer를 0으로 초기화 시킴.
        if (Tutorial_UI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Tutorial_UI.SetActive(false);
                Timer = 0.1f;
                Game_Manager.pauseGame();
            }
        }


    }


    //유저가 존에 들어오면 발생. (플레이어 카운터로 한번만 말생하게 함.)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerCount < 1)
            {
                PlayerCount++;
                if (!Tutorial_UI.activeSelf)
                {
                    Tutorial_UI.SetActive(true);
                    Game_Manager.pauseGame();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Tutorial_UI.SetActive(true);
                Game_Manager.pauseGame();
            }
        }
    }

    public void Initialized()
    {
        Timer = 0;
        PlayerCount = 0;
    }

}
```

### E. PassWord_Toggle.cs  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassWord_Box : MonoBehaviour
{
    GameObject player;

    //우선순위 결정
    public int red = 1;
    public int blue = 2;
    public int yellow = 3;
    public int green = 4;

    //페스워드체크
    public int PassWord_Check = 1;
    public int Pass_Check = 4;

    //통과
    public static bool Pass = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
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

}
```  

### F. PassWord_Toggle.cs  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWord_Toggle : MonoBehaviour
{
    private GameObject player;
    public GameObject Respawn;

    private bool pauseTime = false;

    public GameObject PasswordBox;
    public GameObject ask_UI;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (PasswordBox)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Game_Manager.instance.Cursor_LockOn = true;
                PasswordBox.SetActive(false);
                Game_Manager.pauseGame();
            }
        }

        if (PassWord_Box.Pass)
        {
            ask_UI.SetActive(false);
            player.transform.position = Respawn.transform.position;
            this.gameObject.SetActive(false);
            PassWord_Box.Pass = false;
            Game_Manager.pauseGame();
        }
    }

    //플레이어가 오브젝트의 접근 했는지 체크
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            ask_UI.SetActive(true);
            OnPW_Box();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            ask_UI.SetActive(false);
        }
    }


    //패스워드 박스 온 오프
    void OnPW_Box() 
    {
        if (ask_UI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PasswordBox.SetActive(true);
                Game_Manager.instance.Cursor_LockOn = false;
                Game_Manager.pauseGame();
            }
        }
    }

}
```

________________________  

## 3. 스테이지1 관련
### A. Button_Object.cs  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Object : MonoBehaviour
{
    public GameObject Object_Button;
    public GameObject Push_UI;
    public StageManager stageManager;
    GameObject player;

    public AudioClip[] clip;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject == player)
        {
            if (Push_UI.activeInHierarchy == false)
            {
                Push_UI.SetActive(true); 
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                AudioManager.instance.SFXPlay("버튼 소리", clip[0]);
                Stage01_ButtonTag_Event();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Push_UI.SetActive(false);
    }

    void Stage01_ButtonTag_Event()
    {
        if (this.gameObject.tag == "WinterBook")
        {
            stageManager.WinterCounter ++;
        }
        else if(Object_Button.tag == "SummerBook")
        {
            stageManager.SummerCounter++;
        }
        else if(Object_Button.tag == "AutumnBook")
        {
            stageManager.FallCounter++;
        }
        else if(Object_Button.tag == "SpringBook")
        {
            stageManager.SpringCounter++;
        }
        else
        {
            print(this.gameObject.tag);
        }
    }
}
```

### B. Clock.cs
```cs
//시즌 넘버로 각 시계 오브젝트를 분류하고, 분류된 시계에 따라 스테이지 매니저에서 플레이어에 의하여 
//조작 되어진 각 카운터를 애니메이션 카운터에 대입하여 버튼을 조작하였을때, 
//시침이 움직이는 애니메이션이 나오도록 함.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Range(0, 3)]
    public int seseason_Number = 0;  // 0 = 봄, 1 = 여름, 2 = 가을, 3 = 겨울

    public Animator Clock_animator;

    public StageManager Stage_manager;

    // Update is called once per frame
    void Update()
    {
        if(seseason_Number == 0)
            Clock_animator.SetInteger("ClockCount", Stage_manager.SpringCounter);

        if (seseason_Number == 1)
        Clock_animator.SetInteger("ClockCount", Stage_manager.SummerCounter);

        if (seseason_Number == 2)
            Clock_animator.SetInteger("ClockCount", Stage_manager.FallCounter);

        if (seseason_Number == 3)
            Clock_animator.SetInteger("ClockCount", Stage_manager.WinterCounter);
    }

}
```  

### C. HintEvent.cs  
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintEvent : MonoBehaviour
{
    public GameObject Can_You_Read_UI;
    public GameObject Hint;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hint.SetActive(false);
            Can_You_Read_UI.SetActive(false);
            pauseGame();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject == player)
        {
            if (!Can_You_Read_UI.activeSelf)
            {
                Can_You_Read_UI.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Can_You_Read_UI.SetActive(false);

                if (!Hint.activeSelf)
                {
                    Hint.SetActive(true);
                    pauseGame();
                }
            }

        }
    }


    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject == player)
        Can_You_Read_UI.SetActive(false);
    }

    private void pauseGame()
    {
        if (Hint.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (!Hint.activeSelf)
        {
            Time.timeScale = 1;
        }
    }
}
```


### 번외. Sound_Event.cs
```cs
//플레이어가 클리어를 했을때, 해당 스크립트가 넣어져있는 빈 오브젝트가 하이어락키에서 액티브가 활성화 되어, 특정 소리를 나오게 함.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Event : MonoBehaviour
{
    public AudioClip clip;
    public string AudioMassege = "";

    private void Start()
    {
        AudioManager.instance.SFXPlay(AudioMassege, clip);
    }

}

```  


________________________  

## 3. 스테이지2 관련
### A. Warp.cs  
```cs
// 1스테이지가 클리어 되었을떄, 2스테이지로 가기 위한 스크립트.
// 2스테이지 복도에서 다시 1스테이지로 되돌아 갈수 도 있으며,
// 콜라이더가 없는 오브젝트를 해당 위치에 배치하여 보다 정확하게 이동하게 만듦.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject WarpTarget;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = WarpTarget.transform.position;
        }
    }
}
```  

### B. Talk.cs  
```cs
// 태그에 따라 힌트 박스의 말이 바뀌로록 설정.
// 같은 방법으로, 쪽지에도 태그를 달아, 말이 달라지도록 설정.
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

```

### C. Stage2_Collide_Mission.cs  
```cs
// 1번방 미션이다.
// 미션의 특정 오브젝트가 순서 대로 구멍안에 넣어질시 발생하는 이밴트로,
// 구멍 안의 투명한 오브젝트가 가지는 스크립트이다.
// 구멍 안, 투명한 오브젝트가 특정 오브젝트와 부딪혔을때, 그 부딪힌 오브젝트를 토이박스 라는 공간으로 이동신다.
// 순서가 안맞으면 목표 오브젝트의 위치가 원위치로 돌아간다.

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

```  

### D. Chairs.cs  
```cs
// 의자 문제의 스크립트.
// 특정의 의자의 불이 켜질 때마다 카운터가 올라가게하고,
// 마지막 의지의 불이 켜지면 모든 불이 꺼지고, 불이 켜지지 않게 하여, 클리어 했음을 알림.
// 의자의 불은 껏다 켰다가 가능.
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

```  

### E. Ending.cs  
```cs
// 플레이어가 모든 과제를 클리어 했을때, 열리는 방의 투명한 오브젝트에 닿았을때, 이벤트가 발생한다.
// 플레이어가 움직이지 못하도록, 플레이어의 액티브를 해제하고, 특수 카메라의 액티브를 On시킨다.
// 그후, 페이드 애니메이션이 재생하게 하고, 페이드가 끝날을때, 엔딩 씬으로 전환한다.
// 엔딩 씬으로 전환할때, 플레이어의 도전과제를 확인하고, 달성한 히든과제에 따라, 엔딩이 바뀐다.
// 참고로 히든 과제를 못볼 시, 특별한 엔딩은 없으며, Thank you for playing 만 나온다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject FadePanel;
    public float FadeTime;
    public bool PlayerHit;
    public GameObject Player_EndingCamera;
    public string[] Scenes;

    private void Start()
    {
        if(Player_EndingCamera.activeSelf)
            Player_EndingCamera.SetActive(false);

        if (FadePanel.activeSelf)
            FadePanel.SetActive(false);

        if (PlayerHit)
            PlayerHit = false;

        if (FadeTime > 0)
        {
            FadeTime = 0;
        }
    }

    private void Update()
    {
        if (PlayerHit == true)
        {
            FadeTime += 1 * Time.deltaTime;


            if (StageManager.Stage1_Hidden == true && StageManager.Stage2_Hidden == false)
            {
                if (FadeTime >= 5)
                {
                    SceneManager.LoadScene(Scenes[1]);
                    FadeTime = 0;
                    PlayerHit = false;
                }
            }
            else if (StageManager.Stage1_Hidden == false && StageManager.Stage2_Hidden == true)
            {
                if (FadeTime >= 5)
                {
                    SceneManager.LoadScene(Scenes[2]);
                    FadeTime = 0;
                    PlayerHit = false;
                }
            }
            else if (StageManager.Stage1_Hidden == true && StageManager.Stage2_Hidden == true)
            {
                if (this.gameObject.name == "Ending")
                {
                    if (FadeTime >= 5)
                    {
                        SceneManager.LoadScene(Scenes[2]);
                        FadeTime = 0;
                        PlayerHit = false;
                    }
                }
                else if (this.gameObject.name == "HiddenEnding")
                {
                    if (FadeTime >= 5)
                    {
                        SceneManager.LoadScene(Scenes[3]);
                        FadeTime = 0;
                        PlayerHit = false;
                    }
                }
            }
            else
            {
                if (FadeTime >= 5)
                {
                    SceneManager.LoadScene(Scenes[0]);
                    FadeTime = 0;
                    PlayerHit = false;
                }

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Player_EndingCamera.SetActive(true);
            FadePanel.SetActive(true);
            PlayerHit = true;
        }
    }
}

```

________________________  

## 3. 엔딩 관련
### A. TypingEffect.cs  
```cs
// 엔딩에서 글씨가 한글자 한글자씩 출력 되게 한다.
// msg_text에 텍스트에 적은 내용을 저장하고, msg를 한번 비운다음, 코루틴 함수를 통해,
// 타이핑이펙트가 언제 나오게 할것인지 WaitForTypo에 숫자로 정한다.
// TypoSpeed변수로 글자 속도를 조절한다.
// TypoSpeed는 숫자가 작을 수록 글자가 빨리 나온다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text msg;

    private string msg_text = "";

    [Range(0f,100f)]
    public float WaitForTypo;

    [Range(0.01f,0.99f)]
    public float typoSpeed;

    private void Awake()
    {
        msg_text = msg.text;
    }

    private void Start()
    {
        msg.text = "";
        StartCoroutine(typing());
    }

    IEnumerator typing()
    {
        yield return new WaitForSeconds(WaitForTypo);

        for(int i = 0; i<=msg_text.Length; i++)
        {
            msg.text = msg_text.Substring(0, i);

            yield return new WaitForSeconds(typoSpeed);
        }
    }
}
```

### B. Invoke_Game.cs  
```cs
//스킵트리거를 통해, 엔딩을 스킵할수 있으며, 스킵후, 한번더 누르게 되면 초기화면씬으로 전환한다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invoke_Game : MonoBehaviour
{
    public Animator Ending_UI_Anime;

    public GameObject EndingCanvas;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Ending_UI_Anime.SetTrigger("Skip");

            if (EndingCanvas.activeSelf)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

```

### B. ReturnToMain.cs  
```cs
//말 그대로 아무키나 누르면 메인 매뉴로 바로 넘어간다.
//특수 엔딩이 아닌 노멀 엔딩일 시, 스토리가 따로나오지 않으며,
//Thank you for playing 만 나오기 떄문에, 해당 씬만 유일하게 이 스크립트를 사용하며, 대부분 인보크게임 스크립트를 사용한다.
//인보크는 초기화라는 뜻을 가지고 있는데, 이는 스크립트 네이밍 미스이다.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}

```
