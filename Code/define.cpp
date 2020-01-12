//define.cpp

#include "define.h"

int ConvertNum(char *s)
{
	int len = strlen(s);
	if (len >= 7 && strcmp(s, "1000000"))//�ų�����1e6������
		return -1;
	else if (s[0] == '0')//�ų�0��ǰ׺0
		return -1;
	int num = 0;
	for (int i = 0; i < len; i++)
	{
		if (!isdigit(s[i]))//�ų��������ַ�
			return -1;
		else   num = num * 10 + s[i] - '0';
	}
	return num;
}