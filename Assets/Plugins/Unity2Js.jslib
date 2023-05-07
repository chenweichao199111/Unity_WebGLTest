mergeInto(LibraryManager.library,{
	GetSystemRam:function()
	{
		var memory = getDeviceMemory();
		return memory;
	},
	GetGpuRam:function()
	{
		var memory = getGpuMemory();
		return memory;
	},
	GetProcessorCount:function()
	{
		var processorCount = getProcessorCount();
		return processorCount;
	},
	OnCopy:function(content)
	{
		// 调用js端写好的copy函数, 传入字符串必须通过Pointer_stringify做一次转换才可使用
	    copy(Pointer_stringify(content));
	}
});