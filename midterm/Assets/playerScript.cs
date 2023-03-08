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
    float remainTime = 60;
    //counters and display
    float goldEat = 0;
    public TMP_Text goldCounter;
    public TMP_Text timer;

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
    }
    //robot eating gold
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("fuel"))
        {
            Destroy(other.gameObject);
            goldEat = goldEat + 1;
            goldCounter.text = goldEat.ToString();

        }
    }
}
