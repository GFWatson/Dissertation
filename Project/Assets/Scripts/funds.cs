using UnityEngine;
using System.Collections;

public class funds : MonoBehaviour {

    int money, microMoney, weeklyCost, weeklyGain, monthlyGain;
    UnityEngine.UI.Text textref;
    public notifications scriptX;
    public AudioClip song;

	// Use this for initialization
	void Start () {
        money = 100000;
        microMoney = 50;
        weeklyCost = 6500;
        weeklyGain = 4000;
        monthlyGain = 25000;
        textref = GetComponent<UnityEngine.UI.Text>();
        //if this throws an error ignore it, no actual error hence why you can see funds at start
        textref.text = money.ToString();
        InvokeRepeating("weeklyC", 10.0f, 60.0f);
        InvokeRepeating("weeklyG", 20.0f, 60.0f);
        InvokeRepeating("monthlyG", 240.0f, 240.0f);
        InvokeRepeating("musicLoop", 0.0f, 15.9f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void change(int num)
    {
        money += num;
        textref.text = money.ToString();
    }

    public void changeMicro(int num)
    {
        microMoney += num;
    }

    public void changeWeeklyCost(int num)
    {
        weeklyCost += num;
    }

    public void changeWeeklyGain(int num)
    {
        weeklyGain += num;
    }

    public void changeMonthly(int num)
    {
        monthlyGain += num;
    }
    
    void weeklyC()
    {
        change(-weeklyCost);
        textref.text = money.ToString();
        scriptX.changeText("You have just paid " + weeklyCost + " in bills.");
        scriptX.makeVis();
    }

    void weeklyG()
    {
        change(weeklyGain);
        textref.text = money.ToString();
        scriptX.changeText("You have earned " + weeklyGain + " this week from tourism.");
        scriptX.makeVis();
    }

    void monthlyG()
    {
        change(monthlyGain);
        textref.text = money.ToString();
        scriptX.changeText("You have just recieved " + monthlyGain + " in grants from charities.");
        scriptX.makeVis();
    }

    void musicLoop()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(song, 1.0f);
    }
}
