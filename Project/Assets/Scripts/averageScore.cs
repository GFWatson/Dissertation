using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class averageScore : MonoBehaviour {

    public Sprite none, one, two, three, four, five;
    int c, t, h, av;
    score scriptC, scriptT, scriptH;
    public Button[] tier2, tier3, tier4;
    public notifications scriptX;
    public funds scriptY;
    bool first, second, third, fourth, fifth;

    // Use this for initialization
    void Start () {
        GameObject c = GameObject.Find("cScore");
        scriptC = c.GetComponent<score>();
        GameObject t = GameObject.Find("tScore");
        scriptT = t.GetComponent<score>();
        GameObject h = GameObject.Find("hScore");
        scriptH = h.GetComponent<score>();
        av = 0;
        foreach (Button a in tier2)
        {
            a.interactable = false;
        }
        foreach (Button a in tier3)
        {
            a.interactable = false;
        }
        foreach (Button a in tier4)
        {
            a.interactable = false;
        }
        first = false; second = false; third = false; fourth = false; fifth = false;
    }
	
	// Update is called once per frame
	void Update () {
        c = scriptC.get();
        t = scriptT.get();
        h = scriptH.get();
        av = (c + t + h) / 3;

        if(av == 0)
        {
            gameObject.GetComponent<Image>().sprite = none;
            first = false; second = false; third = false; fourth = false; fifth = false;
        }
        else if (av == 1 && !first)
        {
            gameObject.GetComponent<Image>().sprite = one;
            first = true; second = false; third = false; fourth = false; fifth = false;
        }
        else if (av == 2 && !second)
        {
            gameObject.GetComponent<Image>().sprite = two;
            scriptX.changeText("Congratulations! You've reached 2 stars!");
            scriptX.makeVis();
            foreach (Button a in tier2)
            {
                a.interactable = true;
            }
            scriptY.changeWeeklyCost(6000);
            scriptY.changeWeeklyGain(6000);
            scriptY.changeMonthly(5000);
            first = false; second = true; third = false; fourth = false; fifth = false;
        }
        else if (av == 3 && !third)
        {
            gameObject.GetComponent<Image>().sprite = three;
            scriptX.changeText("Congratulations! You've reached 3 stars!");
            scriptX.makeVis();
            foreach (Button a in tier3)
            {
                a.interactable = true;
            }
            scriptY.changeWeeklyCost(4000);
            scriptY.changeWeeklyGain(4000);
            scriptY.changeMonthly(3000);
            first = false; second = false; third = true; fourth = false; fifth = false;
        }
        else if (av == 4 && !fourth)
        {
            gameObject.GetComponent<Image>().sprite = four;
            scriptX.changeText("Congratulations! You've reached 4 stars!");
            scriptX.makeVis();
            foreach (Button a in tier4)
            {
                a.interactable = true;
            }
            scriptY.changeWeeklyCost(8000);
            scriptY.changeWeeklyGain(9000);
            scriptY.changeMonthly(2000);
            first = false; second = false; third = false; fourth = true; fifth = false;
        }
        else if (av == 5 && !fifth)
        {
            gameObject.GetComponent<Image>().sprite = five;
            scriptX.changeText("Congratulations! You've reached 5 stars!");
            scriptX.makeVis();
            first = false; second = false; third = false; fourth = false; fifth = true;
        }
    }

}
