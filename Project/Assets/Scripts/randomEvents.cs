using UnityEngine;
using System.Collections;

public class randomEvents : MonoBehaviour {

    public funds scriptF;
    public notifications scriptX;
    int lowVan, highVan, lowWea, highWea, lowDis, highDis, poachChance, diseaseChance;

	// Use this for initialization
	void Start () {
        lowVan = 1500; highVan = 3000;
        lowWea = 500; highWea = 1000;
        lowDis = 4000; highDis = 6000;
        poachChance = 80; diseaseChance = 50;
        InvokeRepeating("randomEvent", 180.0f, 180.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void randomEvent()
    {
        bool evnt = false;
        int rnd = Random.Range(0, 5);
        if(rnd < 10)
        {
            evnt = true;
        }
        if (evnt == true)
        {
            int rnd2 = Random.Range(0, 100);
            if (rnd2 < 20)
            {
                vandalism();
            }
            else if (rnd2 >= 20 && rnd2 < diseaseChance)
            {
                disease();
            }
            else if (rnd2 >= 50 && rnd2 < poachChance)
            {
                poaching();
            }
            else if (rnd2 >= 80 && rnd2 < 100)
            {
                weather();
            }
        }
    }

    public void reducePoaching(int num)
    {
        poachChance -= num;
    }

    public void reduceDisease(int num)
    {
        diseaseChance -= num;
    }

    public void reduceDisCosts(int low, int high)
    {
        lowDis = low; highDis = high;
    }

    void vandalism()
    {
        int rnd = Random.Range(lowVan, highVan);
        scriptF.change(-rnd);
        scriptX.changeText("Someone has vandalised your resort. It costs " + rnd + " to repair the damage.");
        scriptX.makeVis();
    }

    void disease()
    {
        int rnd = Random.Range(lowDis, highDis);
        scriptF.change(-rnd);
        scriptX.changeText("Some of your animals have contracted a disease. The vet bills come to " + rnd + ".");
        scriptX.makeVis();
    }
    
    void poaching()
    {
        GameObject ani = GameObject.FindGameObjectWithTag("wrhino");
        if(ani != null)
        {
            ani.GetComponent<animal>().remove();
            scriptX.changeText("A white rhino has been killed by poachers.");
            scriptX.makeVis();
        }
        else
        {
            int rnd = Random.Range(0, 7);
            switch (rnd)
            {
                case 0:
                    ani = GameObject.FindGameObjectWithTag("brhino");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("A black rhino has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
                case 1:
                    ani = GameObject.FindGameObjectWithTag("elephant");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("An elephant has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
                case 2:
                    ani = GameObject.FindGameObjectWithTag("lion");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("A lion has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
                case 3:
                    ani = GameObject.FindGameObjectWithTag("cheetah");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("A cheetah has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
                case 4:
                    ani = GameObject.FindGameObjectWithTag("leopard");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("A leopard has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
                case 5:
                    ani = GameObject.FindGameObjectWithTag("giraffe");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("A giraffe has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
                default:
                    ani = GameObject.FindGameObjectWithTag("zebra");
                    if (ani != null)
                    {
                        ani.GetComponent<animal>().remove();
                        scriptX.changeText("A zebra has been killed by poachers.");
                        scriptX.makeVis();
                    }
                    break;
            }//end switch
            
        }
    }

    void weather()
    {
        int rnd = Random.Range(lowWea, highWea);
        scriptF.change(-rnd);
        scriptX.changeText("A storm has damaged a fence. It costs " + rnd + " to repair.");
        scriptX.makeVis();
    }
}
