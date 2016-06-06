using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class notifications : MonoBehaviour {

    CanvasGroup b;
    public AudioClip tap;

	// Use this for initialization
	void Start () {
        b = this.GetComponent<CanvasGroup>();
        makeInvis();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void makeVis()
    {
        b.alpha = 1;
        b.interactable = true;
        
    }

    public void makeInvis()
    {
        b.alpha = 0;
        b.interactable = false;
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void changeText(string t)
    {
        this.GetComponentInChildren<Text>().text = t;
    }
}
