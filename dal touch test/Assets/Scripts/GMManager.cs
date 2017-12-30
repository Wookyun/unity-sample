using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GMManager : MonoBehaviour
{
    [SerializeField] string gameID = "1646473";
    public static GMManager instance = null;
    public int gameLevel;
    public string currentScene;
    public bool HomeDoor, TheaterDoor,townDoor, SchoolDoor, HospitalDoor, PoliceDoor, SecretBuildingDoor, LocalStationDoor,Apt1Door;


    
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Advertisement.Initialize(gameID, true);

        gameLevel = 1;
        HomeDoor = false;
        TheaterDoor = false;
        HospitalDoor = false;
        PoliceDoor = false;
        SecretBuildingDoor = false;
        LocalStationDoor = false; 

    }

    // Update is called once per frame
    void Update()
    {

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



}

