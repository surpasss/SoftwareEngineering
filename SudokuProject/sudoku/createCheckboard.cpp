#include "define.h"

int node[9] = { 0, 3, 6, 27, 30, 33, 54, 57, 60 };//每个3*3方块中左上角方格的序号
int bias[9] = { 0, 1, 2, 9, 10, 11, 18, 19, 20 };//3*3方块中的9个方格相比于左上角方格的序号偏置


void CreateCheckboard(int n)//需生成的终局个数
{
	CreateSudoku(n);//生成n个终局
	ifstream in("answer.txt");
	if (!in)
	{
		cout << "Open File Failed!" << endl;
		return;
	}
	stringstream buf;
	buf << in.rdbuf();//一次性读取
	in.clear();
	in.close();
	string s = buf.str();

	srand((unsigned)time(NULL));

	for (int index = 0; index < s.length(); index += 163)//循环每个终局
	{
		int num = 0;//该终局已挖空的方格数量
		for (int i = 0; i < 9; i++)//循环9个3*3方块
		{
			int a = index + node[i] * 2;//该3*3方块左上角方格的下标
			int n = rand() % 5 + 2;//随机生成该3*3方块需要挖空的方格数量，2<=n<=6
			//printf("n: %d\n", n);
			for (int j = 0; j < n; )//循环挖空，直到挖空n个方格退出循环
			{
				int m = rand() % 9;
				if (s.at(a + bias[m] * 2) != '0')
				{
					s.at(a + bias[m] * 2) = '0';
					j++;
				}
			}
			num += n;
		}
		//printf("num: %d\n\n", num);
		while (num < 30)//继续挖空，直到达到30个
		{
			int x = rand() % 80;
			if (s.at(index + x * 2) != '0')
			{
				s.at(index + x * 2) = '0';
				num++;
			}
		}
	}
	ofstream out("checkboard.txt");//将所有棋盘写入checkboard.txt文件
	out << s;
	out.clear();
	out.close();

}