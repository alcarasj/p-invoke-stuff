#include "NativeStuff.h"
#include <stdio.h>

__declspec(dllexport) char * say_hello(char * name)
{
	const char* hello = "Hello ";
	const char* exclamationPoint = "!";
	size_t greetingLength = strlen(hello) + strlen(name) + strlen(exclamationPoint) + 1;
	char* greeting = (char *) malloc(greetingLength);
	strcpy_s(greeting, greetingLength, hello);
	strcat_s(greeting, greetingLength, name);
	strcat_s(greeting, greetingLength, exclamationPoint);
	return greeting;
}

int main() 
{
	// Empty main to fix LNK2019 error.
}
