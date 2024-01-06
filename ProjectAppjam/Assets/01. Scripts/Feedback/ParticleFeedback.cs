using Base.Feedback;
using UnityEngine;

public class ParticleFeedback : FeedbackBase
{
    [SerializeField] ParticleSystem prefab;
    [SerializeField] Transform trm;

    public override void CreateFeedback()
    {
        ParticleSystem instance = Instantiate(prefab, trm.position, Quaternion.identity);
        instance.Play();
    }

    public override void FinishFeedback()
    {
        
    }
}
