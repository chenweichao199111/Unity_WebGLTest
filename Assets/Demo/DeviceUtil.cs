#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif
using UnityEngine;

namespace Logic
{
    public class DeviceUtil
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern int GetSystemRam();

        [DllImport("__Internal")]
        private static extern int GetGpuRam();

        [DllImport("__Internal")]
        private static extern int GetProcessorCount();
#endif

        /// <summary>
        /// 获取系统内存，单位MB
        /// </summary>
        /// <returns></returns>
        public static int GetSystemMemory() 
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            return GetSystemRam() * 1024;
#else
            return SystemInfo.systemMemorySize;
#endif
        }

        /// <summary>
        /// 获取图形显卡内存，单位MB
        /// </summary>
        /// <returns></returns>
        public static int GetGpuMemory()
        {
            return SystemInfo.graphicsMemorySize;
        }

        /// <summary>
        /// 获取处理器核心数量
        /// </summary>
        /// <returns></returns>
        public static int GetCpuProcessorCount()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            return GetProcessorCount();
#else
            return SystemInfo.processorCount;
#endif
        }
    }
}
