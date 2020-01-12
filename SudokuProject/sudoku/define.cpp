//define.cpp

#include "define.h"

int ConvertNum(char *s)
{
	int len = strlen(s);
	if (len >= 7 && strcmp(s, "1000000"))//排除大于1e6的整数
		return -1;
	else if (s[0] == '0')//排除0和前缀0
		return -1;
	int num = 0;
	for (int i = 0; i < len; i++)
	{
		if (!isdigit(s[i]))//排除非数字字符
			return -1;
		else   num = num * 10 + s[i] - '0';
	}
	return num;
}