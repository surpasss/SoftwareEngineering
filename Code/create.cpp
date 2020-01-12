#include "define.h"

int init[9] = { 3, 1, 2, 4, 5, 6, 7, 8, 9 };//��1�С���1�����̶ֹ�����2-9�����ִ�С������

//��ͨ����1�еĸ������ƣ�4-6�С�7-9�и�6�α任
int row_trans_0[3] = { 0, 3, 6 };//����1-3�е���������
int row_trans_1[6][3] = { {1, 4, 7}, {1, 7, 4}, {4, 1, 7}, {4, 7, 1}, {7, 1, 4}, {7, 4, 1} };//����4-6�е���������
int row_trans_2[6][3] = { {2, 5, 8}, {2, 8, 5}, {5, 2, 8}, {5, 8, 2}, {8, 2, 5}, {8, 5, 2} };//����7-9�е���������

static char buffer[165000000];//�����ַ�
static int pos;//�����ַ����ĵ�ǰд��λ��

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

void TranslateRow(int trans_1, int trans_2, bool flag)//trans_1Ϊrow_trans_1�ĵ�һάλ�ã�trans_2Ϊrow_trans_2�ĵ�һάλ��
{
	for (int i = 0; i < 3; i++)//д��1-3����buffer��
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
	for (int i = 3; i < 6; i++)//д��4-6����buffer��
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
	for (int i = 6; i < 9; i++)//д��7-9����buffer��
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

void CreateSudoku(int n)//�����ɵ��վָ���
{
	ofstream out("sudoku.txt");//���ļ�
	/*if (!out)
	{
		cout << "Open File Failed!" << endl;
		return;
	}*/
	memset(buffer, ' ', sizeof(buffer));
	pos = 0;
	Init();
	int num = 0;//�����ɵ��վָ���
	do
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				num += 1;
				if (num < n)//�����վָ���δ��꣬�վ�֮�任��
				{
					TranslateRow(i, j, false);
				}
				else//�����վָ����Ѵ�꣬д���ļ����˳�
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
	} while (next_permutation(init + 1, init + 9));//��init�ڶ������ֿ�ʼȫ����
	
}
