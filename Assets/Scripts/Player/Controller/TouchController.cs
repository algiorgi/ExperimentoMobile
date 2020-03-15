using UnityEngine;
using UnityEngine.UI;


namespace experimentomobile.player.controller
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField]        
        private ParticleSystem trailParticle;

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0)
            {                
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {                    
                    trailParticle.Play();
                    trailParticle.transform.position = GetTouchOnWorldPoint(touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {                    
                    trailParticle.transform.position = GetTouchOnWorldPoint(touch.position);
                }
                else if (touch.phase == TouchPhase.Ended)
                {                  
                    trailParticle.Stop();
                }
            }
        }

        private Vector3 GetTouchOnWorldPoint(Vector2 touchPosition)
        {            
            return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 5f));
        }
    }
}

