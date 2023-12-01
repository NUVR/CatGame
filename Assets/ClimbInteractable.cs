using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        if (args.interactorObject is XRDirectInteractor)
        {
            Climber.climbingHand = args.interactorObject.transform.parent.GetComponent<ActionBasedController>();
        }

        base.OnSelectEntered(args);
    }


    protected override void OnSelectExited(SelectExitEventArgs args)
    {

        if (Climber.climbingHand && Climber.climbingHand.name == args.interactorObject.transform.parent.name)
        {
            Climber.climbingHand = null;
        }
        base.OnSelectExited(args);
    }
}

