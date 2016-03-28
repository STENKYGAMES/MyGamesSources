using UnityEngine;
using System.Collections;

public class Player : baseclass 
{
	public static Transform opponent;// ворог
	public static bool isattack; // чи атакуємо
	public static Player player; // гравець
	public float attackImpact; // нанесення шкоди
	public AnimationClip attackanim; // анімація атаки
	Animation animat;//анімація
	void Awake()
	{
		health = maxhealth;// здоров'я
		player = this;// присвоення гравця
		InitAnim();//ініціалізація анімацій
		isattack = false;
	}
	void InitAnim()
	{
		animat = GetComponent<Animation> ();
		AnimationEvent attackEvent = new AnimationEvent ();// атака
		attackEvent.time = attackImpact;//час коли буде викликатися подія
		attackEvent.functionName = "Impact";//функція що викликається
		attackanim.AddEvent(attackEvent);// додаємо подію
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	void Impact()
	{
		opponent.GetComponent<Enemy>().GetHit(damage);// знімаємо здоров'я опоненту
	}
	
	// Update is called once per frame
	void Update () 
	{
		Attack ();//атака
	}
	protected override void Attack()
	{
		if (Input.GetMouseButtonUp (0)) //якщо зажата ліва клавіша мишки
        {
			if (opponent != null && Vector3.Distance (opponent.position, transform.position) < range) //опонент в радіусі атаки
			{
				isattack = true;
				animat.CrossFade(attackanim.name);//анамація атаки
			}
		} 
		if (!animat.IsPlaying(attackanim.name))
		{
			isattack = false;
		}

	}
}
