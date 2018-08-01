using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EventScript : MonoBehaviour{
    public GameObject lazer;
    public GameObject lazeralpha;
    public GameObject forred;
    public GameObject foralpha;
    public GameObject onoff;
    public GameObject linza;
    public GameObject allow;
    public Slider slider;
    public TextMesh Text;
    public Text Textnew;

    Color color;
    public int rotationstateonoff = 1;
    int anglcounter = 0;
    Quaternion rotationZ;

    public GameObject camera1;
    Vector3 targetposition;
    Vector3 position;
    float scrollSpeed = 3.0f;
    float zoomMin = 0.7f;
    float zoomMax = 10.0f;
    float distance;



    private void Start()
    {
        color = lazeralpha.GetComponent<Renderer>().material.color;
        targetposition = linza.transform.position;//для камеры
    }


    public void MoveLinza(float value)//функция передвижения линзы
    {
        Vector3 position = linza.transform.localPosition;//текущая позиция линзы
        position.z = value;//задаем новое положение по оси Z200
        linza.transform.localPosition = position;//применяем изменени       
        Vector3 lr = forred.transform.localScale;//текущий размер правого луча
        lr.y = (35 - value) / 1.95f+ 3f;//задаем новую длину
        forred.transform.localScale = lr;//применяем изменеия 
        Vector3 ll = foralpha.transform.localScale;//текущий размер второго луча
        ll.y = 20.8f-(-value/ 2.5f - 3f);//задаем новую длину
        foralpha.transform.localScale = ll;//применяем изменеия 
    }

    public void RotatLinza(float val)
    {
        allow.transform.localRotation = Quaternion.Euler(-val*10, 90, 90);
        if (rotationstateonoff == 3) displayval(val);
        Textnew.text = (90-(-val*10)).ToString();
    }

    void displayval(float val)
    {
        float rezult = 0;

        if (val == -9)
        {
            // Text.text = "0.226 A";
            rezult = Random.Range(0.224f, 0.228f);
            //Text.text = Mathf.Round(Random.Range(0.224f, 0.228f)).ToString() + " A";
            color.a = 1f;
        }

        if (val == -8)
        {
            color.a = 0.9f;
            //Text.text = "0.221 A";
            rezult = Random.Range(0.219f, 0.223f);
            //Text.text = Random.Range(0.219f, 0.223f).ToString() + " A";
        }
        if (val == -7)
        {
            color.a = 0.8f;
            // Text.text = "0.202 A";
            rezult = Random.Range(0.190f, 0.210f);
            //Text.text = Random.Range(0.190f, 0.210f).ToString() + " A";
        }
        if (val == -6)
        {
            rezult = Random.Range(0.190f, 0.210f);
            color.a = 0.7f;
            //Text.text = "0.169 A";
            //Text.text = Random.Range(0.190f, 0.210f).ToString() + " A";
        }

        if (val == -5)
        {
            color.a = 0.6f;
            rezult = Random.Range(0.110f, 0.140f);
            //Text.text = "0.133 A";
            //Text.text = Random.Range(0.110f, 0.140f).ToString() + " A";
        }
        if (val == -4)
        {
            color.a = 0.5f;
            rezult = Random.Range(0.075f, 0.105f);
            // Text.text = "0.095 A";
            Text.text = Random.Range(0.075f, 0.105f).ToString() + " A";
        }
        if (val == -3)
        {
            color.a = 0.4f;
            rezult = Random.Range(0.030f, 0.070f);
            //Text.text = "0.053 A";
           // Text.text = Random.Range(0.030f, 0.070f).ToString() + " A";
        }
        if (val == -2)
        {
            color.a = 0.3f;
            rezult = Random.Range(0.010f, 0.028f);
            //Text.text = "0.023 A";
            //Text.text = Random.Range(0.010f, 0.028f).ToString() + " A";
        }
        if (val == -1)
        {
            color.a = 0.2f;
            rezult = Random.Range(0.003f, 0.008f);
            //Text.text = "0.004 A";
            //Text.text = Random.Range(0.003f, 0.008f).ToString() + " A";
        }
        if (val == 0)
        {
            color.a = 0.1f;
            rezult = Random.Range(0.001f, 0.002f);
            //Text.text = "0.001 A";
            //Text.text = Random.Range(0.001f, 0.002f).ToString() + " A";
        }
        print(rezult);
        rezult *= 1000;
        print(rezult);
        float res = (int)rezult;
        print(res);
        res /= 1000;
        print(res);
        Text.text = res.ToString() + " A";
        lazeralpha.GetComponent<Renderer>().material.color = color;
    }

    public void ClickOnOff()
    {
        if (rotationstateonoff == 1)
        {
            rotationstateonoff = 2;
            rotationZ = Quaternion.AngleAxis(2, Vector3.forward);
        }

        if (rotationstateonoff == 3)
        {
            rotationstateonoff = 4;
            rotationZ = Quaternion.AngleAxis(2, Vector3.back);
            Text.text = "";
        }


    }
    
    void FixedUpdate()
    {
        
        if (rotationstateonoff == 2)
        {      
            onoff.transform.rotation *= rotationZ;
            anglcounter++;
            if (anglcounter >= 30)
            {
                rotationstateonoff = 3;
                lazer.SetActive(true);
                lazeralpha.SetActive(true);
                displayval(slider.value);
                anglcounter = 0;
            }
        }


        if (rotationstateonoff == 4)
        {
            Quaternion rotationZ = Quaternion.AngleAxis(2, Vector3.back);
            onoff.transform.rotation *= rotationZ;
            anglcounter++;
            if (anglcounter >= 30)
            {
                rotationstateonoff = 1;
                lazer.SetActive(false);
                lazeralpha.SetActive(false);
                anglcounter = 0;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            distance = Vector3.Distance(camera1.transform.position, targetposition);
            distance = ZoomLimit(distance - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, zoomMin, zoomMax);
            position = -(camera1.transform.forward * distance) + targetposition;
            camera1.transform.position = position;

        }

    }
    public static float ZoomLimit(float dist, float min, float max)

    {
        if (dist < min) dist = min;
        if (dist > max) dist = max;
        return dist;
    }


}
