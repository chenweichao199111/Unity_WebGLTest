using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestDevice : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public Button getDeviceBtn;

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
            int level = QualitySettings.GetQualityLevel();
            Debug.Log("质量等级由" + level + "调成0");
            QualitySettings.SetQualityLevel(0, true);
        }

        #region 显示部分
        if (dpl == DevicePerformanceLevel.High)
        {
            textMeshPro.text = string.Format("显卡存储：{0}MB\r\nCPU核心：{1}\r\n内存：{2}MB\r\n当前设备是高性能设备",
                SystemInfo.graphicsMemorySize, SystemInfo.processorCount, SystemInfo.systemMemorySize);
        }
        else if (dpl == DevicePerformanceLevel.Mid)
        {
            textMeshPro.text = string.Format("显卡存储：{0}MB\r\nCPU核心：{1}\r\n内存：{2}MB\r\n当前设备是中性能设备",
                SystemInfo.graphicsMemorySize, SystemInfo.processorCount, SystemInfo.systemMemorySize);
        }
        else
        {
            textMeshPro.text = string.Format("显卡存储：{0}MB\r\nCPU核心：{1}\r\n内存：{2}MB\r\n当前设备是低性能设备",
                SystemInfo.graphicsMemorySize, SystemInfo.processorCount, SystemInfo.systemMemorySize);
        }
        getDeviceBtn.onClick.AddListener(OnClickGetDeviceBtn);
        #endregion
    }

    private void OnClickGetDeviceBtn()
    {
        GUIUtility.systemCopyBuffer = textMeshPro.text;
    }
}
