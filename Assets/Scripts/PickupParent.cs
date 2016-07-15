using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

    public Main main;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;
    public GameObject prefabSphere;
    public GameObject prefabCube;
    public GameObject prefabCylinder;


    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are holding 'Touch' on the Trigger");
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You activated TouchDown on the Trigger");
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You activated TouchUp on the Trigger");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You are holding 'Press' on the Trigger");
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You activated PressDown on the Trigger");
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You activated PressUp on the Trigger");
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("You activated PressUp on the Touchpad");
            main.l_go_PlayerUnits.Add(GameObject.Instantiate(prefabSphere).GetComponent<PickUpableObject>());
            main.l_go_PlayerUnits[main.l_go_PlayerUnits.Count - 1].main = main;

            //sphere.transform.position = Vector3.zero;
            //sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    void OnTriggerStay (Collider col)
    {
        Debug.Log("You have collided with " + col.name + " and activated OnTriggerStay");
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You have collided with " + col.name + " while holding down Touch");
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(gameObject.transform);

            PickUpableObject tempPickUpObject;
            tempPickUpObject = col.GetComponent<PickUpableObject>();
            tempPickUpObject.b_PickedUp = true;
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You have released Touch while colliding with " + col.name);
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;

            tossObject(col.attachedRigidbody);

            PickUpableObject tempPickUpObject;
            tempPickUpObject = col.GetComponent<PickUpableObject>();
            tempPickUpObject.b_PickedUp = false;
        }
    }

    void tossObject(Rigidbody rigidBody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigidBody.velocity = origin.TransformVector(device.velocity);
            rigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        } else
        {
            rigidBody.velocity = device.velocity;
            rigidBody.angularVelocity = device.angularVelocity;
        }
        
    }
}
