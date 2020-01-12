#include "define.h"


/*
处理命令行输入
*/
int main(int argc, char* argv[])
{
	clock_t start = clock();
	if (argc != 3)//参数数量出错
	{
		cout << "Wrong! please input right format." << endl;
		return 0;
	}

	if (strcmp(argv[1], "-c") == 0)
	{
		/*
		检查argv[2]，如果合法，返回对应整数；
		如果不合法，返回-1
		*/
		int num = ConvertNum(argv[2]);
		if (num == -1)//argv[2]不合法
		{
			cout << "Wrong! please input right format." << endl;
			return 0;
		}
		else//argv[2]合法
		{
			CreateSudoku(num);
		}
	}
	else if (strcmp(argv[1], "-s") == 0)
	{
		SolveSudoku(argv[2]);
	}
	else//argv[1]既不是"-c"，也不是"-s"
	{
		cout << "Wrong! please input right format." << endl;
		return 0;
	}
	//打印总的运行时间
	clock_t end = clock();
	cout << "Running time : " << ((double)end - start) / CLOCKS_PER_SEC << "s\n";
}



/*
处理测试分支覆盖率工具OpenCppCoverage
将所有测试用例保存在test.txt，然后逐行读取
*/
//int main()
//{
//	ifstream in;
//	in.open("test.txt");
//	while (!in.eof())
//	{
//		string str;
//		getline(in, str);
//		cout << endl << str << endl;
//		string result;
//		stringstream input(str);
//		vector<string> res;
//		while (input >> result)
//			res.push_back(result);
//		clock_t start = clock();
//		if (res.size() != 3)//参数数量出错
//		{
//			cout << "Wrong! please input right format." << endl;
//			continue;
//		}
//		char str1[100], str2[100];
//		strcpy_s(str1, res[1].c_str());
//		strcpy_s(str2, res[2].c_str());
//		if (strcmp(str1, "-c") == 0)
//		{
//			/*
//			检查argv[2]，如果合法，返回对应整数；
//			如果不合法，返回-1
//			*/
//			int num = ConvertNum(str2);
//			if (num == -1)//argv[2]不合法
//			{
//				cout << "Wrong! please input right format." << endl;
//				continue;
//			}
//			else//argv[2]合法
//			{
//				CreateSudoku(num);
//			}
//		}
//		else if (strcmp(str1, "-s") == 0)
//		{
//			SolveSudoku(str2);
//		}
//		else//argv[1]既不是"-c"，也不是"-s"
//		{
//			cout << "Wrong! please input right format." << endl;
//			continue;
//		}
//		//打印总的运行时间
//		clock_t end = clock();
//		cout << "Running time : " << ((double)end - start) / CLOCKS_PER_SEC << "s\n";
//		Sleep(1000);
//	}
//	in.clear();
//	in.close();
//}


