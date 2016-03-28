using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {
	NavMeshAgent nav;// navmeshagent
	public AnimationClip runanimation;//біг
	public AnimationClip idleanimation;//тиша
	Animation anim;//анімація
	// Use this for initialization
	void Start () 
	{
		nav = GetComponent<NavMeshAgent> ();//ініціалізація агента
		anim = GetComponent<Animation> ();//анімації
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();//рух
		Animate ();//анімація
	}
	//Фунція,що виконує рух персонажа.
	//Рух відбувається на те місце терейна, 
	//куди була нажата ліва клавіша миші.
	void Move()
	{
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);// зчитуємо де маємо бути після натискання клавіші миші
		if (Input.GetMouseButtonUp (1)) 
		{
			if(Physics.Raycast(ray,out hit,100))
			{
				nav.SetDestination(hit.point);//йдемо туди
			}
		}
	}
	void Animate()
	{
		if (!(Player.isattack))//якщо не атакуємо
		{
			if (nav.velocity.magnitude > 0.5f) 
			{
				anim.CrossFade (runanimation.name);//біжимо на те місце
			} 
			else 
			{
				anim.CrossFade (idleanimation.name);//інакше стоїмо
			}
		}
	}
}
