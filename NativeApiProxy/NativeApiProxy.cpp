#include <windows.h>

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

#include "../include/types.h"

class IComponentBase
{
public:
	virtual ~IComponentBase() {}
};

typedef const WCHAR_T* (*GetClassNamesPtr)();
typedef long(*GetClassObjectPtr)(const wchar_t* wsName, IComponentBase** pInterface);
typedef long(*DestroyObjectPtr)(IComponentBase** pIntf);

extern "C" __declspec(dllexport) const WCHAR_T * GetClassNames(const WCHAR_T * wsLibrary)
{
	auto hModule = LoadLibrary(wsLibrary);
	if (hModule == nullptr) return nullptr;
	auto proc = (GetClassNamesPtr)GetProcAddress(hModule, "GetClassNames");
	return proc();
}

extern "C" __declspec(dllexport) IComponentBase * GetClassObject(const WCHAR_T * wsLibrary, const WCHAR_T * wsName)
{
	auto hModule = LoadLibrary(wsLibrary);
	if (hModule == nullptr) return nullptr;
	auto proc = (GetClassObjectPtr)GetProcAddress(hModule, "GetClassObject");
	if (proc == nullptr) return nullptr;
	IComponentBase* pComponent = nullptr;
	auto ok = proc(wsName, &pComponent);
	return pComponent;
}

extern "C" __declspec(dllexport) long DestroyObject(IComponentBase * pInterface)
{
	if (pInterface) delete pInterface;
	return 0;
}
