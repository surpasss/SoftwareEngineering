#include "define.h"

static char buffer[165000000];//输出字符串
static int pos;//输出字符串的当前写入位置

int map[9][9];
bool flag;//是否已求解
int occupy[3][10][10];
int belong[9][9] =
{
	{0, 0, 0, 1, 1, 1, 2, 2, 2},
	{0, 0, 0, 1, 1, 1, 2, 2, 2},
	{0, 0, 0, 1, 1, 1, 2, 2, 2},
	{3, 3, 3, 4, 4, 4, 5, 5, 5},
	{3, 3, 3, 4, 4, 4, 5, 5, 5},
	{3, 3, 3, 4, 4, 4, 5, 5, 5},
	{6, 6, 6, 7, 7, 7, 8, 8, 8},
	{6, 6, 6, 7, 7, 7, 8, 8, 8},
	{6, 6, 6, 7, 7, 7, 8, 8, 8},
};//对应小方格的序号


//变量初始化
static void Init()
{
	flag = false;
	memset(occupy, 0, sizeof(occupy));
	for (int i = 0; i < 9; i++)
		for (int j = 0; j < 9; j++)
		{
			int tmp = map[i][j];
			if (tmp)
			{
				occupy[0][i][tmp] = 1;//所在行号
				occupy[1][j][tmp] = 1;//所在列号
				occupy[2][belong[i][j]][tmp] = 1;//所在小方格序号
			}
		}
}


//n为小格子的序号(0-80)，key为是否填充该小格子的数字(1-9)
bool Check(int n, int key)
{
	int x = n / 9;//行号
	int y = n % 9;//列号
	if (occupy[0][x][key])	return false;
	else if (occupy[1][y][key])	 return false;
	else if (occupy[2][belong[x][y]][key])	return false;
	return true;//满足条件返回真
}

void DFS(int n)
{
	if (n > 80)//已到达最后的小格子
	{
		flag = true;
		return;
	}
	if (map[n / 9][n % 9] != 0)//已填充
	{
		DFS(n + 1);
	}
	else
	{
		for (int i = 1; i <= 9; i++)
		{
			if (Check(n, i) == true)
			{
				int x = n / 9;
				int y = n % 9;
				//暂存原值
				int a = occupy[0][x][i];
				int b = occupy[1][y][i];
				int c = occupy[2][belong[x][y]][i];
				//更新
				map[x][y] = i;
				occupy[0][x][i] = 1;
				occupy[1][y][i] = 1;
				occupy[2][belong[x][y]][i] = 1;
				DFS(n + 1);//递归
				//已求解，层层回退
				if (flag == true)
					return;
				//还原
				map[x][y] = 0;
				occupy[0][x][i] = a;
				occupy[1][y][i] = b;
				occupy[2][belong[x][y]][i] = c;
			}
		}
	}
}

void SolveSudoku(char *path)
{
	//打开文件
	ifstream in(path);
	if (!in)
	{
		cout << "Open File Failed!" << endl;
		return;
	}
	ofstream out("sudoku.txt");
	/*if (!out)
	{
		cout << "Open File Failed!" << endl;
		return;
	}*/
	stringstream buf;
	buf << in.rdbuf();//一次性读取
	string s = buf.str();
	int index = 0;//字符串s的当前下标
	memset(buffer, ' ', sizeof(buffer));//用空格初始化输出字符串
	pos = 0;
	while (index + 161 <= s.length())
	{
		for (int i = 0; i < 9; i++)
			for (int j = 0; j < 9; j++)
			{
				map[i][j] = s.at(index) - '0';
				if (map[i][j] < 0 || map[i][j] > 9)
				{
					cout << "File Format Error!" << endl;
					return;
				}
				index += 2;//跳过空格或者行末换行符
			}
		index += 1;//跳过待求解问题之间的换行符
		Init();
		DFS(0);
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				buffer[pos] = map[i][j] + '0';
				pos += 2;//跳过空格
			}
			buffer[pos++] = map[i][8] + '0';
			buffer[pos++] = '\n';
		}
		buffer[pos++] = '\n';
	}
	out.write(buffer, pos - 2);//不写入最后的换行符
	cout << "Solve Finished." << endl;
	//关闭文件
	in.clear();
	in.close();
	out.clear();
	out.close();
}