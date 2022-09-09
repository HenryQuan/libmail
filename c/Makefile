CC=gcc

all: shared main
main:
	$(CC) -o mail main.c mail.c
shared:
	$(CC) -shared -o libmail.dll mail.c
clean:
	del *.dll *.exe
