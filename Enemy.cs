using UnityEngine;
using System.Collections;

public class Enemy : baseclass 
{
	Player p;//гравець
	bool block;//блокування
	NavMeshAgent navM;//об'єкт меш агента
	public float chasingrange;//радіус огляду
	// Use this for initialization
	void Start () 
	{
		p = Player.player;//переініціаліація гравця
		navM = GetComponent<NavMeshAgent> ();//ініціалізація NavMeshAgent
	}

	
	// Update is called once per frame
	void Update () 
	{
		Attack ();//атака
		FollowPlayer ();//слідувати за гравцем
	}
	bool IsInRange(float range)
	{
		if (Vector3.Distance (p.transform.position, transform.position) < range) //коло огляду
        {
			return true;
		} 
		else 
		{
			return false;
		}
	}
	void FollowPlayer()
	{
		if (IsInRange (chasingrange)) 
		{
			navM.SetDestination (p.transform.position);//йдемо за гравцем
		} 
		else 
		{
			navM.SetDestination(transform.position);//повертаємось назад
		}
	}
	//Функція, що зменшує здоров'я ворога, 
	//на величину пошкоджень від гравця

	void OnMouseOver()
	{
		Player.opponent = transform;
	}
	protected override void Attack()
	{
		if (IsInRange(range)) 
		{
			if(!block)
			{
				p.GetHit(damage);//отримати пошкодження
				block = true;// блокувати удар
				Invoke("UnBlock",attckSpeed);//розблокувати після завершення атаки
			}
		}
	}
	void UnBlock()
	{
		block = false;
	}
}
