详细过程请见：https://www.cnblogs.com/zyj-surpass/  
***
目录结构：  
BIN  
&emsp;sudoku.exe //可执行文件  
&emsp;1000.txt //1000个不需求解的终局，作为求解数独的路径  
&emsp;1000_0.txt //1000个全是0的残局，作为求解数独的路径  
&emsp;test.txt //22个供测试的命令行输入  
Code  
&emsp;main.cpp //主函数  
&emsp;define.h //头文件  
&emsp;define.cpp //内含判定-c后参数的合理性的函数  
&emsp;create.cpp //生成终局  
&emsp;createTest.cpp //测试生成终局的正确性  
&emsp;solve.cpp //求解数独  
&emsp;solveTest.cpp //测试求解数独的正确性  
SudokuProject //VS工程文件夹，不附带BIN中的测试文件

