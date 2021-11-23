using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformControl : Agent
{
    [SerializeField] protected BallControl ballControl;
    [SerializeField] protected Transform basketTransform;
    [SerializeField] protected Rigidbody2D rigidbodyPlatform;
    [SerializeField] protected float pushMaxAllowedHeight = 2f;
    [SerializeField] protected Vector2 pushForce = Vector2.up * 20f;
    [SerializeField] protected float moveSpeed = 2f;
    public BehaviorParameters behaviorParameters;

    Vector2 moveDirection = Vector2.zero;
    [SerializeField] Vector2 moveDirectionAI = Vector2.zero;
    [SerializeField] float pushAI = 0f;

    Vector3 startPosition = Vector3.zero;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void OnMoveDirectionUpdated(InputAction.CallbackContext context)
    {
        moveDirection.x = context.ReadValue<float>();
        //print("OnMoveDirectionUpdated: Value = " + context.ReadValue<float>() + " | Phase = " + context.phase);
    }

    public void OnPushUpdated(InputAction.CallbackContext context)
    {
        if ((behaviorParameters.BehaviorType == BehaviorType.HeuristicOnly) && context.phase == InputActionPhase.Performed)
        {
            if (rigidbodyPlatform)
            {
                Push();
                //print("Called!!!");
            }
        }
        //print("OnPushUpdated: Value = " + context.ReadValue<float>() + " | Phase = " + context.phase);
    }

    private void Push()
    {
        if (transform.localPosition.y < pushMaxAllowedHeight)
        {
            rigidbodyPlatform.AddForce(pushForce, ForceMode2D.Impulse);
        }
    }

    public void WinTriggered()
    {
        //transform.position = startPosition;
        //ballControl.ResetBall();
        SetReward(1f);
        EndEpisode();
    }

    public void DeathTriggered()
    {
        //transform.position = startPosition;
        //ballControl.ResetBall();
        SetReward(-1f);
        EndEpisode();
    }

    private void FixedUpdate()
    {

        if (behaviorParameters.BehaviorType == BehaviorType.HeuristicOnly)
        {
            transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(moveDirectionAI.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    #region AIAgent

    public override void OnEpisodeBegin()
    {
        transform.position = startPosition;
        ballControl.ResetBall();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(ballControl.transform.localPosition.x);
        sensor.AddObservation(ballControl.transform.localPosition.y);
        sensor.AddObservation(ballControl.BallBody.velocity.x);
        sensor.AddObservation(ballControl.BallBody.velocity.y);
        sensor.AddObservation(transform.localPosition.x);
        sensor.AddObservation(transform.localPosition.y);
        sensor.AddObservation(basketTransform.localPosition.x);
        sensor.AddObservation(basketTransform.localPosition.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        moveDirectionAI.x = actions.ContinuousActions[0];
        pushAI = actions.ContinuousActions[1];
        print("AI actions: " + actions.ContinuousActions[0] + ", " + actions.ContinuousActions[1]);
        if (pushAI > 0f)
        {
            Push();
        }
    }

    #endregion

}
