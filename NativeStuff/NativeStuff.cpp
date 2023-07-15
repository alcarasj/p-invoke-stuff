#include "NativeStuff.h"
#include <stdio.h>

__declspec(dllexport) void say_hello(const char* name) {
	printf("Hello %s!\n", name);
}

int main() {
	// Empty main to fix LNK2019 error.
}
