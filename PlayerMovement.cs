using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameManager manager;// об'єкт класу Gamemanager
	public float moveSpeed;//швидкість руху
	public GameObject deathParticles;//частки під час смерті

	private float maxSpeed = 5f; // максимальна швидкість
	private Vector3 input;// ввід з клавіатури

	private Vector3 spawn;// точка респауну

    public int life_count = 3;//к-ть життів

	// Use this for initialization
	void Start () {
		spawn = transform.position; // беремо початкову позицію як точка респауну
	}



	void FixedUpdate () {
		input = new Vector3(Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));//ввід з клавіатури
		if(rigidbody.velocity.magnitude < maxSpeed)// якщо швидкість менша за максимальну
		{
			rigidbody.AddRelativeForce(input * moveSpeed);//збільшуємо її у необхідному напрямку
		}

		if (transform.position.y < -2)// якщо входимо за межі рівня
		{
			Die ();// помираємо
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy")// якщо стикаємося з ворогом
		{
			Die ();//помираємо
            life_count--;
		}
        if (life_count == 0)// якщо життя закінчилося
        {
            lose();//кінець гри
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die ();
            life_count--;
		}
		if (other.transform.tag == "Goal")// якщо це фініш рівня
		{
			GameManager.CompleteLevel();//перехід на наступний рівень
		}
        if (life_count == 0)
        {
            lose();
        }
	}

	void Die()
	{
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));// частинки рухаються вверх
		transform.position = spawn;//респаун
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));//частинки рухаються вверх
	}

    void lose()
    {
        Application.LoadLevel("MainMenu");// завантаження початкового рівня
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10,10,150,50), "Life: " + life_count);// вивід на екран к-ті життів
    }
}
