#include "mail.h"
#include <stdio.h>

int main(int argc, char* argv[]) {
    if (argc < 4) {
        printf("Usage: mail <subject> <body> <to>");
        return 0;
    }
    
    int result = send_email(argv[1], argv[2], argv[3]);
    // true is returned
    return result == 1;
}
