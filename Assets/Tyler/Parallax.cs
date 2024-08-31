using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, posY=1f;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos=transform.position.x;
        length=GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x *(1-parallaxEffect));
        float dist=(cam.transform.position.x*parallaxEffect);
        //Using this line will make the background track the player moves as they move up and down
        // transform.position=new Vector3(startpos+dist, transform.position.y,transform.position.z);
        //Using this line will make the background not track the player as they move up and down
        transform.position=new Vector3(startpos+dist,posY,transform.position.z);
        if(temp>startpos+length)startpos+=length*2;
        else if(temp<startpos-length)startpos-=length*2;
    }
}
