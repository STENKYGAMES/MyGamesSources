using UnityEngine;

using System.Collections;


public class Play_Door_Anim : Door_Open //наслідуємо з Door_Open
{

    public AnimationClip clip;

	// анімація

    void OnCollisionEnter(Collision other)//якщо заходимо в тригер
    {
        if (other.transform.tag == "Player")// і це гравець
        {
            if (is_key)//і у нас є ключ
            {
                animation.Play(clip.name);//грає анімація
                is_key = false;//ключ знищується
            }
        
	}

    
    }

}
