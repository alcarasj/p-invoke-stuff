#include <string>
#ifndef _NATIVESTUFF_H_
#define _NATIVESTUFF_H_

typedef struct _DATA
{
    char* name;
    char* greeting;
} _GREETING;

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport) void say_hello(_DATA* data);

#ifdef __cplusplus
}
#endif

#endif // _NATIVESTUFF_H_