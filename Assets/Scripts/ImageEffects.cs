using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger_Fading(GameObject targetobj)
    {
        StartCoroutine(Fading(targetobj));
    }

    public void Trigger_Showing(GameObject targetobj)
    {
        StartCoroutine(Showing(targetobj));
    }

    IEnumerator Showing(GameObject targetobj)
    {
        targetobj.SetActive(true);
        Color tempcolor = targetobj.GetComponent<Image>().color;
        float f = 0;

        while (true)
        {
            Debug.Log(f);
            if (f >= 1)
                break;
            targetobj.GetComponent<Image>().color = Color.Lerp(tempcolor, new Color(0, 0, 0, 1), f);
            f += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }

    IEnumerator Fading(GameObject targetobj)
    {
        Color tempcolor = targetobj.GetComponent<Image>().color;
        float f = 0;
        while (true)
        {
            if (f >= 1)
                break;
            targetobj.GetComponent<Image>().color = Color.Lerp(tempcolor, new Color(255, 255, 255, 0), f);
            f += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        targetobj.SetActive(false);
        yield break;
    }
}