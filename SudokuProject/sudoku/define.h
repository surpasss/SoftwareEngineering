#ifndef _DEFINE_H_
#define _DEFINE_H_

#include <stdio.h>
#include <string.h>
#include <iostream>
#include <algorithm>
#include <fstream>
#include <sstream>
#include <vector>
#include <ctype.h> 
#include <time.h>
#include <Windows.h>
using namespace std;


int ConvertNum(char *s);

void CreateSudoku(int n);

void SolveSudoku(char *path);

void TestCreate();

void TestSolve();

#endif
