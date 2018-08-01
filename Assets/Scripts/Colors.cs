using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour {

    public Text rm1;
    public Text rm2;
    public GameObject linza;
    public Material no;
    public Material red;
    public Material green;
    public Material blue;
    public Material yellow;
    public GameObject spot;

    // Update is called once per frame
    public void Click(Button btn)
    {       

        float r1 = 0;
        float r2 = 0;
        
        Vector3 scale = linza.transform.localScale;
        var color = spot.GetComponent<Renderer>().material.color;
        if (btn.name == "red")
        { 
            r1 = 29.5f;
            r2 = 42f;
            linza.GetComponent<Renderer>().material = red;
            scale.x = 3.5f;
            scale.y = scale.x;
            color.r = 255;
            color.g = 0;
            color.b = 0;
            
        }

        if (btn.name == "yellow")
        {
            r1 = 27f;
            r2 = 38f;
            linza.GetComponent<Renderer>().material = yellow;
            scale.x = 3.2f;
            scale.y = scale.x;
            color.r = 255;
            color.g = 255;
            color.b = 0;
        }
        if (btn.name == "green")
        {
            r1 = 25.8f;
            r2 = 36.4f;
            scale.x = 3.0f;
            scale.y = scale.x;
            linza.GetComponent<Renderer>().material = green;
            color.r = 0;
            color.g = 255;
            color.b = 0;
        }
        if (btn.name == "blue")
        {
            scale.x = 2.8f;
            scale.y = scale.x;
            r1 = 24.2f;
            r2 = 33.6f;
            linza.GetComponent<Renderer>().material = blue;
            color.r = 0;
            color.g = 0;
            color.b = 255;
        }

        if (btn.name == "off")
        {
            linza.GetComponent<Renderer>().material = no;
            scale.x = 3.5f;
            scale.y = scale.x;
            rm1.text = "rm1 = ";
            rm2.text = "rm2 = ";
            color.r = 150;
            color.g = 150;
            color.b = 150;
        }
        else
        {

            /*r = Mathf.Sqrt(l*1000000000*R/100);
            r = r / 1000000;
            float r2 = r * Mathf.Sqrt(2);
            r1.text = "r1 = " + r + " мм" + r2 +"мм";
            Rtext.text = "R = " + R + "см";
            */
            r1 += Random.Range(-0.5f, 0.5f);
            r2 += Random.Range(-0.5f, 0.5f);
            linza.transform.localScale = scale;
            rm1.text = "rm1 = " + r1;
            rm2.text = "rm2 = " + r2;
        }
        spot.GetComponent<Renderer>().material.color = color;

    }
}
