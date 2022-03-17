using Leap;
using Leap.Unity;
using Leap.Unity.HandsModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTest : HandModelBase
{
    public Hand LeapHand;

    public SerializedTransform[] DefaultHandPose;

    public bool EditPoseNeedsResetting = false;

    public Chirality Chirality;
    public override Chirality Handedness { get { return Chirality; } set { } }
    public override ModelType HandModelType { get { return ModelType.Graphics; } }

    public override Hand GetLeapHand()
    {
        return LeapHand;
    }

    public override void SetLeapHand(Hand hand)
    {
        LeapHand = hand;
    }

    public override void BeginHand()
    {
        base.BeginHand();

    }
    void Start()
    {
        EventCenter.AddListener(EventDefine.ToSelectionState, toSelectionState);

    }

    public override void UpdateHand()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        if (LeapHand == null)
        {
            ResetHand();
            return;
        }


        if (ValueSheet.GameState == State.PB)
        {
            pbMouseMovement();
        }
        else if (ValueSheet.GameState == State.Selection)
        {
            SelectionMouseMovement(LeapHand.PalmVelocity.x,LeapHand.GrabStrength);


        }
        else if (ValueSheet.GameState == State.VideoPlay)
        {

        }
        
    }

    private bool mouseCoolDown;

    private void pbMouseMovement()
    {
        if (LeapHand != null&&!mouseCoolDown)
        {
            Debug.Log("Ω¯»ÎSelection");
            mouseCoolDown = true;
            //Go to Selection state;          
            EventCenter.Broadcast(EventDefine.ToSelectionState);
        }
    }

    private void toSelectionState()
    {
        mouseCoolDown = false;

    }

    private void SelectionMouseMovement(float velocityX,float grab)
    {
        if (Utility.moveDirection(velocityX) == SelectionMune.Right && !mouseCoolDown)
        {

             Debug.Log("right");
            Utility.MoveRight();
            mouseCoolDown = true;
        }
        else if (Utility.moveDirection(velocityX) == SelectionMune.Left && !mouseCoolDown)
        {

            //MediaCtr.instance.LoadVideo(ValueSheet.udp_VideoinfoPairs["1"]);

            Debug.Log("left");
            Utility.MoveLeft();
            mouseCoolDown = true;
        }

        else if(Utility.IsGrab(grab) && !mouseCoolDown)
        {
            EventCenter.Broadcast(EventDefine.ToVideoState);
            Debug.Log("submit");
            //submit
            mouseCoolDown = true;
        }

        else if (Utility.moveDirection(velocityX) == SelectionMune.Idle&& !Utility.IsGrab(grab) && mouseCoolDown)
        {
            Debug.Log("IDLE");
            mouseCoolDown = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetHand(bool forceReset = false)
    {

        if (DefaultHandPose == null || EditPoseNeedsResetting == false && forceReset == false)
        {
            return;
        };

        for (int i = 0; i < DefaultHandPose.Length; i++)
        {

            var baseTransform = DefaultHandPose[i];
            if (baseTransform != null && baseTransform.reference != null)
            {
                baseTransform.reference.transform.localPosition = baseTransform.transform.position;
                baseTransform.reference.transform.localRotation = Quaternion.Euler(baseTransform.transform.rotation);
            }
        }
        EditPoseNeedsResetting = false;
    }
}
