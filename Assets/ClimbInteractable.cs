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
            Debug.Log("on select");
            Debug.Log(args.interactorObject.transform.name);
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
/*{
    // Start is called before the first frame update
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        if (interactor is XRDirectInteractor)
            Climber.Instance.climbingHand = interactor.GetComponent<XRController>();
    }


    // Update is called once per frame
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        if (interactor is XRDirectInteractor)
        {
            if (Climber.Instance.climbingHand && Climber.Instance.climbingHand.name == interactor.name)
            {
                Climber.Instance.climbingHand = null;
            }
        }
    }
}*/
