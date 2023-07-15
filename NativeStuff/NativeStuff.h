#include <string>
#ifndef _NATIVESTUFF_H_
#define _NATIVESTUFF_H_

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport) const std::string reverse(const std::string str);

#ifdef __cplusplus
}
#endif

#endif // _NATIVESTUFF_H_