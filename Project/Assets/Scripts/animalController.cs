using UnityEngine;
using System.Collections;

public class animalController : MonoBehaviour {

    public int price, wCost, wGain, hRate, cRate, tRate;
    float moveX;
    float moveY;
    Vector3 averagePos;
    int current;
    public GameObject ani;
    public string aniTag;
    public funds scriptB;
    public microFunds scriptA;
    public score scriptC, scriptT, scriptH;
    public notifications scriptX;
    bool owned;

    // Use this for initialization
    void Start () {
        moveX = 0.5f;
        moveY = 0.5f;
        current = 0;
        /*
        GameObject b = GameObject.Find("Funds");
        scriptB = b.GetComponent<funds>();
        GameObject a = GameObject.Find("MicroFunds");
        scriptA = a.GetComponent<microFunds>();
        GameObject c = GameObject.Find("cScore");
        scriptC = c.GetComponent<score>();
        GameObject t = GameObject.Find("tScore");
        scriptT = t.GetComponent<score>();
        GameObject h = GameObject.Find("hScore");
        scriptH = h.GetComponent<score>();
        */
        float rdm1 = Random.Range(-2.0f, 2.0f);
        float rdm2 = Random.Range(-2.0f, 2.0f);
        averagePos = new Vector3(rdm1, rdm2, 0.0f);
        owned = false;        
    }
	
	// Update is called once per frame
	void Update () {
        current++;
        if (current == 100) {
            moveX = Random.Range(-1.0f, 1.0f);
            moveY = Random.Range(-1.0f, 1.0f);
            current = 0;
        }
	}

    public void create() {
        //instantiate animal
        Instantiate(ani, averagePos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        scriptB.change(-price);
        scriptB.changeWeeklyCost(wCost);
        scriptB.changeWeeklyGain(wGain);
        scriptC.change(cRate);
        scriptT.change(tRate);
        scriptH.change(hRate);
        /*
        scriptX.changeText("Test Button");
        scriptX.makeVis();
        */
        if (!owned)
        {
            InvokeRepeating("calcAvPos", 0.0f, 120.0f);
            owned = true;
        }
    }

    public void rescueCreate()
    {
        Instantiate(ani, averagePos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        scriptB.changeWeeklyCost(wCost);
        scriptB.changeWeeklyGain(wGain);
        scriptC.change(cRate);
        scriptT.change(tRate);
        scriptH.change(hRate);
        if (!owned)
        {
            InvokeRepeating("calcAvPos", 0.0f, 120.0f);
            owned = true;
        }
    }

    public void microCreate()
    {
        Instantiate(ani, new Vector3(0.0f, 0.0f, -1.0f), new Quaternion( 0.0f, 0.0f, 0.0f, 0.0f));
        scriptA.change(-25);
        scriptB.changeWeeklyCost(wCost);
        scriptB.changeWeeklyGain(wGain);
        scriptC.change(cRate);
        scriptT.change(tRate);
        scriptH.change(hRate);
        if (!owned)
        {
            InvokeRepeating("calcAvPos", 0.0f, 120.0f);
            owned = true;
        }
    }

    public void rem()
    {
        //for some reason using the already defined scripts causes errors
        //no one could find the reason why
        //so just reset into locals here
        GameObject b = GameObject.Find("Funds");
        funds scriptB = b.GetComponent<funds>();
        GameObject a = GameObject.Find("MicroFunds");
        microFunds scriptA = a.GetComponent<microFunds>();
        GameObject c = GameObject.Find("cScore");
        score scriptC = c.GetComponent<score>();
        GameObject t = GameObject.Find("tScore");
        score scriptT = t.GetComponent<score>();
        GameObject h = GameObject.Find("hScore");
        score scriptH = h.GetComponent<score>();
        
        scriptB.changeWeeklyCost(-wCost);
        scriptB.changeWeeklyGain(-wGain);
        scriptC.change(-cRate);
        scriptT.change(-tRate);
        scriptH.change(-hRate);

        scriptX.changeText("Your" + aniTag + " has just died.");
        scriptX.makeVis();
        
    }

    public float getX() {
        return moveX;
    }

    public float getY() {
        return moveY;
    }

    void calcAvPos()
    {
        float x = 0.0f;
        float y = 0.0f;
        int num = 0;
        GameObject[] allAnimals = GameObject.FindGameObjectsWithTag(aniTag);
        if (allAnimals.Length != 0)
        {
            foreach (GameObject a in GameObject.FindGameObjectsWithTag(aniTag))
            {
                num++;
                Vector3 vec3 = a.transform.position;
                x += vec3.x;
                y += vec3.y;
            }

            averagePos.x = x / num;
            averagePos.y = y / num;
            averagePos.z = 0.0f;
        }
        else
        {
            averagePos.x = 0.19f;
            averagePos.y = 0.04f;
        }
    }

    public void deb()
    {
        Debug.Log("log");
    }
}
