using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;


public class SelectManager : MonoBehaviour
{
    enum stages {stage1, stage2, stage3, stage4};


    public ImageEffects imageef;
    public Animator ani;

    public AudioSource BGsound;

    public Image ShinyBG;

    public GameObject Tea_cup;
    public GameObject Stage_Symbol;
    public GameObject Score_Rank;
    public GameObject Score_Reward;
    public GameObject Song_Title;
    public GameObject Song_artist;  

    public int currentSelectedStage ;

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SelectStage()
    {
        //imageef.Trigger_Fading(Stage_Symbol);
        StartCoroutine(LoadStage());
    }

    IEnumerator LoadStage()
    {
        StartCoroutine(OffMusic());
        ani.SetTrigger("Tri");
        yield return new WaitForSeconds(1.0f);

        yield return new WaitForSeconds(3.0f);

        AsyncOperation operation = SceneManager.LoadSceneAsync("PlayScene");

        yield break;
    }

    IEnumerator OffMusic()
    {
        while(BGsound.volume>0)
        {
            BGsound.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
