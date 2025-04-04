using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using System;

  public struct PlayerInputs
  {
    public float MoveAxisForward;
    public float MoveAxisRight;
    public Quaternion CameraRotation;
    public bool JumpPressed;
  }

  public class PlayerCharacterController : MonoBehaviour, ICharacterController
    {
        [SerializeField]
        public KinematicCharacterMotor _motor;

        [SerializeField]
        private Vector3 _gravity = new Vector3(0f, -30f, 0f);

        [SerializeField]
        private float _maxStableMoveSpeed = 10f, _stableMovementSharpness = 15f, _orientationSharpness = 10f;

        [SerializeField]
        private float _jumpSpeed = 10f;

        private Vector3 _moveInputVector, _lookInputVector;
        private bool _jumpRequested;
        private Animator _animator;

        private void Start()
        {
            // Assign to motor
            _motor.CharacterController = this;

            _animator = GetComponentInChildren<Animator>();
        }

        public void SetInputs(ref PlayerInputs inputs)
        {
            Vector3 moveInputVector = Vector3.ClampMagnitude(new Vector3(inputs.MoveAxisRight, 0f, inputs.MoveAxisForward), 1f);
            Vector3 cameraPlanarDirection = Vector3.ProjectOnPlane(inputs.CameraRotation * Vector3.forward, _motor.CharacterUp).normalized;

            if(cameraPlanarDirection.sqrMagnitude == 0f)
            {
                cameraPlanarDirection = Vector3.ProjectOnPlane(inputs.CameraRotation * Vector3.up, _motor.CharacterUp).normalized;;
            }
            
            Quaternion cameraPlanarRotation = Quaternion.LookRotation(cameraPlanarDirection, _motor.CharacterUp);

            _moveInputVector = cameraPlanarRotation * moveInputVector;
            _lookInputVector = _moveInputVector.normalized;

            if(inputs.JumpPressed)
            {
                _jumpRequested = true;
            }
        }

        public void BeforeCharacterUpdate(float deltaTime)
        {
            // This is called before the motor does anything
        }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            // This is called when the motor wants to know what its rotation should be right now
            if(_lookInputVector.sqrMagnitude > 0f && _orientationSharpness > 0f)
            {
                Vector3 smoothedLookInputDirection = Vector3.Slerp(_motor.CharacterForward, _lookInputVector, 1 - Mathf.Exp(-_orientationSharpness * deltaTime)).normalized;

                currentRotation = Quaternion.LookRotation(smoothedLookInputDirection, _motor.CharacterUp);
            }
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            // This is called when the motor wants to know what its velocity should be right now
            if (_motor.GroundingStatus.IsStableOnGround)
            {
                float currentVelocityMagnitude = currentVelocity.magnitude;
                Vector3 effectiveGroundNormal = _motor.GroundingStatus.GroundNormal;

                currentVelocity = _motor.GetDirectionTangentToSurface(currentVelocity, effectiveGroundNormal) * currentVelocityMagnitude;

                Vector3 inputRight = Vector3.Cross(_moveInputVector, _motor.CharacterUp);
                Vector3 reorientedInput = Vector3.Cross(effectiveGroundNormal, inputRight).normalized * _moveInputVector.magnitude;

                Vector3 targetMovementVelocity = reorientedInput * _maxStableMoveSpeed;

                currentVelocity = Vector3.Lerp(currentVelocity, targetMovementVelocity, 1f - Mathf.Exp(-_stableMovementSharpness * deltaTime));
            }
            else
            {
                currentVelocity += _gravity * deltaTime;
            }

            if (_jumpRequested)
            {
                currentVelocity += (_motor.CharacterUp * _jumpSpeed) - Vector3.Project(currentVelocity, _motor.CharacterUp);
                _jumpRequested = false;
                _motor.ForceUnground();
            }
        }

        public void AfterCharacterUpdate(float deltaTime)
        {
            // This is called after the motor has finished everything in its update
            // Determine if the player is moving on the ground
            Vector3 horizontalVelocity = Vector3.ProjectOnPlane(_motor.Velocity, _motor.CharacterUp);
            bool isMoving = horizontalVelocity.sqrMagnitude > 0.1f;

            // Set the Animator parameter
            _animator.SetBool("isMoving", isMoving);

            // Check jump state (for isJumping)
            bool isJumping = !_motor.GroundingStatus.IsStableOnGround;
            _animator.SetBool("isJumping", isJumping);

            Debug.Log(isJumping);
        }

        public bool IsColliderValidForCollisions(Collider coll)
        {
            // This is called after when the motor wants to know if the collider can be collided with (or if we just go through it)
            return true;
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            // This is called when the motor's ground probing detects a ground hit
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            // This is called when the motor's movement logic detects a hit
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
            // This is called after every hit detected in the motor, to give you a chance to modify the HitStabilityReport any way you want
        }

        public void PostGroundingUpdate(float deltaTime)
        {
            // This is called after the motor has finished its ground probing, but before PhysicsMover/Velocity/etc.... handling
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
            // This is called by the motor when it is detecting a collision that did not result from a "movement hit".
        }
    }