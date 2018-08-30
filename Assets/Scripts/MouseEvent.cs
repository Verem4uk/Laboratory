using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseEvent : MonoBehaviour, IPointerEnterHandler{

    public Text text;
    public Text article;

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("навели на" + gameObject.name);
        
        if (gameObject.name == "1_LR")
        {
            print("пишем текст для" + gameObject.name);
            text.text = "Определение радиуса кривизны линзы путём наблюдения колец Ньютона";
            article.text = "Лабораторная работа №1";
        }
        else if (gameObject.name == "2_LR")
        {
            print("пишем текст для" + gameObject.name);
            text.text = "Получение и исследование поляризованного света";
            article.text = "Лабораторная работа №2";
        }
        else if (gameObject.name == "3_LR")
        {
            print("пишем текст для" + gameObject.name);
            text.text = "Исследование дисперсии стеклянной призмы";
            article.text = "Лабораторная работа №3";
        }
        
    }
    
}
