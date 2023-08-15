using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private const float MIN_Y_POS = -3.93f;
    private const float MAX_Y_POS = 3.93f;
    
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private Ball _ball;
    

    private void Update()
    {
        KeepTrackOfBall();
    }

    private void KeepTrackOfBall()
    {
        var targetY = _ball.transform.position.y;
        targetY = Mathf.Clamp(targetY, MIN_Y_POS, MAX_Y_POS);
        var step = _verticalSpeed * Time.deltaTime;
        var targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
