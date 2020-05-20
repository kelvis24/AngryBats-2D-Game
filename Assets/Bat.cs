
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bat : MonoBehaviour
{
	private Vector3 _intialPosition;
	private bool lauched;
	private float rolling;
	
	private void Awake()
    {
		_intialPosition = transform.position;
        
    }
  
	
	private void OnMouseUp() {
		
		GetComponent<SpriteRenderer>().color = Color.white;
		
		Vector2 directionToInitialPosition = _intialPosition - transform.position;
		GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * 1000);
		GetComponent<Rigidbody2D>().gravityScale = 1;
		lauched = true;
	}
	
	private void OnMouseDown() {
		
		GetComponent<SpriteRenderer>().color = Color.red;	
	}


	
	private void OnMouseDrag() {
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		transform.position = new Vector3(pos.x, pos.y);
	}
	
	
	private void Update() {
		
		if (transform.position.y > 15 ||
		transform.position.y < -15 ||
		transform.position.x > 40||
		transform.position.x < -30 ||
		rolling > 3.0
		) {
			
			string name = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(name);
			
		}	
		
		
		if (lauched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) {
			
			rolling += Time.deltaTime;
		}	
	}	



	
	
}
