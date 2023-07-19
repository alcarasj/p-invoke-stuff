#include "NativeStuff.h"
#include <stdio.h>
#include <comutil.h>

BSTR concat(BSTR a, BSTR b)
{
    auto lengthA = SysStringLen(a);
    auto lengthB = SysStringLen(b);

    auto result = SysAllocStringLen(NULL, lengthA + lengthB);

    memcpy(result, a, lengthA * sizeof(OLECHAR));
    memcpy(result + lengthA, b, lengthB * sizeof(OLECHAR));

    result[lengthA + lengthB] = 0;
    return result;
}

__declspec(dllexport) BSTR say_hello(BSTR name)
{
	BSTR hello = ::SysAllocString(L"Hello ");
	BSTR exclamationPoint = ::SysAllocString(L"!");
    BSTR greeting = concat(hello, name);

    return concat(greeting, exclamationPoint);
}

int main() 
{
	// Empty main to fix LNK2019 error.
}
