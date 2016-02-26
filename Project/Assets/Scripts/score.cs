using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public Sprite none, one, two, three, four, five;
    int currentScore, currentImage;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().sprite = one;
        currentScore = 5;
        currentImage = 1;
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentScore <= 0 && currentImage != 0)
        {
            currentImage = 0;
            gameObject.GetComponent<Image>().sprite = none;
        }
        else if (currentScore > 0 && currentScore <= 15 && currentImage != 1)
        {
            currentImage = 1;
            gameObject.GetComponent<Image>().sprite = one;
        }
        else if(currentScore > 15 && currentScore <= 70 && currentImage != 2)
        {
            currentImage = 2;
            gameObject.GetComponent<Image>().sprite = two;
        }
        else if (currentScore > 70 && currentScore <= 150 && currentImage != 3)
        {
            currentImage = 3;
            gameObject.GetComponent<Image>().sprite = three;
        }
        else if (currentScore > 150 && currentScore <= 250 && currentImage != 4)
        {
            currentImage = 4;
            gameObject.GetComponent<Image>().sprite = four;
        }
        else if (currentScore > 250 && currentImage != 5)
        {
            currentImage = 5;
            gameObject.GetComponent<Image>().sprite = five;
        }
    }

    public void change(int num)
    {
        currentScore += num;
    }

    public int get()
    {
        return currentImage;
    }
}
