using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float height = 20;//висота
	public float radius = 10;//радіус
	public float angle = 12;//кут
	public float rotationalSpeed = 1;//швидкість повороту
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		
		float cameraX = target.position.x + (radius * Mathf.Cos(angle));//фіксація х координати
		float cameraY = target.position.y + height;//y
		float cameraZ = target .position.z + (radius * Mathf.Sin(angle));//z
		
		if (Input.GetKey(KeyCode.Q))
		{
			angle = angle - rotationalSpeed * Time.deltaTime;//якщо натиснута Q змінюємо кут(поворот камери вліво)
			
		}
		else if (Input.GetKey(KeyCode.E))
		{
			angle = angle + rotationalSpeed * Time.deltaTime;//якщо натиснута E (поворот направо)
		}
		transform.position  = new Vector3(cameraX, cameraY, cameraZ);// зберігаємо змінену позицію
		transform.LookAt (target.position);//дивимось на гравця
	}
}