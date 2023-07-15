#include "NativeStuff.h"
#include <stdio.h>

__declspec(dllexport) void say_hello(_DATA* data) {
	std::string name = data->name;
	std::string greeting = "Hello " + name;

	unsigned int size = greeting.length() + 1;
	strcpy_s(data->greeting, size, greeting.c_str());
}

int main() {
	// Empty main to fix LNK2019 error.
}
