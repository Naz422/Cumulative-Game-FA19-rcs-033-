using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private static bool check;
    private Rigidbody rb;
    private int count;
    // public GameObject particals;
    public GameObject resultpanel;
    void Start()
    {
        resultpanel.SetActive(false);
        rb = GetComponent<Rigidbody>();
        count = 0;
        //SetCountText();
        winText.text = "";
        check = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Pick Up"))
        {
            if (IsPalindrome(collision.gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text.ToString()))
            {
                //UnityEngine.Debug.Log("palindd=rom");
                collision.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
            else
            {
                collision.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }

        }
    }

    void SetCountText()
    {
        
        countText.text = "Count: " + count.ToString();
        Debug.Log("hjdbjsd" + CreatingBlocks.CP);
        if (count >= CreatingBlocks.CP)
        {
            Debug.Log("jfrejf" + count);
            resultpanel.SetActive(true);
            winText.text = "TotalCount: " + count.ToString();
        }
    }

    public static bool IsPalindrome(string text)
    {
        if (text.Length <= 1)
            return true;
        else
        {
            if (text[0] != text[text.Length - 1])
                return false;
            else
                return IsPalindrome(text.Substring(1, text.Length - 2));
        }
    }
}
