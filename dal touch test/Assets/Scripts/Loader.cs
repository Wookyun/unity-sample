using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Purchasing;

public class Loader : MonoBehaviour {

    [SerializeField] string gameID = "1646473";
    public GameObject gManager;          //GameManager prefab to instantiate.
    private GameObject invencan, querry, invenmenu,pl;
    private GameObject inventory, map;
    static string scene;
    int level;
   // bool door;

    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GMManager.instance == null)
        {
            //Instantiate gameManager prefab
            Instantiate(gManager);
        }

        Advertisement.Initialize(gameID, true);
        invencan = GameObject.FindWithTag("invencanvas");
        querry = invencan.transform.Find("Querry").gameObject;
        inventory = invencan.transform.Find("Inventory").gameObject;
        invenmenu = invencan.transform.Find("InvenMenu").gameObject;
        map = invencan.transform.Find("Map").gameObject;
        level = GMManager.instance.gameLevel;
        //door = GMManager.instance.Apt1Door;

        LevelSet();

        pl = GameObject.Find("Player");

        switch (GMManager.instance.currentScene)
        {
            case ("School"):
        
            
                pl.transform.position = new Vector2(-5.01f, 3.53f);
                break;

            case ("Home"):
                pl.transform.position = new Vector2(-23f, 2.18f);
                break;

            case ("Theater"):
                pl.transform.position = new Vector2(0.17f, -0.3f);
                break;

        }

    }



  

    

    public void DeactiveQuerry()
    {
        querry.SetActive(false);
    }

    public void InvenMenu()
    {

        invenmenu.SetActive(true);
        inventory.SetActive(false);
    }

    public void DeInvenMenu()
    {
        invenmenu.SetActive(false);
        inventory.SetActive(true);
    }

    public void Map()
    {
        map.SetActive(true);
        inventory.SetActive(false);
        invenmenu.SetActive(false);

    }

    public void UnMap()
    {
        map.SetActive(false);
        inventory.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LevelSet()
    {
        if(level == 1)
        {
            GMManager.instance.HomeDoor = true;
            GMManager.instance.TheaterDoor = true;
            GMManager.instance.HospitalDoor = false;
            GMManager.instance.PoliceDoor = false;
            GMManager.instance.LocalStationDoor = false;
            GMManager.instance.SchoolDoor = true;
            GMManager.instance.townDoor = true;
        }
    }


    public void ShowAd(string zone = "")
    {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone, options);
    }

    void AdCallbackhandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Finished. Rewarding player...");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }

    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }



    public void Fulfill(Product product)
    {
        if (product != null)
        {
            switch (product.definition.id)
            {
                case "removeads":
                    Debug.Log("You Removed Ads!");
                    break;
                case "100dia":
                    Debug.Log("You got 100 diamonds!");
                    break;

        
                default:
                    Debug.Log(
                    string.Format("Unrecognized productId \"{0}\"", product.definition.id)
                        );
                    break;
            }
        }
    }

    public void FailPuchase()
    {
        print("falipuchase");
    }
}


