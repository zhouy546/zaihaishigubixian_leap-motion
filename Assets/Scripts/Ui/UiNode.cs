using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiNode : MonoBehaviour
{
    public int id;
    public UiNode next;
    public UiNode pervious;
    public Sprite titleSprite;

    public Vector3 currentSlotPosition;

    public Vector3 targetSlotPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (id == 0)
        {
            ValueSheet.currentUiNode = this;
        }

        EventCenter.AddListener(EventDefine.UiMoveLeft, MoveLeft);
        EventCenter.AddListener(EventDefine.UiMoveRight, MoveRight);
        currentSlotPosition = this.transform.position;
    }

    public void MoveLeft()
    {
        if (!ValueSheet.UIAnimationLock)
        {
            targetSlotPosition = pervious.currentSlotPosition;

            LeanTween.move(gameObject, targetSlotPosition, .5f).setOnStart(() =>
            {
                ValueSheet.UIAnimationLock = true;
            }).setOnComplete(() =>
            {
                currentSlotPosition = targetSlotPosition;
                ValueSheet.UIAnimationLock = false;
            });
        }
    }

    public void MoveRight()
    {
        if (!ValueSheet.UIAnimationLock)
        {
            targetSlotPosition = next.currentSlotPosition;

            LeanTween.move(gameObject, targetSlotPosition, .5f).setOnStart(() =>
            {
                ValueSheet.UIAnimationLock = true;
            }).setOnComplete(() =>
            {
                currentSlotPosition = targetSlotPosition;
                ValueSheet.UIAnimationLock = false;
            });
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(getRectTransformX());
        }
    }

    private float getRectTransformX()
    {
        return this.transform.localPosition.x;
    }
    // Update is called once per frame

}
