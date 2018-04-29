using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayManager : MonoBehaviour
{
    public MusicPlayer MP;

    public Text ScoreText;
    public int CurrentScore = 0;

    public Text fevertext;

    public Image[] Healthbar = new Image[2];
    public float HealthScore = 100.0f;

    public Image FeverGage;
    public float FeverScore = 0;
    public int FeverBlock = 0;
    public bool isDecreasing = false;

    public GameObject[] FeverBlockObject = new GameObject[4];
    public Transform Judge_Parent;
    public GameObject Judge_Perfect;

    public Image[] FeverGrid = new Image[4];

    
	// Use this for initialization  
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FeverGage.fillAmount = (float)FeverScore / 100f;
        if (FeverScore >= 100)
        {
            if (FeverBlock < 4)
            {
                if (!isDecreasing)
                {
                    StartCoroutine(Fever_Scaler(FeverBlockObject[FeverBlock]));
                    StartCoroutine(FeverScore_Dncrease(100));
                    FeverBlock++;
                }
            }
            else
                FeverScore = 100f;
        }
        ScoreText.text = CurrentScore.ToString();
        fevertext.text = FeverScore.ToString();
        if (HealthScore > 0)
        {
            HealthScore -= 0.05f;
            Healthbar[0].fillAmount = (float)HealthScore / 100f;
            Healthbar[1].fillAmount = (float)HealthScore / 100f;
        }

    }
    public void AddScore(int score)
    {
        CurrentScore += score;

        StartCoroutine(FeverScore_Increase((score/10)));

        HealthScore += score / 10f;
        if (HealthScore > 100)
            HealthScore = 100;
        if (score == 100)
        {
            StartCoroutine(Scaler());
        }
        return;
    }

    public void StartGame()
    {
        MP.PlayMusic();
        
    }
    
    public void EndSong()
    {

    }
    IEnumerator Scaler()
    {
        GameObject ScoreImage = Instantiate(Judge_Perfect, new Vector3(0, 0, 0), Quaternion.identity);
        ScoreImage.transform.SetParent(Judge_Parent);
        ScoreImage.transform.localScale = new Vector3(0, 0, 0);
        ScoreImage.transform.localPosition = new Vector3(0, 180, 0);

        float f = 0;
        while (f < 1)
        {
            ScoreImage.transform.localScale = new Vector3(f, f, f);
            f = f + 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1.5f);

        Destroy(ScoreImage);
        yield break;
    }
    IEnumerator Fever_Scaler(GameObject obj)
    {
        float f = 0;
        while (f < 1)
        {
            obj.transform.localScale = new Vector3(f, f, f);
            f = f + 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    IEnumerator Fever_deScaler(GameObject obj)
    {
        float f = 1;
        while (f > 0)
        {
            obj.transform.localScale = new Vector3(f, f, f);
            f = f - 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }

    IEnumerator FeverScore_Increase(int score)
    {
        for(int i=0;i<score;i++)
        {
            yield return new WaitWhile(() => isDecreasing);
            FeverScore++;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    IEnumerator FeverScore_Dncrease(int score)
    {
        isDecreasing = true;
        for (int i = 0; i < score; i++)
        {
            FeverScore--;
            yield return new WaitForSeconds(0.01f);
        }
        isDecreasing = false;
    }

}
