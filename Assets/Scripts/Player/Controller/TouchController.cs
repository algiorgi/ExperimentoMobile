using UnityEngine;
using UnityEngine.UI;


namespace experimentomobile.player.controller
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem trailParticle;

        [SerializeField]
        private bool showTrail;

        [SerializeField]
        private float trailPositionOnZ = 5f;

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0)
            {                
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    StartToTrailTouchPosition(GetTouchOnWorldPoint(touch.position));                    
                }
                else if (touch.phase == TouchPhase.Moved)
                {                    
                    UpdateTrailTouchPosition(GetTouchOnWorldPoint(touch.position));
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    StopToTrailTouchPosition();                    
                }
            }
        }

        private Vector3 GetTouchOnWorldPoint(Vector2 touchPosition)
        {            
            return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, trailPositionOnZ));
        }

        private void StartToTrailTouchPosition(Vector3 startPosition)
        {
            if (showTrail)
            {
                trailParticle.Play();
                trailParticle.transform.position = startPosition;
            }            
        }

        private void UpdateTrailTouchPosition(Vector3 updatedPosition)
        {
            if(showTrail)
                trailParticle.transform.position = updatedPosition;
        }

        private void StopToTrailTouchPosition()
        {
            if (showTrail)
                trailParticle.Stop();
        }
    }
}

