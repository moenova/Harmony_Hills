﻿using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using TMPro;
using System;
public class Character : MonoBehaviour
{
    public PathCreator pathCreatorLeft;
    public PathCreator pathCreatorMiddle;
    public PathCreator pathCreatorRight;
    public PathCreator pathCreatorSelected;
    public int position = 0;
    float distanceTravelled;
    private TMP_Text tone_text;
    public int tone = 0;
    public int score = 0;
    void Start()
    {
        pathCreatorSelected = pathCreatorMiddle;
        position = 0;
        tone_text = transform.Find("mark").Find("Text (TMP)").GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        float speed = 20;
        distanceTravelled += speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown("left"))
        {
            if(position == 2)
            {
                pathCreatorSelected = pathCreatorMiddle;
                position = 0;
            } else if (position == 0)
            {
                pathCreatorSelected = pathCreatorLeft;
                position = -2;
            }
        } 
        if (Input.GetKeyDown(KeyCode.JoystickButton8) ||Input.GetKeyDown("right"))
        {
            if(position == -2)
            {
                pathCreatorSelected = pathCreatorMiddle;
                position = 0;
            } else if (position == 0)
            {
                pathCreatorSelected = pathCreatorRight;
                position = 2;
            }
        }
        transform.position = pathCreatorSelected.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreatorSelected.path.GetRotationAtDistance(distanceTravelled);
        if (Input.GetKeyDown(KeyCode.UpArrow) && tone < 2)
        {
            tone += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && tone > -2)
        {
            tone -= 1;
        }
        if (tone == 0)
        { 
            tone_text.text = "";
        }
        else if (tone > 0)
        {
            tone_text.text = new String('+', tone);
        }
        else if (tone < 0) {
            tone_text.text = new String('-', -tone);
        }
    }


    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "music_note")
    //     {
    //         score += 50;
            
    //         //st.text = "Score: " + score.ToString();
    //         //if (score >= max_score)
    //         //{
    //         //    max_score = score;
    //         //    mst.text = "Max Score: " + max_score.ToString();
    //         //}

    //         other.gameObject.GetComponent<Music_Note_scpt>().hit();
    //         Debug.Log("hit111111111111111111111");

    //     }

    // }

}
