using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	//Fuerza de Velociodad
	public float moveSpeed;

	//Reiniciar la velocidad del jugador al morir
	private float moveSpeedStore;
	//Multiplicador de velocidad
	public float speedMultiplier;

	//Incrementador de velocidad
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;

	//Contadores de velocidad
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	//Cuando este en el piso se detendra el salto
	private bool stoppedJumping;

	//Doble Salto
	private bool canDoubleJump;

	//Fuerza deSalto
	public float jumpForce;
	//Momentum para el salto
	public float jumpTime;
	private float jumpTimeCounter;

	//mi RigidBody
	private Rigidbody2D myRigidBody;

	//detecta si esta en el suelo
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform goundCheck;
	public float goundCheckRadius;

	//private Collider2D myCollider;

	private Animator myAnimator;

	//GameManager
	public GameManager theGameManager;

	//Efectos de sonido
	public AudioSource jumpSource;
	public AudioSource deathSource;

	// Use this for initialization
	void Start () {
	
		myRigidBody = GetComponent<Rigidbody2D>(); 

		//myCollider = GetComponent<Collider2D>();

		myAnimator = GetComponent<Animator>();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		//Reiniciar la velocidad del jugador al morir
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

		//Basicamente, toma si el player esta tocando el ground, si es asi, grounded es true
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle (goundCheck.position, goundCheckRadius, whatIsGround);

		//Aumenta la velocidad en base a la posicion
		if(transform.position.x > speedMilestoneCount){

			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		/*asigno un nuevo vector 2 por que es en 2D y le agrego en el eje x 
		a moveSpeed para que se mueva y myRigidBody.velocity.y para que tome los valores por defecto de y*/
		myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

		//Metodo para saltar
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){

			//Si grounded es true, no permitira el salto infinito, solo saltara si toca el ground
			if(grounded){ 
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSource.Play();
			}

			//Cuando pase esta condicion se resetea el jumptimecounter y se puede hacer un doble salto mejor
			if (!grounded && canDoubleJump) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSource.Play();
			}
		}

		//Con que solo se presione la tecla le da momentum
		if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping){

			if(jumpTimeCounter > 0){

				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		//Cancelar el momentun, si lo quito puedo hacer que salte dos veces
		if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButton (0)) {

			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		//Reiniciar el momentum
		if(grounded){

			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		//Con esto determino la velocidad del aniamtor en base a la del eje x
		myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
		//Aca Uso el metodo grounded para que en el aniamtor pueda usar la animacion
		myAnimator.SetBool ("Grounded", grounded);
	}

	//Al tocar algun objeto con el tag killbox, hara que se active la corotina y empieza el juego de nuevo	
	void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.tag == "killbox") {

			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSource.Play ();
		}
	}
}
