using UnityEngine;
using Leap;
using System.Collections.Generic;

public class LeapControled : MonoBehaviour
{

    /// <summary>
    /// The Leap controller.
    /// </summary>
    Controller controller;

    /// <summary>
    /// The current frame captured by the Leap Motion.
    /// </summary>
    Frame CurrentFrame
    {
        get { return (IsReady) ? controller.Frame() : null; }
    }

    /// <summary>
    /// Gets the hands data captured from the Leap Motion.
    /// </summary>
    /// <value>
    /// The hands data captured from the Leap Motion.
    /// </value>
    List<Hand> Hands
    {
        get { return (CurrentFrame != null && CurrentFrame.Hands.Count > 0) ? CurrentFrame.Hands : null; }
    }

    /// <summary>
    /// Gets a value indicating whether the Leap Motion is ready.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is ready; otherwise, <c>false</c>.
    /// </value>
    bool IsReady
    {
        get { return (controller != null && controller.Devices.Count > 0 && controller.IsConnected); }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        controller = new Controller();
    }

    /// <summary>
    /// Update function called every frame.
    /// </summary>
    void Update()
    {
        Hand mainHand; // The front most hand captured by the Leap Motion Controller

        // Check if the Leap Motion Controller is ready
        if (!IsReady || Hands == null)
        {
            return;
        }

        mainHand = Hands[0];

        transform.rotation = Quaternion.Euler(mainHand.Direction.Pitch, mainHand.Direction.Yaw, mainHand.PalmNormal.Roll);
        
        // For relative orientation
        //transform.rotation *= Quaternion.Euler(mainHand.Direction.Pitch, mainHand.Direction.Yaw, mainHand.PalmNormal.Roll);

    }

}