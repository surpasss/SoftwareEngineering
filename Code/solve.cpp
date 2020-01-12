#include "define.h"

static char buffer[165000000];//����ַ���
static int pos;//����ַ����ĵ�ǰд��λ��

int map[9][9];
bool flag;//�Ƿ������
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
};//��ӦС��������


//������ʼ��
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
				occupy[0][i][tmp] = 1;//�����к�
				occupy[1][j][tmp] = 1;//�����к�
				occupy[2][belong[i][j]][tmp] = 1;//����С�������
			}
		}
}


//nΪС���ӵ����(0-80)��keyΪ�Ƿ�����С���ӵ�����(1-9)
bool Check(int n, int key)
{
	int x = n / 9;//�к�
	int y = n % 9;//�к�
	if (occupy[0][x][key])	return false;
	else if (occupy[1][y][key])	 return false;
	else if (occupy[2][belong[x][y]][key])	return false;
	return true;//��������������
}

void DFS(int n)
{
	if (n > 80)//�ѵ�������С����
	{
		flag = true;
		return;
	}
	if (map[n / 9][n % 9] != 0)//�����
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
				//�ݴ�ԭֵ
				int a = occupy[0][x][i];
				int b = occupy[1][y][i];
				int c = occupy[2][belong[x][y]][i];
				//����
				map[x][y] = i;
				occupy[0][x][i] = 1;
				occupy[1][y][i] = 1;
				occupy[2][belong[x][y]][i] = 1;
				DFS(n + 1);//�ݹ�
				//����⣬������
				if (flag == true)
					return;
				//��ԭ
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
	//���ļ�
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
	buf << in.rdbuf();//һ���Զ�ȡ
	string s = buf.str();
	int index = 0;//�ַ���s�ĵ�ǰ�±�
	memset(buffer, ' ', sizeof(buffer));//�ÿո��ʼ������ַ���
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
				index += 2;//�����ո������ĩ���з�
			}
		index += 1;//�������������֮��Ļ��з�
		Init();
		DFS(0);
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				buffer[pos] = map[i][j] + '0';
				pos += 2;//�����ո�
			}
			buffer[pos++] = map[i][8] + '0';
			buffer[pos++] = '\n';
		}
		buffer[pos++] = '\n';
	}
	out.write(buffer, pos - 2);//��д�����Ļ��з�
	cout << "Solve Finished." << endl;
	//�ر��ļ�
	in.clear();
	in.close();
	out.clear();
	out.close();
}