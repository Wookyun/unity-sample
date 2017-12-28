using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Theater : MonoBehaviour {

    //Canvas canva;
    public VideoPlayer video;
    private GameObject goCanva, goSelect;

    // Use this for initialization
    void Start () {
        // canva = gameObject.GetComponent<Canvas>();
        //canva.enabled = true;
        goCanva = GameObject.Find("CanvasTheater");
        goSelect = goCanva.transform.Find("Select").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToTown()
    {
        SceneManager.LoadScene("town");
    }

    public void WatchMovie()
    {
        goSelect.SetActive(false);
        print("fff");
        video.Play();
        video.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        player.Stop();
        goSelect.SetActive(true);

    }


}

