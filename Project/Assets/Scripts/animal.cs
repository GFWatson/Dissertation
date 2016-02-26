using UnityEngine;
using System.Collections;

public class animal : MonoBehaviour {

    int current, current2;
    bool outOfBounds, direction;
    public int moveAmount;
    public animalController scriptB;
    float startTime, moveX, moveY;
    public float deathTime;
    public notifications scriptX;

    void Start() {
        current = 0; current2 = 0;
        startTime = Time.timeSinceLevelLoad;
        outOfBounds = false;
        direction = false;
    }

	// Update is called once per frame
	void Update () {
        //check for death
        float timeSinceStart = Time.timeSinceLevelLoad - startTime;
        
        if(timeSinceStart >= deathTime)
        {
            remove();
        }
        
        //move
        current++;
        if (current == moveAmount && outOfBounds == false && direction == false) {
            int rdm = Random.Range(0, 10);
            if(rdm < 7)
            {
                moveAverage();
            }
            else
            {
                moveRandom();
            }
            //make sure not out of bounds
            current = 0;
            direction = true;
            checkBounds();
        }//keep moving in direction for short time
        else if (current == moveAmount && outOfBounds == false && direction == true)
        {
            move();
            current2++;
            current = 0;
            if(current2 == 5)
            {
                direction = false;
                current2 = 0;
            }
        }//move back into area
        else if (current == moveAmount && outOfBounds == true)
        {
            move();
            current = 0;
            current2++;
            if(current2 <= 10)
            {
                current2 = 0;
                outOfBounds = false;
            }
        }

    }

    public void remove()
    {
        scriptB.rem();
        Destroy(this.gameObject);
    }

    void moveAverage()
    {
        moveX = scriptB.getX() / 25;
        moveY = scriptB.getY() / 25;
        move();
    }

    void moveRandom()
    {
        moveX = Random.Range(-1.0f, 1.0f) / 25;
        moveY = Random.Range(-1.0f, 1.0f) / 25;
        move();
    }

    void move()
    {
        transform.Translate(Vector3.up * moveY, Space.Self);
        transform.Translate(Vector3.right * moveX, Space.Self);
    }

    void checkBounds()
    {
        if (transform.position.x < -11.0f)
        {
            moveX = 0.04f;
            outOfBounds = true;
            direction = false;
        }
        else if (transform.position.x > 6.0f)
        {
            moveX = -0.04f;
            outOfBounds = true;
            direction = false;
        }
        if (transform.position.y > 4.5f)
        {
            moveY = -0.04f;
            outOfBounds = true;
            direction = false;
        }
        else if (transform.position.y < -4.5)
        {
            moveY = 0.04f;
            outOfBounds = true;
            direction = false;
        }
    }

}
