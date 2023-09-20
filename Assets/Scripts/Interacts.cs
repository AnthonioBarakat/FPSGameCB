using Mono.Reflection;
using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{

    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5f;

    private Animator anim;

    [SerializeField]private GameObject promptMessage;
    private Text textInPromptMessage;

    private InputManager inputManager;

    private bool isDoorOpened, isBoxOpened;
    private Light lightPoint;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        lightPoint = GameObject.FindWithTag("DoorButton").GetComponent<Light>();
        textInPromptMessage = promptMessage.GetComponent<Text>();
    }


    void LateUpdate()
    {
        CheckInteractObjects();
    }

    void CheckInteractObjects()
    {
        //This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit hitObject;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hitObject, MaxDistance))
        {

            // if raycast hits, then it checks if it hit an object with the tag Door.
            if (hitObject.transform.tag == "DoorButton" && !isDoorOpened)
            {
                textInPromptMessage.text = "Press [E] to open door";
                promptMessage.SetActive(true);

                if (inputManager.onFoot.Interact.triggered)
                {
                    promptMessage.SetActive(false);

                    //This line will get the Animator from  Parent of the door that was hit by the raycast.
                    anim = GameObject.FindWithTag("Door").GetComponent<Animator>();


                    //This line will set the bool true so it will play the animation.
                    anim.SetBool("open", true);
                    isDoorOpened = true;
                    lightPoint.color = Color.green;
                }
                
            }
            else if (hitObject.transform.tag == "Box" && !isBoxOpened)
            {
                textInPromptMessage.text = "Press [E] to open box";
                promptMessage.SetActive(true);

                if (inputManager.onFoot.Interact.triggered)
                {
                    promptMessage.SetActive(false);

                    //This line will get the Animator from  Parent of the door that was hit by the raycast.
                    anim = GameObject.Find("Armature").GetComponent<Animator>();


                    //This line will set the bool true so it will play the animation.
                    anim.SetBool("open", true);
                    isBoxOpened = true;
                }
            }
            else if (hitObject.transform.tag == "BoxWeapon" && isBoxOpened)
            {

                textInPromptMessage.text = "Press [F] to take weapon";
                promptMessage.SetActive(true);

                if (inputManager.onFoot.TakeWeapon.triggered)
                {
                    promptMessage.SetActive(false);

                    var boxWeaponComp = hitObject.transform.gameObject.GetComponent<BoxWeapon>();

                    Debug.Log($"picking up {hitObject.transform.name}");

                    Destroy(GameObject.Find("boxweapon"));
					gameObject.GetComponent<PlayerBullets>().RestoreBullet(30);
                    gameObject.GetComponent<PlayerWeapons>().EquipWeapon(boxWeaponComp != null ? boxWeaponComp.weaponIndex : 0);
                }
            }
            else if (hitObject.transform.tag == "Medkit")
            {
                textInPromptMessage.text = "Press [E] to take medkit";
                promptMessage.SetActive(true);

                if (inputManager.onFoot.Interact.triggered)
                {
                    promptMessage.SetActive(false);

                    Destroy(GameObject.Find("medkit"));
                    gameObject.GetComponent<PlayerHealthBar>().RestoreHealth();
                }
            }
            else if (hitObject.transform.tag == "Bullets")
            {
				textInPromptMessage.text = "Press [E] to take bullets";
				promptMessage.SetActive(true);

				if (inputManager.onFoot.Interact.triggered)
				{
					promptMessage.SetActive(false);

                    Destroy(hitObject.transform.gameObject);
					gameObject.GetComponent<PlayerBullets>().RestoreBullet(100);
				}
			}
            else
            {
                promptMessage.SetActive(false);
            }
        }
        else
        {
            promptMessage.SetActive(false);
        }
    }
}

//IEnumerator OpenDoor()
//    {
//        isOpening = true;
//        door.GetComponent<Animator>().Play("DoorOpen");
//        yield return new WaitForSeconds(5f);
//        door.GetComponent<Animator>().Play("New State");
//        isOpening = false;
//    }
//}
