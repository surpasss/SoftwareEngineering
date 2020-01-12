#include "define.h"

int init[9] = { 3, 1, 2, 4, 5, 6, 7, 8, 9 };//第1行。第1个数字固定，第2-9个数字从小到大布置

//均通过第1行的各列右移，4-6行、7-9行各6次变换
int row_trans_0[3] = { 0, 3, 6 };//生成1-3行的右移列数
int row_trans_1[6][3] = { {1, 4, 7}, {1, 7, 4}, {4, 1, 7}, {4, 7, 1}, {7, 1, 4}, {7, 4, 1} };//生成4-6行的右移列数
int row_trans_2[6][3] = { {2, 5, 8}, {2, 8, 5}, {5, 2, 8}, {5, 8, 2}, {8, 2, 5}, {8, 5, 2} };//生成7-9行的右移列数

static char buffer[165000000];//缓冲字符
static int pos;//缓冲字符串的当前写入位置

static void Init()
{
	init[0] = 3;
	init[1] = 1;
	init[2] = 2;
	init[3] = 4;
	init[4] = 5;
	init[5] = 6;
	init[6] = 7;
	init[7] = 8;
	init[8] = 9;
}

void TranslateRow(int trans_1, int trans_2, bool flag)//trans_1为row_trans_1的第一维位置，trans_2为row_trans_2的第一维位置
{
	for (int i = 0; i < 3; i++)//写入1-3行至buffer中
	{
		int trans = 9 - row_trans_0[i];
		for (int j = 0; j < 8; j++)
		{
			buffer[pos] = init[(j + trans) % 9] + '0';
			pos += 2;
		}
		buffer[pos++] = init[(8 + trans) % 9] + '0';
		buffer[pos++] = '\n';
	}
	for (int i = 3; i < 6; i++)//写入4-6行至buffer中
	{
		int trans = 9 - row_trans_1[trans_1][i - 3];
		for (int j = 0; j < 8; j++)
		{
			buffer[pos] = init[(j + trans) % 9] + '0';
			pos += 2;
		}
		buffer[pos++] = init[(8 + trans) % 9] + '0';
		buffer[pos++] = '\n';
	}
	for (int i = 6; i < 9; i++)//写入7-9行至buffer中
	{
		int trans = 9 - row_trans_2[trans_2][i - 6];
		for (int j = 0; j < 8; j++)
		{
			buffer[pos] = init[(j + trans) % 9] + '0';
			pos += 2;
		}
		buffer[pos++] = init[(8 + trans) % 9] + '0';
		buffer[pos++] = '\n';
	}
	if (flag == false)
		buffer[pos++] = '\n';
}

void CreateSudoku(int n)//需生成的终局个数
{
	ofstream out("sudoku.txt");//打开文件
	/*if (!out)
	{
		cout << "Open File Failed!" << endl;
		return;
	}*/
	memset(buffer, ' ', sizeof(buffer));
	pos = 0;
	Init();
	int num = 0;//已生成的终局个数
	do
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				num += 1;
				if (num < n)//生成终局个数未达标，终局之间换行
				{
					TranslateRow(i, j, false);
				}
				else//生成终局个数已达标，写入文件并退出
				{
					TranslateRow(i, j, true);
					out.write(buffer, pos - 1);
					out.clear();
					out.close();
					cout << "Create sudokus successfully." << endl;
					return;
				}
			}
		}
	} while (next_permutation(init + 1, init + 9));//从init第二个数字开始全排列
	
}
