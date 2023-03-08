using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScript : MonoBehaviour
{
    //movement and rotation speed, adjustable from the game object
    public float mSpeed;
    public float rSpeed;
    //time remaining
    //counters and display
    float goldEat = 0;
    float timeS = 60;
    public TMP_Text goldCounter;
    public TMP_Text timer;
    //frasier bombs
    public GameObject frasier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player controls
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * mSpeed * vAxis, Space.World);
        gameObject.transform.Rotate(0, rSpeed * Time.deltaTime * hAxis, 0);
        //countdown
        timeS = 60 - Time.time;
        timer.text = timeS.ToString() + " Seconds Left";
        if (timeS <= 0)
        {
            timer.text = "GAME OVER";
        }

    }
    //robot eating gold
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("fuel"))
        {
            Destroy(other.gameObject);
            goldEat = goldEat + 1;
            goldCounter.text = goldEat.ToString() + " Gold Fuel Consumed";


        }
        if (goldEat >= 10)
        {
            goldCounter.text = "Victory!";
        }

        //robot running into wine, will generate Frasier Cubes
        if (other.CompareTag("wine"))
        {
            Destroy(other.gameObject);
            for (int i = 0; i < 4; i++)
            {
                float xPos = Random.Range(-50, 50);
                float zPos = Random.Range(-50, 50);
                GameObject Fraj = Instantiate(frasier, new Vector3(xPos, 20, zPos), transform.rotation);
            }
        }
    }
    
}
