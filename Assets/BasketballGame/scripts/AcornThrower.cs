using System;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{

    [RequireComponent(typeof(Camera))]
    public class AcornThrower : MonoBehaviour
    {
        [SerializeField]
        Rigidbody m_ProjectilePrefab;

        public Rigidbody projectileRB;

        [SerializeField]
        // This is the force of the throw
        public float m_ThrowForce = 100f;

        // X and Y axis damping factors for the throw direction
        public float m_ThrowDirectionX = -0.17f;
        public float m_ThrowDirectionY = -0.87f;

        // Offset of the ball's position in relation to camera's position
        public Vector3 m_BallCameraOffset = new Vector3(0f, -1.4f, 3f);

        // The following variables contain the state of the current throw
        private Vector3 startPosition;
        private Vector3 endPosition;
        private Vector3 direction;
        private float startTime;
        private float endTime;
        private float duration;
        private bool directionChosen = false;
        private bool throwStarted;

        private void Start()
        {
            ResetBall();
        }

        void Update()
        {
            // We've started the touch of the screen, which will start collecting info about the ball throw
            if (Input.GetMouseButtonDown(0))
            { // Works for both Mouse and Touch on Mobile, when we press/touch

                startPosition = Input.mousePosition;
                startTime = Time.time;
                directionChosen = false;
                
            }
            // We've ended the touch of the screen, which will end collecting info about the ball throw
            else if (Input.GetMouseButtonUp(0))
            { // Works for both Mouse and Touch, when we release click/touch
                endTime = Time.time;
                duration = endTime - startTime;
                endPosition = Input.mousePosition;
                direction = startPosition - endPosition;
                directionChosen = true;
                throwStarted = true;
                projectileRB.isKinematic = true;
            }

            // Direction was chosen, which will release/throw the ball
            if (directionChosen)
            {
                projectileRB.mass = 1;
                projectileRB.useGravity = true;
                projectileRB.isKinematic = false;

                FindObjectOfType<BasketAudioManager>().Play("Swish");
                projectileRB.AddForce(
                    GetComponent<Camera>().transform.forward * m_ThrowForce / duration +
                    GetComponent<Camera>().transform.up * direction.y * m_ThrowDirectionY +
                    direction.x * m_ThrowDirectionX * GetComponent<Camera>().transform.right);
                startTime = 0.0f;
                duration = 0.0f;

                startPosition = new Vector3(0, 0, 0);
                endPosition = new Vector3(0, 0, 0);
                direction = new Vector3(0, 0, 0);

                directionChosen = false;

            }

            // 2 seconds after throwing the ball, we reset it's position
            if (throwStarted && Time.time - endTime >= 3 && Time.time - endTime <= 4)
            {
                ResetBall();
            }

        }
        public void ResetBall()
        {
            var projectile = Instantiate(m_ProjectilePrefab);
            projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.mass = 0;
            projectileRB.useGravity = false;
            projectileRB.velocity = Vector3.zero;
            projectileRB.angularVelocity = Vector3.zero;
            endTime = 0.0f;
            throwStarted = false;

            Vector3 ballPos = GetComponent<Camera>().transform.position + GetComponent<Camera>().transform.forward * m_BallCameraOffset.z + GetComponent<Camera>().transform.up * m_BallCameraOffset.y;
            projectileRB.position = ballPos;
        }
    }
}