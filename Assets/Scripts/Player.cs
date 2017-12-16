using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	//Transformar
	[SerializeField]Transform spawnPoint;
	[SerializeField]Transform Gamer;
	public Transform spawnPrefab;
	public Transform potionPrefab;
	public Transform damagePrefab;
	public Transform groundCheck;
	public Transform PopUp;
	public Transform player;

	//floats
	public float groundCheckRadius;
	public float velocidade;
	public float jumpPower;
	public float invincibleTime = 3.0f;

	//ints
	public int timerpop;
	public int curHealth;
	public int maxRealth = 5;
	int p;


	//bools
	private bool grounded;
	public bool pular = false;
	private bool  invulnerable = false;

	//etc
	public LayerMask whatIsGround;
	private Potions pt;
	private Animator animator;
	private GUIStyle guiStyle = new GUIStyle();
	private GameObject temporario;
	public Text InvencibleT;





	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);	

		if (grounded == true) {
			animator.SetBool ("ground", true);
		} else {
			animator.SetBool ("ground", false);
			}

	}

	void Start () {
		
		curHealth = maxRealth;
		animator = player.GetComponent<Animator> ();
		pt = GameObject.FindGameObjectWithTag ("potiontext").GetComponent<Potions> ();
	}



	void Update () {
		
		timerpop = PopUp.GetComponent<ButtonsPopUp>().botao;
		if (timerpop == 1) {
			velocidade = 0;
			jumpPower = 0;
			player.GetComponent<Animator>().enabled = false;
		} else {
			player.GetComponent<Animator>().enabled = true;
			animator.SetFloat ("run", Mathf.Abs (Input.GetAxis ("Horizontal")));
			velocidade = 8;
			jumpPower = 8500f;
		}
		if (curHealth > maxRealth) {
			curHealth = maxRealth;
		}
		if(curHealth <= 0){
			Die();
		}
		Movimentar();

		if (Input.GetKeyDown(KeyCode.P)) {
			p++;
		}

		if (p%2 == 0) {
			Time.timeScale = 1f;
		}
			if (p%2 == 1) {
			Time.timeScale = 0f;
		}

	}
	void OnGUI()
	{
		if (p % 2 == 1) {
			guiStyle.fontSize = 80;
			guiStyle.normal.textColor = Color.red;
			guiStyle.normal.background = MakeTex (8, 200, new Color (0f, 1f, 1f, 2f));
			GUI.Label (new Rect (600, 250, 320, 80), "Pausado", guiStyle);

		} else {
		}
	}
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[(width) * height];
		for( int i = 1; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width	, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}


	void Movimentar(){

		animator.SetFloat ("run", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}
		if (grounded == true && ((Input.GetKeyDown (KeyCode.UpArrow)) || (Input.GetKeyDown (KeyCode.Space)))) {

			animator.SetBool ("jump", pular);
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * jumpPower );
			if (Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetKeyDown (KeyCode.Space))) {
				pular = true;
			} else {
				pular = false;
			}
		}
	}
	void Die(){
		SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
	}

	void OnTriggerEnter2D(Collider2D obj)
	{

		if (obj.gameObject.tag == "freefall"){
			Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation);
			Gamer.transform.position = spawnPoint.transform.position;
			curHealth--;
		}

		if (obj.gameObject.tag == "danger") {
			Instantiate (damagePrefab, player.transform.position, player.transform.rotation);
			Gamer.gameObject.transform.Translate(-Vector2.right * 3);
			curHealth--;
		}

		if (obj.gameObject.tag == "potions") {
			Instantiate (potionPrefab, obj.transform.position, obj.transform.rotation);
			pt.npotions++;
			Destroy (obj.gameObject);

		}

		if (obj.gameObject.tag == "bullet") {
			Instantiate (damagePrefab, player.transform.position, player.transform.rotation);
			Destroy (obj.gameObject);
			curHealth--;
		}
			
		}

	void OnCollisionEnter2D(Collision2D obj){
		if (obj.gameObject.tag == "plataformas") {
		}
		if (obj.gameObject.tag == "pisofalso") {
			obj.gameObject.GetComponent<Rigidbody2D> ().AddForce(Vector3.down * 20);
		} 
		if (obj.gameObject.tag == "danger" && invulnerable == false) {
			Instantiate (damagePrefab, player.transform.position, player.transform.rotation);
			Gamer.gameObject.transform.Translate(-Vector2.right * 3);
			curHealth--;
			SetInvincible();
			Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
		if (invulnerable == true && obj.gameObject.tag == "danger") {
			Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

		}
	}

	void OnCollisionStay2D(Collision2D obj){
		if (obj.gameObject.tag == "danger" && invulnerable == false) {
			Instantiate (damagePrefab, player.transform.position, player.transform.rotation);
			Gamer.gameObject.transform.Translate(-Vector2.right * 3);
			curHealth--;
			SetInvincible();
		}
		if (invulnerable == true && obj.gameObject.tag == "danger") {
			Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

		}
	}

	void SetDamageable()
	{
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);
		invulnerable = false;
	}
	public void SetInvincible()
	{
		InvencibleT.text = (invincibleTime+ "\n" + "Segundos de invencibilidade");
		invulnerable = true;
		Invoke( "SetDamageable", invincibleTime );
	}
}		
