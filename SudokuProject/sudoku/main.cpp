#include "define.h"


/*
��������������
*/
int main(int argc, char* argv[])
{
	clock_t start = clock();
	if (argc != 3)//������������
	{
		cout << "Wrong! please input right format." << endl;
		return 0;
	}

	if (strcmp(argv[1], "-c") == 0)
	{
		/*
		���argv[2]������Ϸ������ض�Ӧ������
		������Ϸ�������-1
		*/
		int num = ConvertNum(argv[2]);
		if (num == -1)//argv[2]���Ϸ�
		{
			cout << "Wrong! please input right format." << endl;
			return 0;
		}
		else//argv[2]�Ϸ�
		{
			CreateSudoku(num);
		}
	}
	else if (strcmp(argv[1], "-s") == 0)
	{
		SolveSudoku(argv[2]);
	}
	else//argv[1]�Ȳ���"-c"��Ҳ����"-s"
	{
		cout << "Wrong! please input right format." << endl;
		return 0;
	}
	//��ӡ�ܵ�����ʱ��
	clock_t end = clock();
	cout << "Running time : " << ((double)end - start) / CLOCKS_PER_SEC << "s\n";
}



/*
������Է�֧�����ʹ���OpenCppCoverage
�����в�������������test.txt��Ȼ�����ж�ȡ
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
//		if (res.size() != 3)//������������
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
//			���argv[2]������Ϸ������ض�Ӧ������
//			������Ϸ�������-1
//			*/
//			int num = ConvertNum(str2);
//			if (num == -1)//argv[2]���Ϸ�
//			{
//				cout << "Wrong! please input right format." << endl;
//				continue;
//			}
//			else//argv[2]�Ϸ�
//			{
//				CreateSudoku(num);
//			}
//		}
//		else if (strcmp(str1, "-s") == 0)
//		{
//			SolveSudoku(str2);
//		}
//		else//argv[1]�Ȳ���"-c"��Ҳ����"-s"
//		{
//			cout << "Wrong! please input right format." << endl;
//			continue;
//		}
//		//��ӡ�ܵ�����ʱ��
//		clock_t end = clock();
//		cout << "Running time : " << ((double)end - start) / CLOCKS_PER_SEC << "s\n";
//		Sleep(1000);
//	}
//	in.clear();
//	in.close();
//}


