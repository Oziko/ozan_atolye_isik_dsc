using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerw : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    int count; //TMPRO İÇİN
    public TextMeshProUGUI countText, winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; //TMPRO İÇİN
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    //COLLECTABLE'LARI DİZDİKTEN SONRA

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            count++; //TMRO İÇİN
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            winText.text = "You Win!";
        }
    }
}
