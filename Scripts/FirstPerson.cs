using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstPerson : MonoBehaviour {

	public ArrayList positions;
	public ArrayList rotations;

    public CharacterController controller;
    public float speed;
    public Camera camera;
    public float xSensitivity, ySensitivity;
    public float inversion = -1;
	public GameObject End;
    public StateController state;

	//time since last damage taken
	private float lastDamage = 0;

    // Use this for initialization

    public float health = 100;
	public float maxHealth;
    
	void Start() {
        state = GameObject.Find("StateController").GetComponent<StateController>();
		positions = new ArrayList ();
		rotations = new ArrayList ();
		End = GameObject.Find ("End");

		maxHealth = health;
    }

    // Update is called once per frame
    void Update() {
        Vector3 movement, rotation;
        float vertical, horizontal, pitch, playerRotation;
		if (!End.GetComponent<Key> ().phase2) {
			positions.Add (transform.position);
			rotations.Add (transform.rotation);
		}
			
        vertical = Input.GetAxis("Vertical");

        horizontal = Input.GetAxis("Horizontal");

        movement = transform.TransformDirection(horizontal, 0, vertical);

        Vector3.ClampMagnitude(movement, speed);

        //movement.x *= vertical;
        //movement.y *= horizontal;

        move(movement);

        playerRotation = Input.GetAxis("Mouse X") * xSensitivity;
        pitch = Input.GetAxis("Mouse Y") * ySensitivity * inversion;

        rotateCharacter(playerRotation);
        pitchCamera(pitch);

        if (health <= 0)
            state.end(0);
		else regen();
    }

    void move(Vector3 v) {
        controller.SimpleMove(v * Time.deltaTime * speed);
    }

    void pitchCamera(float pitch) {
        Vector3 rotation = camera.transform.localEulerAngles;
        rotation.x += pitch * Time.deltaTime * ySensitivity;
        if (rotation.x > 70 && rotation.x < 100)
            rotation.x = Mathf.Clamp(rotation.x, 70, 70);
        else if (rotation.x < 290 && rotation.x > 100)
            rotation.x = Mathf.Clamp(rotation.x, 290, 290);
        camera.transform.localEulerAngles = rotation;
    }

    void rotateCharacter(float playerRotation) {

        Vector3 rotation = controller.transform.localEulerAngles;
        rotation.y += playerRotation * Time.deltaTime * ySensitivity;
        controller.transform.localEulerAngles = rotation;
    }

	public void takeDamage(float damage){
		health -= damage;
		Debug.Log("health: " + health);
		lastDamage = Time.time;
	}

	/**
	 * regen health after three seconds of not taking damage
	 */
	private void regen(){
		if(Time.time - lastDamage > 3 && health < maxHealth)
			health++;
	}

}
