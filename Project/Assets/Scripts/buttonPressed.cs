using UnityEngine;
using System.Collections;

public class buttonPressed : MonoBehaviour {

    bool open = false;
    public string inName, outName;
    CanvasGroup herbButton, carnButton, bnrButton, microButton, scoreButton;
    public AudioClip tap;

    void Start()
    {
        GameObject a = GameObject.Find("HerbMenuButton");
        GameObject b = GameObject.Find("CarnMenuButton");
        GameObject c = GameObject.Find("BnRMenuButton");
        GameObject d = GameObject.Find("MicroMenuButton");
        GameObject e = GameObject.Find("ScoreMenuButton");
        herbButton = a.GetComponent<CanvasGroup>();
        carnButton = b.GetComponent<CanvasGroup>();
        bnrButton = c.GetComponent<CanvasGroup>();
        microButton = d.GetComponent<CanvasGroup>();
        scoreButton = e.GetComponent<CanvasGroup>();
    }

	// Update is called once per frame
	public void move() {
	    
        if(open == false)
        {
            //play animation to open menu
            Animator ani = this.GetComponent<Animator>();
            ani.Play(inName);
            open = true;
        }
        else
        {
            //play animation to close menu
            Animator ani = this.GetComponent<Animator>();
            ani.Play(outName);
            open = false;
        }

	}

    public void herbPressed()
    {
        if (open == true)
        {
            carnButton.interactable = false;
            carnButton.alpha = 0;
            bnrButton.interactable = false;
            bnrButton.alpha = 0;
            microButton.interactable = false;
            microButton.alpha = 0;
            scoreButton.interactable = false;
            scoreButton.alpha = 0;
        }
        else
        {
            herbButton.interactable = true;
            herbButton.alpha = 1;
            carnButton.interactable = true;
            carnButton.alpha = 1;
            bnrButton.interactable = true;
            bnrButton.alpha = 1;
            microButton.interactable = true;
            microButton.alpha = 1;
            scoreButton.interactable = true;
            scoreButton.alpha = 1;
        }
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void carnPressed()
    {
        if (open == true)
        {
            herbButton.interactable = false;
            herbButton.alpha = 0;
            bnrButton.interactable = false;
            bnrButton.alpha = 0;
            microButton.interactable = false;
            microButton.alpha = 0;
            scoreButton.interactable = false;
            scoreButton.alpha = 0;
        }
        else
        {
            herbButton.interactable = true;
            herbButton.alpha = 1;
            carnButton.interactable = true;
            carnButton.alpha = 1;
            bnrButton.interactable = true;
            bnrButton.alpha = 1;
            microButton.interactable = true;
            microButton.alpha = 1;
            scoreButton.interactable = true;
            scoreButton.alpha = 1;
        }
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void bnrPressed()
    {
        if (open == true)
        {
            herbButton.interactable = false;
            herbButton.alpha = 0;
            carnButton.interactable = false;
            carnButton.alpha = 0;
            microButton.interactable = false;
            microButton.alpha = 0;
            scoreButton.interactable = false;
            scoreButton.alpha = 0;
        }
        else
        {
            herbButton.interactable = true;
            herbButton.alpha = 1;
            carnButton.interactable = true;
            carnButton.alpha = 1;
            bnrButton.interactable = true;
            bnrButton.alpha = 1;
            microButton.interactable = true;
            microButton.alpha = 1;
            scoreButton.interactable = true;
            scoreButton.alpha = 1;
        }
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void microPressed()
    {
        if (open == true)
        {
            herbButton.interactable = false;
            herbButton.alpha = 0;
            carnButton.interactable = false;
            carnButton.alpha = 0;
            bnrButton.interactable = false;
            bnrButton.alpha = 0;
            scoreButton.interactable = false;
            scoreButton.alpha = 0;
        }
        else
        {
            herbButton.interactable = true;
            herbButton.alpha = 1;
            carnButton.interactable = true;
            carnButton.alpha = 1;
            bnrButton.interactable = true;
            bnrButton.alpha = 1;
            microButton.interactable = true;
            microButton.alpha = 1;
            scoreButton.interactable = true;
            scoreButton.alpha = 1;
        }
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void scorePressed()
    {
        if (open == true)
        {
            herbButton.interactable = false;
            herbButton.alpha = 0;
            carnButton.interactable = false;
            carnButton.alpha = 0;
            bnrButton.interactable = false;
            bnrButton.alpha = 0;
            microButton.interactable = false;
            microButton.alpha = 0;
        }
        else
        {
            herbButton.interactable = true;
            herbButton.alpha = 1;
            carnButton.interactable = true;
            carnButton.alpha = 1;
            bnrButton.interactable = true;
            bnrButton.alpha = 1;
            microButton.interactable = true;
            microButton.alpha = 1;
            scoreButton.interactable = true;
            scoreButton.alpha = 1;
        }
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }
}
