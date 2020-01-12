#include "define.h"

void CreateTestFile()
{
	//一次性读取完整终局文件，保存在字符串s中
	ifstream in("1000.txt");
	if (!in)
	{
		cout << "Open 1000.txt Failed!" << endl;
		return;
	}
	stringstream buf;
	buf << in.rdbuf();//一次性读取
	string s = buf.str();
	in.clear();
	in.close();

	//随机选择每一行的某个数字置换为0
	int index = 0;//字符串s的当前下标
	srand((unsigned)time(NULL));
	while (index + 161 <= s.length())
	{
		for (int i = 0; i < 9; i++)
		{
			int a = rand() % 9;//生成0-8以内的随机数
			//cout << a << " ";//打印随机数a的值
			s.at(index + a * 2) = '0';
			index += 18;//跳至下一行初始位置
		}
		//cout << endl;
		index += 1;//跳过数独间的换行符
	}

	//把修改后的字符串s写入test_solve.txt文件
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
	CreateTestFile();//生成残局文件test_solve.txt
	char fileName[] = "test_solve.txt";
	SolveSudoku(fileName);//求解残局文件，结果保存在sudoku.txt文件中

	//一次性读取1000.txt
	ifstream in_1("1000.txt");
	stringstream buf_1;
	buf_1 << in_1.rdbuf();//一次性读取
	string s1 = buf_1.str();
	in_1.clear();
	in_1.close();

	//一次性读取sudoku.txt
	ifstream in_2("sudoku.txt");
	stringstream buf_2;
	buf_2 << in_2.rdbuf();
	string s2 = buf_2.str();
	in_2.clear();
	in_2.close();

	//比较1000.txt和sudoku.txt的内容是否相等
	if (s1 == s2)
	{
		cout << "Confirm Right." << endl;
	}
	else
	{
		cout << "Confirm Wrong!" << endl;
	}
}