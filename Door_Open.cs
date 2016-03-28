using UnityEngine;

using System.Collections;


public class Door_Open : MonoBehaviour 
{

    protected bool is_key = false;//чи є ключ?
    public GameObject key;
 // сам ключ
    void OnCollisionEnter(Collision other)// заходимо в тригер(точка відкриття дверей)
    {
        if (other.transform.tag == "Key")//якщо це ключ
        {
            is_key = true;//беремо його
            DestroyObject(key);
//знищуємо об'єкт        
	}
    
     }

    void OnGUI()
    {
        GUI.Box(new Rect(10,60,150,50), "Invetar: \n Key: " + is_key);
  // виводимо на екран true або false  
    }

}
