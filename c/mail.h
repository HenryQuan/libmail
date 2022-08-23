#ifndef _HENRYQUAN_MAIL_H_
#define _HENRYQUAN_MAIL_H_

/// Call `SendEmail` from .NET DLL
/// @param subject The subject of the email
/// @param body The body of the email
/// @param to The email address of the recipient
int send_email(char*, char*, char*);

#endif
