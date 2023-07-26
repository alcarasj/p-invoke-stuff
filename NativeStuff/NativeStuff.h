#include <comutil.h>
#ifndef _NATIVESTUFF_H_
#define _NATIVESTUFF_H_

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport) char * say_hello(char * name);

#ifdef __cplusplus
}
#endif

#endif _NATIVESTUFF_H_