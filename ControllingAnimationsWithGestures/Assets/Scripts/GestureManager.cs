using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using MagicLeap;
using MagicLeapInternal;

public class GestureManager : MonoBehaviour {

    Dictionary<string, Sprite> _gestureImage = new Dictionary<string, Sprite>();

    public Dictionary<string, Sprite> GestureImage
    {
        get
        {
            return _gestureImage;
        }

        set
        {
            _gestureImage = value;
        }
    }

    public Image LeftHandGestureImage;
    public Image RightHandGestureImage;
    public Text GestureIndicatorText;

    // Use this for initialization
    void Start () {
        Sprite[] images = Resources.LoadAll<Sprite>("GestureImages/") as Sprite[];

        for(int i = 0; i < images.Length; i++)
        {
            GestureImage[images[i].name] = images[i];
        }
        Debug.Log(_gestureImage.Count);
	}
	
	// Update is called once per frame
	void Update () {
		if(GestureImage.Count != 0)
        {
            LeftHandGestureImage.sprite = GestureImage[GetGestureHandImage(LeftHandGestureImage.gameObject, MLHands.Left.KeyPose)];
            RightHandGestureImage.sprite = GestureImage[GetGestureHandImage(LeftHandGestureImage.gameObject, MLHands.Right.KeyPose)];
        }

        GestureIndicatorText.text = string.Format("Left hand has {0} gesture with {1} confidence, \n " + "Right hand has {2} gesture with {3} confidence",
        MLHands.Left.KeyPose.ToString(), 
        MLHands.Left.KeyPoseConfidence, 
        MLHands.Right.KeyPose.ToString(),
        MLHands.Right.KeyPoseConfidence);
	}

    string GetGestureHandImage(GameObject Hand, MLHandKeyPose _type)
    {
        switch(_type)
        {
            case MLHandKeyPose.Fist:
                Hand.GetComponent<Animator>().SetTrigger(_type.ToString());
                break;
            case MLHandKeyPose.Pinch:
                Hand.GetComponent<Animator>().SetTrigger(_type.ToString());
                break;
            case MLHandKeyPose.Thumb:
                Hand.GetComponent<Animator>().SetTrigger(_type.ToString());
                break;
            default:
                break;
        }

        return _type.ToString();
    }
}
