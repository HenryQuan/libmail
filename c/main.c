#include "mail.h"
#include <stdio.h>

int main() {
    int result = send_email("Hello", "Hello World", "");
    // true is returned
    return result == 1;
}
