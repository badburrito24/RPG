using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector3 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
           
            //if (player.GetComponent<PlayerMovement>().transform.position < -20.58)
            //{

           // }
            //cam.transform.position += cameraChange;
           // cam.minPosition += cameraChange;
           // cam.maxPosition += cameraChange;
            //other.transform.position += playerChange;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }    
        }
    }
    public IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);

    }
}
