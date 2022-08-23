#include "mail.h"
#include <Windows.h>
#include <stdio.h>

int send_email(char* subject, char* body, char* to) {
    // load the library
    HMODULE hLib = LoadLibrary("HenryQuan.Mail.dll");
    if (hLib == NULL) {
        printf("Failed to load HenryQuan.Mail.dll\n");
        return -1;
    }

    // get the function address
    typedef int(*SendEmail)(char*, char*, char*);
    SendEmail pSendEmail = (SendEmail)GetProcAddress(hLib, "SendEmail");
    if (pSendEmail == NULL) {
        printf("Failed to get the address of SendEmail\n");
        return -1;
    }

    return pSendEmail(subject, body, to);
}
