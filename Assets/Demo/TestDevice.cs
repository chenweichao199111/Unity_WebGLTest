using Logic;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestDevice : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public Button getDeviceBtn;

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void OnCopy(string content);
#endif

    void Start()
    {
        DevicePerformanceLevel dpl = DevicePerformanceUtil.GetDevicePerformanceLevel();
        if (dpl == DevicePerformanceLevel.High)
        {
            Debug.Log("当前设备是高性能设备");
            QualitySettings.SetQualityLevel(5);
        }
        else if (dpl == DevicePerformanceLevel.Mid)
        {
            Debug.Log("当前设备是中性能设备");
            QualitySettings.SetQualityLevel(2);
        }
        else 
        {
            Debug.Log("当前设备是低性能设备");
            QualitySettings.SetQualityLevel(0, true);
        }

#region 显示部分
        if (dpl == DevicePerformanceLevel.High)
        {
            string str = string.Format("显卡名称：{0}\r\n显卡存储：{1}MB\r\nCPU核心：{2}\r\n内存：{3}MB",
                SystemInfo.graphicsDeviceName,
                DeviceUtil.GetGpuMemory(),
                DeviceUtil.GetCpuProcessorCount(),
                DeviceUtil.GetSystemMemory());
            str = string.Format("{0}\r\n当前设备是高性能设备", str);
            textMeshPro.text = str;
        }
        else if (dpl == DevicePerformanceLevel.Mid)
        {
            string str = string.Format("显卡名称：{0}\r\n显卡存储：{1}MB\r\nCPU核心：{2}\r\n内存：{3}MB",
                SystemInfo.graphicsDeviceName,
                DeviceUtil.GetGpuMemory(),
                DeviceUtil.GetCpuProcessorCount(),
                DeviceUtil.GetSystemMemory());
            str = string.Format("{0}\r\n当前设备是中性能设备", str);
            textMeshPro.text = str;
        }
        else
        {
            string str = string.Format("显卡名称：{0}\r\n显卡存储：{1}MB\r\nCPU核心：{2}\r\n内存：{3}MB",
                SystemInfo.graphicsDeviceName,
                DeviceUtil.GetGpuMemory(),
                DeviceUtil.GetCpuProcessorCount(),
                DeviceUtil.GetSystemMemory());
            str = string.Format("{0}\r\n当前设备是低性能设备", str);
            textMeshPro.text = str;
        }
        getDeviceBtn.onClick.AddListener(OnClickGetDeviceBtn);
#endregion
    }

    private void OnClickGetDeviceBtn()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OnCopy(textMeshPro.text);
#else
        GUIUtility.systemCopyBuffer = textMeshPro.text;
#endif
    }
}
