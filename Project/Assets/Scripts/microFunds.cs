using UnityEngine;
using System.Collections;

public class microFunds : MonoBehaviour {

    int microMoney;
    UnityEngine.UI.Text textref;

	// Use this for initialization
	void Start () {
        microMoney = 50;
        textref = GetComponent<UnityEngine.UI.Text>();
        textref.text = microMoney.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void change(int num)
    {
        microMoney += num;
        textref.text = microMoney.ToString();
    }
}
