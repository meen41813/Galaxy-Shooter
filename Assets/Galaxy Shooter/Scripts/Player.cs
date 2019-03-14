using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool tripleOn = false;
    public bool speedOn = false;
    public bool shieldOn = false;
    public int lives = 3;

    [SerializeField]
    private GameObject _ExplosionPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObj;


    [SerializeField]
    private float _fireRate = 0.23f;
    private float _canFire = 0f;
    //fire rate = 0.25f
    //canfire = has the amount of time between firing passed
    //time.time

    [SerializeField]
    private float _speedBoost = 2.5f;
    [SerializeField]
    private float _speed = 5.0f;

    private UIManager _UIManager;

    void Start()
    {
        //current position = new position
        transform.position = new Vector3(0, 0, 0);

        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_UIManager != null)
        {
            _UIManager.updateLives(lives);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {      
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButton(0)))
        {
            if (Time.time > _canFire)
            {
                if(tripleOn == true)
                {                  
                    Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);                               
                }
                else
                {
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.975f, 0), Quaternion.identity);
                }               
                _canFire = Time.time + _fireRate;
            }
        }
    }

    private void Movement()
    {
        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");  
        if(speedOn == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput * _speedBoost);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput * _speedBoost);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
        }
        
        //player bound setting
        if (transform.position.y <= -4.18f)
        {
            transform.position = new Vector3(transform.position.x, -4.18f, transform.position.z);
        }
        else if (transform.position.y >= 4.18f)
        {
            transform.position = new Vector3(transform.position.x, 4.18f, transform.position.z);
        }
        else if (transform.position.x >= 8.6f)
        {
            transform.position = new Vector3(-8.6f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -8.6f)
        {
            transform.position = new Vector3(8.6f, transform.position.y, transform.position.z);
        }
    }


    public void Damageed()
    {
        if(shieldOn == true)
        {
            shieldOn = false;
            _shieldGameObj.SetActive(false);
            return;
        }
        lives--;
        _UIManager.updateLives(lives);

        if (lives < 1)
        {
            Instantiate(_ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    
    public void TripleShotPowerUpOn()
    {
        tripleOn = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public void SpeedBoostPowerUpOn()
    {
        speedOn = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
    public void ShieldPowerUpOn()
    {
        shieldOn = true;
        _shieldGameObj.SetActive(true);
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        tripleOn = false;
    }
    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speedOn = false;
    }
}
