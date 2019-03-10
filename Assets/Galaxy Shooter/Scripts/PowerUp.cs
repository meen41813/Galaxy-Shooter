using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int powerUpID; // 0 = triple 1 = speed 2 = shield

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if(transform.position.y <= -6f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //access the player
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                if(powerUpID == 0)
                {
                    //turn the triple shot bool is true
                    player.TripleShotPowerUpOn();
                }
                else if (powerUpID == 1)
                {
                    //turn the triple shot bool is true
                    player.SpeedBoostPowerUpOn();
                }
                else if (powerUpID == 2)
                {
                    player.ShieldPowerUpOn();
                }


            }
            //destroy our selves
            Destroy(this.gameObject);
        }
    }

}
