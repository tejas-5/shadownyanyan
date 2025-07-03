using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class BoxLightTrigger : MonoBehaviour
{
    
        public Light2D boxLight;
        public string boxTag = "PushableBox";

        private bool boxInside = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(boxTag))
            {
                boxInside = true;
                UpdateLight();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(boxTag))
            {
                boxInside = false;
                UpdateLight();
            }
        }

        void UpdateLight()
        {
            // เปิดไฟถ้ามีกล่องในจุด และไม่ปิดตามร่างผู้เล่น
            boxLight.enabled = boxInside;
        }
    }
