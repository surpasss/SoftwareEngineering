#include "define.h"

int node[9] = { 0, 3, 6, 27, 30, 33, 54, 57, 60 };//ÿ��3*3���������ϽǷ�������
int bias[9] = { 0, 1, 2, 9, 10, 11, 18, 19, 20 };//3*3�����е�9��������������ϽǷ�������ƫ��


void CreateCheckboard(int n)//�����ɵ��վָ���
{
	CreateSudoku(n);//����n���վ�
	ifstream in("answer.txt");
	if (!in)
	{
		cout << "Open File Failed!" << endl;
		return;
	}
	stringstream buf;
	buf << in.rdbuf();//һ���Զ�ȡ
	in.clear();
	in.close();
	string s = buf.str();

	srand((unsigned)time(NULL));

	for (int index = 0; index < s.length(); index += 163)//ѭ��ÿ���վ�
	{
		int num = 0;//���վ����ڿյķ�������
		for (int i = 0; i < 9; i++)//ѭ��9��3*3����
		{
			int a = index + node[i] * 2;//��3*3�������ϽǷ�����±�
			int n = rand() % 5 + 2;//������ɸ�3*3������Ҫ�ڿյķ���������2<=n<=6
			//printf("n: %d\n", n);
			for (int j = 0; j < n; )//ѭ���ڿգ�ֱ���ڿ�n�������˳�ѭ��
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
		while (num < 30)//�����ڿգ�ֱ���ﵽ30��
		{
			int x = rand() % 80;
			if (s.at(index + x * 2) != '0')
			{
				s.at(index + x * 2) = '0';
				num++;
			}
		}
	}
	ofstream out("checkboard.txt");//����������д��checkboard.txt�ļ�
	out << s;
	out.clear();
	out.close();

}