using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buildResearch : MonoBehaviour {

    funds scriptF;
    randomEvents scriptR;
    public GameObject v, r, s, c, b, h;
    public Button vB, rB, sB, cB, bB, hB, vacB;
    public animalController[] controllers;

	// Use this for initialization
	void Start () {
        GameObject f = GameObject.Find("Funds");
        scriptF = f.GetComponent<funds>();
        GameObject r = GameObject.Find("rndEvnt");
        scriptR = r.GetComponent<randomEvents>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void vet()
    {
        scriptF.change(-40000);
        Instantiate(v, new Vector3(9.04f, 4.18f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        vB.interactable = false;
        scriptR.reduceDisCosts(3000, 4000);
    }

    public void ranger()
    {
        scriptF.change(-20000);
        Instantiate(r, new Vector3(9.11f, 1.24f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        rB.interactable = false;
        scriptR.reducePoaching(6);
    }

    public void staff()
    {
        scriptF.change(-12000);
        scriptF.changeWeeklyCost(1000);
        Instantiate(s, new Vector3(9.14f, 2.77f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        sB.interactable = false;
    }

    public void vacc()
    {
        scriptF.change(-48000);
        vacB.interactable = false;
        scriptR.reduceDisease(6);
    }

    public void car()
    {
        scriptF.change(-30000);
        scriptF.changeWeeklyGain(1000);
        Instantiate(c, new Vector3(9.06f, -1.57f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        cB.interactable = false;
        scriptR.reducePoaching(2);
    }

    public void balloon()
    {
        scriptF.change(-40000);
        scriptF.changeWeeklyGain(2000);
        Instantiate(b, new Vector3(9.27f, -0.43f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        bB.interactable = false;
        scriptR.reducePoaching(3);
    }

    public void hotel()
    {
        scriptF.change(-30000);
        scriptF.changeWeeklyGain(2000);
        Instantiate(h, new Vector3(9.26f, -3.21f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        hB.interactable = false;
        scriptR.reducePoaching(3);
    }

    public void rescue()
    {
        scriptF.change(-15000);
        int rnd = Random.Range(1, 23);
        controllers[rnd].rescueCreate();
    }
}
