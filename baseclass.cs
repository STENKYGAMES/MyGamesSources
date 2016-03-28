using UnityEngine;
using System.Collections;

public abstract class baseclass : MonoBehaviour 
{
	public int maxhealth = 1000;//максимальне здоров'я
	public int health;//поточне
	public int damage;//пошкодження
	public float range;//радіус
	public float attckSpeed = 3f;//швидкість атаки
	public void GetHit(int playerDamage)
	{
		health = health - playerDamage;//зміна здоров'я
	}
	protected abstract void Attack();//атака
}