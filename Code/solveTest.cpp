#include "define.h"

void CreateTestFile()
{
	//һ���Զ�ȡ�����վ��ļ����������ַ���s��
	ifstream in("1000.txt");
	if (!in)
	{
		cout << "Open 1000.txt Failed!" << endl;
		return;
	}
	stringstream buf;
	buf << in.rdbuf();//һ���Զ�ȡ
	string s = buf.str();
	in.clear();
	in.close();

	//���ѡ��ÿһ�е�ĳ�������û�Ϊ0
	int index = 0;//�ַ���s�ĵ�ǰ�±�
	srand((unsigned)time(NULL));
	while (index + 161 <= s.length())
	{
		for (int i = 0; i < 9; i++)
		{
			int a = rand() % 9;//����0-8���ڵ������
			//cout << a << " ";//��ӡ�����a��ֵ
			s.at(index + a * 2) = '0';
			index += 18;//������һ�г�ʼλ��
		}
		//cout << endl;
		index += 1;//����������Ļ��з�
	}

	//���޸ĺ���ַ���sд��test_solve.txt�ļ�
	ofstream out("test_solve.txt");
	if (!out)
	{
		cout << "Open test_solve.txt Failed!" << endl;
		return;
	}
	out.write(s.c_str(), index - 2);
	out.clear();
	out.close();
	cout << "Create test_solve.txt Successed." << endl;
}

void TestSolve()
{
	CreateTestFile();//���ɲо��ļ�test_solve.txt
	char fileName[] = "test_solve.txt";
	SolveSudoku(fileName);//���о��ļ������������sudoku.txt�ļ���

	//һ���Զ�ȡ1000.txt
	ifstream in_1("1000.txt");
	stringstream buf_1;
	buf_1 << in_1.rdbuf();//һ���Զ�ȡ
	string s1 = buf_1.str();
	in_1.clear();
	in_1.close();

	//һ���Զ�ȡsudoku.txt
	ifstream in_2("sudoku.txt");
	stringstream buf_2;
	buf_2 << in_2.rdbuf();
	string s2 = buf_2.str();
	in_2.clear();
	in_2.close();

	//�Ƚ�1000.txt��sudoku.txt�������Ƿ����
	if (s1 == s2)
	{
		cout << "Confirm Right." << endl;
	}
	else
	{
		cout << "Confirm Wrong!" << endl;
	}
}