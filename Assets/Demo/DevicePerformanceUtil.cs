using UnityEngine;

namespace Logic
{
    public static class DevicePerformanceUtil
    {
        /// <summary>
        /// 获取设备性能评级
        /// </summary>
        /// <returns>性能评级</returns>
        public static DevicePerformanceLevel GetDevicePerformanceLevel()
        {
            if (SystemInfo.graphicsDeviceVendorID == 32902)
            {
                Debug.Log("当前设备显卡是集成显卡");
                //集显
                return DevicePerformanceLevel.Low;
            }
            else //NVIDIA系列显卡(N卡)和AMD系列显卡
            {
                Debug.Log("CPU核心数:" + SystemInfo.processorCount);
                //根据目前硬件配置三个平台设置了不一样的评判标准(仅个人意见)
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_WEBGL
                if (SystemInfo.processorCount <= 2)
#elif UNITY_STANDALONE_OSX || UNITY_IPHONE
            if (SystemInfo.processorCount < 2)
#elif UNITY_ANDROID
            if (SystemInfo.processorCount <= 4)
#endif
                {
                    //CPU核心数<=2判定为低端
                    return DevicePerformanceLevel.Low;
                }
                else
                {
                    //显存
                    int graphicsMemorySize = SystemInfo.graphicsMemorySize;
                    Debug.Log("显存:" + graphicsMemorySize);
                    //内存
                    int systemMemorySize = SystemInfo.systemMemorySize;
                    Debug.Log("内存:" + systemMemorySize);
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_WEBGL
                    if (graphicsMemorySize >= 4000 && systemMemorySize >= 8000)
                        return DevicePerformanceLevel.High;
                    else if (graphicsMemorySize >= 2000 && systemMemorySize >= 4000)
                        return DevicePerformanceLevel.Mid;
                    else
                        return DevicePerformanceLevel.Low;
#elif UNITY_STANDALONE_OSX || UNITY_IPHONE
            if (graphicsMemorySize >= 4000 && systemMemorySize >= 8000)
                    return DevicePerformanceLevel.High;
                else if (graphicsMemorySize >= 2000 && systemMemorySize >= 4000)
                    return DevicePerformanceLevel.Mid;
                else
                    return DevicePerformanceLevel.Low;
#elif UNITY_ANDROID
            if (graphicsMemorySize >= 6000 && systemMemorySize >= 8000)
                    return DevicePerformanceLevel.High;
                else if (graphicsMemorySize >= 2000 && systemMemorySize >= 4000)
                    return DevicePerformanceLevel.Mid;
                else
                    return DevicePerformanceLevel.Low;
#endif
                }
            }
        }
    }
    public enum DevicePerformanceLevel
    {
        Low,
        Mid,
        High
    }
}