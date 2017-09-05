using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCount();
        winText.text = "";
    }
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            winText.text = "You Lose ! ! ";
            Application.Quit();

        }
       else if (other.gameObject.CompareTag("Red"))
        {
            winText.text = "You Lose ! !  ";
            //DestroyObject(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCount();
        }
    }
    void setCount()
    {
        countText.text = "Count : "+count.ToString();
        if (count >= 8)
        {
            winText.text = "You WIN!!";

        }
    }
}
