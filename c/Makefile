CC=gcc

all: shared main
main:
	$(CC) -o main main.c mail.c
shared:
	$(CC) -shared -o libmail.dll mail.c
clean:
	del *.dll *.exe
