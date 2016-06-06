using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buildResearch : MonoBehaviour {

    funds scriptF;
    randomEvents scriptR;
    public GameObject v, r, s, c, b, h;
    public Button vB, rB, sB, cB, bB, hB, vacB;
    public animalController[] controllers;
    public notifications scriptX, scriptY;
    bool res;
    public AudioClip tap;

	// Use this for initialization
	void Start () {
        GameObject f = GameObject.Find("Funds");
        scriptF = f.GetComponent<funds>();
        GameObject r = GameObject.Find("rndEvnt");
        scriptR = r.GetComponent<randomEvents>();
        res = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void vet()
    {
        scriptF.change(-40000);
        Instantiate(v, new Vector3(26.04f, 12.18f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        vB.interactable = false;
        scriptR.reduceDisCosts(3000, 4000);
        scriptX.changeText("You have built a vetinary surgery!");
        scriptX.makeVis();
        scriptY.changeText("Having a vet on site will reduce their costs in case of emergencies and disease.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void ranger()
    {
        scriptF.change(-20000);
        Instantiate(r, new Vector3(26.0f, 7.5f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        rB.interactable = false;
        scriptR.reducePoaching(6);
        scriptX.changeText("You have built a ranger station!");
        scriptX.makeVis();
        scriptY.changeText("A ranger station will help the effort to stop poachers, keeping your animals alive and well.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void staff()
    {
        scriptF.change(-12000);
        scriptF.changeWeeklyCost(1000);
        Instantiate(s, new Vector3(26.0f, 2.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        sB.interactable = false;
        scriptX.changeText("You have built staff quarters!");
        scriptX.makeVis();
        scriptY.changeText("Housing for staff will reduce the running cost of the park, and make sure staff are on hand for emergencies.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void vacc()
    {
        scriptF.change(-48000);
        vacB.interactable = false;
        scriptR.reduceDisease(6);
        scriptX.changeText("You have vaccinated the animals!");
        scriptX.makeVis();
        scriptY.changeText("Vaccinating animals helps to keep the park disease free.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void car()
    {
        scriptF.change(-30000);
        scriptF.changeWeeklyGain(1000);
        Instantiate(c, new Vector3(26.0f, -2.5f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        cB.interactable = false;
        scriptR.reducePoaching(2);
        scriptX.changeText("You now offer a car safari!");
        scriptX.makeVis();
        scriptY.changeText("Tours are key to eco-tourism which not only increases funding for the park but is a great way of generating awareness around the world. Crucially, by boosting the local economy and creating jobs it will also reduce crime in the area, particularly poaching.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void balloon()
    {
        scriptF.change(-40000);
        scriptF.changeWeeklyGain(2000);
        Instantiate(b, new Vector3(26.0f, -6.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        bB.interactable = false;
        scriptR.reducePoaching(3);
        scriptX.changeText("You now offer a balloon safari!");
        scriptX.makeVis();
        scriptY.changeText("Tours are key to eco-tourism which not only increases funding for the park but is a great way of generating awareness around the world. Crucially, by boosting the local economy and creating jobs it will also reduce crime in the area, particularly poaching.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void hotel()
    {
        scriptF.change(-30000);
        scriptF.changeWeeklyGain(2000);
        Instantiate(h, new Vector3(26.0f, -10.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        hB.interactable = false;
        scriptR.reducePoaching(3);
        scriptX.changeText("You have a hotel!");
        scriptX.makeVis();
        scriptY.changeText("A hotel is key to eco-tourism which not only increases funding for the park but is a great way of generating awareness around the world. Crucially, by boosting the local economy and creating jobs it will also reduce crime in the area, particularly poaching.");
        scriptY.makeVis();
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void rescue()
    {
        scriptF.change(-15000);
        int rnd = Random.Range(1, 23);
        controllers[rnd].rescueCreate();
        if (!res)
        {
            scriptY.changeText("By funding animal rescue missions around the world you have introduced new animals into your park. Illegal wildlife trade is estimated to be worth ~$11 billion. A gorilla is estimated to be worth $400,000. It is believed there are more tigers being kept illegally in the US (~5,000) than alive in the wild (~3,000). This trade is the fourth largest illegal industry in the world and has caused the deaths of 1,000 rangers in the past 10 years. Perhaps worst of all, it is a leading cause of animal endangerment and extinction.");
            scriptY.makeVis();
        }
    }
}
