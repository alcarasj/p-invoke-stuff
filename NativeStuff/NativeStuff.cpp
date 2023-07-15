#include "NativeStuff.h"
#include <stdio.h>

__declspec(dllexport) const std::string reverse(const std::string str) {
	std::string result = "";
	for (int i = str.size() - 1; i > 0; i--) {
		result += str[i];
	}
	return result;
}

int main() {
	// Empty main to fix LNK2019 error.
}
