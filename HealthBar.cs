using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	Image healthbar;
	Player play;
	// Use this for initialization
	void Start () 
	{
		healthbar = GetComponent<Image> ();//відображення здоров'я
		play = Player.player;//переініціалізація гравця
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount,(float)play.health/(float)play.maxhealth,0.25f);//залежно від здоров'я заповнення шкали здоров'я змінюється
	}
}
