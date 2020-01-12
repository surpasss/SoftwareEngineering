#include "define.h"

static int map[9][9];
int judge[10];
string strings[1000];

bool IsSudoku()
{
	for (int i = 0; i < 9; i++)//遍历1-9行
	{
		memset(judge, 0, sizeof(judge));
		for (int j = 0; j < 9; j++)//遍历该行的每个小方格
		{
			int x = map[i][j];
			judge[x] = 1;
		}
		for (int k = 1; k <= 9; k++)
		{
			if (judge[k] != 1)
				return false;
		}
	}
	for (int i = 0; i < 9; i++)//遍历1-9列
	{
		memset(judge, 0, sizeof(judge));
		for (int j = 0; j < 9; j++)//遍历该列的每个小方格
		{
			int x = map[j][i];
			judge[x] = 1;
		}
		for (int k = 1; k <= 9; k++)
		{
			if (judge[k] != 1)
				return false;
		}
	}
	//遍历每个3*3方块
	for (int i = 0; i < 9; i += 3)
		for (int j = 0; j < 9; j += 3)
		{
			memset(judge, 0, sizeof(judge));
			//遍历该方块的每个小方格
			for (int a = 0; a < 3; a++)
				for (int b = 0; b < 3; b++)
				{
					int x = map[i + a][j + b];
					judge[x] = 1;
				}
			for (int k = 1; k <= 9; k++)
			{
				if (judge[k] != 1)
					return false;
			}
		}
	return true;
}

bool IsUnique(int n)
{
	bool flag = true;
	for (int i = 0; i < n; i++)
		for (int j = i + 1; j < n; j++)
		{
			if (strings[i] == strings[j])
			{
				printf("Wrong! position %d and position %d are same.\n", i, j);
				flag = false;
			}
		}
	return flag;
}


void TestCreate()
{
	//一次性读文件，保存在字符串s中
	ifstream in("1000.txt");
	if (!in)
	{
		cout << "Open File Failed!" << endl;
		return;
	}
	stringstream buf;
	buf << in.rdbuf();//一次性读取
	string s = buf.str();
	in.clear();
	in.close();

	//判断每个数独是否合法
	int index = 0;//字符串s的当前下标
	bool flag = true;
	while (index + 161 <= s.length())
	{
		for (int i = 0; i < 9; i++)
			for (int j = 0; j < 9; j++)
			{
				map[i][j] = s.at(index) - '0';
				index += 2;//跳过空格和行末换行符
			}
		index += 1;
		if (!IsSudoku())
		{
			cout << "Wrong! " << "Postion: " << (index - 1) / 163 << endl;
			flag = false;
		}
	}
	if (flag == true)
	{
		cout << "Right, all sudokus are legal." << endl;
	}

	//判断每个数独是否唯一
	int num = (s.length() + 2) / 163;
	for (int i = 0; i < num; i++)
	{
		strings[i] = s.substr(i * 163, 161);
	}
	if (IsUnique(num))
	{
		cout << "Right, all sudokus are unique." << endl;
	}
}