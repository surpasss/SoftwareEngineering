详细过程请见：https://www.cnblogs.com/zyj-surpass/  
***
目录结构：  
BIN  
&emsp;1000.txt //1000个不需求解的终局，作为求解数独的路径  
&emsp;1000_0.txt //1000个全是0的残局，作为求解数独的路径  
&emsp;sudoku.exe //可执行文件  
&emsp;test.txt //22个供测试的命令行输入  
Code  
&emsp;create.cpp //生成终局  
&emsp;createCheckboard.cpp //生成残局和答案  
&emsp;createTest.cpp //测试生成终局的正确性  
&emsp;define.cpp //内含判定-c后参数的合理性的函数  
&emsp;define.h //头文件  
&emsp;main.cpp //主函数  
&emsp;solve.cpp //求解数独  
&emsp;solveTest.cpp //测试求解数独的正确性  
GUIBIN  
&emsp;sudoku.exe //生成残局文件和答案文件的程序  
&emsp;SudokuGame.exe //GUI游戏可执行文件  
&emsp;腻害.gif //图片  
GUICode  
&emsp;Form1.cs //控件的方法  
&emsp;Form1.Designer.cs //控件的属性  
GUIProject //VS工程文件夹  
SudokuProject //VS工程文件夹，不附带BIN中的测试文件

