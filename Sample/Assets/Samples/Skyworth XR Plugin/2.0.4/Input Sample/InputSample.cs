using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class InputSample : MonoBehaviour
{
    [Header("HMD")]
    public Text HMD_position;
    public Text HMD_rotation;
    public GameObject HMD_ClickButton;
    public GameObject HMD_VolumeUpButton;
    public GameObject HMD_VolumeDownButton;
    [Header("RightController")]
    public GameObject R_Connected;
    public Text R_position;
    public Text R_rotation;
    public Text R_DeviceVelocity;
    public Text R_DeviceAngularVelocity;
    public Text R_battery;
    public Text R_trigger;
    public Text R_grip;
    public GameObject R_PrimaryButton;
    public GameObject R_PrimaryTouch;
    public GameObject R_SecondaryButton;
    public GameObject R_SecondaryTouch;
    public GameObject R_GripButton;
    public GameObject R_Menu;
    public GameObject R_TriggerButton;
    public GameObject R_TriggerTouch;
    public GameObject R_Primary2DAxisClick;
    public GameObject R_Primary2DAxisTouch;
    public Text R_Primary2DAxis;
    public Text R_Name;
    public Text R_Manufacturer;
    public Text R_TrackState;
    [Header("LeftController")]
    public GameObject L_Connected;
    public Text L_position;
    public Text L_rotation;
    public Text L_DeviceVelocity;
    public Text L_DeviceAngularVelocity;
    public Text L_battery;
    public Text L_trigger;
    public Text L_grip;
    public GameObject L_PrimaryButton;
    public GameObject L_PrimaryTouch;
    public GameObject L_SecondaryButton;
    public GameObject L_SecondaryTouch;
    public GameObject L_GripButton;
    public GameObject L_Menu;
    public GameObject L_TriggerButton;
    public GameObject L_TriggerTouch;
    public GameObject L_Primary2DAxisClick;
    public GameObject L_Primary2DAxisTouch;
    public Text L_Primary2DAxis;
    public Text L_Name;
    public Text L_Manufacturer;
    public Text L_TrackState;

    [Header("震动")]
    public Slider amplitudeSlider;
    public Text amplitudeSliderText;
    public Slider timeSlider;
    public Text timeSliderText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        amplitudeSliderText.text = amplitudeSlider.value.ToString();
        timeSliderText.text = timeSlider.value.ToString();
        UpdateHMDDevice();

        UpdateRightControllerDevice();
        UpdateLeftControllerDevice();
    }
    private void UpdateHMDDevice()
    {
        InputDevice HMDDevice = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
        if (HMDDevice.TryGetFeatureValue(CommonUsages.centerEyePosition, out Vector3 position))
        {
            HMD_position.text = position.ToString();
        }
        if (HMDDevice.TryGetFeatureValue(CommonUsages.centerEyeRotation, out Quaternion rotation))
        {
            HMD_rotation.text = rotation.ToString();
        }
       
        if (HMDDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool clickvalue))
        {
            HMD_ClickButton.SetActive(clickvalue);
        }
        if (HMDDevice.TryGetFeatureValue(new InputFeatureUsage<bool>("VolumeUpButton"), out bool VolumeUpvalue))
        {
            HMD_VolumeUpButton.SetActive(VolumeUpvalue);
        }
        if (HMDDevice.TryGetFeatureValue(new InputFeatureUsage<bool>("VolumeDownButton"), out bool VolumeDownvalue))
        {
            HMD_VolumeDownButton.SetActive(VolumeDownvalue);
        }
    }
    private void UpdateRightControllerDevice()
    {
        InputDevice RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if(RightControllerDevice.TryGetFeatureValue(CommonUsages.trackingState,out InputTrackingState state))
        {
            R_TrackState.text = GetTrackStateStr(state);
        }
        R_Connected.SetActive(RightControllerDevice.isValid);
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position)) 
        {
            R_position.text = position.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
        {
            R_rotation.text = rotation.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 DeviceVelocity))
        {
            R_DeviceVelocity.text = DeviceVelocity.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out Vector3 DeviceAngularVelocity))
        {
            R_DeviceAngularVelocity.text = DeviceAngularVelocity.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.batteryLevel, out float battery))
        {
            R_battery.text = battery.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue))
        {
            R_trigger.text = triggervalue.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.grip, out float Gripvalue))
        {
            R_grip.text = Gripvalue.ToString();
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool PrimaryButtonvalue))
        {
            R_PrimaryButton.SetActive(PrimaryButtonvalue);
            if(PrimaryButtonvalue)
                ToShadk(RightControllerDevice);
        }
        else
        {
            R_PrimaryButton.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool PrimaryTouchvalue))
        {
            R_PrimaryTouch.SetActive(PrimaryTouchvalue);
        }
        else
        {
            R_PrimaryTouch.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool SecondaryButtonvalue))
        {
            R_SecondaryButton.SetActive(SecondaryButtonvalue);
        }
        else
        {
            R_SecondaryButton.SetActive(false);
        }

        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool SecondaryTouchvalue))
        {
            R_SecondaryTouch.SetActive(SecondaryTouchvalue);
        }
        else
        {
            R_SecondaryTouch.SetActive(false);
        }
        
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool GripButtonvalue))
        {
            R_GripButton.SetActive(GripButtonvalue);
        }
        else
        {
            R_GripButton.SetActive(false);
        }

        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool Menuvalue))
        {
            R_Menu.SetActive(Menuvalue);
        }
        else
        {
            R_Menu.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool TriggerButtonvalue))
        {
            R_TriggerButton.SetActive(TriggerButtonvalue);
            
        }
        else
        {
            R_TriggerButton.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(new InputFeatureUsage<bool>("TriggerTouch"), out bool TriggerTouchvalue))
        {
            R_TriggerTouch.SetActive(TriggerTouchvalue);
        }
        else
        {
            R_TriggerTouch.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool Primary2DAxisClickvalue))
        {
            R_Primary2DAxisClick.SetActive(Primary2DAxisClickvalue);
        }
        else
        {
            R_Primary2DAxisClick.SetActive(false);
        }
       
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool Primary2DAxisTouchvalue))
        {
            R_Primary2DAxisTouch.SetActive(Primary2DAxisTouchvalue);
        }
        else
        {
            R_Primary2DAxisTouch.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerbuttonvalue))
        {
            R_TriggerButton.SetActive(triggerbuttonvalue);
        }
        else
        {
            R_TriggerButton.SetActive(false);
        }
        if (RightControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 Primary2DAxisvalue))
        {
            R_Primary2DAxis.text = Primary2DAxisvalue.ToString();
        }
        
        if (RightControllerDevice.isValid)
        {
            R_Name.text = RightControllerDevice.name;
            R_Manufacturer.text = RightControllerDevice.manufacturer;
        }
        
    }
    private string GetTrackStateStr(InputTrackingState state) 
    {
        StringBuilder sb = new StringBuilder();
        if ((state & InputTrackingState.Position) != InputTrackingState.None) 
        {
            sb.Append("空间位置");
        }
        if ((state & InputTrackingState.Rotation) != InputTrackingState.None)
        {
            sb.Append("和");
            sb.Append("角度坐标");
        }
        if ((state & InputTrackingState.Velocity) != InputTrackingState.None)
        {
            sb.Append("和");
            sb.Append("加速度");
        }
        if ((state & InputTrackingState.AngularVelocity) != InputTrackingState.None)
        {
            sb.Append("和");
            sb.Append("角速度");
        }

        return sb.ToString();
    }
    private void UpdateLeftControllerDevice()
    {
        InputDevice LeftControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.trackingState, out InputTrackingState state))
        {
            
            L_TrackState.text = GetTrackStateStr(state);
        }
        L_Connected.SetActive(LeftControllerDevice.isValid);
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position))
        {
            L_position.text = position.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
        {
            L_rotation.text = rotation.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 DeviceVelocity))
        {
            L_DeviceVelocity.text = DeviceVelocity.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out Vector3 DeviceAngularVelocity))
        {
            L_DeviceAngularVelocity.text = DeviceAngularVelocity.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.batteryLevel, out float battery))
        {
            L_battery.text = battery.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggervalue))
        {
            L_trigger.text = triggervalue.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.grip, out float Gripvalue))
        {
            L_grip.text = Gripvalue.ToString();
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool PrimaryButtonvalue))
        {
            L_PrimaryButton.SetActive(PrimaryButtonvalue);
            if(PrimaryButtonvalue)
                ToShadk(LeftControllerDevice);
        }
        else
        {
            L_PrimaryButton.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool PrimaryTouchvalue))
        {
            L_PrimaryTouch.SetActive(PrimaryTouchvalue);
        }
        else
        {
            L_PrimaryTouch.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool SecondaryButtonvalue))
        {
            L_SecondaryButton.SetActive(SecondaryButtonvalue);
        }
        else
        {
            L_SecondaryButton.SetActive(false);
        }

        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool SecondaryTouchvalue))
        {
            L_SecondaryTouch.SetActive(SecondaryTouchvalue);
        }
        else
        {
            L_SecondaryTouch.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool GripButtonvalue))
        {
            L_GripButton.SetActive(GripButtonvalue);
        }
        else
        {
            L_GripButton.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool Menuvalue))
        {
            L_Menu.SetActive(Menuvalue);
        }
        else
        {
            L_Menu.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool TriggerButtonvalue))
        {
            L_TriggerButton.SetActive(TriggerButtonvalue);
            
        }
        else
        {
            L_TriggerButton.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(new InputFeatureUsage<bool>("TriggerTouch"), out bool TriggerTouchvalue))
        {
            L_TriggerTouch.SetActive(TriggerTouchvalue);
        }
        else
        {
            L_TriggerTouch.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool Primary2DAxisClickvalue))
        {
            L_Primary2DAxisClick.SetActive(Primary2DAxisClickvalue);
        }
        else
        {
            L_Primary2DAxisClick.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool Primary2DAxisTouchvalue))
        {
            L_Primary2DAxisTouch.SetActive(Primary2DAxisTouchvalue);
        }
        else
        {
            L_Primary2DAxisTouch.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerbuttonvalue))
        {
            L_TriggerButton.SetActive(triggerbuttonvalue);
        }
        else
        {
            L_TriggerButton.SetActive(false);
        }
        if (LeftControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 Primary2DAxisvalue))
        {
            L_Primary2DAxis.text = Primary2DAxisvalue.ToString();
        }

        if (LeftControllerDevice.isValid)
        {
            L_Name.text = LeftControllerDevice.name;
            L_Manufacturer.text = LeftControllerDevice.manufacturer;
        }


    }

    public void ToShadk(InputDevice inputDevice)
    {
        float amplitudevalue = amplitudeSlider.value;
        float timevalue = timeSlider.value;
        if (inputDevice.isValid)
            inputDevice.SendHapticImpulse(0, amplitudevalue, timevalue);
    }
}
