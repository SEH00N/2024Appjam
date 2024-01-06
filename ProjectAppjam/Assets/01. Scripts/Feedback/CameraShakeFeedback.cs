using Base.Feedback;
using UnityEngine;

public class CameraShakeFeedback : FeedbackBase
{
    [SerializeField] float duration;
    [SerializeField] float power;
    [SerializeField] float frequency;

    public override void CreateFeedback()
    {
        CameraManager.Instance.ShakeCam(duration, power, frequency);
    }

    public override void FinishFeedback()
    {
        CameraManager.Instance.ShakeCam(0f, 0f, 0f);
    }
}
