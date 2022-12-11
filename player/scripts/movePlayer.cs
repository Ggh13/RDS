using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class movePlayer : player_stats
{
    [Header("SPEEEEEDS")]
    public float _moveSpeed = 2.0f;
    public float _runSpeed = 5.0f;
    [SerializeField] private float _jumpHeight = 1.0f;


    [Header("Additional parameters")]
    [SerializeField] private float _smoothRotate = 0.25f;
    [SerializeField] private float _checkGroundDistance;

    private Vector3 _playerVelocity;
    private bool _isGrounded;
    private bool _isStaminaRecovery;

    [Header("References")]
    [SerializeField] private Transform _thisTransform;
    [SerializeField] private CharacterController characterController;

    private float _currentSpeed;
    private float _currentStamina;

    public Animator blackDeathBackround;
    public Animator my_anim;

    public const float gravity = -9.81f;

    [Header("cameraControllerIntoPlayer")]
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Vector2 rotation = Vector2.zero;

    public bool canMove = true;


    [Header("Attack")]
    public GameObject enemy;
    public float timer;
    public float cdAttack;
    public int damage;
    public int enemyHp;

    public Color32 panelHP;
    public float alpha = 0;
    public Image panel;
    public Slider hp_slider;
    public GameObject swapSword;
    public GameObject walkSound;
    public GameObject runSound;
    public bool dead = false;
    
    public GameObject spawnPoint;

    public GameObject[] swordSound;
    private void Start()
    {
        dead = false;
        swapSword.SetActive(false);
        _currentSpeed = _moveSpeed;
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }
    private void Update()
    {

        alpha = ((float)hp / (float)maxHp);
        panelHP.a = (System.Byte)alpha;
        panel.color = new Color32(255, 0,0, (System.Byte)(255 - alpha * 255));

    }
    private void FixedUpdate()
    {
            //*** Проверка на земле ли персонаж
            Vector3 moveDirection = Vector3.zero;


            hp_slider.value = hp;
            stamina_slider.value = stamina;

            _isGrounded = CheckGround();

            if (_isGrounded)
            {
                _playerVelocity.y = 0f;
            }

            //***

            //*** Блок с ускорение персонажа
            stamina_res();
            if (Input.GetKey(KeyCode.LeftShift) && stamina >= exp_run)
            {
                stamina -= exp_run;
                _currentSpeed = _runSpeed;
                my_anim.SetInteger("goState", 2);
                walkSound.SetActive(false);
                runSound.SetActive(true);
            }
            else
            {
                //stamina += stamina_res_count;
                _currentSpeed = _moveSpeed;
                my_anim.SetInteger("goState", 1);
                walkSound.SetActive(true);
                runSound.SetActive(false);
            }




            //***

            //*** Блок с передвижением персонажа



            moveDirection = Vector3.zero;
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);


            //ector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 forward = transform.forward;
            // Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 right = transform.right;
            float inputVertical = Input.GetAxis("Vertical");
            float inputHorizontal = Input.GetAxis("Horizontal");

            if (inputVertical + inputHorizontal == 0)
            {
                walkSound.SetActive(false);
                runSound.SetActive(false);
            }

            float curSpeedX = _isGrounded ? _moveSpeed * inputVertical : 0;
            float curSpeedY = _isGrounded ? _moveSpeed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);




            if (moveDirection != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

                Quaternion deltaRotate = Quaternion.Lerp(_thisTransform.rotation, desiredRotation, _smoothRotate);

                _thisTransform.rotation = deltaRotate;

            }
            else
            {
                my_anim.SetInteger("goState", 0);
            }


            characterController.Move(moveDirection * _currentSpeed + new Vector3(0, gravity, 0));

            //***

            //*** Блок с прыжком персонажа

        
            //Debug.Log(timer.ToString() + " " + Time.time.ToString() + "   " + (timer < Time.time).ToString() + "  " + (enemy != null).ToString());
            if (Input.GetMouseButtonDown(0) && timer < Time.time && enemy != null && stamina >= punchStamina)
            {
                swapSword.SetActive(false);
                swapSword.SetActive(true);
                timer = Time.time + cdAttack;
                my_anim.SetTrigger("attack");
            StartCoroutine(swapBom());
                enemy.GetComponent<base_totem>().hp -= damage;
                my_anim.SetTrigger("attack");
                enemyHp = enemy.GetComponent<base_totem>().hp;
            }


            //***
        }

        private bool CheckGround()
        {
            var ray = new Ray(_thisTransform.position, -_thisTransform.up);

            return Physics.Raycast(ray, _checkGroundDistance);
        }



        public void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name + "   " + other.gameObject.tag);
            if (other.gameObject.tag == "totem")
            {
                if (other.gameObject.GetComponent<base_totem>())
                {
                    enemy = other.gameObject;
                }
                else
                {
                    enemy = other.gameObject.transform.parent.gameObject;
                }

            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "totem")
            {
                if (other.gameObject.GetComponent<base_totem>())
                {
                    enemy = null;
                }
                else
                {
                    if (other.gameObject.transform.parent.gameObject.GetComponent<base_totem>())
                    {
                        enemy = null;
                    }

                }

            }
        }
        public void stamina_res()
        {
            if (stamina < stamina_res_count)
                stamina = stamina_res_count;
            else if (stamina > max_stamina)
            {
                stamina = max_stamina;
            }

            if (last_stamina > stamina)
            {
                res = false;
                timer_stamina = Time.time + timer_res_stamina;
                last_stamina = stamina;
            }
            else if (timer_stamina <= Time.time)
            {
                last_stamina = stamina;
                res = true;
                stamina += stamina_res_count;

            }
        }
    public void allOffSounds()
    {
        for (int i = 0; i < swordSound.Length; i++)
        {
            swordSound[i].SetActive(false);
        }
        
    }

    
    public IEnumerator swapBom()
    {
        yield return new WaitForSeconds(0.7f);
        allOffSounds();
        swordSound[Random.Range(0, swordSound.Length)].SetActive(true);
    }
}
