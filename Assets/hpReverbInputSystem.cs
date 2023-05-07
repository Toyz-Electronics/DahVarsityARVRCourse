//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Microsoft.MixedReality.Input;
//using UnityEngine;

////ThisTakesCode from here: https://learn.microsoft.com/en-us/windows/mixed-reality/develop/unity/unity-reverb-g2-controllers
////My Verssion of MotionControllerStateCache
//public class hpReverbInputSystem : MonoBehaviour
//{
//    // Start is called before the first frame update
//    MotionController motionController;
//    int PressedThreshold = 0;

//    /// <summary> 
//    /// Starts monitoring controller's connections and disconnections 
//    /// </summary> 
//    public void Start()
//    {
//        _watcher = new MotionControllerWatcher();
//        _watcher.MotionControllerAdded += _watcher_MotionControllerAdded;
//        _watcher.MotionControllerRemoved += _watcher_MotionControllerRemoved;
//        var nowait = _watcher.StartAsync();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        var now = DateTime.Now;

//        lock (_controllers)
//        {
//            foreach (var controller in _controllers)
//            {
//                controller.Value.Update(now);
//            }
//        }

//        var stateCache = gameObject.GetComponent<hpReverbInputSystem>();
//        //foreach (var sourceState in InteractionManager.GetCurrentReading())
//        //{
//        //    float graspValue = stateCache.GetValue(sourceState.source.handedness,
//        //        Microsoft.MixedReality.Input.ControllerInput.Grasp);
//        //}
//    }

//    /// <summary> 
//    /// Returns the current value of a controller input such as button or trigger 
//    /// </summary> 
//    /// <param name="handedness">Handedness of the controller</param> 
//    /// <param name="input">Button or Trigger to query</param> 
//    /// <returns>float value between 0.0 (not pressed) and 1.0 
//    /// (fully pressed)</returns> 
//    public float GetValue(Handedness handedness, ControllerInput input)
//    {
//        MotionControllerReading currentReading = null;

//        lock (_controllers)
//        {
//            if (_controllers.TryGetValue(handedness, out MotionControllerState mc))
//            {
//                currentReading = mc.CurrentReading;
//            }
//        }

//        return (currentReading == null) ? 0.0f : currentReading.GetPressedValue(input);
//    }

//    /// <summary> 
//    /// Returns the current value of a controller input such as button or trigger 
//    /// </summary> 
//    /// <param name="handedness">Handedness of the controller</param> 
//    /// <param name="input">Button or Trigger to query</param> 
//    /// <returns>float value between 0.0 (not pressed) and 1.0 
//    /// (fully pressed)</returns> 
//    public float GetValue(UnityEngine.InputSystem.XR.XRController xrControllerHand, ControllerInput input)
//    {
//        return GetValue(xrControllerHand, input);
//    }

//    /// <summary> 
//    /// Returns a boolean indicating whether a controller input such as button or trigger is pressed 
//    /// </summary> 
//    /// <param name="handedness">Handedness of the controller</param> 
//    /// <param name="input">Button or Trigger to query</param> 
//    /// <returns>true if pressed, false if not pressed</returns> 
//    public bool IsPressed(Handedness handedness, ControllerInput input)
//    {
//        return GetValue(handedness, input) >= PressedThreshold;
//    }

//    /// <summary> 
//    /// Internal helper class which associates a Motion Controller 
//    /// and its known state 
//    /// </summary> 
//    private class MotionControllerState
//    {
//        /// <summary> 
//        /// Construction 
//        /// </summary> 
//        /// <param name="mc">motion controller</param>` 
//        public MotionControllerState(MotionController mc)
//        {
//            this.MotionController = mc;
//        }

//        /// <summary> 
//        /// Motion Controller that the state represents 
//        /// </summary> 
//        public MotionController MotionController { get; private set; }

//        /// <summary> 
//        /// Update the current state of the motion controller 
//        /// </summary> 
//        /// <param name="when">time of the reading</param> 
//        public void Update(System.DateTime when)
//        {
//            this.CurrentReading = this.MotionController.TryGetReadingAtTime(when);
//        }

//        /// <summary> 
//        /// Last reading from the controller 
//        /// </summary> 
//        public MotionControllerReading CurrentReading { get; private set; }

//        //public MotionController.GetPressableInputs() pressableInputs { get; private set; }
//        //private bool[] GetPressed(MotionControllerReading reading)
//        //{
//        //    if (reading == null)
//        //    {
//        //            return null;
//        //     }
//        //        else
//        //        { 
//        //        bool[] ret = new bool[this.pressableInputs.Length];
//        //        for (int i = 0; i < pressableInputs.Length; ++i)
//        //        {
//        //            ret[i] = reading.GetPressedValue(pressableInputs[i]) >= PressedThreshold;
//        //        }

//        //        return ret;
//        //    }
//        //}

//        ///// <summary> 
//        ///// Returns an array representng buttons which are pressed 
//        ///// </summary> 
//        ///// <param name="reading">motion controller reading</param> 
//        ///// <returns>array of booleans</returns> 


//        ///// <summary> 
//        ///// Get the next available state of the motion controller 
//        ///// </summary> 
//        ///// <param name="lastReading">previous reading</param> 
//        ///// <param name="newReading">new reading</param> 
//        ///// <returns>true is a new reading was available</returns> 
//        //private bool GetNextReading(MotionControllerReading lastReading, out MotionControllerReading newReading)
//        //{
//        //    if (lastReading == null)
//        //    {
//        //        // Get the first state published by the controller 
//        //        newReading = this.motionController.TryGetReadingAfterSystemRelativeTime(TimeSpan.FromSeconds(0.0));
//        //    }
//        //    else
//        //    {
//        //        // Get the next state published by the controller 
//        //        newReading = this.motionController.TryGetReadingAfterTime(lastReading.InputTime);
//        //    }

//        //    return newReading != null;
//        //}

//        ///// <summary> 
//        ///// Processes all the new states published by the controller since the last call 
//        ///// </summary> 
//        //public IEnumerable<MotionControllerEventArgs> GetNextEvents()
//        //{
//        //    MotionControllerReading lastReading = this.CurrentReading;
//        //    bool[] lastPressed = GetPressed(lastReading);
//        //    MotionControllerReading newReading;
//        //    bool[] newPressed;

//        //    while (GetNextReading(lastReading, out newReading))
//        //    {
//        //        newPressed = GetPressed(newReading);

//        //        // If we have two readings, compare and generate events 
//        //        if (lastPressed != null)
//        //        {
//        //            for (int i = 0; i < pressableInputs.Length; ++i)
//        //            {
//        //                if (newPressed[i] != lastPressed[i])
//        //                {
//        //                    yield return new MotionControllerEventArgs(this.MotionController.Handedness, newPressed[i], this.pressableInputs[i], newReading.InputTime);
//        //                }
//        //            }
//        //        }

//        //        lastPressed = newPressed;
//        //        lastReading = newReading;
//        //    }

//        //    // No more reading 
//        //    this.CurrentReading = lastReading;
//        //}
    
//    }

//    private MotionControllerWatcher _watcher;
//    private Dictionary<Handedness, MotionControllerState>
//        _controllers = new Dictionary<Handedness, MotionControllerState>();

//    /// <summary> 
//    /// Stops monitoring controller's connections and disconnections 
//    /// </summary> 
//    public void Stop()
//    {
//        if (_watcher != null)
//        {
//            _watcher.MotionControllerAdded -= _watcher_MotionControllerAdded;
//            _watcher.MotionControllerRemoved -= _watcher_MotionControllerRemoved;
//            _watcher.Stop();
//        }
//    }

//    /// <summary> 
//    /// called when a motion controller has been removed from the system: 
//    /// Remove a motion controller from the cache 
//    /// </summary> 
//    /// <param name="sender">motion controller watcher</param> 
//    /// <param name="e">motion controller </param> 
//    private void _watcher_MotionControllerRemoved(object sender, MotionController e)
//    {
//        lock (_controllers)
//        {
//            _controllers.Remove(e.Handedness);
//        }
//    }

//    /// <summary> 
//    /// called when a motion controller has been added to the system: 
//    /// Remove a motion controller from the cache 
//    /// </summary> 
//    /// <param name="sender">motion controller watcher</param> 
//    /// <param name="e">motion controller </param> 
//    private void _watcher_MotionControllerAdded(object sender, MotionController e)
//    {
//        lock (_controllers)
//        {
//            _controllers[e.Handedness] = new MotionControllerState(e);
//        }
//    }

//    /// <summary> 
//    /// Event raised when a button is pressed 
//    /// </summary> 
//    public event EventHandler<MotionControllerEventArgs> InputPressed;

//    /// <summary> 
//    /// Event raised when a button is released 
//    /// </summary> 
//    public event EventHandler<MotionControllerEventArgs> InputReleased;

//}

///// <summary> 
///// Event argument class for InputPressed and InputReleased events 
///// </summary> 
//public class MotionControllerEventArgs : EventArgs
//{
//    public MotionControllerEventArgs(Handedness handedness, bool isPressed, ControllerInput input, DateTime inputTime)
//    {
//        this.Handedness = handedness;
//        this.Input = input;
//        this.InputTime = inputTime;
//        this.IsPressed = isPressed;
//    }

//    /// <summary> 
//    /// Handedness of the controller raising the event 
//    /// </summary> 
//    public Handedness Handedness { get; private set; }

//    /// <summary> 
//    /// Button pressed or released 
//    /// </summary> 
//    public ControllerInput Input { get; private set; }

//    /// <summary> 
//    /// Time of the event 
//    /// </summary> 
//    public DateTime InputTime { get; private set; }

//    /// <summary> 
//    /// true if button is pressed, false otherwise 
//    /// </summary> 
//    public bool IsPressed { get; private set; }
//}

