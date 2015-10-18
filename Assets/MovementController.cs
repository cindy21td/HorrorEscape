using UnityEngine;
using System.Collections;
using Leap;

public class MovementController : MonoBehaviour {
    Controller controller;

	public Camera camera = null;
	public float _moveSpeed;
	public GameObject leapMotionOVRController = null;
	
	void Start () {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 100.0f);
		controller.Config.SetFloat ("Gesture.Swipe.MinVelocity", 50f);
		controller.Config.Save ();
    }
	
	
	void Update () {
        Frame frame = controller.Frame();
        GestureList gestures = frame.Gestures();
        for (int i = 0; i < gestures.Count; i++)
        {
            Gesture gesture = gestures[i];
            if (gesture.Type == SwipeGesture.ClassType())
            {
				leapMotionOVRController.transform.localPosition += camera.transform.forward * _moveSpeed * Time.deltaTime;
                Debug.Log("yoo");
            }
        }
	}
}
