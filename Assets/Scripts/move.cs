using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;
using UnityEngine;


public class move : MonoBehaviour {

    //объявление переменных для связывания с объектами
    public Camera maincamera;//главная камера
    public Camera camera1;//камера первой лабораторной работы
    public Camera camera2;//камера второй лабораторной работы
    public Camera camera3;//камера третьей лабораторной работы
    public Canvas can1;//интефейс первой лабораторной работы
    public Canvas can2;//интефейс второй лабораторной работы
    public Canvas can3;//интефейс третьей лабораторной работы
    public Canvas can4;//интефейс третьей лабораторной работы

    public bool ready = false;//находится ли пользователь возле установки
    public bool intoexp = false;//выполняет ли пользователь лабораторную работу
    

    RaycastHit hit;//луч, для начала выполнения лабораторной работы
    
    void Start ()//перед запуском лаборатории
    {
        Cursor.visible = false;//отключаем курсор мыши
        camera1.enabled = false;//отключаем первый интерфейс
        camera2.enabled = false;//отключаем второй интерфейс
        camera3.enabled = false;//отключаем третий интерфейс
        can1.enabled = false;//отключаем первый интерфейс
        can2.enabled = false;//отключаем второй интерфейс
        can3.enabled = false;//отключаем третий интерфейс
        can4.enabled = false;//отключаем третий интерфейс
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        if (Input.GetKeyDown(KeyCode.E)&&ready)//при нажатии клавиши E
        {
            if (!intoexp)
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000))//посылаем луч
                {
                    if (hit.transform.name == "Cube2")//если луч попал в коллайдер первой работы
                    {
                        intoexp = true;//работа выполняется
                        camera1.enabled = true;//включается камера первой работы
                        maincamera.enabled = false;//выключается главная камера
                        Cursor.visible = true;//включается курсор
                        can1.enabled = true;//включается интерфейс первой работы
                    }
                    if (hit.transform.name == "Cubemicro")//если луч попал в коллайдер второй работы
                    {
                        intoexp = true;//работа выполняется
                        camera2.enabled = true;//включается камера второй работы
                        maincamera.enabled = false;//выключается главная камера
                        can2.enabled = true;//включается интерфейс второй работы
                        Cursor.visible = true;//включается курсор
                    }
                    if (hit.transform.name == "Cubelab3")//если луч попал в коллайдер второй работы
                    {
                        intoexp = true;//работа выполняется
                        camera3.enabled = true;//включается камера второй работы
                        maincamera.enabled = false;//выключается главная камера
                        can3.enabled = true;//включается интерфейс второй работы
                        Cursor.visible = true;//включается курсор
                    }
                    print(hit.transform.name);

                }
            }

            else//была нажата клавиша E во время выполнения лабораторной работы
            {
                
                maincamera.enabled = true;//включается главная камера
                camera1.enabled = false;//выключается камера первой работы
                camera2.enabled = false;//выключается камера второй работы
                camera3.enabled = false;//выключается камера третьей работы
                intoexp = false;//работа не выполняется
                Cursor.visible = false;//выключается курсор
                can1.enabled = false;//выключается интерфейс первой работы
                can2.enabled = false;//выключается интерфейс второй работы
                can3.enabled = false;//выключается интерфейс третьей работы
                can4.enabled = false;//выключается интерфейс третьей работы
            }
        }    
    }
    private void OnTriggerEnter(Collider other)//при попадании в триггер (бокс-коллайдеры у столов лабораторных)
    {
        ready = true;//пользователь находиться у стола
    }
    private void OnTriggerExit(Collider other)//пры выходе из коллайдера
    {
        ready = false;//пользователь не находиться у стола
    }
}
