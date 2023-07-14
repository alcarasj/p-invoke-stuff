#include "NativeStuff.h"
#include <stdio.h>

__declspec(dllexport) void print_line(const char* str) {
	printf("%s\n", str);
}

int main() {
	// Empty main to fix LNK2019 error.
}
