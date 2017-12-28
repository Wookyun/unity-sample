using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {

    
    public float moveSpeed = 4f;

    Animator thisAnim;
    float lastX, lastY;
    static string scene;
    private SpriteRenderer sprite;
    private GameObject invencan, querry,messages;
    
    string door;
    float shift;
    

    void Awake()
    {
        
        invencan = GameObject.FindWithTag("invencanvas");
        querry = invencan.transform.Find("Querry").gameObject;
        messages = invencan.transform.Find("Messages").gameObject;
        //inventory = invencan.transform.Find("Inventory").gameObject;
        //invenmenu = invencan.transform.Find("InvenMenu").gameObject;
        //map = invencan.transform.Find("Map").gameObject;
        
  


    }

    // Use this for initialization
    void Start () {
       thisAnim = GetComponent<Animator>();
       //sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.W))
        {
            if (Input.GetButton("Fire3"))
            {
                shift = 2f;
            }
            else
            {
                shift = 1;
            }
            float keyboardH = Input.GetAxis("Horizontal")*shift;
            float keyboardV = Input.GetAxis("Vertical")*shift;
            Move(keyboardH, keyboardV);
        }
        else
        {
            print("nokey down");
            float keyboardH = CrossPlatformInputManager.GetAxis("Horizontal");
            float keyboardV = CrossPlatformInputManager.GetAxis("Vertical");
            Move(keyboardH, keyboardV);
        }
	}

    void Move(float a, float b)
    {
        
            Vector3 rightMovement = Vector3.right * moveSpeed * Time.deltaTime * a; //Input.GetAxis("Horizontal");
            Vector3 upMovement = Vector3.up * moveSpeed * Time.deltaTime *b ;  //Input.GetAxis("Vertical");
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            transform.position += rightMovement;
            transform.position += upMovement;

            UpdateAnimation(heading);
       
    }

    void UpdateAnimation(Vector3 dir)
    {
        if(dir.x == 0f && dir.y == 0f)
        {
            thisAnim.SetFloat("LastDirX", lastX);
            thisAnim.SetFloat("LastDirY", lastY);
            thisAnim.SetBool("Movement", false);
        }
        else
        {
            lastX = dir.x;
            lastY = dir.y;
            thisAnim.SetBool("Movement", true);
        }

        thisAnim.SetFloat("DirX", dir.x);
        thisAnim.SetFloat("DirY", dir.y);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        sprite = collision.transform.parent.GetComponent<SpriteRenderer>();
        
        //string a = "gameLevel";
        //print((int)GMManager.instance.GetType().GetField(a).GetValue(GMManager.instance));

        if (collision.tag == "SceneChange")
        {
            if (Input.GetKeyUp(KeyCode.Space) || CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                door = collision.name + "Door";
                print(door);
                if ( (bool)GMManager.instance.GetType().GetField(door).GetValue(GMManager.instance) == false )
                {
                    

                    
                    StartCoroutine(GetText());
                    //messages.SetActive(false);
                    print("nreturnsuccess");

                }

                else
                {
                    scene = collision.name;
                    print(scene);
                    querry.SetActive(true);
                    //print(querry.name);}


                }
            }
        }
            print(collision.name);
       // print(GMManager.instance.gameLevel);

        if (collision.name == "Sort")
        {
            if (transform.position.y <= collision.transform.parent.position.y)
            {

               sprite.sortingOrder = -5;
            }
            else
            {
                sprite.sortingOrder = 5;
            }
        }

    }

    
    

    public void LoadTown()
    {
        //print(scene);
        GMManager.instance.currentScene = SceneManager.GetActiveScene().name;



        SceneManager.LoadScene(scene);
    }


    IEnumerator GetText()
     {
        print("coroutineGetTextSucccc");
        messages.SetActive(true);
        yield return new WaitForSeconds(2);
        messages.SetActive(false);
     }

}

